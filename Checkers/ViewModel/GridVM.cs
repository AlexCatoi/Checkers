using Checkers.Commands;
using Checkers.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Checkers.Services;
using System.Windows.Media;
using System.Windows.Controls;

namespace Checkers.ViewModel
{
    public class GridViewModel
    {
        public ObservableCollection<ObservableCollection<Cell>> Cells { get; set; }
        //private ICommand CellCommand { get; set; }
        public ICommand Restart { get; set; }

        public ICommand Save { get; set; }
        public ICommand BackToMenu {  get; set; }
        public ICommand Load { get; set; }
        public GameLogic gl { get; set; }
        public event Action<string> GameWon;
        public event Action Again;
        public event Action SaveIt;
        public event Action Back;
        public event Action Loadit;


        public GridViewModel()
        {
            Cells = new ObservableCollection<ObservableCollection<Cell>>();
            
            for (int i = 0; i < 8; i++) 
            {
                ObservableCollection<Cell> Line= new ObservableCollection<Cell>();
                for (int j = 0; j < 8; j++)
                    Line.Add(new Cell(i, j,OnClick));
                Cells.Add(Line);
            }
            gl= new GameLogic(Cells);
            gl.GameWon += message => GameWon?.Invoke(message);
            Save = new RelayCommand<object>(SaveTheGame);
            Restart = new RelayCommand<object>(RestartGame);
            BackToMenu = new RelayCommand<object>(obj => Back?.Invoke());
            Load= new RelayCommand<object>(obj => Loadit?.Invoke());
        }
        private void OnClick(Cell clickedCell)
        {
            gl.PlayingTurn(clickedCell);
        }
        private void RestartGame(object obj)
        {
            Again?.Invoke();
        }
        private void SaveTheGame(object obj)
        {
            SaveIt?.Invoke();

            var Sg = new SaveGame(Cells, gl.WhiteTurn,gl.WhitePieces,gl.RedPieces);
            Sg.SaveToJson();
        }


        public void LoadContent()
        {
            var SaveGame = new SaveGame(Cells);
            SaveGame.ReadFromJson();
            Cells = SaveGame.Board;
            if (SaveGame.turn)
            {
                gl.Turn = "White turn!";
                gl.WhiteTurn = true;
            }
            else
            {
                gl.Turn = "Red turn!";
                gl.WhiteTurn = false;
            }
            gl.WhitePieces = SaveGame.pa;
            gl.RedPieces = SaveGame.pr;
        }
    }
}

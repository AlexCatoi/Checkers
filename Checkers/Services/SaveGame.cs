using Checkers.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Documents;
using System.IO;
using Microsoft.Win32;

namespace Checkers.Services
{
    public class SaveGame
    {
        public class MyGame
        {
            public int PieseAlbe {  get; set; }
            public int PieseRosii {  get; set; }
            public bool player {  get; set; }
            public List<List<int>> boardStatus { get; set; }
        }

        public ObservableCollection<ObservableCollection<Cell>> Board { get; set; }
        public bool turn { get; set; }
        public int pa {  get; set; }
        public int pr {  get; set; }

        public SaveGame(ObservableCollection<ObservableCollection<Cell>> Cells,bool turn,int pa,int pr)
        {
            this.Board = Cells;
            this.turn = turn;
            this.pa = pa;
            this.pr = pr;
        }
        public SaveGame(ObservableCollection<ObservableCollection<Cell>> Cells)
        {
            this.Board = Cells;
            this.turn = true;
        }

        public void SaveToJson()
        {
            var mg=CodeBoard();
            string json = JsonConvert.SerializeObject(mg, Formatting.Indented);

            string projectDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\DataFiles"));

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Json files (*.json)|*.json";
            saveFileDialog.Title = "Save game state";
            saveFileDialog.InitialDirectory = projectDirectory;
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                File.WriteAllText(saveFileDialog.FileName, json);
            }
        }


        
        public void ReadFromJson()
        {
            string projectDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\DataFiles"));

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Json files (*.json)|*.json";
            openFileDialog.Title = "Open game state";
            openFileDialog.InitialDirectory = projectDirectory;
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != "")
            {
                string json = File.ReadAllText(openFileDialog.FileName);
                MyGame game = JsonConvert.DeserializeObject<MyGame>(json);
                DecodeBoard(game);
            }
            
        }

        private MyGame CodeBoard()
        {
            var mg= new MyGame();
            mg.boardStatus=new List<List<int>>();
            foreach (var row in Board)
            {
                List<int> RowStatus = new List<int>();
                foreach (Cell cell in row)
                {
                    if (cell.piesa.ISK == true)
                        RowStatus.Add(cell.piesa.player + 2);
                    else
                        RowStatus.Add(cell.piesa.player);
                }
                mg.boardStatus.Add(RowStatus);
            }
            mg.player = turn;
            mg.PieseAlbe = pa;
            mg.PieseRosii = pr;
            return mg;
        }
        private void DecodeBoard(MyGame mg)
        {
            for (int i = 0; i < mg.boardStatus.Count; i++)
            {
                for (int j = 0; j < mg.boardStatus[i].Count; j++)
                {
                    int status = mg.boardStatus[i][j];
                    bool isK = status > 2;
                    if (mg.boardStatus[i][j] % 2 == 1)
                    {
                        Board[i][j].piesa = new Piece(Board[i][j],1, isK);
                        Board[i][j].isEmpty = false;
                    }
                    else if (mg.boardStatus[i][j] % 2 == 0 && mg.boardStatus[i][j] != 0)
                    {
                        Board[i][j].piesa = new Piece(Board[i][j],2, isK);
                        Board[i][j].isEmpty = false;
                    }
                    else
                    {
                        Board[i][j].piesa = new Piece(Board[i][j],0, isK);
                        Board[i][j].isEmpty = true;
                    }
                }
            }
            turn = mg.player;
            pa = mg.PieseAlbe;
            pr = mg.PieseRosii;
        }

    }
}

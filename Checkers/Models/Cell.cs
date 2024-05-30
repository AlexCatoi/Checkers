using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Checkers.Commands;
using Checkers.Services;

namespace Checkers.Models
{
    public class Cell: BaseNotification
    {
        public int x { get; set; }
        public int y { get; set; }
        Helper help=new Helper();
        public string piece { get; set; }
        public string color;
        public bool isEmpty = true;
        public Piece piesa;
        GameLogic gl=new GameLogic();
        public ICommand CellCommand { get; set; }
        public Cell(int x, int y, Action<Cell> action)
        {
            this.x = x;
            this.y = y;
            CellCommand = new RelayCommand<Cell>(action);
            color = help.ColorBoard(x, y);
            isEmpty = help.InitialSetUpOccupiedCells(x, y);
            piesa = help.CreatePieces(this);
        }
        public string Color
        {
            get
            {
                return color;
               
            }
            set {
                color = value;
                NotifyPropertyChanged("Color");
            }
        }
        public Piece Piesa
        {
            get
            {
                return piesa;
            }
            set
            {
                piesa= value;
                NotifyPropertyChanged("Piesa");
                NotifyPropertyChanged("EllipseColor");
            }
        }
        public Brush EllipseColor
        {
            get
            {
                return gl.showPieces(this);
            }
        }
        public void UpdateEllipseColor()
        {
            NotifyPropertyChanged("EllipseColor");
        }
    }
}

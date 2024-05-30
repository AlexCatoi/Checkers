using Checkers.Models;
using Checkers.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;

namespace Checkers.Services
{

    public class GameLogic:BaseNotification
    {
        public ObservableCollection<ObservableCollection<Cell>> Cells { get; set; }
        public GameLogic(ObservableCollection<ObservableCollection<Cell>> Cells)
        {
            this.Cells = Cells;
        }
        public event Action<String> GameWon;
        Cell previousCell;
        private bool whiteTurn = true;
        private bool takeLeft = false;
        private bool takeRight = false;
        private int redPieces=12;
        private int whitePieces = 12;
        private string turn="White turn!";
        public int RedPieces
        {
            get
            {
                return redPieces;
            }
            set { 
                redPieces = value;
                NotifyPropertyChanged("RedPieces");
            }
        }

        public bool WhiteTurn
        {
            get
            {
                return whiteTurn;
            }
            set
            {
                whiteTurn = value;
            }
        }
        public int WhitePieces
        {
            get
            {
                return whitePieces;
            }
            set
            {
                whitePieces = value;
                NotifyPropertyChanged("WhitePieces");
            }
        }

        public string Turn
        {
            get
            {
                return turn;
            }
            set
            {
                turn = value;
                NotifyPropertyChanged("Turn");
            }
        }
        public GameLogic() { }
        
        private bool RedMove(Cell position)
        {
            if (position == null) return false;
            if (position.Color != "Green" || (position.Color == "Green" && Math.Abs(position.x - previousCell.x) != 2))
            {
                takeLeft = false;
                takeRight = false;
            }
            if (position.Color == "Green")
            {
                clearGreen();
                position.isEmpty = false;
                position.Piesa.ISK = previousCell.Piesa.ISK;
                position.Piesa.Player= previousCell.Piesa.Player;
                previousCell.Piesa.Player = 0;
                previousCell.Piesa.ISK = false;
                previousCell.isEmpty = true;
                if (position.x == previousCell.x - 2)
                {
                    takeWhite(position);
                    WhitePieces--;
                    Console.WriteLine(whitePieces);
                }
                if(position.x == previousCell.x + 2 && position.Piesa.ISK==true)
                {
                    takeRed(position);
                    WhitePieces--;
                    Console.WriteLine(whitePieces);
                }
                if (position.x == 0)
                {
                    position.Piesa.ISK = true;
                }
                return true;
            }
            return false;
        }

       
        private bool WhiteMove(Cell position)
        {
            if (position == null) return false;

            if(position.Color !="Green" ||(position.Color=="Green" && Math.Abs(position.x-previousCell.x)!=2))
            {
                takeLeft = false;
                takeRight= false;
            }

            if (position.Color == "Green")
            {
                clearGreen();

                position.isEmpty = false;
                position.Piesa.ISK = previousCell.Piesa.ISK;
                position.Piesa.Player = previousCell.Piesa.Player;
                previousCell.Piesa.Player = 0;
                previousCell.Piesa.ISK = false;
                previousCell.isEmpty = true;
                if (position.x == previousCell.x + 2)
                {
                    takeRed(position);
                    RedPieces--;
                    Console.WriteLine(whitePieces);
                }
                if (position.x == previousCell.x - 2 && position.Piesa.ISK == true)
                {
                    takeWhite(position);
                    RedPieces--;
                    Console.WriteLine(whitePieces);
                }
                if (position.x == 7)
                {
                    position.Piesa.ISK = true;
                }
                return true;
            }
            return false;
        }



        public void PlayingTurn(Cell clickedCell)
        {
            if (whiteTurn == true)
            {
                if(clickedCell.Piesa.Player==1 || clickedCell.Color=="Green")
                {
                    if(clickedCell.Piesa.ISK)
                    {
                        showMovesWhite(clickedCell);
                        showMovesRed(clickedCell);
                        if(clickedCell.color=="Green")
                            if (RedMove(clickedCell) || WhiteMove(clickedCell))
                                whiteTurn = false;
                    }
                    else
                    {
                        showMovesWhite(clickedCell);
                        if (clickedCell.color == "Green")
                            if (WhiteMove(clickedCell))
                                whiteTurn = false;
                    }
                }
                if(WhiteWon())
                {
                    var stats = new SaveStats("White", whitePieces);
                    GameWon?.Invoke("Player 1 has won!");
                }
                WhoseTurn();

            }
            else
            {
                if(clickedCell.Piesa.Player==2 || clickedCell.Color == "Green")
                {
                    if (clickedCell.Piesa.ISK)
                    {
                        showMovesWhite(clickedCell);
                        showMovesRed(clickedCell);
                        if (clickedCell.color == "Green")
                            if (RedMove(clickedCell) || WhiteMove(clickedCell))
                                whiteTurn = true;
                    }
                    else
                    {
                        showMovesRed(clickedCell);
                        if (clickedCell.color == "Green")
                            if (RedMove(clickedCell))
                                whiteTurn = true;
                    }
                }
                if(RedWon())
                {
                    var stats = new SaveStats("Red", redPieces);
                    GameWon?.Invoke("Player 2 has won!");
                }
                WhoseTurn();
            }
        }

        public Brush showPieces(Cell c)
        {
            if(c.Piesa.player==1 && c.Piesa.ISK==true)
                return Brushes.Aqua;
            else if(c.Piesa.player == 2 && c.Piesa.ISK == true)
                return Brushes.Orange;
            else if (c.Piesa.player == 1)
                return Brushes.White;
            else if (c.Piesa.player == 2)
                return Brushes.Red;
            else
                return Brushes.Transparent;
        }

        private void clearGreen()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                    Cells[i][j].Color = (Cells[i][j].x + Cells[i][j].y) % 2 == 0 ? "Yellow" : "Black"; ;
            }
        }

        public void showMovesRed(Cell clickedCell)
        {
            Cell upper;
            if (clickedCell.Color != "Green" && (clickedCell.Piesa.Player == 2 || clickedCell.Piesa.ISK == true))
            {
                if(clickedCell.Piesa.ISK==false)
                    clearGreen();
                if (clickedCell.x > 0)
                {
                    if (clickedCell.y > 0 && clickedCell.y < 7)
                    {
                        upper = Cells[clickedCell.x - 1][clickedCell.y + 1];
                        if (upper.isEmpty == true)
                            upper.Color = "Green";
                        else if (clickedCell.x > 1 && clickedCell.y < 6)
                        {
                            if (upper.Piesa.player != clickedCell.Piesa.player && Cells[clickedCell.x - 2][clickedCell.y + 2].isEmpty == true)
                            {
                                upper = Cells[clickedCell.x - 2][clickedCell.y + 2];
                                upper.Color = "Green";
                                takeLeft = true;
                            }

                        }
                        upper = Cells[clickedCell.x - 1][clickedCell.y - 1];
                        if (upper.isEmpty == true)
                            upper.Color = "Green";
                        else if (clickedCell.x > 1 && clickedCell.y > 1)
                        {
                            if (upper.Piesa.player != clickedCell.Piesa.player && Cells[clickedCell.x - 2][clickedCell.y - 2].isEmpty == true)
                            {
                                upper = Cells[clickedCell.x - 2][clickedCell.y - 2];
                                upper.Color = "Green";
                                takeRight = true;
                            }

                        }
                        previousCell = clickedCell;
                    }
                    else if (clickedCell.y == 0)
                    {
                        upper = Cells[clickedCell.x - 1][clickedCell.y + 1];
                        if (upper.isEmpty == true)
                            upper.Color = "Green";
                        else if (clickedCell.x > 1 && clickedCell.y < 6)
                        {
                            if (upper.Piesa.player != clickedCell.Piesa.player && Cells[clickedCell.x - 2][clickedCell.y + 2].isEmpty == true)
                            {
                                upper = Cells[clickedCell.x - 2][clickedCell.y + 2];
                                upper.Color = "Green";
                                takeLeft = true;
                            }
                        }
                        previousCell = clickedCell;
                    }
                    else if (clickedCell.y == 7)
                    {
                        upper = Cells[clickedCell.x - 1][clickedCell.y - 1];
                        if (upper.isEmpty == true)
                            upper.Color = "Green";
                        else if (clickedCell.x > 1 && clickedCell.y > 1)
                        {
                            if (upper.Piesa.player != clickedCell.Piesa.player && Cells[clickedCell.x - 2][clickedCell.y - 2].isEmpty == true)
                            {
                                upper = Cells[clickedCell.x - 2][clickedCell.y - 2];
                                upper.Color = "Green";
                                takeRight = true;

                            }
                        }
                        previousCell = clickedCell;
                    }
                }
            }
        }

        public void showMovesWhite(Cell clickedCell)
        {
            Cell upper;
            if (clickedCell.Color != "Green" && (clickedCell.Piesa.Player == 1 || clickedCell.Piesa.ISK == true))
            {
                if(clickedCell.Piesa.ISK==false)
                    clearGreen();
                if (clickedCell.x < 7)
                {
                    if (clickedCell.y > 0 && clickedCell.y < 7)
                    {
                        upper = Cells[clickedCell.x + 1][clickedCell.y + 1];
                        if (upper.isEmpty == true)
                            upper.Color = "Green";
                        else if (clickedCell.x < 6 && clickedCell.y < 6)
                        {
                            if (upper.Piesa.player != clickedCell.Piesa.player && Cells[clickedCell.x + 2][clickedCell.y + 2].isEmpty == true)
                            {
                                upper = Cells[clickedCell.x + 2][clickedCell.y + 2];
                                upper.Color = "Green";
                                takeRight = true;
                            }

                        }
                        upper = Cells[clickedCell.x + 1][clickedCell.y - 1];
                        if (upper.isEmpty == true)
                            upper.Color = "Green";
                        else if (clickedCell.x < 6 && clickedCell.y > 1)
                        {
                            if (upper.Piesa.player != clickedCell.Piesa.player && Cells[clickedCell.x + 2][clickedCell.y - 2].isEmpty == true)
                            {
                                upper = Cells[clickedCell.x + 2][clickedCell.y - 2];
                                upper.Color = "Green";
                                takeLeft = true;
                            }

                        }
                        previousCell = clickedCell;
                    }
                    else if (clickedCell.y == 0)
                    {
                        upper = Cells[clickedCell.x + 1][clickedCell.y + 1];
                        if (upper.isEmpty == true)
                            upper.Color = "Green";
                        else if (clickedCell.x < 6 && clickedCell.y < 6)
                        {
                            if (upper.Piesa.player != clickedCell.Piesa.player && Cells[clickedCell.x + 2][clickedCell.y + 2].isEmpty == true)
                            {
                                upper = Cells[clickedCell.x + 2][clickedCell.y + 2];
                                upper.Color = "Green";
                                takeRight = true;
                            }
                        }
                        previousCell = clickedCell;
                    }
                    else if (clickedCell.y == 7)
                    {
                        upper = Cells[clickedCell.x + 1][clickedCell.y - 1];
                        if (upper.isEmpty == true)
                            upper.Color = "Green";
                        else if (clickedCell.x < 6 && clickedCell.y > 1)
                        {
                            if (upper.Piesa.player != clickedCell.Piesa.player && Cells[clickedCell.x + 2][clickedCell.y - 2].isEmpty == true)
                            {
                                upper = Cells[clickedCell.x + 2][clickedCell.y - 2];
                                upper.Color = "Green";
                                takeLeft = true;

                            }
                        }
                        previousCell = clickedCell;
                    }
                }
            }
        }

        private void takeWhite(Cell position)
        {
            if (takeLeft)
            {
                Cell aux = Cells[position.x + 1][position.y - 1];
                aux.isEmpty = true;
                aux.Piesa.Player = 0;
                takeLeft = false;
            }
            if (takeRight)
            {
                Cell aux = Cells[position.x + 1][position.y + 1];
                aux.isEmpty = true;
                aux.Piesa.Player = 0;
                takeRight = false;
            }
        }

        private void takeRed(Cell position)
        {
            if (takeLeft)
            {
                Cell aux = Cells[position.x - 1][position.y + 1];
                aux.isEmpty = true;
                aux.Piesa.Player = 0;
                takeLeft = false;
            }
            if (takeRight)
            {
                Cell aux = Cells[position.x - 1][position.y - 1];
                aux.isEmpty = true;
                aux.Piesa.Player = 0;
                takeRight = false;
            }
        }

        public bool RedWon()
        {
            if (whitePieces == 0)
                return true;
            return false;
        }
        public bool WhiteWon()
        {
            if (redPieces == 0)
                return true;
            return false;
        }
        public void WhoseTurn()
        {
            if (whiteTurn == false)
                Turn= "Red Turn!";
            else
                Turn= "White Turn!";
        }
    }
}

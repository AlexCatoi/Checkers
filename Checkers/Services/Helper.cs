using Checkers.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Services
{
    class Helper
    {
        public static Cell PreviousCell { get; set; }
        public string ColorBoard(int x, int y)
        {
            return (x + y) % 2 == 0 ? "Yellow" : "Black";
        }
        public bool InitialSetUpOccupiedCells(int x,int y)
        {
            if(((x>=0 && x<=2) && (x + y) % 2 == 1) || ((x >= 5 && x <= 7) && (x + y) % 2 == 1))
            {
                return false;
            }
            return true;
        }
        public Piece CreatePieces(Cell c)
        {
             if ((c.x >= 0 && c.x <= 2) && c.Color == "Black")
            {
                return new Piece(c, 1); 
            }
            else if((c.x >= 5 && c.x <= 7) && c.Color=="Black")
                return new Piece(c, 2);
            return  new Piece(c, 0);
        }
    }
}

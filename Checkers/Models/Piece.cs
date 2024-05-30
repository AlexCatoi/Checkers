using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers.Services;

namespace Checkers.Models
{
    public class Piece:BaseNotification
    {
        public int player;
        private bool isKing = false;
        
        public bool ISK
        { get
            {
                return isKing;
            }

            set
            {
                isKing = value;
            }
        }
        public int Player
        { get
          {
             return player;
          }
          set 
          { 
             player = value;
             NotifyPropertyChanged("Player");
             c.UpdateEllipseColor();
            } 
        }
        Helper help=new Helper();
        public Cell c;

        public Piece(Cell c,int p)
        {
            this.c = c;
            player = p;
        }

        public Piece(Cell c,int p, bool isk)
        {
            this.c = c;
            ISK = isk;
            player = p;
        }
    }
}

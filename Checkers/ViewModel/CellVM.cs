using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using Checkers.Commands;

namespace Checkers.ViewModel
{
    public class CellViewModel : INotifyPropertyChanged
    {
        

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        
    }
}

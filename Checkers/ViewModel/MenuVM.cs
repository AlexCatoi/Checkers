using Checkers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Checkers.Services;
using System.Net;

namespace Checkers.ViewModel
{
    public class MenuVM
    {
        public ICommand Start { get; set; }
        public ICommand StartNewGame { get; set; }

        public ICommand Continue { get; set; }
        public ICommand Back { get; set; }
        public ICommand Help { get; set; }
        public ICommand About { get; set; }
        public ICommand HTP { get; set; }
        public ICommand Stats { get; set; }

        public event Action StartG;
        public event Action StartNG;
        public event Action GoBack;
        public event Action HelpM;
        public event Action AboutCreator;
        public event Action How_to_Play;
        public event Action SeeStats;
        public event Action Continu;

        public MenuVM()
        {
            Start = new RelayCommand<Object>(StartGame);
            StartNewGame = new RelayCommand<object>(StartN);
            Back = new RelayCommand<object>(GoBackToMenu);
            Help = new RelayCommand<object>((obj) => HelpM?.Invoke());
            About = new RelayCommand<object>((obj) => AboutCreator?.Invoke());
            HTP = new RelayCommand<object>((obj) => How_to_Play?.Invoke());
            Stats = new RelayCommand<object>((obj) => SeeStats?.Invoke());
            Continue = new RelayCommand<object>((obj) => Continu?.Invoke());
        }
        public void StartGame(object obj)
        {
            StartG?.Invoke();
        }
        public void StartN(object obj)
        {
            StartNG?.Invoke();
        }
        public void GoBackToMenu(object obj)
        {
            GoBack?.Invoke();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Checkers.Services;
using Checkers.ViewModel;
using Checkers.Services;

namespace Checkers.Views
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        public Game(bool ok)
        {
            InitializeComponent();
            var viewModel = this.DataContext as GridViewModel;
            if(viewModel!=null)
                { 
                viewModel.GameWon += OnGameWon;
                viewModel.Again += Restart;
                viewModel.Loadit += LoadGame;
                viewModel.Back += Back;
            }
            if(ok) 
            {
                viewModel.LoadContent();
            }

        }
        private void OnGameWon(string message)
        {
            var winnerPage = new Winner();
            winnerPage.WinnerLabel.Content = message;
            winnerPage.DataContext=this.DataContext;
            Frame frame = new Frame();
            frame.Content = winnerPage;
            this.Content = frame;
        }
        private void Restart()
        {
            var NewGame = new Game(false);
            this.Close();
            NewGame.Show();
        }

        private void LoadGame()
        {
            var NewGame = new Game(true);
            this.Close();
            NewGame.Show();
        }
        private void Back()
        {
            var menu = new MainWindow();
            this.Close();
            menu.Show();
        }
    }
}

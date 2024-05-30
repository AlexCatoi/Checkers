using Checkers.ViewModel;
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

namespace Checkers.Views
{
    /// <summary>
    /// Interaction logic for ChosingGamePage.xaml
    /// </summary>
    public partial class ChosingGamePage : Page
    {
        public ChosingGamePage(MenuVM dc)
        {
            InitializeComponent();
            this.DataContext = dc;
            var viewModel = this.DataContext as MenuVM;
            if (viewModel != null)
            {
                viewModel.StartNG += StartGame;
                viewModel.GoBack += GoBackToMenu;
                viewModel.Continu += Continue;
            }

        }
        private void StartGame()
        {
            var game = new Game(false);
            Window.GetWindow(this).Close();
            game.Show();
        }
        private void GoBackToMenu()
        {
            var menu = new MainWindow();
            Window.GetWindow(this).Close();
            menu.Show();
        }
        private void Continue()
        {
            var game = new Game(true);
            Window.GetWindow(this).Close();
            game.Show();
        }
    }
}

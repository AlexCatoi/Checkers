using Checkers.ViewModel;
using Checkers.Views;
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

namespace Checkers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var viewModel = this.DataContext as MenuVM;
            if (viewModel != null)
            {
                viewModel.StartG+=ChosePage;
                viewModel.HelpM += ShowHelpPage;
                viewModel.SeeStats += ShowStats;
            }

        }

        
        private void ChosePage()
        {
            var chosingPage = new ChosingGamePage(this.DataContext as MenuVM);
            this.Content = chosingPage;
        }
        
        private void ShowHelpPage()
        {
            var help = new HelpPage(this);
            this.Content = help;
        }
        private void ShowStats()
        {
            var stat = new StatsPage(this);
            this.Content = stat;
        }
    }
}

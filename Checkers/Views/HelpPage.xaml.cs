using Checkers.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for HelpPage.xaml
    /// </summary>
    public partial class HelpPage : Page
    {
        private Window parent;
        public HelpPage(Window dc)
        {
            InitializeComponent();
            parent = dc;
            this.DataContext = dc.DataContext;
            var viewModel = this.DataContext as MenuVM;
            if (viewModel != null)
            {
                viewModel.How_to_Play += HowToPlay;
                viewModel.AboutCreator += AboutMe;

            }
        }

        private void HowToPlay()
        {
            parent.Content=new HowToPlayPage(parent);
        }
        private void AboutMe()
        {
            parent.Content = new AboutPage(parent);
        }
        public void Back(object sender, RoutedEventArgs e)
        {
            var window=new MainWindow();
            window.Show();
            parent.Close();
        }

    }
}

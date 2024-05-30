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
using Checkers.ViewModel;

namespace Checkers.Views
{
    /// <summary>
    /// Interaction logic for StatsPage.xaml
    /// </summary>
    public partial class StatsPage : Page
    {
        private Window parent;
        public StatsPage(Window parent)
        {
            this.DataContext = new StatsVM();
            InitializeComponent();
            this.parent = parent;
        }
        public void Back(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow();
            window.Show();
            parent.Close();
        }
    }
}

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
    /// Interaction logic for AboutPage.xaml
    /// </summary>
    public partial class AboutPage : Page
    {
        private Window parent;
        public AboutPage(Window parent)
        {
            InitializeComponent();
            this.parent = parent;
        }
        public void Back(object sender, RoutedEventArgs e)
        {
            parent.Content=new HelpPage(parent);
        }
    }
}

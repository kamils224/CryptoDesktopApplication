using PZ_generatory.Generators.Progowy;
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

namespace PZ_generatory
{
    /// <summary>
    /// Interaction logic for UserControl_progowy.xaml
    /// </summary>
    public partial class UserControl_progowy : UserControl
    {
        public UserControl_progowy()
        {
            InitializeComponent();
        }

        private void Wykorzystaj_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GridProgowy.Children.Clear();
            usc = new Settings_progowy();
            GridProgowy.Children.Add(usc);
        }

        private void BackTo_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Panel).Children.Remove(this);
        }
    }
}

using PZ_generatory.Generators.Gollmana;
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
    /// Interaction logic for UserControl_gollmana.xaml
    /// </summary>
    public partial class UserControl_gollmana : UserControl
    {
        public UserControl_gollmana()
        {
            InitializeComponent();
        }

        private void Wykorzystaj_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GridGollmana.Children.Clear();
            usc = new Settings_gollmana();
            GridGollmana.Children.Add(usc);
        }

        private void BackTo_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Panel).Children.Remove(this);
        }
    }
}
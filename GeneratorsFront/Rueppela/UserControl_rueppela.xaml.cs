using PZ_generatory.Generators.Rueppela;
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
    /// Interaction logic for UserControl_rueppela.xaml
    /// </summary>
    public partial class UserControl_rueppela : UserControl
    {
        public UserControl_rueppela()
        {
            InitializeComponent();
        }

        private void Wykorzystaj_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GridRueppela.Children.Clear();
            usc = new Settings_rueppela();
            GridRueppela.Children.Add(usc);
        }

        private void BackTo_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Panel).Children.Remove(this);
        }
    }
}
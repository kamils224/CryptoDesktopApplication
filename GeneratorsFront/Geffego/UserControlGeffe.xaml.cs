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

namespace CryptoDesktopApplication.GeneratorsFront.Geffego
{
    /// <summary>
    /// Interaction logic for UserControlGeffe.xaml
    /// </summary>
    public partial class UserControlGeffe : UserControl
    {
        public UserControlGeffe()
        {
            InitializeComponent();
        }

        private void Wykorzystaj_Click(object sender, RoutedEventArgs e)
        {
            GridGeffego.Children.Clear();
            //usc = new Settings_geffego();
            //GridGeffego.Children.Add(usc);
        }

        private void BackTo_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Panel).Children.Remove(this);
        }
    }
}

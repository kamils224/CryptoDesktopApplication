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
    /// Interaction logic for GeffeSettings.xaml
    /// </summary>
    public partial class GeffeSettings : UserControl
    {
        public GeffeSettings()
        {
            InitializeComponent();
        }


        public void Clear_lfsr1(object Sender, RoutedEventArgs e)
        {
            lfsr1.Text = string.Empty;
        }
    }
}

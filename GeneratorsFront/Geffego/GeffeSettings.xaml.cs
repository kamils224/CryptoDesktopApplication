using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class PolynomialModel
    {
        public int Length { get; set; }
        public string Polynomial { get; set; }
    }
    public partial class GeffeSettings : UserControl
    {
        public GeffeSettings()
        {
            InitializeComponent();
            ObservableCollection<PolynomialModel> polynomials = new ObservableCollection<PolynomialModel>();
            polynomials.Add(new PolynomialModel() { Length = 2, Polynomial = "test" });
            polynomials.Add(new PolynomialModel() { Length = 2, Polynomial = "test" });
            polynomials.Add(new PolynomialModel() { Length = 2, Polynomial = "test" });
            polynomials.Add(new PolynomialModel() { Length = 2, Polynomial = "test" });
            PolynomialDataGrid.ItemsSource = polynomials;

        }


        public void Clear_lfsr1(object Sender, RoutedEventArgs e)
        {
            lfsr1.Text = string.Empty;
        }
    }
}

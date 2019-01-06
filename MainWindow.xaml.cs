using CryptoDesktopApplication.GeneratorsFront;
using CryptoDesktopApplication.GeneratorsFront.Cascade;
using CryptoDesktopApplication.GeneratorsFront.Geffe;
using CryptoDesktopApplication.GeneratorsFront.LfsrGen;
using CryptoDesktopApplication.GeneratorsFront.SelfDecimation;
using CryptoDesktopApplication.GeneratorsFront.SelfShrinking;
using CryptoDesktopApplication.GeneratorsFront.Shrinking;
using CryptoDesktopApplication.GeneratorsFront.StopAndGo;
using CryptoDesktopApplication.GeneratorsFront.Threshold;
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

namespace CryptoDesktopApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainContainer.Children.Add(new LfsrGeneratorSettings());
        }

        private void lfsrTab_Click(object sender, RoutedEventArgs e)
        {
            MainContainer.Children.Clear();
            MainContainer.Children.Add(new LfsrGeneratorSettings());
        }

        private void geffeTab_Click(object sender, RoutedEventArgs e)
        {
            MainContainer.Children.Clear();
            MainContainer.Children.Add(new GeffeSettings());
        }

        private void cascadeTab_Click(object sender, RoutedEventArgs e)
        {
            MainContainer.Children.Clear();
            MainContainer.Children.Add(new CascadeSettings());
        }

        private void thresholdTab_Click(object sender, RoutedEventArgs e)
        {
            MainContainer.Children.Clear();
            MainContainer.Children.Add(new ThresholdSettings());
        }

        private void shrinkingTab_Click(object sender, RoutedEventArgs e)
        {
            MainContainer.Children.Clear();
            MainContainer.Children.Add(new ShrinkingSettings());
        }

        private void selfdecimationTab_Click(object sender, RoutedEventArgs e)
        {
            MainContainer.Children.Clear();
            MainContainer.Children.Add(new SelfDecimationSettings());
        }

        private void selfshrinkingTab_Click(object sender, RoutedEventArgs e)
        {
            MainContainer.Children.Clear();
            MainContainer.Children.Add(new SelfShrinkingSettings());
        }

        private void stopandgoTab_Click(object sender, RoutedEventArgs e)
        {
            MainContainer.Children.Clear();
            MainContainer.Children.Add(new StopAndGoSettings());
        }
    }
}

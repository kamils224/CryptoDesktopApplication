using CryptoDesktopApplication.Backend;
using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CryptoDesktopApplication.Fips;
using MaterialDesignThemes.Wpf;
using System.Windows.Media;

namespace CryptoDesktopApplication.GeneratorsFront.Geffego
{

    public partial class GeffeSettings : UserControl
    {
        private GeffesGenerator generator = new GeffesGenerator();
        string lastGeneratedString= null;

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


        private void Clear_lfsr1(object Sender, RoutedEventArgs e)
        {
            lfsr1.Text = string.Empty;
        }
        private void Clear_lfsr2(object Sender, RoutedEventArgs e)
        {
            lfsr2.Text = string.Empty;
        }
        private void Clear_lfsr3(object Sender, RoutedEventArgs e)
        {
            lfsr3.Text = string.Empty;
        }

        private void Clear_outputLength(object Sender, RoutedEventArgs e)
        {
            outputLength.Text = string.Empty;
        }

        private void lfsr1_TextChanged(object sender, TextChangedEventArgs e)
        {
            r1Counter.Content = lfsr1.Text.Length;
        }

        private void lfsr2_TextChanged(object sender, TextChangedEventArgs e)
        {
            r2Counter.Content = lfsr2.Text.Length;
        }

        private void lfsr3_TextChanged(object sender, TextChangedEventArgs e)
        {
            r3Counter.Content = lfsr3.Text.Length;
        }

        private void setRegister1_Click(object sender, RoutedEventArgs e)
        {
            var input = lfsr1.Text;
            r1State.Content = input;
            r1CurrentCounter.Content = input.Length;
        }

        private void setRegister2_Click(object sender, RoutedEventArgs e)
        {
            var input = lfsr2.Text;
            r2State.Content = input;
            r2CurrentCounter.Content = input.Length;
        }

        private void setRegister3_Click(object sender, RoutedEventArgs e)
        {
            var input = lfsr3.Text;
            r3State.Content = input;
            r3CurrentCounter.Content = input.Length;
        }

        #region InputValidation

        private static readonly Regex _digitsOnlyRegex = new Regex("[^0-9.-]+");
        private static bool IsTextAllowed(string text)
        {
            return _digitsOnlyRegex.IsMatch(text);
        }

        private static readonly Regex _binaryStringOnlyRegex = new Regex("[^0-1]+");
        private static bool IsBinaryString(string text)
        {
            return _binaryStringOnlyRegex.IsMatch(text);
        }

        private void TextBoxPasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (IsTextAllowed(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }
        private void BinaryStringPasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (IsBinaryString(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex rgx = new Regex("[^0-9]+"); 
            e.Handled = rgx.IsMatch(e.Text);
        }

        private void BinaryStringValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-1]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        #endregion


        private void GenerateBtn_Click(object sender, RoutedEventArgs e)
        {
            string r1 = r1State.Content as string;
            string r2 = r1State.Content as string;
            string r3 = r1State.Content as string;

            Lfsr[] lfsrs = new Lfsr[3];

            lfsrs[0] = new Lfsr(r1);
            lfsrs[1] = new Lfsr(r2);
            lfsrs[2] = new Lfsr(r3);

            for (int i = 0; i < lfsrs.Length; i++)
            {
                generator.ChangeRegister(lfsrs[i], i);
            }

            var format = outputFormatComboBox.SelectedIndex;

            int seriesLength = 0;
            if (outputLength.Text != "")
            {
                seriesLength= int.Parse(outputLength.Text);
            }
             

            ClearOutput();

            Task.Run(() =>
            {
                SetLoadingCircle(true);
                ResetFipsIcons();
                byte[] generatedBytes = null;
                switch (format)
                {
                    case 0:
                        {
                            lastGeneratedString = new string(generator.GenerateBitsAsChars(seriesLength));
                            SetOutputText(lastGeneratedString);
                            SetLoadingCircle(false);
                            break;
                        }
                    case 1:
                        {
                            generatedBytes = generator.GenerateBytes(seriesLength);
                            lastGeneratedString = Convert.ToBase64String(generatedBytes);
                            SetOutputText(lastGeneratedString);
                            SetLoadingCircle(false);
                            break;
                        }
                    default:
                        break;
                }
                UpdateRegisterState(generator);

                if (seriesLength >= 20000)
                {
                    SingleBitTestResult singleBitResult = null;
                    SeriesTestResult seriesResult = null;
                    LongSeriesTestResult longSeriesResult = null;
                    PokerTestResult pokerResult = null;

                    if (format == 0)
                    {
                        FipsTests fipsTests = new FipsTests();
                        var testInput = lastGeneratedString.Substring(0, 20000);

                        singleBitResult = fipsTests.SingleBitTest(testInput);
                        seriesResult = fipsTests.SeriesTest(testInput);
                        longSeriesResult = fipsTests.LongSeriesTests(testInput);
                        pokerResult = fipsTests.PokerTest(testInput);
                    }
                    else if (format == 1)
                    {
                        FipsTests fipsTests = new FipsTests();
                        byte[] testArray = new byte[2500];
                        Array.Copy(generatedBytes, testArray, 2500);
                        if (generatedBytes != null)
                        {
                            singleBitResult = fipsTests.SingleBitTest(testArray);
                            seriesResult = fipsTests.SeriesTest(testArray);
                            longSeriesResult = fipsTests.LongSeriesTests(testArray);
                            pokerResult = fipsTests.PokerTest(testArray);
                        }

                    }

                    if (singleBitResult.TestPassed)
                    {
                        singleBitSuccess();
                    }
                    else
                    {
                        singleBitFail();
                    }
                    if (seriesResult.TestPassed)
                    {
                        seriesSuccess();
                    }
                    else
                    {
                        seriesFail();
                    }
                    if (longSeriesResult.TestPassed)
                    {
                        longSeriesSuccess();
                    }
                    else
                    {
                        longSeriesFail();
                    }
                    if (pokerResult.TestPassed)
                    {
                        pokerSuccess();
                    }
                    else
                    {
                        pokerFail();
                    }
                }

            });
        }

        private void ResetFipsIcons()
        {
            Dispatcher.Invoke(() => 
            {
                singleBit.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2196F3"));
                singleBit.Kind = PackIconKind.CloseCircle;
                seriesTest.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2196F3"));
                seriesTest.Kind = PackIconKind.CloseCircle;
                longSeriesTest.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2196F3"));
                longSeriesTest.Kind = PackIconKind.CloseCircle;
                poker.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2196F3"));
                poker.Kind = PackIconKind.CloseCircle;

            });
        }

        private void singleBitSuccess()
        {
            Dispatcher.Invoke(() =>
            {
                singleBit.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Green"));
                singleBit.Kind = PackIconKind.Approval;
            });
        }
        private void singleBitFail()
        {
            Dispatcher.Invoke(() =>
            {
                singleBit.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
                singleBit.Kind = PackIconKind.CloseCircle;
            });
        }

        private void seriesSuccess()
        {
            Dispatcher.Invoke(() =>
            {
                seriesTest.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Green"));
                seriesTest.Kind = PackIconKind.Approval;
            });
        }
        private void seriesFail()
        {
            Dispatcher.Invoke(() =>
            {
                seriesTest.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
                seriesTest.Kind = PackIconKind.CloseCircle;
            });
        }

        private void longSeriesSuccess()
        {
            Dispatcher.Invoke(() =>
            {
                longSeriesTest.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Green"));
                longSeriesTest.Kind = PackIconKind.Approval;
            });
        }
        private void longSeriesFail()
        {
            Dispatcher.Invoke(() =>
            {
                longSeriesTest.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
                longSeriesTest.Kind = PackIconKind.CloseCircle;
            });
        }
        private void pokerSuccess()
        {
            Dispatcher.Invoke(() =>
            {
                poker.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Green"));
                poker.Kind = PackIconKind.Approval;
            });
        }
        private void pokerFail()
        {
            Dispatcher.Invoke(() =>
            {
                poker.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
                poker.Kind = PackIconKind.CloseCircle;
            });
        }





        private void UpdateRegisterState(LfsrGenerator generator)
        {
            var registers = generator.Registers;
            Dispatcher.Invoke(() =>
            {
                r1State.Content = registers[0].ToString();
                r2State.Content = registers[1].ToString();
                r3State.Content = registers[2].ToString();
            });
           
        }

        private void ClearOutput()
        {
            output.Text = string.Empty;
        }

        private void SetOutputText(string text)
        {
            Dispatcher.Invoke(() => 
            {
                output.Text = text;
            });
        }

        private void SetLoadingCircle(bool state)
        {
            Dispatcher.Invoke(() =>
            {
                if (state)
                {
                    LoadingCircle.Visibility = Visibility.Visible;
                }
                else
                {
                    LoadingCircle.Visibility = Visibility.Collapsed;
                }

            });
        }
    }
}

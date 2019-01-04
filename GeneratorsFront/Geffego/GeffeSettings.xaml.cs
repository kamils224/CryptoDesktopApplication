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
using System.IO;
using Microsoft.Win32;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Data;
using System.Linq;

namespace CryptoDesktopApplication.GeneratorsFront.Geffego
{

    public partial class GeffeSettings : UserControl
    {
        private readonly List<PolynomialModel> _feedbackFunctions = new List<PolynomialModel>();
        private Dictionary<int, int[]> functionsDicts;
        private GeffesGenerator generator = new GeffesGenerator();
        string lastGeneratedString= null;
        int lastGeneratedFormat = 0;

        public GeffeSettings()
        {
            InitializeComponent();
            SetFeedbackFunctions();
            SetFeedbackFunctionsTable();
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
            if (input.Length < 2)
            {
                MessageBox.Show("Rejestr musi mieć co najmniej 2 bity!");
                return;
            }
            r1State.Content = input;
            r1CurrentCounter.Content = input.Length;
        }

        private void setRegister2_Click(object sender, RoutedEventArgs e)
        {
            var input = lfsr2.Text;
            if (input.Length < 2)
            {
                MessageBox.Show("Rejestr musi mieć co najmniej 2 bity!");
                return;
            }
            r2State.Content = input;
            r2CurrentCounter.Content = input.Length;
        }

        private void setRegister3_Click(object sender, RoutedEventArgs e)
        {
            var input = lfsr3.Text;
            if (input.Length < 2)
            {
                MessageBox.Show("Rejestr musi mieć co najmniej 2 bity!");
                return;
            }
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

        private readonly Regex datagridRegex = new Regex("^([1-9]|[1-9][0-9])(,([1-9]|[1-9][0-9]))*$");

        private void DatagridValidation(object sender, DataGridCellEditEndingEventArgs e)
        {
            
            if (e.EditAction == DataGridEditAction.Commit)
            {
                var column = e.Column as DataGridBoundColumn;
                if (column != null)
                {
                    var bindingPath = (column.Binding as Binding).Path.Path;
                    if (bindingPath == "Polynomial")
                    {
                        int rowIndex = e.Row.GetIndex();
                        int lfsrLength = (rowIndex + 2); 
                        var el = e.EditingElement as TextBox;
                        if (datagridRegex.IsMatch(el.Text))
                        {
                            var arr = el.Text.Split(',');
                            for (int i = 0; i < arr.Length; i++)
                            {
                                var val = int.Parse(arr[i]);
                                if (val > lfsrLength)
                                {
                                    e.Cancel = true;
                                    (sender as DataGrid).CancelEdit(DataGridEditingUnit.Cell);
                                    MessageBox.Show("Rejestr jest za krótki dla podanego wielomianu!");
                                    return;
                                }
                            }
                            var unique = arr.Distinct().ToArray();
                            
                            var res = string.Join(",", unique);
                            _feedbackFunctions[rowIndex].Polynomial = res;
                            el.Text = res;
                        }
                        else
                        {
                            e.Cancel = true;
                            (sender as DataGrid).CancelEdit(DataGridEditingUnit.Cell);
                            MessageBox.Show("Niepoprawny format wielomianu!");
                        }
                        // rowIndex has the row index
                        // bindingPath has the column's binding
                        // el.Text has the new, user-entered value
                    }
                }
            }

        }
        private void PolynomialDataGrid_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            e.CancelCommand();
        }

        #endregion

        private void ChangeLfsrFeedbackFunctions(Lfsr[] registers)
        {
            for (int i = 0; i < registers.Length; i++)
            {
                int registerLength = registers[i].Register.Length;
                string function =_feedbackFunctions[registerLength - 2].Polynomial;
                var numbersText = function.Split(',');
                int[] newFunction = new int[numbersText.Length];

                for (int j = 0; j < numbersText.Length; j++)
                {
                    newFunction[j]=int.Parse(numbersText[j])-1;
                }

                registers[i].FeedbackFunction = newFunction;
            }
        }

        private void GenerateBtn_Click(object sender, RoutedEventArgs e)
        {
            string r1 = r1State.Content as string;
            string r2 = r1State.Content as string;
            string r3 = r1State.Content as string;

            Lfsr[] lfsrs = new Lfsr[3];

            lfsrs[0] = new Lfsr(r1);
            lfsrs[1] = new Lfsr(r2);
            lfsrs[2] = new Lfsr(r3);


            //setting custom feedback function
            ChangeLfsrFeedbackFunctions(lfsrs);

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
                            lastGeneratedFormat = format;
                            lastGeneratedString = new string(generator.GenerateBitsAsChars(seriesLength));
                            SetOutputText(lastGeneratedString);
                            SetLoadingCircle(false);
                            break;
                        }
                    case 1:
                        {
                            generatedBytes = generator.GenerateBytes(seriesLength);
                            lastGeneratedFormat = format;
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

        private void saveFileTxt_Click(object sender, RoutedEventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (.txt)|.txt";
            saveFileDialog1.FilterIndex = 2;
            Nullable<bool> result = saveFileDialog1.ShowDialog();
            if (result == true)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    byte[] buffer = Encoding.Default.GetBytes(output.Text);
                    myStream.Write(buffer, 0, buffer.Length);

                    myStream.Close();

                }
            }
        }

        private void saveFileBin_Click(object sender, RoutedEventArgs e)
        {
            if(lastGeneratedFormat==0)
            {
                var chars = (output.Text).ToCharArray();
                int rozmiar = ((output.Text).Length);
                BitArray a2 = new BitArray(rozmiar);
                for (int i = 0; i < rozmiar; i++)
                {

                    if (chars[i] == '1')
                    {
                        a2[i] = true;
                    }
                    if (chars[i] == '0')
                    {
                        a2[i] = false;
                    }
                }
                byte[] buffer = ToByteArray(a2);

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "Binary File (*.bin)|*.bin";
                saveFileDialog1.FilterIndex = 2;
                Nullable<bool> result = saveFileDialog1.ShowDialog();
                if (result == true)
                {
                    File.WriteAllBytes(saveFileDialog1.FileName, buffer);
                }
            }else if (lastGeneratedFormat == 1)
            {
                byte[] buffer = Convert.FromBase64String(output.Text);

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "Binary File (*.bin)|*.bin";
                saveFileDialog1.FilterIndex = 2;
                Nullable<bool> result = saveFileDialog1.ShowDialog();
                if (result == true)
                {
                    File.WriteAllBytes(saveFileDialog1.FileName, buffer);
                }
            }
        }
        private byte[] ToByteArray(BitArray input)
        {
            if (input.Length % 8 != 0)
            {
                byte[] ret = new byte[(input.Length / 8)];
                for (int i = 0; i < input.Length - input.Length % 8; i += 8)
                {
                    int value = 0;
                    for (int j = 0; j < 8; j++)
                    {
                        if (input[i + j])
                        {
                            value += 1 << (7 - j);
                        }
                    }
                    ret[i / 8] = (byte)value;
                }
                return ret;

            }
            else
            {
                byte[] ret = new byte[input.Length / 8];
                for (int i = 0; i < input.Length; i += 8)
                {
                    int value = 0;
                    for (int j = 0; j < 8; j++)
                    {
                        if (input[i + j])
                        {
                            value += 1 << (7 - j);
                        }
                    }
                    ret[i / 8] = (byte)value;
                }
                return ret;
            }
        }

        private void outputFormatComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (outputFormatComboBox.SelectedIndex == 0)
            {
                seriesLengthLabel.Content = "Długość ciągu (w bitach)";
            }
            else
            {
                seriesLengthLabel.Content = "Długość ciągu (w bajtach)";
            }
        }

        private void SetFeedbackFunctions()
        {
            functionsDicts = Lfsr.GenerateFeedbackFunctions();
;
            foreach (var item in functionsDicts)
            {
                int[] tapsArray = new int[item.Value.Length];
                for (int i = 0; i < tapsArray.Length; i++)
                {
                    tapsArray[i] = item.Value[i] + 1;
                }
                var polynomial = new PolynomialModel()
                {
                    Length = item.Key,
                    Polynomial = string.Join(",", tapsArray)
                };
                _feedbackFunctions.Add(polynomial);
            }

        }

        private void SetFeedbackFunctionsTable()
        {
            if (_feedbackFunctions != null)
            {
                PolynomialDataGrid.ItemsSource = _feedbackFunctions;
            }
        }

        private void setPolynomial_Click(object sender, RoutedEventArgs e)
        {
            _feedbackFunctions.Clear();
            foreach (var item in functionsDicts)
            {
                int[] tapsArray = new int[item.Value.Length];
                for (int i = 0; i < tapsArray.Length; i++)
                {
                    tapsArray[i] = item.Value[i] + 1;
                }
                var polynomial = new PolynomialModel()
                {
                    Length = item.Key,
                    Polynomial = string.Join(",", tapsArray)

                };
                _feedbackFunctions.Add(polynomial);
            }

            PolynomialDataGrid.Items.Refresh();
        }

    }
}

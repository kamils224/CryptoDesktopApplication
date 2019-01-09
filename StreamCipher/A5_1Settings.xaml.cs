using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using CryptoDesktopApplication.Backend;
using Microsoft.Win32;

namespace CryptoDesktopApplication.StreamCipher
{
    public partial class A5_1Settings : UserControl
    {
        private A5_1Generator generator = new A5_1Generator();
        private byte[] output = null;
        private List<TextBox> register19 = new List<TextBox>();
        private List<TextBox> register22 = new List<TextBox>();
        private List<TextBox> register23 = new List<TextBox>();

        private readonly string hexPattern = @"^[A-Fa-f0-9]*$";
        public A5_1Settings()
        {
            InitializeComponent();
            foreach (var item in register_19.Children)
            {
                register19.Add(item as TextBox);
            }
            foreach (var item in register_22.Children)
            {
                register22.Add(item as TextBox);
            }
            foreach (var item in register_23.Children)
            {
                register23.Add(item as TextBox);
            }
        }

        private static readonly Regex _binaryStringOnlyRegex = new Regex("[^0-1]+");
        private static bool IsBinaryString(string text)
        {
            return _binaryStringOnlyRegex.IsMatch(text);
        }

        private void BinaryStringValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-1]+");
            e.Handled = regex.IsMatch(e.Text);
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

        private void outputFormatComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (outputFormatCombobox == null)
            {
                return;
            }

            if (seriesLengthLabel == null)
            {
                return;
            }
            if (outputFormatCombobox.SelectedIndex == 0)
            {
                seriesLengthLabel.Content = "Długość ciągu (w bitach)";
            }
            else
            {
                seriesLengthLabel.Content = "Długość ciągu (w bajtach)";
            }
        }

        private static readonly Regex _digitsOnlyRegex = new Regex("[^0-9.-]+");
        private static bool IsTextAllowed(string text)
        {
            return _digitsOnlyRegex.IsMatch(text);
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

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex rgx = new Regex("[^0-9]+");
            e.Handled = rgx.IsMatch(e.Text);
        }

        private void encryptFileBtn_Click(object sender, RoutedEventArgs e)
        {
            string input = outputLength.Text;
            if (string.IsNullOrEmpty(input))
            {
                return;
            }

            int selectedOutputType = outputCombobox.SelectedIndex;
            int selectedOutputFormat = outputFormatCombobox.SelectedIndex;

            string filename = "";
            if (outputCombobox.SelectedIndex == 1)
            {
                SaveFileDialog fileDialog = new SaveFileDialog();
                if (fileDialog.ShowDialog() == true)
                {
                    filename = fileDialog.FileName;
                }
            }

            Lfsr[] lfsrs = new Lfsr[3] {new Lfsr(19,true), new Lfsr(22, true), new Lfsr(23, true) };
            for (int i = 0; i < register19.Count; i++)
            {
                string txt = register19[i].Text;
                char toAdd = '0';
                if (txt.Length == 1)
                {
                    toAdd = txt[0];
                }

                lfsrs[0].Register[i] = (toAdd == '1');
            }

            for (int i = 0; i < register22.Count; i++)
            {
                string txt = register22[i].Text;
                char toAdd = '0';
                if (txt.Length == 1)
                {
                    toAdd = txt[0];
                }

                lfsrs[1].Register[i] = (toAdd == '1');
            }

            for (int i = 0; i < register23.Count; i++)
            {
                string txt = register23[i].Text;
                char toAdd = '0';
                if (txt.Length == 1)
                {
                    toAdd = txt[0];
                }

                lfsrs[2].Register[i] = (toAdd == '1');
            }
            
            generator.ChangeRegister(lfsrs[0],0);
            generator.ChangeRegister(lfsrs[1],1);
            generator.ChangeRegister(lfsrs[2],2);

            Task.Run(() =>
            {
                ShowLoadingCircle();
                DisableAllButtons();
                int seriesLength = int.Parse(input);
                if (selectedOutputType == 0)
                {
                    if (selectedOutputFormat == 0)
                    {
                        char[] series = generator.GenerateBitsAsChars(seriesLength);

                        SetGeneratorOutput(new string(series));

                    }
                    else if (selectedOutputFormat == 1)
                    {
                        byte[] series = generator.GenerateBytes(seriesLength);

                        SetGeneratorOutput(Convert.ToBase64String(series));
                    }
                }
                else if (selectedOutputType == 1)
                {
                    if (selectedOutputFormat == 0)
                    {
                        char[] series = generator.GenerateBitsAsChars(seriesLength);

                        File.WriteAllText(filename,new string(series));

                    }
                    else if (selectedOutputFormat == 1)
                    {
                        byte[] series = generator.GenerateBytes(seriesLength);

                        File.WriteAllBytes(filename,series);
                    }
                }
                EnableAllButtons();
                HideLoadingCircle();
                UpdateRegisters();


            });

            

        }

        private void UpdateRegisters()
        {
            Dispatcher.Invoke(() =>
            {

                string[] registers = new string[]
                {
                    generator.Registers[0].ToString(), generator.Registers[1].ToString(),
                    generator.Registers[2].ToString()
                };

                for (int i = 0; i < register19.Count; i++)
                {
                    register19[i].Text = registers[0][i].ToString();
                }
                for (int i = 0; i < register22.Count; i++)
                {
                    register22[i].Text = registers[1][i].ToString();
                }
                for (int i = 0; i < register23.Count; i++)
                {
                    register23[i].Text = registers[2][i].ToString();
                }
            });
        }

        private void SetGeneratorOutput(string text)
        {
            Dispatcher.Invoke(() => { generatorOutput.Text = text; });
        }

        private void ShowLoadingCircle()
        {
            Dispatcher.Invoke(() => { LoadingCircle.Visibility = Visibility.Visible; });
        }
        private void HideLoadingCircle()
        {
            Dispatcher.Invoke(() => { LoadingCircle.Visibility = Visibility.Collapsed; });
        }

        private void EnableAllButtons()
        {
            bool state = true;
            Dispatcher.Invoke(() =>
            {
                fillR1Btn.IsEnabled = state;
                fillR2Btn.IsEnabled = state;
                fillR3Btn.IsEnabled = state;
                generateKeyBtn.IsEnabled = state;
                encryptBtn.IsEnabled = state;
                loadFileEncrypt.IsEnabled = state;
                encryptFileBtn.IsEnabled = state;
                foreach (RadioButton item in inputFormat.Children)
                {
                    item.IsEnabled = state;
                }
                foreach (RadioButton item in outputFormat.Children)
                {
                    item.IsEnabled = state;
                }
            });
        }
        private void DisableAllButtons()
        {
            bool state = false;
            Dispatcher.Invoke(() =>
            {
                fillR1Btn.IsEnabled = state;
                fillR2Btn.IsEnabled = state;
                fillR3Btn.IsEnabled = state;
                generateKeyBtn.IsEnabled = state;
                encryptBtn.IsEnabled = state;
                loadFileEncrypt.IsEnabled = state;
                encryptFileBtn.IsEnabled = state;
                foreach (RadioButton item in inputFormat.Children)
                {
                    item.IsEnabled = state;
                }
                foreach (RadioButton item in outputFormat.Children)
                {
                    item.IsEnabled = state;
                }
            });
        }

        private void Clear_outputLength(object Sender, RoutedEventArgs e)
        {
            outputLength.Text = string.Empty;
        }

        private void encryptBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(inputEncrypt.Text))
            {
                return;
            }


            string input = inputEncrypt.Text;

            var checkedRB = inputFormat.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked == true);
            string format = checkedRB.DataContext as string;
            byte[] encodedText = null;

            bool changeRegisters = false;
            if (ChangeRegistersCheckbox.IsChecked == true)
            {
                changeRegisters = true;
            }

            Lfsr[] lfsrs = new Lfsr[3] { new Lfsr(19, true), new Lfsr(22, true), new Lfsr(23, true) };
            for (int i = 0; i < register19.Count; i++)
            {
                string txt = register19[i].Text;
                char toAdd = '0';
                if (txt.Length == 1)
                {
                    toAdd = txt[0];
                }

                lfsrs[0].Register[i] = (toAdd == '1');
            }

            for (int i = 0; i < register22.Count; i++)
            {
                string txt = register22[i].Text;
                char toAdd = '0';
                if (txt.Length == 1)
                {
                    toAdd = txt[0];
                }

                lfsrs[1].Register[i] = (toAdd == '1');
            }

            for (int i = 0; i < register23.Count; i++)
            {
                string txt = register23[i].Text;
                char toAdd = '0';
                if (txt.Length == 1)
                {
                    toAdd = txt[0];
                }

                lfsrs[2].Register[i] = (toAdd == '1');
            }

            generator.ChangeRegister(lfsrs[0], 0);
            generator.ChangeRegister(lfsrs[1], 1);
            generator.ChangeRegister(lfsrs[2], 2);


            Task.Run(() => {

                DisableAllButtons();
                ShowLoadingCircle();
                switch (format)
                {
                    case "ascii":
                        {
                            encodedText = Encoding.ASCII.GetBytes(input);
                            output = Encrypt(encodedText, changeRegisters);
                            break;
                        }
                    case "hex":
                        {
                            Regex regex = new Regex(hexPattern);
                            if (!regex.IsMatch(input))
                            {
                                Dispatcher.Invoke(() =>
                                {
                                    HideLoadingCircle();
                                    EnableAllButtons();
                                    MessageBox.Show("Podano niepoprawny tekst dla formatu hex!");
                                });

                                return;
                            }
                            try
                            {
                                encodedText = Helpers.StringToByteArrayFastest(input);
                            }
                            catch (Exception ex)
                            {
                                Dispatcher.Invoke(() =>
                                {
                                    HideLoadingCircle();
                                    EnableAllButtons();
                                    MessageBox.Show(ex.Message);
                                });
                                return;
                            }

                            output = Encrypt(encodedText, changeRegisters);

                            break;
                        }
                    case "base64":
                        {
                            try
                            {
                                encodedText = Convert.FromBase64String(input);
                            }
                            catch (FormatException)
                            {
                                Dispatcher.Invoke(() =>
                                {
                                    HideLoadingCircle();
                                    EnableAllButtons();
                                    MessageBox.Show("niepoprawny format Base64!");
                                });
                                return;
                            }
                            output = Encrypt(encodedText,changeRegisters);
                            break;
                        }
                    case "unicode":
                        {
                            encodedText = Encoding.Unicode.GetBytes(input);
                            output = Encrypt(encodedText, changeRegisters);
                            break;
                        }
                    default:
                        break;
                }

                HideLoadingCircle();
                EnableAllButtons();

                asciiOutput = null;
                hexOutput = null;
                base64Output = null;
                unicodeOutput = null;
                WriteToOutputTextbox(output);

            });
        }

        private void WriteToOutputTextbox(byte[] encrypted)
        {
            Dispatcher.Invoke(() =>
            {
                var checkedRB = outputFormat.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked == true);
                var format = checkedRB.DataContext as string;

                switch (format)
                {
                    case "ascii":
                    {
                        asciiOutput = Encoding.ASCII.GetString(encrypted);
                        outputEncrypt.Text = asciiOutput;
                        break;
                    }
                    case "hex":
                    {
                        var hex = BitConverter.ToString(encrypted).Replace("-", string.Empty);
                        hexOutput = hex;
                        outputEncrypt.Text = hexOutput;

                        break;
                    }
                    case "base64":
                    {
                        base64Output = Convert.ToBase64String(encrypted);
                        outputEncrypt.Text = base64Output;
                        break;
                    }
                    case "unicode":
                    {
                        unicodeOutput = Encoding.Unicode.GetString(encrypted);
                        outputEncrypt.Text = unicodeOutput;
                        break;
                    }
                    default:
                        break;
                }

            });
        }

        private byte[] Encrypt(byte[] message,bool updateRegisters)
        {
            var key = generator.GenerateBytes(message.Length);
            byte[] output = new byte[message.Length];

            for (int i = 0; i < message.Length; i++)
            {
                int xor = message[i] ^ key[i];
                output[i] = (byte) xor;
            }

            if (updateRegisters)
            {
                UpdateRegisters();
            }


            return output;
        }

        private byte[] loadedFile;
        private uint fileLengthinBits;

        private void loadFileEncrypt_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() == true)
            {
                loadedFile = File.ReadAllBytes(fileDialog.FileName);
                fileLengthinBits = (uint)loadedFile.Length * 8;
                filenameInfo.Text = "Nazwa pliku: " + fileDialog.SafeFileName;
                fileLengthInfo.Text = "Liczba bitów: " + fileLengthinBits;
            }
        }

        private string asciiOutput = null;
        private string hexOutput = null;
        private string base64Output = null;
        private string unicodeOutput = null;

        private void ChangeOutputToAscii(object sender, RoutedEventArgs e)
        {
            if (output != null)
            {
                if (asciiOutput == null)
                {
                    asciiOutput = Encoding.ASCII.GetString(output);
                    outputEncrypt.Text = asciiOutput;
                }
                else
                {
                    outputEncrypt.Text = asciiOutput;
                }
            }

        }
        private void ChangeOutputToHex(object sender, RoutedEventArgs e)
        {
            if (output != null)
            {
                if (hexOutput == null)
                {
                    var hex = BitConverter.ToString(output).Replace("-", string.Empty);
                    hexOutput = hex;
                    outputEncrypt.Text = hexOutput;
                }
                else
                {
                    outputEncrypt.Text = hexOutput;
                }


            }

        }
        private void ChangeOutputToBase64(object sender, RoutedEventArgs e)
        {
            if (output != null)
            {
                if (base64Output == null)
                {
                    base64Output = Convert.ToBase64String(output);
                    outputEncrypt.Text = base64Output;
                }
                else
                {
                    outputEncrypt.Text = base64Output;
                }
            }

        }
        private void ChangeOutputToUnicode(object sender, RoutedEventArgs e)
        {
            if (output != null)
            {
                if (unicodeOutput == null)
                {
                    unicodeOutput = Encoding.Unicode.GetString(output);
                    outputEncrypt.Text = unicodeOutput;
                }
                else
                {
                    outputEncrypt.Text = unicodeOutput;
                }

            }

        }

        private void fillR1Btn_Click(object sender, RoutedEventArgs e)
        {
            var textbox = R1_txtBox.Text;
            int lastIndex = 0;
            for (int i = 0; i < textbox.Length; i++)
            {
                register19[i].Text = textbox[i].ToString();
                lastIndex = i;
            }

            for (int i = lastIndex+1; i < register19.Count; i++)
            {
                register19[i].Text = "0";
            }
        }

        private void fillR2Btn_Click(object sender, RoutedEventArgs e)
        {
            var textbox = R2_txtBox.Text;
            int lastIndex = 0;
            for (int i = 0; i < textbox.Length; i++)
            {
                register22[i].Text = textbox[i].ToString();
                lastIndex = i;
            }

            for (int i = lastIndex + 1; i < register22.Count; i++)
            {
                register22[i].Text = "0";
            }
        }

        private void fillR3Btn_Click(object sender, RoutedEventArgs e)
        {
            var textbox = R3_txtBox.Text;
            int lastIndex = 0;
            for (int i = 0; i < textbox.Length; i++)
            {
                register23[i].Text = textbox[i].ToString();
                lastIndex = i;
            }

            for (int i = lastIndex + 1; i < register23.Count; i++)
            {
                register23[i].Text = "0";
            }
        }

        private void encryptFileBtn_Click_1(object sender, RoutedEventArgs e)
        {
            if (loadedFile == null)
            {
                MessageBox.Show("Nie wczytano pliku!");
                return;
            }

            bool updateRegisters = ChangeRegistersCheckbox.IsChecked==true;

            SaveFileDialog fileDialog = new SaveFileDialog();

            string filename = null;
            if (fileDialog.ShowDialog() == true)
            {
                filename = fileDialog.FileName;
            }

            ShowLoadingCircle();
            DisableAllButtons();

            Task.Run(() =>
            {
                if (filename != null)
                {


                    File.WriteAllBytes(filename, Encrypt(loadedFile, true));

                    HideLoadingCircle();
                    EnableAllButtons();
                }

                if (updateRegisters)
                {
                    UpdateRegisters();
                }

            });



        }
    }
}

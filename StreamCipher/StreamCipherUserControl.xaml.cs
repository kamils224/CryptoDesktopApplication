using Microsoft.Win32;
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

namespace CryptoDesktopApplication.StreamCipher
{

    public partial class StreamCipherUserControl : UserControl
    {
        private enum KeyType
        {
            NONE,
            TXT,
            BIN
        }

        private readonly string hexPattern = @"^[A-Fa-f0-9]*$";

        private byte[] loadedKey;
        private string loadedKeyTxt;
        private KeyType keyformat;
        private string loadedFilename;
        private uint loadedFileNumOfBits;


        private byte[] output = null;

        public StreamCipherUserControl()
        {
            InitializeComponent();
        }

        private bool ValidateTxtKey(string key)
        {
            for (int i = 0; i < key.Length; i++)
            {
                if(key[i]!='1' && key[i] != '0')
                {
                    return false;
                }
            }

            return true;
        }

        private void loadKeyBtn_Click(object sender, RoutedEventArgs e)
        {
            if (txtFile.IsChecked == true)
            {
                OpenFileDialog fileDialog = new OpenFileDialog();

                if (fileDialog.ShowDialog() == true)
                {
                    //Readallines instead of readalltext - allows files with new line character
                    loadedKeyTxt= string.Join("",File.ReadAllLines(fileDialog.FileName));
                    if (!ValidateTxtKey(loadedKeyTxt))
                    {
                        MessageBox.Show("Niepoprawny format pliku z kluczem!");
                        return;
                    }
                    loadedKey = Helpers.BinaryStringToBytes(loadedKeyTxt);
                    keyformat = KeyType.TXT;
                    loadedFilename = fileDialog.SafeFileName;
                    loadedFileNumOfBits = (uint)loadedKeyTxt.Length;

                    keyFilenameInfo.Text = "Nazwa pliku: " + loadedFilename;
                    keyFileInfo.Text = "Liczba bitów:" + loadedFileNumOfBits;
                }


            }
            if (binFile.IsChecked == true)
            {
                OpenFileDialog fileDialog = new OpenFileDialog();

                if (fileDialog.ShowDialog() == true)
                {

                    loadedKey = File.ReadAllBytes(fileDialog.FileName);
                    keyformat = KeyType.BIN;
                    loadedFilename = fileDialog.SafeFileName;
                    loadedFileNumOfBits = (uint)loadedKey.Length*8;

                    keyFilenameInfo.Text = "Nazwa pliku: " + loadedFilename;
                    keyFileInfo.Text = "Liczba bitów: " + loadedFileNumOfBits;
                }
            }
        }

        private void txtFile_Checked(object sender, RoutedEventArgs e)
        {
            if(binFile!=null)
                binFile.IsChecked = false;
        }

        private void binFile_Checked(object sender, RoutedEventArgs e)
        {
            if (txtFile != null)
                txtFile.IsChecked = false;
        }

        private void encryptBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(inputEncrypt.Text))
            {
                return;
            }

            if (keyformat == KeyType.NONE)
            {
                return;
            }

            string input = inputEncrypt.Text;

            var checkedRB=inputFormat.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked==true);
            string format = checkedRB.DataContext as string;
            byte[] encodedText=null;

            Task.Run(() => {

                disableAllButtons();
                showLoadingCircle();
                switch (format)
                {
                    case "ascii":
                        {
                            encodedText = Encoding.ASCII.GetBytes(input);
                            output = Encrypt(encodedText, loadedKey);
                            break;
                        }
                    case "hex":
                        {
                            Regex regex = new Regex(hexPattern);
                            if (!regex.IsMatch(input))
                            {
                                Dispatcher.Invoke(() =>
                                {
                                    hideLoadingCircle();
                                    enableAllbuttons();
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
                                    hideLoadingCircle();
                                    enableAllbuttons();
                                    MessageBox.Show(ex.Message); 
                                });
                                return;
                            }

                            output = Encrypt(encodedText, loadedKey);

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
                                    hideLoadingCircle();
                                    enableAllbuttons();
                                    MessageBox.Show("niepoprawny format Base64!");
                                });
                                return;
                            }
                            output = Encrypt(encodedText, loadedKey);
                            break;
                        }
                    case "unicode":
                        {
                            encodedText = Encoding.Unicode.GetBytes(input);
                            output = Encrypt(encodedText, loadedKey);
                            break;
                        }
                    default:
                        break;
                }

                hideLoadingCircle();
                enableAllbuttons();

                asciiOutput = null;
                hexOutput = null;
                base64Output = null;
                unicodeOutput = null;
                WriteToOutputTextbox(output);

            });
        }

        private byte[] Encrypt(byte[] input, byte[] key)
        {
            int keyCounter = 0;
            int xored = 0;
            byte[] output = new byte[input.Length]; 
            for (int i = 0; i < input.Length; i++)
            {
                xored = input[i] ^ key[keyCounter];
                output[i] = (byte)xored;
                ++keyCounter;
                if(keyCounter>= key.Length)
                {
                    keyCounter = 0;
                }
            }

            return output;
        }


        private void WriteToOutputTextbox(byte[] encrypted)
        {
            Dispatcher.Invoke(() => 
            {
                var checkedRB =outputFormat.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked == true);
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

        private void showLoadingCircle()
        {
            Dispatcher.Invoke(() =>
            {
                LoadingCircle.Visibility = Visibility.Visible;
            });
        }

        private void hideLoadingCircle()
        {
            Dispatcher.Invoke(() =>
            {
                LoadingCircle.Visibility = Visibility.Collapsed;
            });
        }

        private void disableAllButtons()
        {
            bool state = false;
            Dispatcher.Invoke(() =>
            {
                loadKeyBtn.IsEnabled = state;
                encryptBtn.IsEnabled = state;
                encryptFileBtn.IsEnabled = state;
                loadFileEncrypt.IsEnabled = state;
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
        private void enableAllbuttons()
        {
            bool state = true;
            Dispatcher.Invoke(() =>
            {
                loadKeyBtn.IsEnabled = state;
                encryptBtn.IsEnabled = state;
                encryptFileBtn.IsEnabled = state;
                loadFileEncrypt.IsEnabled = state;
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

    }
}

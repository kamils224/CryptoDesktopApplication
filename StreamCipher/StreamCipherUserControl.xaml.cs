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

        private readonly string hexPattern = "^([a-fA-F0-9]{2}\\s+)+";

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

        private void encryptBtn_Copy1_Click(object sender, RoutedEventArgs e)
        {
            if (keyformat == KeyType.NONE)
            {
                return;
            }

            string input = inputEncrypt.Text;

            var checkedRB=inputFormat.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked==true);
            string format = checkedRB.DataContext as string;
            byte[] encodedText=null;

            Task.Run(() => {

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
                            outputEncrypt.Text = Encoding.ASCII.GetString(encrypted);
                            break;
                        }
                    case "hex":
                        {
                            var hex = BitConverter.ToString(encrypted, 16).Replace("-", string.Empty);
                            outputEncrypt.Text = hex;

                            break;
                        }
                    case "base64":
                        {
                            outputEncrypt.Text = Convert.ToBase64String(encrypted);
                            break;
                        }
                    case "unicode":
                        {
                            outputEncrypt.Text = Encoding.Unicode.GetString(encrypted);
                            break;
                        }
                    default:
                        break;
                }

            });
        }
    }
}

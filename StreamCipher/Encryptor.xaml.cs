using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;




namespace PZ_generatory
{
    /// <summary>
    /// Interaction logic for Encryptor.xaml
    /// </summary>
    public partial class Encryptor : UserControl
    {
        public Encryptor()
        {
            InitializeComponent();
        }



        string ciąg = null;

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            bin.IsChecked = false;
        }

        private void bin_Checked(object sender, RoutedEventArgs e)
        {
            txt.IsChecked = false;
        }

        static String odczyt_z_pliku(String path)
        {
            string s = File.ReadAllText(path, Encoding.Default);
            return s;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (txt.IsChecked == true)
            {


                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.FileName = "Document"; // Default file name
                dlg.DefaultExt = ".txt"; // Default file extension
                dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

                // Show open file dialog box
                Nullable<bool> result = dlg.ShowDialog();

                // Process open file dialog box results
                if (result == true)
                {
                    // Open document
                    string path = dlg.FileName;
                    ciąg = odczyt_z_pliku(path);

                }
            }

            if (bin.IsChecked == true)
            {

                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.FileName = "Document"; // Default file name
                dlg.DefaultExt = ".bin"; // Default file extension
                dlg.Filter = "Binary documents (.bin)|*.bin"; // Filter files by extension

                // Show open file dialog box
                Nullable<bool> result = dlg.ShowDialog();

                // Process open file dialog box results
                if (result == true)
                {
                    // Open document
                    string path = dlg.FileName;
                    byte[] b = File.ReadAllBytes(path);

                    BitArray bity = new BitArray(b);
                    char[] s = new char[(b.Length) * 8];
                    char[] pom = new char[(b.Length) * 8];

                    int rr = 0;
                    foreach (bool value in bity)
                    {
                        if (value == true)
                        {
                            s[rr] = '1';
                            pom[rr] = '1';
                        }
                        else
                        {
                            s[rr] = '0';
                            pom[rr] = '0';
                        }
                        rr++;
                    }

                    int z = (b.Length);
                    Console.WriteLine("Długosć z: " + z);
                    int k = 0;
                    while (z > 0)
                    {
                        s[0 + k] = pom[7 + k];
                        s[1 + k] = pom[6 + k];
                        s[2 + k] = pom[5 + k];
                        s[3 + k] = pom[4 + k];
                        s[4 + k] = pom[3 + k];
                        s[5 + k] = pom[2 + k];
                        s[6 + k] = pom[1 + k];
                        s[7 + k] = pom[0 + k];

                        z--;
                        k = k + 8;
                    }



                    ciąg = new string(s);

                }




            }
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {

            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (.txt)|.txt";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            Nullable<bool> result = saveFileDialog1.ShowDialog();
            if (result == true)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    byte[] buffer = Encoding.Default.GetBytes(tekst.Text);
                    myStream.Write(buffer, 0, buffer.Length);

                    myStream.Close();
                }
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string path = dlg.FileName;
                tekst.Text = odczyt_z_pliku(path);
            }
        }

        private void wynik_txt_Click(object sender, RoutedEventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (.txt)|.txt";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            Nullable<bool> result = saveFileDialog1.ShowDialog();
            if (result == true)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    byte[] buffer = Encoding.Default.GetBytes(wynik.Text);
                    myStream.Write(buffer, 0, buffer.Length);

                    myStream.Close();
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

        private void wynik_bin_Click(object sender, RoutedEventArgs e)
        {
            var chars = (wynik.Text).ToCharArray();
            int rozmiar = ((wynik.Text).Length);
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

            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "bin files (.bin)|.bin";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            Nullable<bool> result = saveFileDialog1.ShowDialog();
            if (result == true)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {

                    myStream.Write(buffer, 0, buffer.Length);

                    myStream.Close();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) //button_szyfruj
        {
            if (ciąg == null)
            {
                MessageBox.Show("Nie wczytano ciągu pseudolosowego!");
            }
            else
            {
                wynik.Clear();

                var chars = ciąg.ToCharArray();

                int rozmiar = ((tekst.Text).Length) * 8;
                BitArray a2 = new BitArray(rozmiar);
                int p = 0;
                for (int i = 0; i < rozmiar; i++)
                {

                    if (chars[p] == '1')
                    {
                        a2[i] = true;
                    }
                    if (chars[p] == '0')
                    {
                        a2[i] = false;
                    }

                    p++;
                    if (p > (chars.Length) - 1)
                    {
                        p = 0;
                    }


                }
                // byte[] ciąg_b = Encoding.ASCII.GetBytes(ciąg);
                //BitArray a1 = new BitArray(ciąg_b);
                byte[] ciąg_t = Encoding.ASCII.GetBytes(tekst.Text);
                BitArray a1 = new BitArray(ciąg_t);

                BitArray a3 = new BitArray(rozmiar);
                a3 = a1.Xor(a2);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i <a3.Length; i++)
                {
                    if (a3[i])
                    {
                        sb.Append('1');
                    }
                    else
                    {
                        sb.Append('0');
                    }
                }

                wynik.Text = sb.ToString();
            }
        }

        private void BackTo_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Panel).Children.Remove(this);
        }




    }
}

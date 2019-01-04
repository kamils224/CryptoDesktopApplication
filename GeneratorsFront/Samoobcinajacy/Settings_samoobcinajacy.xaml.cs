using CryptoDesktopApplication.Backend;
using CryptoDesktopApplication.Fips;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

namespace PZ_generatory.Generators.Samoobcinajacy
{
    /// <summary>
    /// Interaction logic for Settings_samoobcinajacy.xaml
    /// </summary>
    public partial class Settings_samoobcinajacy : UserControl
    {
        public Settings_samoobcinajacy()
        {
            InitializeComponent();
            PrepareRegisterLenghtCombobox();
        }
        private void PrepareRegisterLenghtCombobox()
        {
            for (int i = 2; i <= 20; i++)
            {
                RegisterLength_ComboBox.Items.Add(i);
            }
            RegisterLength_ComboBox.SelectedIndex = 0;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            uint parsedValue;
            if ((series_length.Text).ToString().Length == 0)
            {
                MessageBox.Show("Podaj długość ciągu do wygenerowania.");
                return;
            }
            else if (!uint.TryParse(series_length.Text, out parsedValue))
            {
                MessageBox.Show("Długość ciągu do wygenerowania musi być dodatnią liczbą całkowitą.");
                return;
            }

            uint parsed;
            if (!uint.TryParse(lfsr1.Text, out parsed))
            {
                MessageBox.Show("Wartości początkowe rejestrów muszą być dodatnią liczbą całkowitą.");
                return;
            }
            else if ((lfsr1.Text).ToString().Length == 0)
            {
                MessageBox.Show("Uzupełnij pola z wartościami początkowymi rejestrów.");
                return;
            }

            var registersLength = Convert.ToInt32(RegisterLength_ComboBox.SelectedItem);

            var boolArray = Convert.ToString(parsed, 2).Select(str => str.Equals('1')).Take(registersLength).ToArray();
            var bitArray = new BitArray(registersLength);
            for (int j = 0; j < boolArray.Length; j++)
            {
                bitArray[j] = boolArray[j];
            }

            int numOfLfsr = 1;
            Lfsr[] lfsr = new Lfsr[numOfLfsr];
                lfsr[0] = new Lfsr(registersLength);
                TextBox tb = (TextBox)this.FindName("lfsr1");
                lfsr[0].SetRegisterValues(bitArray);
            

            wynik.Clear();
            LfsrGenerator generator = new SelfShrinkingGenerator(lfsr);
            if (typ.SelectedIndex == 0)
            {
                var gen = generator.GenerateBitsAsChars(Convert.ToInt32(series_length.Text));
                wynik.Text = new string(gen);
            }
            else if (typ.SelectedIndex == 1)
            {
                var gen1 = generator.GenerateBytes(Convert.ToInt32(series_length.Text));
                wynik.Text = BitConverter.ToString(gen1);
            }
            else if (typ.SelectedIndex == 2)
            {
                var gen1 = generator.GenerateIntegers(Convert.ToInt32(series_length.Text));
                wynik.Text = String.Join(" ", gen1.Select(p => p.ToString()).ToArray());
            }

        }
        private void Clear_lfsr1(object sender, RoutedEventArgs e)
        {
            lfsr1.Clear();
        }

        private void Clear_series_length(object sender, RoutedEventArgs e)
        {
            series_length.Clear();
        }

        FipsTests fips = new FipsTests();


        private void tests_TextChanged(object sender, EventArgs e)
        {
            if (byte_type.IsSelected || int_type.IsSelected)
            {
                SingleBit.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2196F3"));
                SingleBit.Kind = PackIconKind.CloseCircle;
                Series.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2196F3"));
                Series.Kind = PackIconKind.CloseCircle;
                LongSeries.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2196F3"));
                LongSeries.Kind = PackIconKind.CloseCircle;
                Poker.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2196F3"));
                Poker.Kind = PackIconKind.CloseCircle;
            }
            else if (wynik.Text.Length == 0)
            {
                SingleBit.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2196F3"));
                SingleBit.Kind = PackIconKind.CloseCircle;
                Series.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2196F3"));
                Series.Kind = PackIconKind.CloseCircle;
                LongSeries.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2196F3"));
                LongSeries.Kind = PackIconKind.CloseCircle;
                Poker.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2196F3"));
                Poker.Kind = PackIconKind.CloseCircle;
            }
            else
            {

                var result = StartTestWithTxt();


                if (result != null)
                {
                    //SingleBit Tests
                    if (result.SingleBitTestResult.TestPassed)
                    {
                        SingleBit.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Green"));
                        SingleBit.Kind = PackIconKind.Approval;
                    }
                    else
                    {
                        SingleBit.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
                        SingleBit.Kind = PackIconKind.CloseCircle;
                    }
                    //Series Tests
                    if (result.SeriesTestResult.TestPassed)
                    {
                        Series.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Green"));
                        Series.Kind = PackIconKind.Approval;
                    }
                    else
                    {
                        Series.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
                        Series.Kind = PackIconKind.CloseCircle;
                    }
                    //LongSeries Tests
                    if (result.LongSeriesTestResult.TestPassed)
                    {
                        LongSeries.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Green"));
                        LongSeries.Kind = PackIconKind.Approval;
                    }
                    else
                    {
                        LongSeries.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
                        LongSeries.Kind = PackIconKind.CloseCircle;
                    }
                    //Poker Tests
                    if (result.PokerTestResult.TestPassed)
                    {
                        Poker.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Green"));
                        Poker.Kind = PackIconKind.Approval;
                    }
                    else
                    {
                        Poker.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
                        Poker.Kind = PackIconKind.CloseCircle;
                    }
                }
                else
                {
                    SingleBit.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
                    SingleBit.Kind = PackIconKind.CloseCircle;

                    Series.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
                    Series.Kind = PackIconKind.CloseCircle;

                    LongSeries.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
                    LongSeries.Kind = PackIconKind.CloseCircle;

                    Poker.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
                    Poker.Kind = PackIconKind.CloseCircle;
                }

            }
        }


        private class FipsResult
        {
            public SingleBitTestResult SingleBitTestResult;
            public SeriesTestResult SeriesTestResult;
            public LongSeriesTestResult LongSeriesTestResult;
            public PokerTestResult PokerTestResult;
        }

        private FipsResult StartTestWithTxt()
        {
            if (wynik.Text.Length < 20000)
            {
                //Jak ciąg będzie mniejszy niż <20000 
                return null;
            }

            foreach (var item in wynik.Text.ToCharArray())
            {
                if (item != '1' && item != '0')
                {
                    //Jak wczytany plik zawiera znaki różne od '0' i '1'"
                    return null;
                }
            }
            var input = (wynik.Text).Substring(0, 20000);
            FipsResult fipsResult = new FipsResult()
            {
                SingleBitTestResult = fips.SingleBitTest(input),
                SeriesTestResult = fips.SeriesTest(input),
                LongSeriesTestResult = fips.LongSeriesTests(input),
                PokerTestResult = fips.PokerTest(input)
            };

            return fipsResult;

        }
    }
}

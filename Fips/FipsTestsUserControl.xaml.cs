using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using System.Collections;
using System.IO;
using System.Linq;
using System.Windows.Media;


namespace CryptoDesktopApplication.Fips
{
    public partial class FipsTestsUserControl : UserControl
    {
        FipsTests fips = new FipsTests();
        


        public FipsTestsUserControl()
        {
            InitializeComponent();
        }

        private void LoadFileButton_Click(object sender, RoutedEventArgs e)
        {
            string positive = "Wynik pozytywny";
            string negative = "Wynik negatywny";

            try
            {
                switch (FormatTypeComboBox.SelectedIndex)
                {
                    case 0:
                        {
                            var result = StartTestWithTxt();
                            SingletestInfo.Text = "Liczba jedynek: "+result.SingleBitTestResult.NumberOfOneBits.ToString();

                            if(result.SingleBitTestResult.TestPassed)
                            {
                                SingleTestResult.Text = positive;
                                SingleTestResult.Foreground = Brushes.Green;
                            }else
                            {
                                SingleTestResult.Text = negative;
                                SingleTestResult.Foreground = Brushes.Red;
                            }
                            

                            var oneArray = result.SeriesTestResult.SeriesOneArray;
                            var seriesOne = String.Format("1:{0}, 2:{1}, 3:{2}, 4:{3}, 5:{4}, 6:{5}",
                                oneArray[0], oneArray[1], oneArray[2], oneArray[3], oneArray[4], oneArray[5]);

                            var zeroArray = result.SeriesTestResult.SeriesZeroArray;
                            var seriesZero = String.Format("1:{0}, 2:{1}, 3:{2}, 4:{3}, 5:{4}, 6:{5}",
                                zeroArray[0], zeroArray[1], zeroArray[2], zeroArray[3], zeroArray[4], zeroArray[5]);

                            SeriesOnesText.Text ="Seria jedynek: " +seriesOne;
                            SeriesZerosText.Text = "Seria zer: "+seriesZero;
                            if(result.SeriesTestResult.TestPassed)
                            {
                                SeriesResultText.Text = positive;
                                SeriesResultText.Foreground = Brushes.Green;
                            }
                            else
                            {
                                SeriesResultText.Text = negative;
                                SeriesResultText.Foreground = Brushes.Red;

                            }


                            LongSeriesInfoText.Text ="Najdłuższa seria: "+ result.LongSeriesTestResult.LongestSeries.ToString();

                            if(result.LongSeriesTestResult.TestPassed)
                            {
                                LongSeriesResultText.Text = positive;
                                LongSeriesResultText.Foreground = Brushes.Green;
                            }
                            else
                            {
                                LongSeriesResultText.Text = negative;
                                LongSeriesResultText.Foreground = Brushes.Red;
                            }

                            PokerTestXText.Text ="Wartość X: "+ result.PokerTestResult.Result.ToString();
                            
                            if(result.PokerTestResult.TestPassed)
                            {
                                PokerTestResultText.Text = positive;
                                PokerTestResultText.Foreground = Brushes.Green;
                            }
                            else
                            {
                                PokerTestResultText.Text = negative;
                                PokerTestResultText.Foreground = Brushes.Red;
                            }


                        }

                        break;

                    case 1:
                        {
                            var result = StartTestWithBin();
                            SingletestInfo.Text = "Liczba jedynek: " + result.SingleBitTestResult.NumberOfOneBits.ToString();

                            if (result.SingleBitTestResult.TestPassed)
                            {
                                SingleTestResult.Text = positive;
                                SingleTestResult.Foreground = Brushes.Green;
                            }
                            else
                            {
                                SingleTestResult.Text = negative;
                                SingleTestResult.Foreground = Brushes.Red;
                            }


                            var oneArray = result.SeriesTestResult.SeriesOneArray;
                            var seriesOne = String.Format("1:{0}, 2:{1}, 3:{2}, 4:{3}, 5:{4}, 6:{5}",
                                oneArray[0], oneArray[1], oneArray[2], oneArray[3], oneArray[4], oneArray[5]);

                            var zeroArray = result.SeriesTestResult.SeriesZeroArray;
                            var seriesZero = String.Format("1:{0}, 2:{1}, 3:{2}, 4:{3}, 5:{4}, 6:{5}",
                                zeroArray[0], zeroArray[1], zeroArray[2], zeroArray[3], zeroArray[4], zeroArray[5]);

                            SeriesOnesText.Text = "Seria jedynek: " + seriesOne;
                            SeriesZerosText.Text += "Seria zer: " + seriesZero;
                            if (result.SeriesTestResult.TestPassed)
                            {
                                SeriesResultText.Text = positive;
                                SeriesResultText.Foreground = Brushes.Green;
                            }
                            else
                            {
                                SeriesResultText.Text = negative;
                                SeriesResultText.Foreground = Brushes.Red;

                            }


                            LongSeriesInfoText.Text = "Najdłuższa seria: " + result.LongSeriesTestResult.LongestSeries.ToString();

                            if (result.LongSeriesTestResult.TestPassed)
                            {
                                LongSeriesResultText.Text = positive;
                                LongSeriesResultText.Foreground = Brushes.Green;
                            }
                            else
                            {
                                LongSeriesResultText.Text = negative;
                                LongSeriesResultText.Foreground = Brushes.Red;
                            }

                            PokerTestXText.Text = "Wartość X: " + result.PokerTestResult.Result.ToString();

                            if (result.PokerTestResult.TestPassed)
                            {
                                PokerTestResultText.Text = positive;
                                PokerTestResultText.Foreground = Brushes.Green;
                            }
                            else
                            {
                                PokerTestResultText.Text = negative;
                                PokerTestResultText.Foreground = Brushes.Red;
                            }
                        }
                    break;

                    default:
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Niepoprawny format pliku");
                return;
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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                var input = ReadTxtFile(openFileDialog.FileName);
                if (input.Length != 20000)
                {
                    input = input.Substring(0, 20000);
                }

                if(input.Length<20000)
                {
                    throw new ArgumentException("Długość pliku musi wynosić conajmniej 20000 znaków");
                }


                foreach (var item in input.ToCharArray())
                {
                    if (item != '1' && item != '0')
                    {
                        throw new IOException("Wczytany plik zawiera znaki różne od '0' i '1'");
                    }
                }
                FipsResult fipsResult = new FipsResult()
                {
                    SingleBitTestResult = fips.SingleBitTest(input),
                    SeriesTestResult = fips.SeriesTest(input),
                    LongSeriesTestResult = fips.LongSeriesTests(input),
                    PokerTestResult = fips.PokerTest(input)
                };


                return fipsResult;

            }

            throw new Exception("Nie wybrano pliku");
        }


        private FipsResult StartTestWithBin()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                byte[] input = ReadBinFile(openFileDialog.FileName);
                if (input.Length != 2500)
                {
                    input = input.Take(2500).ToArray();
                }

                if (input.Length < 2500)
                {
                    throw new ArgumentException("Długość pliku musi wynosić conajmniej 2500 bajtów (20000 bitów)");
                }

                FipsResult fipsResult = new FipsResult()
                {
                    SingleBitTestResult = fips.SingleBitTest(input),
                    SeriesTestResult = fips.SeriesTest(input),
                    LongSeriesTestResult = fips.LongSeriesTests(input),
                    PokerTestResult = fips.PokerTest(input)
                };


                return fipsResult;

            }

            throw new Exception("Nie wybrano pliku");
        }




        private string ReadTxtFile(string path)
        {
            string text = File.ReadAllText(path);

            return text;
        }

        private byte[] ReadBinFile(string path)
        {
            var bytes = File.ReadAllBytes(path);

            return bytes;
        }



    }
}

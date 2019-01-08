﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CryptoDesktopApplication.Backend
{
    public class Lfsr
    {
        public bool OutputBit { get; set; }
        public static Dictionary<int, int[]> GenerateFeedbackFunctions()
        {
            Dictionary<int, int[]> dictionary = new Dictionary<int, int[]>();

            for (int length = 2; length <= 64; length++)
            {
                switch (length)
                {
                    case 2:
                        dictionary.Add(length, new int[] {0, length - 1});
                        break;
                    case 3:
                        dictionary.Add(length, new int[] { 0, length - 1 });
                        break;
                    case 4:
                        dictionary.Add(length, new int[] { 0, length - 1 });
                        break;
                    case 5:
                        dictionary.Add(length, new int[] { 1, length - 1 });
                        break;
                    case 6:
                        dictionary.Add(length, new int[] { 0, length - 1 });
                        break;
                    case 7:
                        dictionary.Add(length, new int[] { 0, length - 1 });
                        break;
                    case 8:
                        dictionary.Add(length, new int[] { 3,4,5,7 });
                        break;
                    case 9:
                        dictionary.Add(length, new int[] { 4,8 });
                        break;
                    case 10:
                        dictionary.Add(length, new int[] { 6,9 });
                        break;
                    case 11:
                        dictionary.Add(length, new int[] { 8,10 });
                        break;
                    case 12:
                        dictionary.Add(length, new int[] { 3,9,10,11 });
                        break;
                    case 13:
                        dictionary.Add(length, new int[] { 7,10,11,12 });
                        break;
                    case 14:
                        dictionary.Add(length, new int[] { 1,11,12,13 });
                        break;
                    case 15:
                        dictionary.Add(length, new int[] {13,14});
                        break;
                    case 16:
                        dictionary.Add(length, new int[] {3,12,14,15});
                        break;
                    case 17:
                        dictionary.Add(length, new int[] { 13,16 });
                        break;
                    case 18:
                        dictionary.Add(length, new int[] { 10,17 });
                        break;
                    case 19:
                        dictionary.Add(length, new int[] {13,16,17,18 });
                        break;
                    case 20:
                        dictionary.Add(length, new int[] { 16,19 });
                        break;
                    case 21:
                        dictionary.Add(length, new int[] { 18,20 });
                        break;
                    case 22:
                        dictionary.Add(length, new int[] { 20,21 });
                        break;
                    case 23:
                        dictionary.Add(length, new int[] { 17,22 });
                        break;
                    case 24:
                        dictionary.Add(length, new int[] {16,21,22,23 });
                        break;
                    case 25:
                        dictionary.Add(length, new int[] { 21,24 });
                        break;
                    case 26:
                        dictionary.Add(length, new int[] { 0,1,5,25 });
                        break;
                    case 27:
                        dictionary.Add(length, new int[] { 0,1,4,26 });
                        break;
                    case 28:
                        dictionary.Add(length, new int[] { 24,27 });
                        break;
                    case 29:
                        dictionary.Add(length, new int[] { 26,28 });
                        break;
                    case 30:
                        dictionary.Add(length, new int[] { 0,3,5,29 });
                        break;
                    case 31:
                        dictionary.Add(length, new int[] { 27,30 });
                        break;
                    case 32:
                        dictionary.Add(length, new int[] { 0,1,21,31 });
                        break;
                }
            }

            return dictionary;
        }

        public BitArray Register { get; private set; }
        public int[] FeedbackFunction { get; set; }
        int length;

        //polynomial string examples: 0,3,4,6; 1,3,6,7,8; 0,5;
        public void SetFeedbackFunction(string polynomialString)
        {
            if (String.IsNullOrEmpty(polynomialString))
            {
                FeedbackFunction = new int[]{0};
            }
            else
            {
                var values = polynomialString.Split(',');

                int[] function = new int[values.Length];
                for (int i = 0; i < function.Length; i++)
                {
                    function[i] = int.Parse(values[i]);
                }

                FeedbackFunction = function;
            }

        }

        public override string ToString()
        {
            char[] result = new char[Register.Length];

            for (int i = 0; i < Register.Length; i++)
            {
                result[i] = Register[i] ? '1' : '0';
            }

            return new string(result);
        }

        public void UpdateOutputBit()
        {
            this.OutputBit = Register[Register.Length - 1];
        }

        public Lfsr()
        {
            Register = new BitArray(8);
            length = 8;
            Random rng = new Random();

            for (int i = 0; i < length; i++)
            {
                Register[i] = rng.Next(0, 2) > 0;

            }

            FeedbackFunctionInit();
            OutputBit = Register[Register.Length - 1];
        }

        public Lfsr(int length)
        {
            Register = new BitArray(length);
            this.length = length;
            Random rng = new Random();

            for (int i = 0; i < length; i++)
            {
                Register[i] = rng.Next(0, 2) > 0;

            }

            FeedbackFunctionInit();
            OutputBit = Register[Register.Length - 1];
        }

        public Lfsr(string registerValues)
        {
            this.length = registerValues.Length;
            Register = new BitArray(length);

            for (int i = 0; i < length; i++)
            {
                Register[i] = registerValues[i] == '1' ? true : false;

            }

            FeedbackFunctionInit();
            OutputBit = Register[Register.Length - 1];
        }

        public void SetRegisterValues(BitArray array)
        {
            Register = new BitArray(array.Length);
            length = array.Length;
            for (int i = 0; i < length; i++)
            {
                Register[i] = array[i];
            }

            FeedbackFunctionInit();
        }

        public void NextStep()
        {
            OutputBit = Register[Register.Length - 1];
            bool temp = false;

            for (int i = 0; i < FeedbackFunction.Length; i++)
            {
                temp ^= Register[FeedbackFunction[i]];
            }

            temp &= true;

            for (int i = Register.Length - 1; i > 0; i--)
            {
                Register[i] = Register[i - 1];
            }


            Register[0] = temp;


        }
        public bool GetOutputBit()
        {
            return OutputBit;
        }

        private void FeedbackFunctionInit()
        {
            switch (length)
            {
                case 2:
                    FeedbackFunction= new int[] { 0, length - 1 };
                    break;
                case 3:
                    FeedbackFunction = new int[] { 0, length - 1 };
                    break;
                case 4:
                    FeedbackFunction = new int[] { 0, length - 1 };
                    break;
                case 5:
                    FeedbackFunction = new int[] { 1, length - 1 };
                    break;
                case 6:
                    FeedbackFunction = new int[] { 0, length - 1 };
                    break;
                case 7:
                    FeedbackFunction = new int[] { 0, length - 1 };
                    break;
                case 8:
                    FeedbackFunction = new int[] { 3, 4, 5, 7 };
                    break;
                case 9:
                    FeedbackFunction = new int[] { 4, 8 };
                    break;
                case 10:
                    FeedbackFunction = new int[] { 6, 9 };
                    break;
                case 11:
                    FeedbackFunction = new int[] { 8, 10 };
                    break;
                case 12:
                    FeedbackFunction = new int[] { 3, 9, 10, 11 };
                    break;
                case 13:
                    FeedbackFunction = new int[] { 7, 10, 11, 12 };
                    break;
                case 14:
                    FeedbackFunction = new int[] { 1, 11, 12, 13 };
                    break;
                case 15:
                    FeedbackFunction = new int[] { 13, 14 };
                    break;
                case 16:
                    FeedbackFunction = new int[] { 3, 12, 14, 15 };
                    break;
                case 17:
                    FeedbackFunction = new int[] { 13, 16 };
                    break;
                case 18:
                    FeedbackFunction = new int[] { 10, 17 };
                    break;
                case 19:
                    FeedbackFunction = new int[] { 13, 16, 17, 18 };
                    break;
                case 20:
                    FeedbackFunction = new int[] { 16, 19 };
                    break;
                case 21:
                    FeedbackFunction = new int[] { 18, 20 };
                    break;
                case 22:
                    FeedbackFunction = new int[] { 20, 21 };
                    break;
                case 23:
                    FeedbackFunction = new int[] { 17, 22 };
                    break;
                case 24:
                    FeedbackFunction = new int[] { 16, 21, 22, 23 };
                    break;
                case 25:
                    FeedbackFunction = new int[] { 21, 24 };
                    break;
                case 26:
                    FeedbackFunction = new int[] { 0, 1, 5, 25 };
                    break;
                case 27:
                    FeedbackFunction = new int[] { 0, 1, 4, 26 };
                    break;
                case 28:
                    FeedbackFunction = new int[] { 24, 27 };
                    break;
                case 29:
                    FeedbackFunction = new int[] { 26, 28 };
                    break;
                case 30:
                    FeedbackFunction = new int[] { 0, 3, 5, 29 };
                    break;
                case 31:
                    FeedbackFunction = new int[] { 27, 30 };
                    break;
                case 32:
                    FeedbackFunction = new int[] { 0, 1, 21, 31 };
                    break;

                default:
                    break;
            }
        }

    }
}

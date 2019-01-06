using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoDesktopApplication
{
    public class Helpers
    {

        public static byte[] StringToByteArrayFastest(string hex)
        {
            hex = hex.ToUpper();

            if (hex.Length % 2 == 1)
            {
                throw new Exception("Napis heksadecymalny musi zawierać parzystą liczbę znaków!");
            }
            byte[] arr = new byte[hex.Length >> 1];

            for (int i = 0; i < hex.Length >> 1; ++i)
            {
                arr[i] = (byte)((GetHexVal(hex[i << 1]) << 4) + (GetHexVal(hex[(i << 1) + 1])));
            }

            return arr;
        }

        public static int GetHexVal(char hex)
        {
            int val = (int)hex;
            //For uppercase A-F letters:
            return val - (val < 58 ? 48 : 55);
            //For lowercase a-f letters:
            //return val - (val < 58 ? 48 : 87);
            //Or the two combined, but a bit slower:
            //return val - (val < 58 ? 48 : (val < 97 ? 55 : 87));
        }

        public static byte[] BinaryStringToBytes(string input)
        {
            if (input.Length % 8 != 0)
            {
                int padding = 8 - input.Length % 8;
                char[] zeros = new char[padding];
                for (int i = 0; i < zeros.Length; i++)
                {
                    zeros[i] = '0';
                }
                string begin = new string(zeros);

                input = string.Join(begin, input);
            }

            int numOfBytes = input.Length / 8;
            byte[] bytes = new byte[numOfBytes];
            for (int i = 0; i < numOfBytes; ++i)
            {
                bytes[i] = Convert.ToByte(input.Substring(8 * i, 8), 2);
            }

            return bytes;
        }

    }
}

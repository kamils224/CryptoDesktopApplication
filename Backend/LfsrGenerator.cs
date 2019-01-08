using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoDesktopApplication.Backend
{
    public class LfsrGenerator : IGenerators
    {

        public Lfsr[] Registers { get; set; }
        public uint Period { get; private set; }

        public LfsrGenerator()
        {
            Registers = new Lfsr[1];
        }

        public LfsrGenerator(Lfsr[] registers)
        {
            this.Registers = registers;
        }

        public void ChangeRegister(Lfsr register, int registerIndex)
        {
            if (registerIndex > Registers.Length - 1)
            {
                throw new ArgumentException("Niepoprawny indeks rejestru!");
            }
            else
            {
                Registers[registerIndex] = register;
            }

            Registers[registerIndex].UpdateOutputBit();
        }

        protected virtual bool GenerateOneBit()
        {
            NextStep();
            bool bit = Registers[0].GetOutputBit();
            return bit;
        }
        protected virtual void NextStep()
        {
            for (int i = 0; i < Registers.Length; i++)
            {
                Registers[i].NextStep();
            }
        }

        public virtual bool[] GenerateAsBool(int length)
        {
            bool[] result = new bool[length * 8];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = GenerateOneBit();
            }

            return result;
        }

        public virtual byte[] GenerateBytes(int length)
        {
            bool[] result = new bool[length * 8];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = GenerateOneBit();
            }

            return SeriesConverter.BoolToByteArray(result);
        }

        public virtual Int32[] GenerateIntegers(int length)
        {
            bool[] result = new bool[length * 32];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = GenerateOneBit();
            }

            return SeriesConverter.BoolToInt32(result);
        }
        public virtual char[] GenerateBitsAsChars(int length)
        {
            char[] result = new char[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = SeriesConverter.BoolToChar(GenerateOneBit());
            }

            return result;
        }
        //period check

        public virtual byte[] GenerateBytesWithPeriodCheck(int length, Lfsr seed)
        {
            uint counter = 0;
            uint period = 0;
            var initialRegister = new BitArray(seed.Register);

            bool[] result = new bool[length * 8];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = GenerateOneBit();
                counter++;

                if (initialRegister.Equals(this.Registers[0]))
                {
                    period = counter;
                }
                this.Period = period;
            }


            return SeriesConverter.BoolToByteArray(result);
        }
        public virtual char[] GenerateBitsAsCharsWithPeriodCheck(int length,Lfsr seed)
        {
            uint counter = 0;
            uint period = 0;
            bool periodFound = false;
            var initialRegister = new BitArray(seed.Register);
            char[] result = new char[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = SeriesConverter.BoolToChar(GenerateOneBit());
                counter++;

                if (CompareBitArrays(initialRegister,this.Registers[0].Register))
                {
                    period = counter;
                    counter = 0;
                    periodFound = true;
                }
            }
            if (periodFound)
            {
                this.Period = period;
            }
            else
            {
                this.Period = counter;
            }
            
            return result;
        }

        private bool CompareBitArrays(BitArray a1, BitArray a2)
        {
            if(a1.Length == a2.Length)
            {
                for (int i = 0; i < a2.Length; i++)
                {
                    if (a1[i] != a2[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
    }
}

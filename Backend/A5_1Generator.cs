using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using CryptoDesktopApplication.Fips;

namespace CryptoDesktopApplication.Backend
{
    public class A5_1Generator : LfsrGenerator
    {
        public readonly int NumberOfRegisters = 3;

        public A5_1Generator()
        {
            Registers = new Lfsr[3];

            Registers[0]=new Lfsr(19,true);
            Registers[1]=new Lfsr(22, true);
            Registers[2]=new Lfsr(23, true);

        }

        protected override void NextStep()
        {

            bool[] outputs = new bool[3];
            byte ones = 0;
            bool clockOne = false;

            outputs[0] = Registers[0].Register[8];
            outputs[1] = Registers[1].Register[10];
            outputs[2] = Registers[2].Register[10];
            for (int i = 0; i < 3; i++)
            {
                if (outputs[i])
                {
                    ones++;
                } 
            }
            if (ones > 1)
            {
                clockOne = true;
            }

            for (int i = 0; i < 3; i++)
            {
                if (clockOne == outputs[i])
                {
                    Registers[i].NextStep();
                }
            }
        }

        protected override bool GenerateOneBit()
        {
            NextStep();
            var bit1 = Registers[0].GetOutputBit();
            var bit2 = Registers[1].GetOutputBit();
            var bit3 = Registers[2].GetOutputBit();

            return bit1 ^ bit2 ^ bit3;
        }

    }
}

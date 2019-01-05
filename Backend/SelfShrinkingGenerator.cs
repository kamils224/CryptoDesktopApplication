using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoDesktopApplication.Backend
{
    public class SelfShrinkingGenerator : LfsrGenerator
    {
        public readonly int NumberOfRegisters = 1;


        public SelfShrinkingGenerator()
        {
            Registers = new Lfsr[1] { new Lfsr() };
        }

        public SelfShrinkingGenerator(Lfsr[] register)
        {
            if (register.Length != NumberOfRegisters)
            {
                throw new ArgumentException("Ten generator musi mieć  1 rejestr!");
            }

            Registers = register;
        }


        protected override bool GenerateOneBit()
        {
            Registers[0].NextStep();
            var value1 = Registers[0].GetOutputBit();
            Registers[0].NextStep();
            var value2 = Registers[0].GetOutputBit();

            int breakValue = 1000;
            int counter = 0;

            while (counter<breakValue)
            {
                if (value1)
                {
                    return value2;
                }
                else
                {
                    Registers[0].NextStep();
                    value1 = Registers[0].GetOutputBit();
                    Registers[0].NextStep();
                    value2 = Registers[0].GetOutputBit();
                }
                counter++;
            }

            throw new Exception("Nie znaleziono bitu '1', zmień wartości w rejestrze!");

        }

        protected override void NextStep()
        {
            return;
        }
    }
}

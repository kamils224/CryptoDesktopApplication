using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoDesktopApplication.Backend
{
    public interface IGenerators
    {
        byte[] GenerateBytes(int length);
        char[] GenerateBitsAsChars(int length);
    }
}

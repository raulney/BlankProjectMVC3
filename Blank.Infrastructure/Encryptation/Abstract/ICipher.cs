using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blank.Infrastructure.Encryptation.Abstract
{
    public interface ICipher
    {
        string Encrypt(string plainText);
        string Decrypt(string cipherText);
    }
}

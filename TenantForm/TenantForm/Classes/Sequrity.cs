using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace TenantForm.Classes
{
    // Zdravko ---> Don't touch this!!! 
    public class Sequrity
    {
        public static string Hashing(string raw)
        {
            byte[] solution = ASCIIEncoding.ASCII.GetBytes(raw);
            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider(); // hash

            byte[] product = sha.ComputeHash(solution);

            return ASCIIEncoding.ASCII.GetString(product);
        }
    }
}

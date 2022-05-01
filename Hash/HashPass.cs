
using System.Security.Cryptography;
using System.Text;



namespace ComputerStoreWebApi.Hash
{
    public class HashPass
    {
        public string Hash(string input)
        {
            StringBuilder Sb = new StringBuilder();
            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(input));
                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }
            return Sb.ToString();
        }
        }
    }


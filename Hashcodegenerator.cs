using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Diagnostics;
using RestSharp;

namespace learnagainplsbeconsistent
{
    class Hashcodegenerator
    {
        public static void Main()
        {
            int numHashes = 1000; // changes the amount of unique ids generated
            string path = @"C:\Users\customer\OneDrive\Desktop\hashcodes.txt"; // Can modify to your preferred location

            using (StreamWriter writer = new StreamWriter(path, append: false)) // can change the false to true if you don't want the file to get overwriten each time.
            {
                for (int i = 0; i < numHashes; i++)
                {
                    string randomString = Guid.NewGuid().ToString(); //Random input
                    string hash = ComputeSHA1(randomString);
                    writer.WriteLine(hash);
                }
            }

            Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });

            Console.Read();
        }

        static string ComputeSHA1(string input)
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha1.ComputeHash(bytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}

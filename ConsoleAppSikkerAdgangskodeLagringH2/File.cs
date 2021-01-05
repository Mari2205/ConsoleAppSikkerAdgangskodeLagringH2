using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleAppSikkerAdgangskodeLagringH2
{
    class File
    {
        public void WriteToFile(string[] HashAndSalt)
        {
            StreamWriter writer = new StreamWriter(@"PasswordAndSalt.txt");

            foreach (string item in HashAndSalt)
            {
                writer.WriteLine(item);
            }
            writer.Close();
        }

        public string[] ReadFromFile()
        {
            StreamReader reader = new StreamReader(@"PasswordAndSalt.txt");

            string[] hash = new string[2];

            for (int i = 0; i < 2; i++)
            {
                hash[i] = reader.ReadLine();
            }
            reader.Close();

            return hash;
        }
    }
}

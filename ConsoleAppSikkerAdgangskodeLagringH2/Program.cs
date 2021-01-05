using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSikkerAdgangskodeLagringH2
{
    class Program
    {
        static void Main(string[] args)
        {
            File file = new File();
            Gui gui = new Gui();

            string[] choicesForTheUser = { "Create Login", "Login"};


            gui.SetMenuHeading();
            gui.SetMenuBody(choicesForTheUser);
            byte[] salt = Hash.GenerateSalt();

            int usrNo = Convert.ToInt32(Console.ReadLine());
            switch (usrNo)
            {
                case 1:
                    Console.WriteLine("Original Password:");
                    string originalPassword = Console.ReadLine();


                    string[] hashToFile = new string[2];
                    byte[] md5HashedPassword = Hash.HashPasswordWhitPBKDF2(Encoding.UTF8.GetBytes(originalPassword), salt, 10000);

                    hashToFile[0] = Convert.ToBase64String(md5HashedPassword);
                    hashToFile[1] = Convert.ToBase64String(salt);

                    file.WriteToFile(hashToFile);
                    break;
                case 2:
                    Console.WriteLine("Original Password:");
                    originalPassword = Console.ReadLine();

                    string[] hashFromFile = file.ReadFromFile();
                    byte[] saltChek = Encoding.ASCII.GetBytes(hashFromFile[0]);

                    byte[] md5HashedTest = Hash.HashPasswordWhitPBKDF2(Encoding.UTF8.GetBytes(originalPassword),saltChek, 10000);

                    Console.WriteLine("TP : " + Convert.ToBase64String(md5HashedTest));
                    Console.WriteLine("OP : " + hashFromFile[0]);

                    if (Convert.ToBase64String(md5HashedTest) == hashFromFile[0])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Welcome");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR");
                        Console.ResetColor();
                    }

                    break;
                default:

                    break;
            }

            Console.ReadKey(); 
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSikkerAdgangskodeLagringH2
{
    class Gui
    {
        public void SetMenuHeading()
        {
            string acsiiMenu = @"                
$$$$$$\$$$$\   $$$$$$\  $$$$$$$\  $$\   $$\ 
$$  _$$  _$$\ $$  __$$\ $$  __$$\ $$ |  $$ |
$$ / $$ / $$ |$$$$$$$$ |$$ |  $$ |$$ |  $$ |
$$ | $$ | $$ |$$   ____|$$ |  $$ |$$ |  $$ |
$$ | $$ | $$ |\$$$$$$$\ $$ |  $$ |\$$$$$$  |
\__| \__| \__| \_______|\__|  \__| \______/                                            
";

            Console.WriteLine(acsiiMenu);
        }
        public void SetMenuBody(string[] listOfChoices)
        {
            int numbering = 1;
            foreach (string choices in listOfChoices)
            {
                Console.WriteLine(numbering + ") " + choices.ToString());
                numbering++;
            }
        }


    }
}

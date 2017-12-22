using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuLibrary
{
    class Example
    {
        private void Main()
        {
            string[] stringsMainMenu = { "Выбор 1", "Выход" };

            ConsoleMenu mainMenu = new ConsoleMenu(stringsMainMenu);
            int mainMenuResult;
            do
            {
                mainMenuResult = mainMenu.PrintMenu();
                mainMenuResult++;
                
                switch (mainMenuResult)
                {
                    case 1:break;
                }
            } while (mainMenuResult != stringsMainMenu.Length);
        }
    }
}

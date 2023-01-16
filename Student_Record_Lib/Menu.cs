using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Record_Lib
{
    public class Menu
    {

        public void start()
        {
            Console.Clear();
            functions functions = new functions();
            box box = new box();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(25, 3);
            Console.WriteLine("Student Record Application");
            box.drawRectangle();

            box.contentofthemainmenu();

            int choice = functions.getInput();
            functions.performAction(choice);

            Console.ReadKey();
        }
    }
}

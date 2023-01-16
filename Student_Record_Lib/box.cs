using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Record_Lib
{
    public class box
    {
        public void drawRectangle()
        {
            int i;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("\u2554");
            for (i = 1; i < 78; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.WriteLine("\u2550");
            }
            Console.SetCursorPosition(78, 0);
            Console.WriteLine("\u2557");
            for (i = 1; i < 25; i++)
            {
                Console.SetCursorPosition(78, i);

                Console.WriteLine("\u2551");

            }
            Console.SetCursorPosition(78, 25);
            Console.WriteLine("\u255d");
            for (i = 77; i > 0; i--)
            {
                Console.SetCursorPosition(i, 25);

                Console.WriteLine("\u2550");

            }
            Console.SetCursorPosition(0, 25);
            Console.WriteLine("\u255A");
            for (i = 24; i > 0; i--)
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine("║");
            }


            for (i = 1; i < 78; i++)
            {
                Console.SetCursorPosition(i, 6);
                Console.WriteLine("\u2550");
            }

            for (i = 7; i < 25; i++)
            {
                Console.SetCursorPosition(35, i);
                Console.WriteLine("║");
            }
 

        }

        public void contentofthemainmenu()
        {
            Console.SetCursorPosition(3, 10);
            Console.WriteLine("1.Add Student");
            Console.SetCursorPosition(3, 11);
            Console.WriteLine("2.Search Student");
            Console.SetCursorPosition(3, 12);
            Console.WriteLine("3.Modify Student Record");
            Console.SetCursorPosition(3, 13);
            Console.WriteLine("4.Generate Marksheet");
            Console.SetCursorPosition(3, 14);
            Console.WriteLine("5.Delete Student Record");
            Console.SetCursorPosition(3, 15);
            Console.WriteLine("6.Delete Dat File");
            Console.SetCursorPosition(3, 16);
            Console.WriteLine("7.About");
            Console.SetCursorPosition(3, 17);
            Console.WriteLine("8.Exit");
        }
        public void marksheet()
        {
            int i;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("\u2554");
            for (i = 1; i < 78; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.WriteLine("\u2550");
            }
            Console.SetCursorPosition(78, 0);
            Console.WriteLine("\u2557");
            for (i = 1; i < 25; i++)
            {
                Console.SetCursorPosition(78, i);

                Console.WriteLine("\u2551");

            }
            Console.SetCursorPosition(78, 25);
            Console.WriteLine("\u255d");
            for (i = 77; i > 0; i--)
            {
                Console.SetCursorPosition(i, 25);

                Console.WriteLine("\u2550");

            }
            Console.SetCursorPosition(0, 25);
            Console.WriteLine("\u255A");
            for (i = 24; i > 0; i--)
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine("║");
            }

        }
    }
}

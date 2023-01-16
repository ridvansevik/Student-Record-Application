using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Record_Lib
{
    public class functions
    {
        
        Menu menu = new Menu();
        Student student = new Student();
        public int getInput()
        {

            int choice = -1;
            while (choice < 1 || choice > 8)
            {
                Console.SetCursorPosition(3, 20);
                Console.WriteLine("Enter your choice : ");
                Console.SetCursorPosition(23, 20);
                choice = Convert.ToInt32(Console.ReadLine());
            }
            return choice;
        }
        public void performAction(int choice)
        {
            switch (choice)
            {
                case 1:
                    addstudent();
                    break;
                case 2:
                    searchstudent();
                    break;
                case 3:
                    modifystudentrecord();
                    break;
                case 4:
                    generatemarksheet();
                    break;
                case 5:
                    deletestudentrecord();
                    break;
                case 6:
                    deletedatfile();
                    break;
                case 7:
                    about();
                    break;
                case 8:
                    Environment.Exit(0);
                    break;
            }
        }
        public void addstudent()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string filename = Path.Combine(path, "student.dat");



            Console.SetCursorPosition(43, 9);
            Console.WriteLine("Id : ");
            Console.SetCursorPosition(48, 9);
            student.Id = Convert.ToInt32(Console.ReadLine());

            Console.SetCursorPosition(43, 11);
            Console.WriteLine("Name : ");
            Console.SetCursorPosition(50, 11);
            student.Name = Console.ReadLine();

            Console.SetCursorPosition(43, 13);
            Console.WriteLine("Address : ");
            Console.SetCursorPosition(53, 13);
            student.Address = Console.ReadLine();

            Console.SetCursorPosition(43, 15);
            Console.WriteLine("Parent's Name : ");
            Console.SetCursorPosition(59, 15);
            student.Parentsname = Console.ReadLine();

            Console.SetCursorPosition(43, 17);
            Console.WriteLine("Class : ");
            Console.SetCursorPosition(51, 17);
            student.Class = Console.ReadLine();

            Console.SetCursorPosition(43, 19);
            Console.WriteLine("Phone Number : ");
            Console.SetCursorPosition(58, 19);
            student.Phonenumber = Console.ReadLine();


            byte[] studentBytes = Student.StudentToByteArrayBlock(student);
            FileUtility.AppendBlock(studentBytes, filename);

            Console.Clear();
            Console.SetCursorPosition(15, 15);
            Console.WriteLine("Succesfully added");
            Console.ReadKey(true);
            menu.start();

        }
        public void searchstudent()
        {
            int i = 1;
            Console.SetCursorPosition(43, 9);
            Console.WriteLine("Enter Id To Search : ");
            Console.SetCursorPosition(67, 9);
            int search = Convert.ToInt32(Console.ReadLine());

            //if()
            //Console.SetCursorPosition(43 , 11);
            //Console.WriteLine("");

            using (StreamReader streamreader = new StreamReader(File.Open("student.dat", FileMode.Open)))
            {
                string myfile = streamreader.ReadLine();
                streamreader.Close();
                do
                {
                    string path = AppDomain.CurrentDomain.BaseDirectory;
                    string filename = Path.Combine(path, "student.dat");

                    byte[] studentWrittenBytes = FileUtility.ReadBlock(i, Student.STUDENT_DATA_BLOCK_SIZE, filename);
                    Student studentWrittenObject = Student.ByteArrayBlockToStudent(studentWrittenBytes);

                    if (studentWrittenObject != null && studentWrittenObject.Id.Equals(search))
                    {
                        Console.SetCursorPosition(43, 11);
                        Console.WriteLine("Id : " + studentWrittenObject.Id);
                        Console.SetCursorPosition(43, 12);
                        Console.WriteLine("Name : " + studentWrittenObject.Name);
                        Console.SetCursorPosition(43, 13);
                        Console.WriteLine("Address : " + studentWrittenObject.Address);
                        Console.SetCursorPosition(43, 14);
                        Console.WriteLine("Parents Name : " + studentWrittenObject.Parentsname);
                        Console.SetCursorPosition(43, 15);
                        Console.WriteLine("Class : " + studentWrittenObject.Class);
                        Console.SetCursorPosition(43, 16);
                        Console.WriteLine("Phone Number : " + studentWrittenObject.Phonenumber);
                    }
                    i++;

                } while (i < ((myfile.Length / Student.STUDENT_DATA_BLOCK_SIZE) + 1));
                Console.ReadKey(true);
                menu.start();
            }
        }
        public void modifystudentrecord()
        {
            Console.SetCursorPosition(43, 7);
            Console.WriteLine("Enter Id To Modify : ");
            Console.SetCursorPosition(67, 7);
            int choice = Convert.ToInt32(Console.ReadLine());

            string path = AppDomain.CurrentDomain.BaseDirectory;
            string filename = Path.Combine(path, "student.dat");

            Console.SetCursorPosition(43, 9);
            Console.WriteLine("Id : ");
            Console.SetCursorPosition(48, 9);
            student.Id = Convert.ToInt32(Console.ReadLine());

            Console.SetCursorPosition(43, 11);
            Console.WriteLine("Name : ");
            Console.SetCursorPosition(50, 11);
            student.Name = Console.ReadLine();

            Console.SetCursorPosition(43, 13);
            Console.WriteLine("Address : ");
            Console.SetCursorPosition(53, 13);
            student.Address = Console.ReadLine();

            Console.SetCursorPosition(43, 15);
            Console.WriteLine("Parent's Name : ");
            Console.SetCursorPosition(59, 15);
            student.Parentsname = Console.ReadLine();

            Console.SetCursorPosition(43, 17);
            Console.WriteLine("Class : ");
            Console.SetCursorPosition(51, 17);
            student.Class = Console.ReadLine();

            Console.SetCursorPosition(43, 19);
            Console.WriteLine("Phone Number : ");
            Console.SetCursorPosition(58, 19);
            student.Phonenumber = Console.ReadLine();

            byte[] studentBytes = Student.StudentToByteArrayBlock(student);
            FileUtility.UpdateBlock(studentBytes, choice, Student.STUDENT_DATA_BLOCK_SIZE, filename);

            Console.Clear();
            Console.SetCursorPosition(15, 15);
            Console.WriteLine("Succesfully modified");
            Console.ReadKey(true);
            menu.start();
        }
        public void deletestudentrecord()
        {


            Console.SetCursorPosition(43, 7);
            Console.WriteLine("Enter The Number Of Student You Want To Delete : ");
            Console.SetCursorPosition(67, 7);
            int booknumber = Convert.ToInt32(Console.ReadLine());

            string path = AppDomain.CurrentDomain.BaseDirectory;
            string filename = Path.Combine(path, "student.dat");

            FileUtility.DeleteBlock(booknumber, Student.STUDENT_DATA_BLOCK_SIZE, filename);
            menu.start();
        }
        public void deletedatfile()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string filename = Path.Combine(path, "student.dat");
            if (File.Exists(filename))
            {
                FileUtility.DeleteFile(filename);
                Console.SetCursorPosition(43, 9);
                Console.WriteLine("Successfully deleted");
                Console.ReadKey(true);
            }
            else
            {
                Console.SetCursorPosition(43, 9);
                Console.WriteLine("Couldn't found any dat file");
                Console.ReadKey(true);
            }
            menu.start();
        }
        public void generatemarksheet()
        {
            int i = 1;
            box Box = new box();
            Console.Clear();
            Box.marksheet();
            int sira = 2;
            using (StreamReader streamreader = new StreamReader(File.Open("student.dat", FileMode.Open)))
            {
                string myfile = streamreader.ReadLine();
                streamreader.Close();
                do
                {
                    string path = AppDomain.CurrentDomain.BaseDirectory;
                    string filename = Path.Combine(path, "student.dat");

                    byte[] studentWrittenBytes = FileUtility.ReadBlock(i, Student.STUDENT_DATA_BLOCK_SIZE, filename);
                    Student studentWrittenObject = Student.ByteArrayBlockToStudent(studentWrittenBytes);

                    if (studentWrittenObject != null)
                    {
                        Console.SetCursorPosition(3, sira);
                        Console.WriteLine("Student Number : " + i);
                        Console.SetCursorPosition(3, sira+1);
                        Console.WriteLine("Id : " + studentWrittenObject.Id);
                        Console.SetCursorPosition(25, sira+1);
                        Console.WriteLine("Name : " + studentWrittenObject.Name);
                        Console.SetCursorPosition(3, sira+2);
                        Console.WriteLine("Address : " + studentWrittenObject.Address);
                        Console.SetCursorPosition(25, sira+2);
                        Console.WriteLine("Parents Name : " + studentWrittenObject.Parentsname);
                        Console.SetCursorPosition(3, sira+3);
                        Console.WriteLine("Class : " + studentWrittenObject.Class);
                        Console.SetCursorPosition(25, sira+3);
                        Console.WriteLine("Phone Number : " + studentWrittenObject.Phonenumber);
                    }
                    i++;
                    sira = sira+6;

                } while (i < ((myfile.Length / Student.STUDENT_DATA_BLOCK_SIZE) + 1));
                Console.ReadKey(true);
                menu.start();
            }
        }
        public void about()
        {
            Console.SetCursorPosition(43, 10);
            Console.WriteLine("easy");
            Console.SetCursorPosition(43, 11);
            Console.WriteLine("Ridvan Sevik");
            Console.SetCursorPosition(43, 12);
            Console.WriteLine("https://github.com/ridvansevik");
            Console.ReadKey(true);
            menu.start();
        }
    }
}

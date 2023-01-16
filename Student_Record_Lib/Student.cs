using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Record_Lib
{
    public class Student
    {

        #region Public Constants
        public const int ID_LENGTH = 4;
        public const int NAME_MAX_LENGTH = 50;
        public const int ADDRESS_MAX_LENGTH = 50;
        public const int PARENTS_NAME_MAX_LENGTH = 50;
        public const int CLASS_MAX_LENGTH = 10;
        public const int PHONE_NUMBER_MAX_LENGTH = 40;

        public const int STUDENT_DATA_BLOCK_SIZE = ID_LENGTH +
                                                NAME_MAX_LENGTH +
                                                ADDRESS_MAX_LENGTH +
                                                PARENTS_NAME_MAX_LENGTH +
                                                CLASS_MAX_LENGTH +
                                                PHONE_NUMBER_MAX_LENGTH;
        #endregion

        #region Private Fields
        private int _id;
        private string _name;
        private string _address;
        private string _parentsname;
        private string _class;
        private string _phonenumber;

        #endregion

        #region Public Properties
        public int Id { get { return _id; } set { _id = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string Address { get { return _address; } set { _address = value; } }
        public string Parentsname { get { return _parentsname; } set { _parentsname = value; } }
        public string Class { get { return _class; } set { _class = value; } }
        public string Phonenumber { get { return _phonenumber; } set { _phonenumber = value; } }

        #endregion

        #region Utility Methods
        public static byte[] StudentToByteArrayBlock(Student student)
        {
            int index = 0;

            byte[] dataBuffer = new byte[STUDENT_DATA_BLOCK_SIZE];

            #region copy student id
            byte[] idBytes = ConversionUtility.IntegerToByteArray(student.Id);
            Array.Copy(idBytes, 0, dataBuffer, index, idBytes.Length);
            index += Student.ID_LENGTH;
            #endregion

            #region copy student name
            byte[] nameBytes = ConversionUtility.StringToByteArray(student.Name);
            Array.Copy(nameBytes, 0, dataBuffer, index, nameBytes.Length);
            index += Student.NAME_MAX_LENGTH;
            #endregion

            #region copy student address
            byte[] addressBytes = ConversionUtility.StringToByteArray(student.Address);
            Array.Copy(addressBytes, 0, dataBuffer, index, addressBytes.Length);
            index += Student.ADDRESS_MAX_LENGTH;
            #endregion

            #region copy student parents name
            byte[] parentsnameBytes = ConversionUtility.StringToByteArray(student.Parentsname);
            Array.Copy(parentsnameBytes, 0, dataBuffer, index, parentsnameBytes.Length);
            index += Student.PARENTS_NAME_MAX_LENGTH;
            #endregion

            #region copy student class
            byte[] classBytes = ConversionUtility.StringToByteArray(student.Class);
            Array.Copy(classBytes, 0, dataBuffer, index, classBytes.Length);
            index += Student.CLASS_MAX_LENGTH;
            #endregion

            #region copy student phone number
            byte[] phonenumberBytes = ConversionUtility.StringToByteArray(student.Phonenumber);
            Array.Copy(phonenumberBytes, 0, dataBuffer, index, phonenumberBytes.Length);
            index += Student.PHONE_NUMBER_MAX_LENGTH;
            #endregion


            #endregion

            if (index != dataBuffer.Length)
            {
                throw new ArgumentException("Index and DataBuffer Size Not Matched");
            }

            return dataBuffer;
        }

        public static Student ByteArrayBlockToStudent(byte[] byteArray)
        {

            Student student = new Student();

            if (byteArray.Length != STUDENT_DATA_BLOCK_SIZE)
            {
                throw new ArgumentException("Byte Array Size Not Match with Constant Data Block Size");
            }

            int index = 0;

            //byte[] dataBuffer = new byte[BOOK_DATA_BLOCK_SIZE];

            #region copy student id
            byte[] idBytes = new byte[Student.ID_LENGTH];
            Array.Copy(byteArray, index, idBytes, 0, idBytes.Length);
            student.Id = ConversionUtility.ByteArrayToInteger(idBytes);

            index += Student.ID_LENGTH;
            #endregion

            #region copy student name
            byte[] nameBytes = new byte[Student.NAME_MAX_LENGTH];
            Array.Copy(byteArray, index, nameBytes, 0, nameBytes.Length);
            student.Name = ConversionUtility.ByteArrayToString(nameBytes);

            index += Student.NAME_MAX_LENGTH;
            #endregion

            #region copy student address
            byte[] addressBytes = new byte[Student.ADDRESS_MAX_LENGTH];
            Array.Copy(byteArray, index, addressBytes, 0, addressBytes.Length);
            student.Address = ConversionUtility.ByteArrayToString(addressBytes);

            index += Student.ADDRESS_MAX_LENGTH;
            #endregion

            #region copy student parents name
            byte[] parentsnameBytes = new byte[Student.PARENTS_NAME_MAX_LENGTH];
            Array.Copy(byteArray, index, parentsnameBytes, 0, parentsnameBytes.Length);
            student.Parentsname = ConversionUtility.ByteArrayToString(parentsnameBytes);

            index += Student.PARENTS_NAME_MAX_LENGTH;
            #endregion

            #region copy student class
            byte[] classBytes = new byte[Student.CLASS_MAX_LENGTH];
            Array.Copy(byteArray, index, classBytes, 0, classBytes.Length);
            student.Class = ConversionUtility.ByteArrayToString(classBytes);

            index += Student.CLASS_MAX_LENGTH;
            #endregion

            #region copy student phone number
            byte[] phonenumberBytes = new byte[Student.PHONE_NUMBER_MAX_LENGTH];
            Array.Copy(byteArray, index, phonenumberBytes, 0, phonenumberBytes.Length);
            student.Phonenumber = ConversionUtility.ByteArrayToString(phonenumberBytes);

            index += Student.PHONE_NUMBER_MAX_LENGTH;
            #endregion



            if (index != byteArray.Length)
            {
                throw new ArgumentException("Index and DataBuffer Size Not Matched");
            }

            if (student.Id == 0)
            {
                return null;
            }
            else
            {
                return student;
            }

        }

    }
}

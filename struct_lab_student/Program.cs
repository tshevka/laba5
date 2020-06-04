using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;


namespace struct_lab_student
{
    struct Student
    {
        public string surName;
        public string firstName;
        public string patronymic;
        public char sex;
        public string dateOfBirth;
        public char mathematicsMark;
        public char physicsMark;
        public char informaticsMark;
        public int scholarship;
    }
    class Students
    {
        List<Student> students;
        string filename;
        public Students(string file)
        {
            if (!File.Exists(file))
            {
                throw new FileNotFoundException();
            }
            filename = file;
            students = new List<Student>();
            LoadFile();
        }
        private void LoadFile()
        {
            string[] words = File.ReadAllText(@filename).Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                students.Add(new Student
                {
                    surName = words[i++],
                    firstName = words[i++],
                    patronymic = words[i++],
                    sex = Convert.ToChar(words[i++]),
                    dateOfBirth = words[i++],
                    mathematicsMark = Convert.ToChar(words[i++]),
                    physicsMark = Convert.ToChar(words[i++]),
                    informaticsMark = Convert.ToChar(words[i++]),
                    scholarship = Convert.ToInt16(words[i++])
                });
            }
        }
        public void runMenu()
        {
            students = students.ToList();
            foreach (Student st in students)
            {
                double bal = (Convert.ToInt32(Convert.ToString(st.physicsMark)) + Convert.ToInt32(Convert.ToString(st.informaticsMark)) + Convert.ToInt32(Convert.ToString(st.mathematicsMark))) / 3.0;
                if (Convert.ToInt32(st.physicsMark) == '5')
                {
                    Console.WriteLine("Студент, що має 5 з фізики  - {0} {1}, середнiй бал студента {2}, стипендія - {3}", Convert.ToString(st.firstName), Convert.ToString(st.patronymic), string.Format("{0:0.##}", bal), Convert.ToString(st.scholarship));

                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Students st = new Students("input.txt");
            st.runMenu();

            Console.ReadKey();
        }
    }
}

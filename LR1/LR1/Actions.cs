<<<<<<< HEAD
﻿
using Grades_Creator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base;

namespace Actions

{
    class Functions
    {
        static Dictionary<string, (int capacity, List<(int id, string name, List<Grade> Grades)> students)> courses = Program.courses;
        static int studentIdCounter = Program.studentIdCounter;
        

        static public void AddCourse()
        {
            Console.Write("Введите название курса: ");
            string name = Console.ReadLine();
            Console.Write("Кол-во студентов: ");
            int capacity = int.Parse(Console.ReadLine());
            courses[name] = (capacity, new List<(int id, string name,List<Grade>) > ());
            Console.WriteLine("Курс был добавлен.");
        }

        static public void ViewCourse()
        {
            Console.Write("Название курса: ");
            string name = Console.ReadLine();
            if (courses.TryGetValue(name, out var course))
                Console.WriteLine($"Курс: {name}, Кол-во студентов: {course.capacity}, Студентов: {course.students.Count}");
            else
                throw new Exception("Курс не найден.");
        }

        static public void DeleteCourse()
        {
            Console.Write("Название курса: ");
            string name = Console.ReadLine();
            if (courses.Remove(name))
                Console.WriteLine("Курс удален.");
            else
                throw new Exception("Курс не найден.");
        }

        static public void EnrollStudent()
        {
            Console.Write("Название курса: ");
            string name = Console.ReadLine();
            Console.Write("Имя студента: ");
            string studentName = Console.ReadLine();
            if (courses.TryGetValue(name, out var course) && course.students.Count < course.capacity)
            {
                course.students.Add((studentIdCounter++, studentName,[]));
                Console.WriteLine("Студент записан.");
            }
            else
                throw new Exception("Курс не найден или нет мест.");
        }

        static public void ViewStudents()
        {
            Console.Write("Название курса: ");
            string name = Console.ReadLine();
            if (courses.TryGetValue(name, out var course))
            {
                Console.WriteLine($"Студенты на курсе {name}:");
                foreach (var student in course.students)
                    Console.WriteLine($"ID: {student.id}, Имя: {student.name}");
            }
            else
                throw new Exception("Курс не найден.");
        }

        static public void RemoveStudent()
        {
            Console.Write("Название курса: ");
            string name = Console.ReadLine();
            Console.Write("ID студента: ");

            if (int.TryParse(Console.ReadLine(), out int studentId))
            {
                if (courses.TryGetValue(name, out var course))
                {
                    var student = course.students.Find(s => s.id == studentId);
                    if (student != default)
                    {
                        course.students.Remove(student);
                        Console.WriteLine("Студент был удален.");
                    }
                    else
                    {
                        throw new Exception("Студент не был найден.");
                    }
                }
                else
                {
                    throw new Exception("Курс не был найден.");
                }
            }
            else
            {
                throw new Exception("Неверный ID студента.");
            }
        }

        static public void addGrades()
        {
            Console.Write("Название курса: ");
            string name = Console.ReadLine();
            //Console.Write("Имя студента: ");
            //string studentName = Console.ReadLine();
            if (courses.TryGetValue(name, out var course) && course.students.Count < course.capacity)
            {
                Console.WriteLine(course.students[2]);
                Console.WriteLine("Студент записан.");
            }
            else
                throw new Exception("Курс не найден или нет мест.");
        }

        static public void showGrades()
        {
            
        }
    }

}
=======
﻿using Enum_Subject;
using Grades_Creator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base;

namespace Actions

{
    class Functions
    {
        static Dictionary<string, (int capacity, List<(int id, string name)> students)> courses = Program.courses;
        static int studentIdCounter = Program.studentIdCounter;
        static List<Grade> Grades = Program.Grades;

        static public void AddCourse()
        {
            Console.Write("Введите название курса: ");
            string name = Console.ReadLine();
            Console.Write("Кол-во студентов: ");
            int capacity = int.Parse(Console.ReadLine());
            courses[name] = (capacity, new List<(int id, string name)>());
            Console.WriteLine("Курс был добавлен.");
        }

        static public void ViewCourse()
        {
            Console.Write("Название курса: ");
            string name = Console.ReadLine();
            if (courses.TryGetValue(name, out var course))
                Console.WriteLine($"Курс: {name}, Кол-во студентов: {course.capacity}, Студентов: {course.students.Count}");
            else
                throw new Exception("Курс не найден.");
        }

        static public void DeleteCourse()
        {
            Console.Write("Название курса: ");
            string name = Console.ReadLine();
            if (courses.Remove(name))
                Console.WriteLine("Курс удален.");
            else
                throw new Exception("Курс не найден.");
        }

        static public void EnrollStudent()
        {
            Console.Write("Название курса: ");
            string name = Console.ReadLine();
            Console.Write("Имя студента: ");
            string studentName = Console.ReadLine();
            if (courses.TryGetValue(name, out var course) && course.students.Count < course.capacity)
            {
                course.students.Add((studentIdCounter++, studentName));
                Console.WriteLine("Студент записан.");
            }
            else
                throw new Exception("Курс не найден или нет мест.");
        }

        static public void ViewStudents()
        {
            Console.Write("Название курса: ");
            string name = Console.ReadLine();
            if (courses.TryGetValue(name, out var course))
            {
                Console.WriteLine($"Студенты на курсе {name}:");
                foreach (var student in course.students)
                    Console.WriteLine($"ID: {student.id}, Имя: {student.name}");
            }
            else
                throw new Exception("Курс не найден.");
        }

        static public void RemoveStudent()
        {
            Console.Write("Название курса: ");
            string name = Console.ReadLine();
            Console.Write("ID студента: ");

            if (int.TryParse(Console.ReadLine(), out int studentId))
            {
                if (courses.TryGetValue(name, out var course))
                {
                    var student = course.students.Find(s => s.id == studentId);
                    if (student != default)
                    {
                        course.students.Remove(student);
                        Console.WriteLine("Студент был удален.");
                    }
                    else
                    {
                        throw new Exception("Студент не был найден.");
                    }
                }
                else
                {
                    throw new Exception("Курс не был найден.");
                }
            }
            else
            {
                throw new Exception("Неверный ID студента.");
            }
        }

        static public void addGrades()
        {
            Grades.Add(new Grade(Subject.Chemestry, 5, DateTime.Parse("2025-05-10")));
            Grades.Add(new Grade(Subject.Math, 3, DateTime.Parse("2025-05-12")));
            Grades.Add(new Grade(Subject.History, 5, DateTime.Parse("2025-05-01")));
            Grades.Add(new Grade(Subject.Biology, 4, DateTime.Parse("2025-05-11")));
        }

        static public void showGrades()
        {
            foreach (Grade i in Grades)
            {
                Console.Write($"{i} \n");
            }
        }
    }
    
}
>>>>>>> c59f26120e21339f454fe3f8b89b7d34945767e6

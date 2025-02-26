using EducationSystem;
using EducationSystem_Elements;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EducationSystem_Actions;

public class Actions
{
    static Dictionary<string, Course> courses = EducationSystem.Program.courses;
    public static int studentIdCounter = 1;
    public static string path = "../../../../data.txt"; 
    public static void AddCourse()
    {
        Console.Write("Название курса: ");
        string name = Console.ReadLine();
        Console.Write("Вместимость: ");
        if (int.TryParse(Console.ReadLine(), out int capacity))
        {
            var course = new Course(name, capacity);
            course.StudentAdded += Course_StudentAdded; // Подписываемся на событие
            courses[name] = course;
            Console.WriteLine("Курс добавлен.");
        }
        else
        {
            Console.WriteLine("Неверная вместимость.");
        }
    }

    public static void ViewCourse()
    {
        Console.Write("Название курса: ");
        string name = Console.ReadLine();
        if (courses.TryGetValue(name, out var course))
            Console.WriteLine($"Курс: {name}, Вместимость: {course.Capacity}, Студентов: {course.Students.Count}");
        else
            throw new Exception("Курс не найден.");
    }

    public static void DeleteCourse()
    {
        Console.Write("Название курса: ");
        string name = Console.ReadLine();
        if (courses.Remove(name))
            Console.WriteLine("Курс удален.");
        else
            throw new Exception("Курс не найден.");
    }

    public static void EnrollStudent()
    {
        Console.Write("Название курса: ");
        string name = Console.ReadLine();
        Console.Write("Имя студента: ");
        string studentName = Console.ReadLine();
        if (courses.TryGetValue(name, out var course))
        {
            var student = new Student(studentIdCounter++, studentName);
            course.AddStudent(student);
            Console.WriteLine("Студент записан.");
        }
        else
            throw new Exception("Курс не найден.");
    }

    public static void ViewStudents()
    {
        Console.Write("Название курса: ");
        string name = Console.ReadLine();
        if (courses.TryGetValue(name, out var course))
        {
            Console.WriteLine($"Студенты на курсе {name}:");
            foreach (var student in course.Students)
                Console.WriteLine($"ID: {student.Id}, Имя: {student.Name}");
        }
        else
            throw new Exception("Курс не найден.");
    }

    public static void RemoveStudent()
    {
        Console.Write("Название курса: ");
        string name = Console.ReadLine();
        Console.Write("ID студента: ");
        if (int.TryParse(Console.ReadLine(), out int studentId))
        {
            if (courses.TryGetValue(name, out var course))
            {
                var student = course.Students.FirstOrDefault(s => s.Id == studentId);
                if (student != null)
                {
                    course.Students.Remove(student);
                    Console.WriteLine("Студент удален.");
                }
                else
                {
                    throw new Exception("Студент не найден.");
                }
            }
            else
            {
                throw new Exception("Курс не найден.");
            }
        }
        else
        {
            throw new Exception("Неверный ID студента.");
        }
    }

    public static void AddGrade()
    {
        Console.Write("Название курса: ");
        string name = Console.ReadLine();
        Console.Write("ID студента: ");
        if (int.TryParse(Console.ReadLine(), out int studentId))
        {
            if (courses.TryGetValue(name, out var course))
            {
                var student = course.Students.FirstOrDefault(s => s.Id == studentId);
                if (student != null)
                {
                    Console.WriteLine("Выберите предмет:");
                    var subjects = Enum.GetValues(typeof(Subject));
                    for (int i = 0; i < subjects.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. {subjects.GetValue(i)}");
                    }

                    Console.Write("Номер предмета: ");
                    if (int.TryParse(Console.ReadLine(), out int subjectIndex) && subjectIndex >= 1 && subjectIndex <= subjects.Length)
                    {
                        var subject = (Subject)subjects.GetValue(subjectIndex - 1);
                        Console.Write("Оценка: ");
                        if (int.TryParse(Console.ReadLine(), out int score))
                        {
                            student.Grades.Add(new Grade(subject, score));
                            Console.WriteLine("Оценка добавлена.");
                        }
                        else
                        {
                            Console.WriteLine("Неверная оценка.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверный номер предмета.");
                    }
                }
                else
                {
                    Console.WriteLine("Студент не найден.");
                }
            }
            else
            {
                Console.WriteLine("Курс не найден.");
            }
        }
        else
        {
            Console.WriteLine("Неверный ID студента.");
        }
    }

    public static void RemoveGrade()
    {
        Console.Write("Название курса: ");
        string name = Console.ReadLine();
        Console.Write("ID студента: ");
        if (int.TryParse(Console.ReadLine(), out int studentId))
        {
            if (courses.TryGetValue(name, out var course))
            {
                var student = course.Students.FirstOrDefault(s => s.Id == studentId);
                if (student != null)
                {
                    Console.WriteLine("Выберите предмет:");
                    var subjects = Enum.GetValues(typeof(Subject));
                    for (int i = 0; i < subjects.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. {subjects.GetValue(i)}");
                    }

                    Console.Write("Номер предмета: ");
                    if (int.TryParse(Console.ReadLine(), out int subjectIndex) && subjectIndex >= 1 && subjectIndex <= subjects.Length)
                    {
                        var subject = (Subject)subjects.GetValue(subjectIndex - 1);
                        var grade = student.Grades.FirstOrDefault(g => g.Subject == subject);
                        if (grade != null)
                        {
                            student.Grades.Remove(grade);
                            Console.WriteLine("Оценка удалена.");
                        }
                        else
                        {
                            Console.WriteLine("Оценка не найдена.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверный номер предмета.");
                    }
                }
                else
                {
                    Console.WriteLine("Студент не найден.");
                }
            }
            else
            {
                Console.WriteLine("Курс не найден.");
            }
        }
        else
        {
            Console.WriteLine("Неверный ID студента.");
        }
    }

    public static void ShowGrades()
    {
        Console.Write("Название курса: ");
        string name = Console.ReadLine();
        Console.Write("ID студента: ");
        if (int.TryParse(Console.ReadLine(), out int studentId))
        {
            if (courses.TryGetValue(name, out var course))
            {
                var student = course.Students.FirstOrDefault(s => s.Id == studentId);
                if (student != null)
                {
                    Console.WriteLine($"Оценки студента {student.Name}:");
                    foreach (var grade in student.Grades)
                    {
                        Console.WriteLine($"Предмет: {grade.Subject}, Оценка: {grade.Score}, Дата: {grade.Date}");
                    }
                }
                else
                {
                    Console.WriteLine("Студент не найден.");
                }
            }
            else
            {
                Console.WriteLine("Курс не найден.");
            }
        }
        else
        {
            Console.WriteLine("Неверный ID студента.");
        }
    }

    public static void Course_StudentAdded(object sender, Student student)
    {
        Console.WriteLine($"Студент {student.Name} добавлен на курс {(sender as Course).Name}.");
    }

    async public static void SaveData()
    {
        using (StreamWriter writer = new StreamWriter(path, true))
        {
            await writer.WriteLineAsync("Addition");
            await writer.WriteAsync("4,5");

            //Console.WriteLine(courses);

            //var student = course.Students.FirstOrDefault(s => s.Id == studentId);
            //if (student != null)
            //        {
            //            Console.WriteLine($"Оценки студента {student.Name}:");
            //            foreach (var grade in student.Grades)
            //            {
            //                Console.WriteLine($"Предмет: {grade.Subject}, Оценка: {grade.Score}, Дата: {grade.Date}");
            //            }
            //        }
            //else
            //        {
            //            Console.WriteLine("Студент не найден.");
            //        }
            //    }

            

        }
    }
} 
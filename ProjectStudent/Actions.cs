using EducationSystem;
using EducationSystem_Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSystem_Actions;

public class Actions
{
    public static int studentIdCounter = 1;
    public static int gradeIdCounter = 1;
    public static List<Student> students= new()  ; 

    public static void EnrollStudent()
    {
        Console.Write("Имя студента: ");
        string studentName = Console.ReadLine();
        var student = new Student(studentIdCounter++,studentName);
        students.Add(student);
            Console.WriteLine("Студент записан.");
    }

    public static void ViewStudents()
    {
        foreach (var student in students)
            Console.WriteLine($"ID: {student.Id}, Имя: {student.Name}");
    }

    public static void RemoveStudent()
    {
        Console.Write("ID студента: ");
        if (int.TryParse(Console.ReadLine(), out int studentId))
        {
            
            var student = students.FirstOrDefault(s => s.Id == studentId);
                if (student != null)
                {
                    students.Remove(student);
                    Console.WriteLine("Студент удален.");
                }
                else
                {
                    throw new Exception("Студент не найден.");
                }          
        }
        else
        {
            throw new Exception("Неверный ID студента.");
        }
    }

    public static void AddGrade()
    {
        
        Console.Write("ID студента: ");
        if (int.TryParse(Console.ReadLine(), out int studentId))
        {
                var student = students.FirstOrDefault(s => s.Id == studentId);
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
                        //Random rnd = new Random();
                        //int grateId = rnd.Next(1, 9999);
                        Console.Write("Оценка: ");
                        if (int.TryParse(Console.ReadLine(), out int score))
                        {
                            student.Grades.Add(new Grade(gradeIdCounter++,subject, score));
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
            Console.WriteLine("Неверный ID студента.");
        }
    }

    public static void RemoveGrade()
    {
        
        Console.Write("ID студента: ");
        if (int.TryParse(Console.ReadLine(), out int studentId))
        {
            
                var student = students.FirstOrDefault(s => s.Id == studentId);
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
            Console.WriteLine("Неверный ID студента.");
        }
    }

    public static void ShowGrades()
    {
        
        Console.Write("ID студента: ");
        if (int.TryParse(Console.ReadLine(), out int studentId))
        {
            
                var student = students.FirstOrDefault(s => s.Id == studentId);
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
            Console.WriteLine("Неверный ID студента.");
        }
    }

}


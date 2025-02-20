////========Газизов Семён========\\

using System;
using System.Collections.Generic;
using Grades_Creator;
using Enum_Subject;
using Actions;

namespace Base;
class Program : Actions.Functions
{

    public static Dictionary<string, (int capacity, List<(int id, string name)> students)> courses = new();
    public static int studentIdCounter = 1;
    public static List<Grade> Grades = new();

    static void Main()
    {

        while (true)
        {
            Console.WriteLine("1. Добавить курс");
            Console.WriteLine("2. Посмотреть студентов выбранного курса");
            Console.WriteLine("3. Удалить курс");
            Console.WriteLine("4. Записать студента на курс");
            Console.WriteLine("5. Показать студентов");
            Console.WriteLine("6. Удалить студента");
            Console.WriteLine("8. Поставить оценку");
            Console.WriteLine("9. Выход");
            Console.Write("Выберите опцию: ");

            string choice = Console.ReadLine();
            

            try
            {
                switch (choice)
                {
                    case "1": AddCourse(); break;
                    case "2": ViewCourse(); break;
                    case "3": DeleteCourse(); break;
                    case "4": EnrollStudent(); break;
                    case "5": ViewStudents(); break;
                    case "6": RemoveStudent(); break;
                    case "7": addGrades(); break;
                    case "8": showGrades();
                    case "9": return;
                    default: Console.WriteLine("Вы ввели неверное число."); break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }

}






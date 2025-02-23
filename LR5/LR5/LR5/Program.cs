////========Газизов Семён========\\

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EducationSystem_Elements;
using EducationSystem_Actions;

namespace EducationSystem
{

    class Program : Actions
    {
        public static Dictionary<string, Course> courses = new();
        static void Main()
        {     
            foreach (var course in courses.Values)
            {
                course.StudentAdded += Course_StudentAdded;
            }

            while (true)
            {
                Console.WriteLine("Меню:\n1. Добавить курс\n2. Посмотреть курс\n3. Удалить курс\n" +
                    "4. Записать студента\n5. Показать студентов\n6. Удалить студента\n" +
                    "7. Добавить оценку\n8. Удалить оценку\n9. Показать оценки\n" +
                    "10. Выход\n");
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
                        case "7": AddGrade(); break;
                        case "8": RemoveGrade(); break;
                        case "9": ShowGrades(); break;
                        case "10": return;
                        default: Console.WriteLine("Неверный выбор."); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }

       
    }
}
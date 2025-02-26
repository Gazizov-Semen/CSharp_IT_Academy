using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EducationSystem_Elements;
using EducationSystem_Actions;  // предположительно, там должны быть какие-то действия
using static System.Formats.Asn1.AsnWriter;

namespace EducationSystem
{
    class Program : Actions
    {
        public static Dictionary<string, Course> courses = new();
        private static EducationSystemService educationService = new();

        static void Main()
        {
            // Инициализация базы данных
            using (var context = new EducationContext())
            {
                context.InitializeDatabase();
            }

            // Инициализация студентов и курсов
            //InitializeData();

            while (true)
            {
                Console.WriteLine("Меню:\n1. Добавить курс\n2. Посмотреть курс\n3. Удалить курс\n" +
                    "4. Записать студента\n5. Показать студентов\n6. Удалить студента\n" +
                    "7. Добавить оценку\n8. Удалить оценку\n9. Показать оценки\n" +
                    "10. Сохранить данные\n" + "11. Выход\n");
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
                        case "10": SaveData(); break;
                        case "11": return;

                        default: Console.WriteLine("Неверный выбор."); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }

        private static void InitializeData()
        {
            // Например, инициализация курса и студентов
            Student student1 = new(1, "Газизов Семён");
            Student student2 = new(2, "Чечиков Влад");
            Student student3 = new(3, "Лампов Кирилл");
            Student student4 = new(4, "Зайцев Василий");
            Student student5 = new(5, "Лебедев Дмитрий");
            Student student6 = new(6, "Гаргонова Саша");

            // Добавляем оценки
            AddGradeToStudent(student1, Subject.CSharp, 5);
            AddGradeToStudent(student1, Subject.Math, 4);
            AddGradeToStudent(student1, Subject.Web_Programming, 3);

            AddGradeToStudent(student2, Subject.Russian_Language, 5);
            AddGradeToStudent(student2, Subject.Math, 4);
            AddGradeToStudent(student2, Subject.Biology, 3);

            AddGradeToStudent(student3, Subject.Biology, 5);
            AddGradeToStudent(student3, Subject.CSharp, 4);
            AddGradeToStudent(student3, Subject.Russian_Language, 3);

            AddGradeToStudent(student4, Subject.Biology, 5);
            AddGradeToStudent(student4, Subject.Web_Programming, 2);
            AddGradeToStudent(student4, Subject.CSharp, 3);

            AddGradeToStudent(student5, Subject.CSharp, 5);
            AddGradeToStudent(student5, Subject.Russian_Language, 4);
            AddGradeToStudent(student5, Subject.Biology, 1);

            AddGradeToStudent(student6, Subject.Math, 5);
            AddGradeToStudent(student6, Subject.Web_Programming, 4);
            AddGradeToStudent(student6, Subject.CSharp, 3);

            Course course1 = new("ИСиТ-22", 6);
            Course course2 = new("ИПО-22", 7);

            course1.AddStudent(student1);
            course1.AddStudent(student2);
            course1.AddStudent(student3);
            course2.AddStudent(student4);
            course2.AddStudent(student5);
            course2.AddStudent(student6);

            courses.Add("ИСиТ-22", course1);
            courses.Add("ИПО-22", course2);

            foreach (var course in courses.Values)
            {
                course.StudentAdded += Course_StudentAdded;

            }
        }

        private static void AddGradeToStudent(Student student, Subject subject, int score)
        {
            student.Grades.Add(new Grade(student.Grades.Count + 1, subject, score));
            educationService.AddStudent(student.Name); // Сохраняем студента
            educationService.AddGrade(student.Id, subject, score); // Сохраняем оценку
        }

        private static void SaveData()
        {
            foreach (var course in courses.Values)
            {
                foreach (var student in course.Students)
                {
                    educationService.AddStudent(student.Name); // Сохранить студента
                    foreach (var grade in student.Grades)
                    {
                        educationService.AddGrade(student.Id, grade.Subject, grade.Score); // Сохранить оценки
                    }
                }
            }
            Console.WriteLine("Данные успешно сохранены.");
        }
    }
}
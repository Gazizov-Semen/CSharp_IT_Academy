////========Газизов Семён========\\

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EducationSystem_Elements;
using EducationSystem_Actions;
using static System.Formats.Asn1.AsnWriter;
using SaveData;
using System.Diagnostics;

namespace EducationSystem
{

    class Program : Actions
    {
        static void Main()
        {



            while (true)
            {
                Console.WriteLine("Меню:\n" +
                    "1. Записать студента\n2. Показать студентов\n3. Удалить студента\n" +
                    "4. Добавить оценку\n5. Удалить оценку\n6. Показать оценки\n" +
                    "7. Сохранить данные\n" + "8. Выход\n");
                Console.Write("Выберите опцию: ");
                string choice = Console.ReadLine();

                //try
                //{
                    switch (choice)
                    {
                        case "1": EnrollStudent(); break;
                        case "2": ViewStudents(); break;
                        case "3": RemoveStudent(); break;
                        case "4": AddGrade(); break;
                        case "5": RemoveGrade(); break;
                        case "6": ShowGrades(); break;
                        case "7": ApplicationContext.AddData(); break;
                        case "8": return;

                        default: Console.WriteLine("Неверный выбор."); break;
                    }
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine($"Ошибка: {ex.Message}");
                //}
            }
        }

        //static void Installization()
        //{
        //    Student student1 = new(1, "Газизов Семён");
        //    //Student student2 = new(2, "Чечиков Влад");
        //    //Student student3 = new(3, "Лампов Кирилл");
        //    Student student4 = new(4, "Зайцев Василий");
        //    //Student student5 = new(5, "Лебедев Дмитрий");
        //    //Student student6 = new(6, "Гаргонова Саша");

        //    student1.Grades.Add(new Grade(Subject.CSharp, 5));
        //    student1.Grades.Add(new Grade(Subject.Math, 4));
        //    student1.Grades.Add(new Grade(Subject.Web_Programing, 3));

        //    //student2.Grades.Add(new Grade(4, Subject.Russian_Language, 5));
        //    //student2.Grades.Add(new Grade(5, Subject.Math, 4));
        //    //student2.Grades.Add(new Grade(6, Subject.Biology, 3));

        //    //student3.Grades.Add(new Grade(7, Subject.Biology, 5));
        //    //student3.Grades.Add(new Grade(8, Subject.CSharp, 4));
        //    //student3.Grades.Add(new Grade(9, Subject.Russian_Language, 3));

        //    student4.Grades.Add(new Grade(Subject.Biology, 5));
        //    student4.Grades.Add(new Grade(Subject.Web_Programing, 2));
        //    student4.Grades.Add(new Grade(Subject.CSharp, 3));

        //    //student5.Grades.Add(new Grade(14, Subject.CSharp, 5));
        //    //student5.Grades.Add(new Grade(15, Subject.Russian_Language, 4));
        //    //student5.Grades.Add(new Grade(16, Subject.Biology, 1));

        //    //student6.Grades.Add(new Grade(17, Subject.Math, 5));
        //    //student6.Grades.Add(new Grade(18, Subject.Web_Programing, 4));
        //    //student6.Grades.Add(new Grade(19, Subject.CSharp, 3));

        //    Course course1 = new("ИСиТ-22", 6);
        //    Course course2 = new("ИПО-22", 7);

        //    course1.AddStudent(student1);
        //    //course1.AddStudent(student2);
        //    //course1.AddStudent(student3);
        //    course2.AddStudent(student4);
        //    //course2.AddStudent(student5);
        //    //course2.AddStudent(student6);

        //    courses.Add("ИСиТ-22", course1);
        //    courses.Add("ИПО-22", course2);
        //}


    }
}
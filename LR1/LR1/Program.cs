////========Газизов Семён========\\

using System;
using System.Collections.Generic;

class Program
{

    static Dictionary<string, (int capacity, List<(int id, string name)> students)> courses = new();
    static int studentIdCounter = 1;
    static List<Grade> Grades = new();

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
            Console.WriteLine("7. Выход");
            Console.Write("Выберите опцию: ");

            string choice = Console.ReadLine();

            addGrades();

            foreach (Grade i in Grades)
            {
                Console.Write($"{i} \n");
            }


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
                    case "7": return;
                    default: Console.WriteLine("Вы ввели неверное число."); break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }



    static void AddCourse()
    {
        Console.Write("Введите название курса: ");
        string name = Console.ReadLine();
        Console.Write("Кол-во студентов: ");
        int capacity = int.Parse(Console.ReadLine());
        courses[name] = (capacity, new List<(int id, string name)>());
        Console.WriteLine("Курс был добавлен.");
    }

    static void ViewCourse()
    {
        Console.Write("Название курса: ");
        string name = Console.ReadLine();
        if (courses.TryGetValue(name, out var course))
            Console.WriteLine($"Курс: {name}, Кол-во студентов: {course.capacity}, Студентов: {course.students.Count}");
        else
            throw new Exception("Курс не найден.");
    }

    static void DeleteCourse()
    {
        Console.Write("Название курса: ");
        string name = Console.ReadLine();
        if (courses.Remove(name))
            Console.WriteLine("Курс удален.");
        else
            throw new Exception("Курс не найден.");
    }

    static void EnrollStudent()
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

    static void ViewStudents()
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

    static void RemoveStudent()
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

    static void addGrades()
    {
        Grades.Add(new Grade(Subject.Chemestry, 5, DateTime.Parse("2025-05-10")));
        Grades.Add(new Grade(Subject.Math, 3, DateTime.Parse("2025-05-12")));
        Grades.Add(new Grade(Subject.History, 5, DateTime.Parse("2025-05-01")));
        Grades.Add(new Grade(Subject.Biology, 4, DateTime.Parse("2025-05-11")));
    }


}

public enum Subject
{
    Math,
    Physics,
    Chemestry,
    Biology,
    History
}

public class Grade
{
    static Subject Subject { get; set; }
    static int Score { get; set; }
    static DateTime Date { get; set; }

    public Grade(Subject subject, int score, DateTime date)
    {
        Subject = subject;
        Score = score;
        Date = date;
    }

    public override string ToString()
    {
        return $"{Subject}: {Score} ({Date.ToShortDateString()})";
    }

}




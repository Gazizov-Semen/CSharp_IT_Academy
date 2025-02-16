//========Газизов Семён========\\

using System;
using System.Collections.Generic;


Dictionary<string, (int capacity, List<(int id, string name)> students)> courses = new();
int studentIdCounter = 1;

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


void AddCourse()
{
    Console.Write("Введите название курса: ");
    string name = Console.ReadLine();
    Console.Write("Кол-во студентов: ");
    int capacity = int.Parse(Console.ReadLine());
    courses[name] = (capacity, new List<(int id, string name)>());
    Console.WriteLine("Курс был добавлен.");
}

void ViewCourse()
{
    Console.Write("Название курса: ");
    string name = Console.ReadLine();
    if (courses.TryGetValue(name, out var course))
        Console.WriteLine($"Курс: {name}, Кол-во студентов: {course.capacity}, Студентов: {course.students.Count}");
    else
        throw new Exception("Курс не найден.");
}
void DeleteCourse()
{
    Console.Write("Название курса: ");
    string name = Console.ReadLine();
    if (courses.Remove(name))
        Console.WriteLine("Курс удален.");
    else
        throw new Exception("Курс не найден.");
}

void EnrollStudent()
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

void ViewStudents()
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

void RemoveStudent()
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

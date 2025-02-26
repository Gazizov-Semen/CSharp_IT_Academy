using EducationSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSystem_Elements;
public enum Subject
{
    Математика,
    Физика,
    Химия,
    Информатика
}

public abstract class GradeBase
{
    public Subject Subject { get; set; }
    public DateTime Date { get; set; }

    protected GradeBase(Subject subject)
    {
        Subject = subject;
        Date = DateTime.Now;
    }
}

public class Person
{
    public int Id { get; private set; }
    public string Name { get; set; }

    public Person(int id, string name)
    {
        Id = id;
        Name = name;
    }
}

 class Course
{
    public string Name { get; private set; }
    public int Capacity { get; private set; }
    public List<Student> Students { get; private set; }

    public delegate void StudentAddedHandler(object sender, Student student);

    public event StudentAddedHandler StudentAdded;

    public Course(string name, int capacity)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Название курса не может быть пустым.");
        if (capacity <= 0)
            throw new ArgumentException("Вместимость курса должна быть положительной.");

        Name = name;
        Capacity = capacity;
        Students = new List<Student>();
    }

    public void AddStudent(Student student)
    {
        if (Students.Count < Capacity)
        {
            Students.Add(student);
            StudentAdded?.Invoke(this, student);
        }
        else
        {
            throw new Exception("Нет мест на курсе.");
        }
    }

}

public class Grade : GradeBase
{
    public int Score { get; set; }

    public Grade(Subject subject, int score) : base(subject)
    {
        if (score < 0 || score > 100)
            throw new ArgumentException("Оценка должна быть в диапазоне от 0 до 100.");

        Score = score;
    }
}



public class Student : Person
{
    public List<Grade> Grades { get; private set; }

    public Student(int id, string name) : base(id, name)
    {
        Grades = new List<Grade>();
    }
}

course1 = new Course;

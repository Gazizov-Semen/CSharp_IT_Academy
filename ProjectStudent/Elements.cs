using EducationSystem;
using EducationSystem_Elements;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EducationSystem_Elements;


public enum Subject
{
    Math,
    Biology,
    Russian_Language,
    CSharp,
    Web_Programing,
}

//public abstract class GradeBase
//{

//    public Subject Subject { get; set; }
//    public DateTime Date { get; set; }

//    protected GradeBase(Subject subject)
//    {
//        Subject = subject;
//        Date = DateTime.Now;
//    }
//}

//public class Person
//{
//    [Key]
    

//    public Person(int id, string name)
//    {
//        Id = id;
//        Name = name;
//    }
//}

public class Grade 
{
    [Key]
    public int Id { get; set; }
    public int Score { get; set; }
    public Subject Subject { get; set; }
    public DateTime Date { get; set; }

    public Grade(int id, Subject subject, int score) 
    {
        Id = id;
        Subject = subject;
        Date = DateTime.Now;
        if (score < 1 || score > 5)
            throw new ArgumentException("Оценка должна быть в диапазоне от 1 до 5.");
        Score = score;
    }
}


public class Student
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Grade> Grades { get; private set; }

    public Student(int id,string name) 
    {
        Id = id;
        Name = name;
        Grades = new List<Grade>();
    }
}

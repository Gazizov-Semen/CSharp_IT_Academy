using EducationSystem_Elements;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSystem_Elements
{
    public enum Subject
    {
        Math,
        Biology,
        Russian_Language,
        CSharp,
        Web_Programming,
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
        [Key]
        public int Id { get; private set; }
        public string Name { get; set; }

        public Person(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    public class Course
    {
        [Key]
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
        [Key]
        public int GradeId { get; set; }

        public Grade(int gradeId, Subject subject, int score) : base(subject)
        {
            if (score < 1 || score > 5)
                throw new ArgumentException("Оценка должна быть в диапазоне от 1 до 5.");
            GradeId = gradeId;
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

    // Контекст базы данных
    public class EducationContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Укажите подключение к вашей базе данных
            optionsBuilder.UseSqlite("Data Source=Database1.mdf"); // Создание базы данных helloapp.db
        }

        public void InitializeDatabase()
        {
            // Создание базы данных, если она не существует
            Database.EnsureCreated();
        }
    }

    public class EducationSystemService
    {
        public void AddStudent(string name)
        {
            using (var context = new EducationContext())
            {
                var student = new Student(context.Students.Count() + 1, name);
                context.Students.Add(student);
                context.SaveChanges();
            }
        }

        public void AddGrade(int studentId, Subject subject, int score)
        {
            using (var context = new EducationContext())
            {
                var student = context.Students.SingleOrDefault(s => s.Id == studentId);
                if (student == null)
                {
                    throw new Exception("Студент не найден.");
                }

                var grade = new Grade(context.Grades.Count() + 1, subject, score);
                student.Grades.Add(grade);
                context.SaveChanges();
            }
        }
    }
}
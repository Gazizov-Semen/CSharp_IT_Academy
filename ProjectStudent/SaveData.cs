using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using EducationSystem_Elements;
using Microsoft.EntityFrameworkCore;

namespace SaveData;

public class ApplicationContext : DbContext
{
    DbSet<Student> Students => Set<Student>();
    DbSet<Grade> Grades => Set<Grade>();
    public ApplicationContext() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=C:/Users/1207/source/repos/ProjectStudent/Database.db");
    }


    static public void AddData()
    {
        ApplicationContext db = new ApplicationContext();

        List<Student> students = EducationSystem_Actions.Actions.students;

        foreach (var student in students)
        {
            db.Students.Add(student);


            foreach (var grade in student.Grades)
            {
                db.Grades.Add(grade);
               

            }
        }

        db.SaveChanges();
        Console.WriteLine("Объекты успешно сохранены");

        //// получаем объекты из бд и выводим на консоль
        //var users = db.Users.ToList();
        //Console.WriteLine("Список объектов:");
        //foreach (User u in users)
        //{
        //    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
        //}
    }

    // создаем два объекта User

}


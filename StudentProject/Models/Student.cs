// Models/Student.cs
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace StudentProject.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Grade> Grades { get; set; } = new List<Grade>();
    }
}
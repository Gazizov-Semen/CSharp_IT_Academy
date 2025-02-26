// Models/Grade.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace StudentProject.Models
{
    public class Grade
    {
        [Key]
        public int Id { get; set; }
        public int Score { get; set; }
        public string Subject { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base;
using Enum_Subject;

namespace Grades_Creator
{
    public class Grade
    {
        Subject Subject { get; set; }
        int Score { get; set; }
        DateTime Date { get; set; }

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

}

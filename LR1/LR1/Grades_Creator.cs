<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base;


namespace Grades_Creator;
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
public enum Subject
{
    Math,
    Physics,
    Chemestry,
    Biology,
    History
}



=======
﻿using System;
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
>>>>>>> c59f26120e21339f454fe3f8b89b7d34945767e6

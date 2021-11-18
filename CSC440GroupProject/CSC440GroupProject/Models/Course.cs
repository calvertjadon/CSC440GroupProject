using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC440GroupProject.Models
{
    public class Course
    {
        public string Prefix { get; }
        public string Number { get; }
        public string Year { get; }
        public string Semester { get; }
        public int Hours { get; }

        public Course(string Prefix, string Number, string Year, string Semester, int Hours)
        {
            this.Prefix = Prefix;
            this.Number = Number;
            this.Year = Year;
            this.Semester = Semester;
            this.Hours = Hours;
        }
    }
}

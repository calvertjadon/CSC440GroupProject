using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC440GroupProject.Models
{
    public class Student
    {
        public int Id { get; }
        public string Name { get; }
        public double GPA { get; }
        public int CreditHours { get; }
        public int GradePoints { get; }

        public Student(int Id, string Name, double GPA, int CreditHours, int GradePoints)
        {
            this.Id = Id;
            this.Name = Name;
            this.GPA = GPA; 
            this.CreditHours = CreditHours;
            this.GradePoints = GradePoints;
        }
    }
}

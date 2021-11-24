using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC440GroupProject.Models
{
    [Table("calvert_student")]
    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double GPA { get; set; }
        public int CreditHours { get; set; }
        public int GradePoints { get; set; }



        // public List<Course> courses { get; set; }
        public List<Grade> grades { get; set; }
    }
}

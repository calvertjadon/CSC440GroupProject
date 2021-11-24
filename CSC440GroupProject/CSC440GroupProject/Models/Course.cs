using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC440GroupProject.Models
{
    [Table("calvert_course")]
    public class Course
    {
        public int Hours { get; set; }

        public string Prefix { get; set; }
        public string Number { get; set; }
        public string Year { get; set; }
        public string Semester { get; set; }

        public string FullCourseIdentifier => Prefix + Number;

        public override string ToString()
        {
            return $"{FullCourseIdentifier} {Semester} {Year}";
        }
    }
}

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
        public int Hours { get; }

        public string Prefix { get; }
        public string Number { get; }
        public string Year { get; }
        public string Semester { get; }

        public string FullCourseIdentifier => Prefix + Number;
    }
}

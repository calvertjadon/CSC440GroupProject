using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC440GroupProject.Models
{
    [Table("calvert_grade")]
    public class Grade
    {
        public string Letter { get; set; }

        public string CoursePrefix { get; set; }
        public string CourseNum { get; set; }
        public string StudentId { get; set; }
        public string Year { get; set; }
        public string Semester { get; set; }

        public Student student { get; set; }
        public Course course { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC440GroupProject.Models
{
    public class Grade
    {
        public string Letter { get; }
        public string CoursePrefix { get; }
        public string CourseNum { get; }
        public int StudentId { get; }
        public string Year { get; }
        public string Semester { get; }

        public Grade(string letter, string coursePrefix, string courseNum, int studentId, string year, string semester)
        {
            this.Letter = Letter;
            this.CoursePrefix = CoursePrefix;
            this.CourseNum = CourseNum;
            this.StudentId = StudentId;
            this.Year = Year;
            this.Semester = Semester;
        }
    }
}

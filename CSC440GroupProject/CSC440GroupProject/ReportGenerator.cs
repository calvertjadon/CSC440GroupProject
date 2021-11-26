using CSC440GroupProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC440GroupProject.Reports
{
    abstract class ReportGenerator
    {
        public Student SelectedStudent { get; private set; }
        public List<Grade> Grades { get; private set; }

        protected ReportGenerator(Student selectedStudent, List<Grade> grades)
        {
            SelectedStudent = selectedStudent;
            Grades = grades;
        }

        public abstract void GenerateReport();
    }
}

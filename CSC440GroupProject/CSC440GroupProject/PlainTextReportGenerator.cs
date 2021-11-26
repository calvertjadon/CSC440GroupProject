using CSC440GroupProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC440GroupProject.Reports
{
    class PlainTextReportGenerator : ReportGenerator
    {
        public PlainTextReportGenerator(Student selectedStudent, List<Grade> grades) : base(selectedStudent, grades)
        {
        }

        public override void GenerateReport()
        {
            Console.WriteLine("PLAIN TEXT: " + SelectedStudent);
        }
    }
}

using CSC440GroupProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC440GroupProject.Reports
{
    class DocxReportGenerator : ReportGenerator
    {
        public DocxReportGenerator(Student selectedStudent, List<Grade> grades) : base(selectedStudent, grades, "docx")
        {
        }

        public override void GenerateReport()
        {
            Console.WriteLine("DOCX: " + SelectedStudent);
        }
    }
}

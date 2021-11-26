using CSC440GroupProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC440GroupProject.Reports
{
    class PdfReportGenerator : ReportGenerator
    {
        public PdfReportGenerator(Student selectedStudent, List<Grade> grades) : base(selectedStudent, grades, "pdf")
        {
        }

        public override void GenerateReport()
        {
            Console.WriteLine("PDF: " + SelectedStudent);
        }
    }
}

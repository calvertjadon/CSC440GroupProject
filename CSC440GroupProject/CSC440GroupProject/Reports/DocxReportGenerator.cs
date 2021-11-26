using CSC440GroupProject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Xceed.Words.NET;

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

            var outputFilePath = getOutputPath();

            if (outputFilePath != null)
            {
                WriteOutput(outputFilePath);

                MessageBox.Show("File saved successfully");

                Process.Start("WINWORD.EXE", outputFilePath);
            }   
        }

        private void WriteOutput(string outputFilePath)
        {
            var doc = DocX.Create(outputFilePath);

            // HEADER
            var header = doc.InsertSection(true);
            header.InsertParagraph("EKU Academic Transcript")
                .FontSize(36);

            header.InsertParagraph($"{SelectedStudent.Name} (ID#: {SelectedStudent.Id})")
                .FontSize(24);

            header.InsertParagraph($"GPA: {SelectedStudent.GPA.ToString("0.00")}");

            var gradesSection = doc.InsertSection(true);

            var years = Grades.GroupBy(g => g.Year).OrderBy(y => y.Key);
            foreach (var year in years)
            {
                var yearSection = doc.InsertSection(true);
                yearSection.InsertParagraph(year.Key)
                    .FontSize(18);

                var semesters = year.GroupBy(g => g.Semester).OrderBy(s => s.Key);

                foreach (var semester in semesters)
                {
                    var semesterSection = doc.InsertSection(true);
                    semesterSection.InsertParagraph(semester.Key)
                        .FontSize(16);

                    var gradesInSemester = Grades
                        .Where(g => g.Year == year.Key && g.Semester == semester.Key)
                        .ToList();

                    foreach (var grade in gradesInSemester)
                    {
                        semesterSection.InsertParagraph($"{grade.FullCourseIdentifier} ({grade.Letter})")
                            .FontSize(12);
                    }
                }
            }


            doc.Save();
        }
    }
}

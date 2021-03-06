using CSC440GroupProject.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CSC440GroupProject.Reports
{
    class PlainTextReportGenerator : ReportGenerator
    {
        public PlainTextReportGenerator(Student selectedStudent, List<Grade> grades) : base(selectedStudent, grades, "txt")
        {
        }

        public override void GenerateReport()
        {
            var outputFilePath = getOutputPath();

            if (outputFilePath != null)
            {
                WriteOutput(outputFilePath);

                MessageBox.Show("File saved successfully");

                Process.Start("NOTEPAD.EXE", outputFilePath);
            }
        }

        private void WriteOutput(string outputFilePath)
        {
            List<string> lines = new List<string>();

            var gradesByYear = Grades
                .GroupBy(g => g.Year).OrderBy(y => y.Key);

            lines.Add($"{SelectedStudent.Name} ({SelectedStudent.Id})");
            lines.Add($"GPA: {SelectedStudent.GPA}");
            lines.Add("");

            foreach (var year in gradesByYear)
            {
                var gradesBySemester = year.GroupBy(y => y.Semester).OrderBy(s => s.Key);

                foreach (var semester in gradesBySemester)
                {
                    lines.Add($"{semester.Key} {year.Key}");

                    var gradesInSemester = Grades.Where(g => g.Year == year.Key && g.Semester == semester.Key).ToList();
                    foreach (var grade in gradesInSemester)
                    {
                        lines.Add($"{grade.FullCourseIdentifier}\t{grade.Letter}");
                    }

                    lines.Add("");
                }
            }

            File.WriteAllLines(outputFilePath, lines);
        }
    }
}

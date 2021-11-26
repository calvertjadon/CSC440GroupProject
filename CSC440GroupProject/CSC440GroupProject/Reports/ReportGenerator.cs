using CSC440GroupProject.Models;
using Microsoft.Win32;
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
        public static string FILE_EXTENSION { get; private set; }

        protected ReportGenerator(Student selectedStudent, List<Grade> grades, string fileExtension)
        {
            SelectedStudent = selectedStudent;
            Grades = grades;
            FILE_EXTENSION = fileExtension;
        }

        public abstract void GenerateReport();

        protected string getOutputPath()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = FILE_EXTENSION;
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            saveFileDialog.Filter = $"{FILE_EXTENSION.ToUpper()} | *.{FILE_EXTENSION}";
            saveFileDialog.FileName = $"Transcript_{SelectedStudent.Name.Replace(" ", "")}{SelectedStudent.Id}";

            var result = saveFileDialog.ShowDialog();
            if (result == true)
            {
                return saveFileDialog.FileName;
            }
            else
            {
                return null;
            }
        }
    }
}

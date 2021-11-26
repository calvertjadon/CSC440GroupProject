using CSC440GroupProject.Models;
using ExcelDataReader;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;

namespace CSC440GroupProject.ViewModels
{
    class ImportRecordsViewModel : ViewModelBase
    {
        public ICommand OpenFileCommand { get; set; }

        public ImportRecordsViewModel()
        {
            OpenFileCommand = new BaseCommand(ImportRecords);
        }

        private void ImportRecords(object _)
        {
            try
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result.Equals(DialogResult.OK))
                {
                    Console.WriteLine(folderBrowserDialog.SelectedPath);

                    DirectoryInfo d = new DirectoryInfo(folderBrowserDialog.SelectedPath);

                    foreach (var file in d.GetFiles("*.xlsx"))
                    {
                        var words = Path.GetFileNameWithoutExtension(file.Name).Split(' ');
                        string coursePrefix = words[0];
                        string courseNum = words[1];
                        string year = words[2];
                        string semester = words[3];

                        Course newCourse = new Course()
                        {
                            Prefix = coursePrefix,
                            Number = courseNum,
                            Year = year,
                            Semester = semester,
                            Hours = 3
                        };

                        AddCourseIfNotExists(newCourse);

                        using (var stream = file.OpenRead())
                        {
                            using (var reader = ExcelReaderFactory.CreateReader(stream))
                            {
                                do
                                {
                                    // Skip headers
                                    reader.Read();

                                    while (reader.Read())
                                    {
                                        string studentName = reader.GetString(0);
                                        string studentId = reader.GetDouble(1).ToString();
                                        string gradeLetter = reader.GetString(2);

                                        Console.WriteLine($"{studentName} {studentId} {gradeLetter}");

                                        Student newStudent = new Student()
                                        {
                                            Name = studentName,
                                            Id = studentId
                                        };

                                        AddStudentIfNotExists(newStudent);

                                        Grade newGrade = new Grade()
                                        {
                                            StudentId = studentId,
                                            CoursePrefix = coursePrefix,
                                            CourseNum = courseNum,
                                            Year = year,
                                            Semester = semester,
                                            Letter = gradeLetter
                                        };

                                        AddGradeIfNotExists(newGrade);
                                    }
                                } while (reader.NextResult());
                            }
                        }
                    }

                    MessageBox.Show("Excel files imported successfully");
                }
            }
            catch
            {
                MessageBox.Show("Failed to import Excel files");
            }

        }

        private void AddStudentIfNotExists(Student newStudent)
        {
            using (var context = new DatabaseContext())
            {
                Student existingStudent = context.Students
                    .Where(s => s.Id.Equals(newStudent.Id))
                    .FirstOrDefault();

                if (existingStudent == null)
                {
                    context.Students.Add(newStudent);
                    context.SaveChanges();
                }
            }
        }

        private void AddCourseIfNotExists(Course newCourse)
        {
            using (var context = new DatabaseContext())
            {
                Course existingCourse = context.Courses
                    .Where(c => (
                        c.Prefix.Equals(newCourse.Prefix) &&
                        c.Number.Equals(newCourse.Number) &&
                        c.Year.Equals(newCourse.Year) &&
                        c.Semester.Equals(newCourse.Semester)))
                    .FirstOrDefault();

                if (existingCourse == null)
                {
                    context.Courses.Add(newCourse);
                    context.SaveChanges();
                }
            }
        }

        private void AddGradeIfNotExists(Grade newGrade)
        {
            using (var context = new DatabaseContext())
            {
                Grade existingGrade = context.Grades
                    .Where(g => (
                        g.StudentId.Equals(newGrade.StudentId) &&
                        g.CoursePrefix.Equals(newGrade.CoursePrefix) &&
                        g.CourseNum.Equals(newGrade.CourseNum) &&
                        g.Year.Equals(newGrade.Year) &&
                        g.Semester.Equals(newGrade.Semester)))
                    .FirstOrDefault();

                if (existingGrade == null)
                {
                    context.Grades.Add(newGrade);
                    context.SaveChanges();
                }
            }
        }
    }
}

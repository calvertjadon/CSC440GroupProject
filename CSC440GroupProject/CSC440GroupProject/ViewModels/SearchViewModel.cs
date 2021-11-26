using CSC440GroupProject.Models;
using CSC440GroupProject.Reports;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CSC440GroupProject.ViewModels
{
    class SearchViewModel : ViewModelBase
    {
        public ICommand ButtonClickCommand { get; set; }
        public ICommand GenerateReportCommand { get; set; }
        public ICommand AddGradeCommand { get; set; }

        NavigationViewModel NavigationViewModel { get; set; }

        private List<Student> students;
        public List<Student> Students
        {
            get => students;

            set
            {
                students = value;
                OnPropertyChanged("Students");
            }
        }

        private Student selectedStudent;
        public Student SelectedStudent
        {
            get => selectedStudent;

            set
            {
                selectedStudent = value;
                Grades = new List<Grade>();

                if (value != null)
                {
                    using (var context = new DatabaseContext())
                    {
                        Grades = context.Grades
                            .Where(g => g.StudentId.Equals(value.Id))
                            .ToList();
                    }
                }

                OnPropertyChanged("SelectedStudent");
            }
        }


        private List<Grade> grades;
        public List<Grade> Grades
        {
            get => grades;

            set
            {
                grades = value;
                OnPropertyChanged("Grades");
            }
        }

        private Grade selectedGrade;
        public Grade SelectedGrade
        {
            get => selectedGrade;

            set
            {
                Console.WriteLine(value);
                selectedGrade = value;

                this.NavigationViewModel.SelectedViewModel = new EditGradeViewModel(value, this.NavigationViewModel);
            }
        }


        private string idInput = "";
        public string IdInput
        {
            get
            {
                return idInput;
            }
            set
            {
                idInput = new string(value.Where(c => char.IsDigit(c)).ToArray());
            }
        }

        private List<RadioClass> radio = new List<RadioClass>()
        {
            new RadioClass { Header = "Plain Text", CheckedProperty = true },
            //new RadioClass { Header = "PDF", CheckedProperty = false },
            new RadioClass { Header = "Microsoft Word", CheckedProperty = false },
        };

        public List<RadioClass> Radio
        {
            get => radio;
        }

        public SearchViewModel(NavigationViewModel navigationViewModel)
        {
            this.ButtonClickCommand = new BaseCommand(LoadStudents);
            this.GenerateReportCommand = new BaseCommand(GenerateReport);
            this.AddGradeCommand = new BaseCommand(AddGrade);

            this.NavigationViewModel = navigationViewModel;

            this.Students = new List<Student>();
            this.Grades = new List<Grade>();

            LoadStudents(null);
        }

        private void AddGrade(object _)
        {
            List<Course> Courses;
            using (var context = new DatabaseContext())
            {
                IEnumerable<Grade> Grades = context.Grades.Where(g => g.StudentId == SelectedStudent.Id);
                Courses = context.Courses.ToList();

                foreach (var grade in Grades)
                {
                    Course course = Courses.Where(c => (
                        grade.CoursePrefix == c.Prefix &&
                        grade.CourseNum == c.Number &&
                        grade.Year == c.Year &&
                        grade.Semester == c.Semester
                    )).FirstOrDefault();

                    if (course != null)
                    {
                        Courses.Remove(course);
                    }
                }
            }

            if (Courses.Count == 0)
            {
                MessageBox.Show("There are no available courses for which to add a grade.");
            } else
            {
                this.NavigationViewModel.SelectedViewModel = new AddGradeViewModel(SelectedStudent, Courses, this.NavigationViewModel);
            }

            
        }

        private void LoadStudents(object _)
        {
            SelectedStudent = null;

            using (var context = new DatabaseContext())
            {
                Students = context.Students
                    .Where(s => s.Id.Contains(IdInput))
                    .ToList();
            }
        }

        private void GenerateReport(object _)
        {
            RadioClass SelectedRadio = Radio
                .Where(r => r.CheckedProperty == true).FirstOrDefault();

            if (SelectedRadio != null && SelectedStudent != null)
            {
                ReportGenerator reportGenerator;

                switch (SelectedRadio.Header)
                {
                    case "Plain Text":
                        reportGenerator = new PlainTextReportGenerator(
                            SelectedStudent,
                            Grades
                        );
                        break;
                    case "PDF":
                        reportGenerator = new PdfReportGenerator(
                            SelectedStudent,
                            Grades
                        );
                        break;
                    case "Microsoft Word":
                        reportGenerator = new DocxReportGenerator(
                            SelectedStudent,
                            Grades
                        );
                        break;
                    default:
                        throw new Exception("Invalid Report Generator Type");
                }

                reportGenerator.GenerateReport();
            }
        }

        public class RadioClass : ViewModelBase
        {
            public string Header { get; set; }

            private bool checkedProperty;
            public bool CheckedProperty
            {
                get => checkedProperty;

                set
                {
                    checkedProperty = value;
                    OnPropertyChanged("CheckedProperty");
                }
            }

        }
    }
}

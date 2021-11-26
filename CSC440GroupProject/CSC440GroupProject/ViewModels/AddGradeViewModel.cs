using CSC440GroupProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CSC440GroupProject.ViewModels
{
    class AddGradeViewModel : ViewModelBase
    {
        public ICommand AddGradeCommand { get; set; }

        private NavigationViewModel NavigationViewModel { get; set; }

        public Student SelectedStudent { get; set; }


        private string selectedGradeLetter;
        public string SelectedGradeLetter
        {
            get => selectedGradeLetter;

            set
            {
                selectedGradeLetter = value;
                OnPropertyChanged("SelectedGradeLetter");
            }
        }

        public List<string> GradeOptions { 
            get => new List<string>()
            {
                "A",
                "B",
                "C",
                "D",
                "F"
            };
        }

        public List<Course> CourseOptions { get; set; }

        private Course selectedCourse;
        public Course SelectedCourse
        {
            get => selectedCourse;

            set
            {
                selectedCourse = value;
                OnPropertyChanged("SelectedCourse");
            }
        }

        public AddGradeViewModel(Student selectedStudent, List<Course> availableCourses, NavigationViewModel navigationViewModel)
        {
            AddGradeCommand = new BaseCommand(AddGrade);

            this.NavigationViewModel = navigationViewModel;

            this.SelectedStudent = selectedStudent;
            this.CourseOptions = availableCourses;

            SelectedGradeLetter = GradeOptions.First();
        }

        private void AddGrade(object _)
        {
            Grade newGrade = new Grade()
            {
                StudentId = SelectedStudent.Id,
                CoursePrefix = SelectedCourse.Prefix,
                CourseNum = SelectedCourse.Number,
                Year = SelectedCourse.Year,
                Semester = SelectedCourse.Semester,
                Letter = SelectedGradeLetter
            };

            if (AddGradeIfNotExists(newGrade))
            {
                MessageBox.Show("Grade added successfully");

                NavigationViewModel.SelectedViewModel = new SearchViewModel(NavigationViewModel) { SelectedStudent=SelectedStudent };
            } else
            {
                MessageBox.Show("A grade for the selected Student/Course combination already exists!");
            }
            
        }

        private bool AddGradeIfNotExists(Grade newGrade)
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

                    return true;
                } else
                {
                    return false;
                }
            }
        }
    }
}

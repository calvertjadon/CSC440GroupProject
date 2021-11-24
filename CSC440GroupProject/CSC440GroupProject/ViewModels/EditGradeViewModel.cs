using CSC440GroupProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CSC440GroupProject.ViewModels
{
    class EditGradeViewModel : ViewModelBase
    {
        public ICommand UpdateGradeCommand { get; set; }

        private NavigationViewModel NavigationViewModel { get; set; }

        public Student SelectedStudent { get; set; }
        public Course SelectedCourse { get; set; }

        public Grade GradeToEdit { get; set; }

        public string SelectedGradeLetter
        {
            get => GradeToEdit.Letter;

            set
            {
                GradeToEdit.Letter = value;
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

        public EditGradeViewModel(Grade selectedGrade, NavigationViewModel navigationViewModel)
        {
            UpdateGradeCommand = new BaseCommand(UpdateGrade);

            this.NavigationViewModel = navigationViewModel;

            GradeToEdit = selectedGrade;
            SelectedGradeLetter = selectedGrade.Letter;

            using (var context = new DatabaseContext())
            {
                SelectedCourse = context.Courses
                    .Where(c => (
                        c.Prefix.Equals(GradeToEdit.CoursePrefix) &&
                        c.Number.Equals(GradeToEdit.CourseNum) &&
                        c.Year.Equals(GradeToEdit.Year) &&
                        c.Semester.Equals(GradeToEdit.Semester)))
                    .First();

                SelectedStudent = context.Students
                    .Where(s => s.Id.Equals(GradeToEdit.StudentId))
                    .First();
            }
        }

        private void UpdateGrade(object _)
        {
            Console.WriteLine("updating gradfe");

            using (var context = new DatabaseContext())
            {
                context.Update(GradeToEdit);
                context.SaveChanges();
            }

            this.NavigationViewModel.SelectedViewModel = new SearchViewModel(this.NavigationViewModel);
        }
    }
}

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
    class EditGradeViewModel : ViewModelBase
    {
        public ICommand UpdateGradeCommand { get; set; }
        public ICommand DeleteGradeCommand { get; set; }

        private NavigationViewModel NavigationViewModel { get; set; }

        public Student SelectedStudent { get; set; }

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
            DeleteGradeCommand = new BaseCommand(DeleteGrade);

            this.NavigationViewModel = navigationViewModel;

            GradeToEdit = selectedGrade;
            SelectedGradeLetter = selectedGrade.Letter;

            using (var context = new DatabaseContext())
            {
                SelectedStudent = context.Students
                    .Where(s => s.Id.Equals(GradeToEdit.StudentId))
                    .First();
            }
        }

        private void UpdateGrade(object _)
        {
            Console.WriteLine("updating grade");

            using (var context = new DatabaseContext())
            {
                context.Update(GradeToEdit);
                context.SaveChanges();

                MessageBox.Show("Grade updated successfully");
            }

            this.NavigationViewModel.SelectedViewModel = new SearchViewModel(this.NavigationViewModel) { SelectedStudent=SelectedStudent };
        }

        private void DeleteGrade(object _)
        {
            Console.WriteLine("deleting grade");

            if (MessageBox.Show("Are you sure you want to delete this grade?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                using (var context = new DatabaseContext())
                {
                    context.Remove(GradeToEdit);
                    context.SaveChanges();

                    MessageBox.Show("Grade deleted succesfully");
                }

                this.NavigationViewModel.SelectedViewModel = new SearchViewModel(this.NavigationViewModel) { SelectedStudent=SelectedStudent };
            }
            
        }
    }
}

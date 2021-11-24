using CSC440GroupProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace CSC440GroupProject.ViewModels
{
    class SearchViewModel : ViewModelBase
    {
        public ICommand ButtonClickCommand { get; set; }

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

        public SearchViewModel(NavigationViewModel navigationViewModel)
        {
            this.ButtonClickCommand = new BaseCommand(LoadStudents);
            this.NavigationViewModel = navigationViewModel;

            this.Students = new List<Student>();
            this.Grades = new List<Grade>();

            LoadStudents(null);
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
    }
}

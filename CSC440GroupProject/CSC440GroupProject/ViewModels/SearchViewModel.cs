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
        public ICommand ButtonClick { get; set; }
        public ICommand IdTextBoxTextChanged { get; set; }

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

        public SearchViewModel()
        {
            this.ButtonClick = new BaseCommand(LoadStudents);

            this.Students = new List<Student>();
            this.Grades = new List<Grade>();

            //LoadStudents(null);
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

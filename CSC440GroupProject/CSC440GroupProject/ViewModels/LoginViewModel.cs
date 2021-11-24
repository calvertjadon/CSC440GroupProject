using CSC440GroupProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace CSC440GroupProject.ViewModels
{
    class LoginViewModel
    {
        public ICommand ButtonClick { get; set; }
        public ICommand IdTextBoxTextChanged { get; set; }
        public ObservableCollection<Student> Students { get; set; }

        private string idInput;
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

        public LoginViewModel()
        {
            this.ButtonClick = new BaseCommand(GetStudentInfo);

            this.Students = new ObservableCollection<Student>();
        }

        private void GetStudentInfo(object _)
        {
            DatabaseContext dbContext = new DatabaseContext();

            var load = (from student in dbContext.Students select student).Where(s => s.Id.Equals(IdInput));
            if (load != null)
            {
                Students.Clear();
                foreach (var student in load)
                {
                    Students.Add(student);
                }
            }
        }
    }
}

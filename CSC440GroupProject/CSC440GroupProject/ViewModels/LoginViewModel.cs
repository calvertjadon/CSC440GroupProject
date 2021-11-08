using CSC440GroupProject.Commands;
using CSC440GroupProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CSC440GroupProject.ViewModels
{
    class LoginViewModel : ViewModelBase
    {
        public ICommand LoginButtonCommand { get; }

        public LoginStatus loginStatus;

        public string Status
        {
            get => loginStatus.Status;
            set
            {
                loginStatus.Status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        public LoginViewModel()
        {
            LoginButtonCommand = new LoginCommand(this);
            loginStatus = new LoginStatus("Not Logged In");
        }
    }
}

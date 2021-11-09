using CSC440GroupProject.Commands;
using CSC440GroupProject.Models;
using CSC440GroupProject.Services;
using CSC440GroupProject.Stores;
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

        public ICommand NavigateToSearchCommand { get; }

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

        public LoginViewModel(NavigationService searchViewNavigationService)
        {
            LoginButtonCommand = new LoginCommand(this);

            NavigateToSearchCommand = new NavigateCommand(searchViewNavigationService);

            loginStatus = new LoginStatus("Not Logged In");
        }
    }
}

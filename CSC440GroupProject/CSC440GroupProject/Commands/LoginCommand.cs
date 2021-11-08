using CSC440GroupProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC440GroupProject.Commands
{
    class LoginCommand : CommandBase
    {
        private readonly LoginViewModel LoginViewModel;
        public LoginCommand(LoginViewModel loginViewModel)
        {
            LoginViewModel = loginViewModel;
        }

        public override void Execute(object parameter)
        {
            Console.WriteLine("LOGIN BUTTON CLICKED");
            LoginViewModel.Status = "Logged In";
        }


    }
}

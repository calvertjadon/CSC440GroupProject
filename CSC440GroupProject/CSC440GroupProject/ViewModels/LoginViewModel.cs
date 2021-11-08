using CSC440GroupProject.Commands;
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

        public LoginViewModel()
        {
            LoginButtonCommand = new LoginCommand();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC440GroupProject.Commands
{
    class LoginCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            Console.WriteLine("LOGIN BUTTON CLICKED");
        }
    }
}

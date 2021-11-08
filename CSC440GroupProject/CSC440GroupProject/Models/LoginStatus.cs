using CSC440GroupProject.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC440GroupProject.Models
{
    class LoginStatus : ViewModelBase
    {
        private string status;
        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                this.status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        public LoginStatus(string status)
        {
            Status = status;
        }
    }
}

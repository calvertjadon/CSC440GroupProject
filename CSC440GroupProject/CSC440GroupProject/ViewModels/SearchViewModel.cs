using CSC440GroupProject.Commands;
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
    class SearchViewModel : ViewModelBase
    {
        public ICommand NavigateToLoginCommand { get; }

        public SearchViewModel(NavigationService loginViewNavigationService)
        {
            NavigateToLoginCommand = new NavigateCommand(loginViewNavigationService);
        }
    }
}

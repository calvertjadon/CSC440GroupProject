using CSC440GroupProject.Commands;
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
        public ICommand SearchButtonCommand { get; }

        public SearchViewModel()
        {
            SearchButtonCommand = new SearchCommand();
        }
    }
}

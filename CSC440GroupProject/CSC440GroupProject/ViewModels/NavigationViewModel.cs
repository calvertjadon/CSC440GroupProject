using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CSC440GroupProject.ViewModels
{
    class NavigationViewModel : ViewModelBase
    {
        public ICommand SearchCommand { get; set; }
        public ICommand ImportRecordsCommand { get; set; }

        private object selectedViewModel;
        public object SelectedViewModel
        {
            get
            {
                return selectedViewModel;
            }
            set
            {
                selectedViewModel = value;
                OnPropertyChanged("SelectedViewModel");
            }
        }

        public NavigationViewModel()
        {
            SearchCommand = new BaseCommand(OpenSearch);
            ImportRecordsCommand = new BaseCommand(OpenImportRecords);

            // DEFAULT TO LOGIN SCREEN
            SearchCommand.Execute(null);
        }

        private void OpenSearch(object _)
        {
            SelectedViewModel = new SearchViewModel(this);
        }

        private void OpenImportRecords(object _)
        {
            SelectedViewModel = new ImportRecordsViewModel();
        }
    }
}

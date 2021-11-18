using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CSC440GroupProject.ViewModels
{
    class NavigationViewModel : INotifyPropertyChanged
    {
        public ICommand LoginCommand { get; set; }
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
            LoginCommand = new BaseCommand(OpenLogin);
            ImportRecordsCommand = new BaseCommand(OpenImportRecords);

            // DEFAULT TO LOGIN SCREEN
            LoginCommand.Execute(null);
        }

        private void OpenLogin(object _)
        {
            SelectedViewModel = new LoginViewModel();
        }

        private void OpenImportRecords(object _)
        {
            SelectedViewModel = new ImportRecordsViewModel();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}

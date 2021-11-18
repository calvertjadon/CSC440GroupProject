using CSC440GroupProject.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CSC440GroupProject.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Globalization;
using System.ComponentModel;

namespace CSC440GroupProject.ViewModels
{
    class ImportRecordsViewModel : INotifyPropertyChanged
    {
        public ICommand GenerateReportCommand { get; set; }

        private List<RadioClass> radio = new List<RadioClass>()
        {
            new RadioClass { Header = "Plain Text", CheckedProperty = true },
            new RadioClass { Header = "PDF", CheckedProperty = false }
        };

        public List<RadioClass> Radio
        {
            get => radio;
        }

        public ImportRecordsViewModel()
        {
            GenerateReportCommand = new BaseCommand(GeneratePlainTextReport);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void GeneratePlainTextReport(object _)
        {
            ReportGenerator reportGenerator;

            RadioClass selectedRadioButton = Radio.Where(radio => radio.CheckedProperty == true).First();
            switch (selectedRadioButton.Header)
            {
                case "Plain Text":
                    reportGenerator = new PlainTextReportGenerator(
                        new Student(1111, "Jadon Calvert", 3.00, 3, 9),
                        new List<Grade>
                        {
                            new Grade("B", "CSC", "191", 1111, "2021", "Spring")
                        }
                    );
                    break;

                case "PDF":
                    reportGenerator = new PdfReportGenerator(
                        new Student(1111, "Jadon Calvert", 3.00, 3, 9),
                        new List<Grade>
                        {
                            new Grade("B", "CSC", "191", 1111, "2021", "Spring")
                        }
                    );
                    break;
                default:
                    throw new Exception("Invalid Report Generator Type");
            }

            
            reportGenerator.GenerateReport();
        }

        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

    }

    public class RadioClass : INotifyPropertyChanged
    {
        public string Header { get; set; }

        private bool checkedProperty;
        public bool CheckedProperty
        {
            get
            {
                return checkedProperty;
            }
            set
            {
                checkedProperty = value;
                OnPropertyChanged("CheckedProperty");
            }
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

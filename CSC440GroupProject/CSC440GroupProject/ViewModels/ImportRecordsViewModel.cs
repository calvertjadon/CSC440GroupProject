using CSC440GroupProject.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CSC440GroupProject.ViewModels
{
    class ImportRecordsViewModel
    {
        public ICommand GenerateReportCommand { get; set; }

        public ImportRecordsViewModel()
        {
            GenerateReportCommand = new BaseCommand(GeneratePlainTextReport);
        }

        private void GeneratePlainTextReport(object _)
        {
            ReportGenerator reportGenerator = new PlainTextReportGenerator(
                new Models.Student(),
                null
            );
            reportGenerator.GenerateReport();
        }
    }
}

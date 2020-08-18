using Endless_Development_Project_Studio;
using Endless_Development_Project_Studio.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endless_Development_Project_Studio.FileTransfer
{
    public class TransferItemViewModel : BaseViewModel
    {
        public string FileName { get; set; }
        public string Type { get; set; }
        public double TypeAngle { get { if (Type == "Download") return 45d; else return 225d; }  }
        public int Progress { get { return OnProgress;  } set { OnProgress = value; ProgressValue = (double)value / 100; OnPropertyChanged(nameof(OnProgress)); OnPropertyChanged(nameof(ProgressValue)); } }
        public string Date { get; set; }
        public int OnProgress { get; set; }
        public double ProgressValue { get; set; }
    }
}

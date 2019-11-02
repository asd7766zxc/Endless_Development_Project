using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endless_Development_Project_Studio.ServerOutputControl
{
    public class OutPutItemControlViewModel : IDisposable
    {
        public string TypeColor { get; set; }

        public string TimeText { get; set; }

        public string OutputText { get; set; }

        public string Type { get; set; }

        public string Thread { get; set; }

        public string Mod { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

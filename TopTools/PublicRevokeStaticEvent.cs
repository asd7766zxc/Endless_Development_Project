using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endless_Development_Project_Studio.TopTools
{
    public static class PublicRevokeStaticEvent
    {
        public delegate void OnPageChangedEcentHandler(object parameter);
        public static event OnPageChangedEcentHandler PageEvent;
        public static void RevokeEvent(object parameter)
        {
            PageEvent?.Invoke(parameter);
            Logger.ConsoleLogger.Log((string)parameter);
        }
    }
}

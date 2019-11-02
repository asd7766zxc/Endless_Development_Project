using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endless_Development_Project_Studio.Events
{
    public static class StaticEvent
    {
        public static event LoginDataHandler LoginEvent;
        public static void OnLoginEvent()
        {
            LoginEvent?.Invoke(null);
        }
    }
}

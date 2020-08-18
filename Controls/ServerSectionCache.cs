using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endless_Development_Project_Studio.Controls
{
    public static class ServerSectionCache
    {
        public static string SSPath { get; set; }
        public static object SectionObject { get; set; }
        public delegate void OnSectionChangedHandler ();
        public static event OnSectionChangedHandler OnSectionChanged;
        public static void ChangeSection()
        {
            OnSectionChanged?.Invoke();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endless_Development_Project_Studio
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        protected async Task RunCommand(System.Linq.Expressions.Expression<Func<bool>> updatingFlag, Func<Task> action)
        {
            if (updatingFlag.GetPropertyValue())
                return;

            updatingFlag.SetPropertyValue(true);

            try
            {
                await action();
            }
            finally
            {
                updatingFlag.SetPropertyValue(false);
            }
        }

    }
}

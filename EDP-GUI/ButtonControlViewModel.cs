using Chat_Pro_NCP;
using Endless_Development_Project_Studio.TopTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Endless_Development_Project_Studio.EDP_GUI
{
    public class ButtonControlViewModel : BaseViewModel
    {
      
        public ICommand OnClick { get; set; }
        public double ButtonOpacity { get; set; }
        public double ButtonPadding { get; set; }
        public double Angle { get; set; }
        public double ButtonFontSize { get; set; }
        public double RotateCenter { get; set; }
        public string ButtonContent { get; set; }
        public double RemoveEventData { get; set; }
        public ButtonControlViewModel()
        {
            OnClick = new RelayCommand(Revoke);
        }
        public void Revoke()
        {
            PublicRevokeStaticEvent.RevokeEvent(ButtonContent);
        }
        public void Unload()
        {
            OnPropertyChanged(nameof(ButtonPadding));
            
        }

    }
    class ButtonControlDesign : ButtonControlViewModel
    {
        public static ButtonControlViewModel Instance
            => new ButtonControlViewModel();
    }
}

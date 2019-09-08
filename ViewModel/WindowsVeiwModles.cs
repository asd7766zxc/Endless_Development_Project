using Endless_Development_Project_Studio.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Endless_Development_Project_Studio
{
    public class WindowsVeiwModles:BaseViewModel
    {
        private Window mWindow;
        private int mOuterMarginSize = 10;
        private int mWindowRadius = 1;

        public int CurrentPage { get; set; } = 0;

        public string backgroundvideo { get { return System.Windows.Forms.Application.StartupPath + @"\Library\video.mp4"; } set { } }

        public double WidowMinimumWidth { get; set; } = 800;

        public string UserName { get; set; }

        public double WidowMinimumHeight { get; set; } = 800;

        public bool Borderless
        {
            get { return (mWindow.WindowState == WindowState.Maximized); }
        }

        public int ResizeBorder => mWindow.WindowState == WindowState.Maximized ? 0 : 6;

        public Thickness ResizeBorderThickness
        { get { return new Thickness(ResizeBorder + OuterMarginSize); } }

        public Thickness InnerContentPadding
        { set; get; } = new Thickness(0);

        public int OuterMarginSize
        {
            get { return mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize; }
            set { mOuterMarginSize = value; }
        }
        public Thickness OuterMarginSizeThickness
        {
            get
            {
                return new Thickness(OuterMarginSize);
            }
        }

        public int WindowRadius
        {
            get { return mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius; }
            set { mWindowRadius = value; }
        }
        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        public int TitleHeight { get; set; } = 22;

        public GridLength TitleHeightGridLenght { get { return new GridLength(TitleHeight + ResizeBorder); } }

        public ICommand MinimizeCommand { get; set; }

        public ICommand MaximizeCommand { get; set; }

        public ICommand CloseCommand { get; set; }

        public ICommand MenuCommand { get; set; }


        public WindowsVeiwModles(Window windows)
        {
            SocketStatus.LoginComplect += SocketStatus_LoginComplect;
            mWindow = windows;
            mWindow.StateChanged += (sender, e) =>
            {
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };
            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => { try { SocketStatus.voice_Client.voicePage.FormMain_FormClosing(); } catch { } try {  SocketStatus.Close(); } catch { }  try { SocketStatus.Logout(); } catch { } SocketStatus.player_RPC.Shutdown(); mWindow.Close(); });
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow, GetMousePosition()));
            var resizer = new WindowResizer(mWindow);
        }

        private void SocketStatus_LoginComplect(object Parameter)
        {
            UserName = (string)Parameter;
            CurrentPage = SocketStatus.Page;
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(ref Win32Point pt);

        [StructLayout(LayoutKind.Sequential)]
        internal struct Win32Point
        {
            public Int32 X;
            public Int32 Y;
        };

        public static Point GetMousePosition()
        {
            Win32Point w32Mouse = new Win32Point();
            GetCursorPos(ref w32Mouse);
            return new Point(w32Mouse.X, w32Mouse.Y);
        }
    }
}

using Endless_Development_Project_Studio.Connection;
using Endless_Development_Project_Studio.SharpDXControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace Endless_Development_Project_Studio
{
    public class WindowsVeiwModles : BaseViewModel
    {
        private Window mWindow;
        private int mOuterMarginSize = 10;
        private int mWindowRadius = 1;

        private object content;
        public object Content
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
                OnPropertyChanged("Content");
            }
        }

        public int CurrentPage { get; set; } = 0;
        public string AvatarUrl { get; set; } = "";
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
            mWindow.SourceInitialized += MWindow_SourceInitialized;
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
            CloseCommand = new RelayCommand(() => { try { SocketStatus.voice_Client.voicePage.FormMain_FormClosing(); } catch { } try { SocketStatus.Close(); } catch { } try { SocketStatus.Logout(); } catch { }/* SocketStatus.player_RPC.Shutdown(); */mWindow.Close(); });
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow, GetMousePosition()));
            var resizer = new WindowResizer(mWindow);
        }
        #region WindowMinSizeHelper
        internal enum WM
        {
            WINDOWPOSCHANGING = 0x0046,
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct WINDOWPOS
        {
            public IntPtr hwnd;
            public IntPtr hwndInsertAfter;
            public int x;
            public int y;
            public int cx;
            public int cy;
            public int flags;
        }

        private static IntPtr DragHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handeled)
        {
            switch ((WM)msg)
            {
                case WM.WINDOWPOSCHANGING:
                    {
                        WINDOWPOS pos = (WINDOWPOS)Marshal.PtrToStructure(lParam, typeof(WINDOWPOS));
                      

                        Window wnd = (Window)HwndSource.FromHwnd(hwnd).RootVisual;
                        if (wnd == null)
                        {
                            return IntPtr.Zero;
                        }

                        bool changedPos = false;

                        // ***********************
                        // Here you check the values inside the pos structure
                        // if you want to override them just change the pos
                        // structure and set changedPos to true
                        // ***********************

                        // this is a simplified version that doesn't work in high-dpi settings
                        // pos.cx and pos.cy are in "device pixels" and MinWidth and MinHeight 
                        // are in "WPF pixels" (WPF pixels are always 1/96 of an inch - if your
                        // system is configured correctly).
                        if (pos.cx < 400) { pos.cx = 400; changedPos = true; }
                        if (pos.cy < 400) { pos.cy = 400; changedPos = true; }


                        // ***********************
                        // end of "logic"
                        // ***********************

                        if (!changedPos)
                        {
                            return IntPtr.Zero;
                        }

                        Marshal.StructureToPtr(pos, lParam, true);
                        handeled = true;
                    }
                    break;
            }

            return IntPtr.Zero;
        }
        #endregion
        private void MWindow_SourceInitialized(object sender, EventArgs e)
        {
            HwndSource hwndSource = (HwndSource)HwndSource.FromVisual((Window)sender);
            hwndSource.AddHook(DragHook);
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

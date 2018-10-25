using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Fasetto
{
    public class WindowViewModel : BaseClass
    {


        #region Private Members

        /// <summary>
        /// The Window this view model controls
        /// </summary>
        private Window mWindow;

        /// <summary>
        /// The Size of the outerMargin
        /// </summary>
        private int mOuterMarginSize = 10;

        /// <summary>
        /// The radius of the window
        /// </summary>
        private int mWindowRadius = 10;

        #endregion

        #region Commands
        public ICommand MinimizeCommand { get; set; }
        public ICommand MaximizeCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand MenuCommand { get; set; }

        #endregion


        #region Public Properties

        /// <summary>
        /// The size of the resize border around the window
        /// </summary
        public int ResizeBorder { get; set; } = 6;

        /// <summary>
        /// The size of the resizeborder taking into account the outer margin
        /// </summary>
        public Thickness ResizeBorederThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }

        /// <summary>
        /// The property to set and assign values to outerMargin
        /// </summary>
        public int OuterMarginSize
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize;
            }

            set
            {
                mOuterMarginSize = value;
            }
        }

        /// <summary>
        /// The property to set and assign values to outerMargin
        /// </summary>
        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }

        /// <summary>
        /// Set Window Radius
        /// </summary>
        public int WindowRadius
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius;
            }

            set
            {
                mWindowRadius = value;
            }
        }

        /// <summary>
        /// Set Corner Window Radius
        /// </summary>
        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        /// <summary>
        /// The height of the CaptionBar
        /// </summary>
        public int TitleHeight { get; set; } = 42;

        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight + ResizeBorder); } }


        #endregion


        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="window"></param>

        #region Constructer

        public WindowViewModel(Window window)
        {
            mWindow = window;
            mWindow.StateChanged += (sender, e) =>
            {
                OnPropertyChanged(nameof(ResizeBorederThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };
            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => mWindow.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow, GetMousePosition()));




        }
        #endregion

        #region PrivateHelpers
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(ref Win32Point pt);
        [StructLayout(LayoutKind.Sequential)]

        internal struct Win32Point
        {
            public Int32 X;
            public Int32 Y;

        }

        private static Point GetMousePosition()
        {
            Win32Point w32Mouse = new Win32Point();
            GetCursorPos(ref w32Mouse);
            return new Point(w32Mouse.X, w32Mouse.Y);
        }


        #endregion
    }
}

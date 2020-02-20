using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace 控制窗口拖动
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private POINT _mouseDownPos;
        private bool _move;
        [DllImport("user32.dll")]
        public static extern bool ClipCursor(ref RECT lpRect);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetCursorPos(out POINT pt);
        public MainWindow()
        {
            InitializeComponent();
            Regex re = new Regex(@"^[\u4e00-\u9fa5a-zA-Z-z0-9-.-_]+$");
            string str = "aag方法#1_11.mp4";
            if (re.IsMatch(str))
            {
                //验证通过
            }
            else
            {
                // 验证不通过
            }
        
        }
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            HwndSource hwndSource = PresentationSource.FromVisual(this) as HwndSource;
            if (hwndSource != null)
            {
                hwndSource.AddHook(new HwndSourceHook((this.WndProc)));
            }
        }
         protected virtual IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            RECT nativeRect;
            switch (msg)
            {
                case 0x20:
                    {
                        int lp = lParam.ToInt32();
                        if ((lp & 0xFFFF) == 2 &&
                        ((lp >> 0x10) & 0xFFFF) == 0x201)
                        {
                            GetCursorPos(out _mouseDownPos);
                            _move = true;
                        }
                    }
                    break;
                case 0x231:
                    if (_move)
                    {
                        System.Drawing.Rectangle rect = System.Windows.Forms.SystemInformation.VirtualScreen;
                        Point ptLeftUp = new Point(0, 0);
                        Point ptRightDown = new Point(this.ActualWidth, this.ActualHeight);
                        ptLeftUp = this.PointToScreen(ptLeftUp);
                        ptRightDown = this.PointToScreen(ptRightDown);
                        nativeRect = new RECT(
                        (int)(_mouseDownPos.X - ptLeftUp.X),
                       (int)( _mouseDownPos.Y - ptLeftUp.Y),
                       (int)(  rect.Right - (ptRightDown.X - _mouseDownPos.X)),
                       (int)( rect.Bottom - (ptRightDown.Y - _mouseDownPos.Y)));
                        ClipCursor(ref nativeRect);
                    }
                    break;
                case 0x0232:
                    if (_move)
                    {
                        nativeRect = new RECT(System.Windows.Forms.SystemInformation.VirtualScreen);
                        ClipCursor(ref nativeRect);
                        _move = false;
                    }
                    break;
            }
            return IntPtr.Zero;
        }

         [StructLayout(LayoutKind.Sequential)]
         public struct POINT
         {
             public int X;
             public int Y;

             public POINT(int x, int y)
             {
                 this.X = x;
                 this.Y = y;
             }

             public override string ToString()
             {
                 return ("X:" + X + ", Y:" + Y);
             }
         }
         [StructLayout(LayoutKind.Sequential)]
         public struct RECT
         {
             public int Left;
             public int Top;
             public int Right;
             public int Bottom;
             public RECT(int left, int top, int right, int bottom)
             {
                 Left = left;
                 Top = top;
                 Right = right;
                 Bottom = bottom;
             }
             public RECT(System.Drawing.Rectangle rect)
             {
                 Left = rect.Left;
                 Top = rect.Top;
                 Right = rect.Right;
                 Bottom = rect.Bottom;
             }
             public System.Drawing.Rectangle Rect
             {
                 get
                 {
                     return new System.Drawing.Rectangle(
                     Left,
                     Top,
                     Right - Left,
                     Bottom - Top);
                 }
             }
             public Size Size
             {
                 get
                 {
                     return new Size(Right - Left, Bottom - Top);
                 }
             }
             public static RECT FromXYWH(int x, int y, int width, int height)
             {
                 return new RECT(x,
                   y,
                   x + width,
                   y + height);
             }
             public static RECT FromRectangle(System.Drawing.Rectangle rect)
             {
                 return new RECT(rect.Left,
                    rect.Top,
                    rect.Right,
                    rect.Bottom);
             }
         }


    }
}

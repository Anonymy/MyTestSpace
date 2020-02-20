using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Point _mouseDownPos;
        private bool _move;
        protected override void WndProc(ref Message m)
        {
            RECT nativeRect;
            switch (m.Msg)
            {
                case 0x20:
                    int lp = m.LParam.ToInt32();
                    if ((lp & 0xFFFF) == 2 &&
                    ((lp >> 0x10) & 0xFFFF) == 0x201)
                    {
                        _mouseDownPos = Control.MousePosition;
                        _move = true;
                    }
                    break;
                case 0x231:
                    if (_move)
                    {
                        Rectangle rect = Screen.GetWorkingArea(this);
                        nativeRect = new RECT(
                         _mouseDownPos.X - Location.X,
                         _mouseDownPos.Y - Location.Y,
                         rect.Right - (Bounds.Right - _mouseDownPos.X),
                         rect.Bottom - (Bounds.Bottom - _mouseDownPos.Y));
                        ClipCursor(ref nativeRect);
                    }
                    break;
                case 0x0232:
                    if (_move)
                    {
                        nativeRect = new RECT(Screen.GetWorkingArea(this));
                        ClipCursor(ref nativeRect);
                        _move = false;
                    }
                    break;
            }
            base.WndProc(ref m);
        }
        [DllImport("user32.dll")]
        public static extern bool ClipCursor(ref RECT lpRect);
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
            public RECT(Rectangle rect)
            {
                Left = rect.Left;
                Top = rect.Top;
                Right = rect.Right;
                Bottom = rect.Bottom;
            }
            public Rectangle Rect
            {
                get
                {
                    return new Rectangle(
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
            public static RECT FromRectangle(Rectangle rect)
            {
                return new RECT(rect.Left,
                   rect.Top,
                   rect.Right,
                   rect.Bottom);
            }
        }
    }
}

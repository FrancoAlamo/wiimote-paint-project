using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices; 

namespace PaintProgram
{
    class ResizeImage
    {
        
        enum ResizingMode
        {
            TopLeft,
            Left,
            BottomLeft,
            Top,
            TopRight,
            Right,
            BottomRight,
            Bottom,
            None
        }

        static ResizingMode _resizeMode = ResizingMode.None;

        private class NativeCalls
        {

            [DllImport("USER32.DLL", EntryPoint = "SendMessage")]

            public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, ref int lParam);

            [DllImport("USER32.DLL")]

            public static extern int ReleaseCapture(IntPtr hwnd);

            public const int WM_SYSCOMMAND = 0x0112;

            public const int SC_DRAGMOVE = 0xF012;
            public const int SC_DRAGSIZE_N = 0xF003;
            public const int SC_DRAGSIZE_S = 0xF006;
            public const int SC_DRAGSIZE_E = 0xF002;
            public const int SC_DRAGSIZE_W = 0xF001;
            public const int SC_DRAGSIZE_NW = 0xF004;
            public const int SC_DRAGSIZE_NE = 0xF005;
            public const int SC_DRAGSIZE_SW = 0xF007;
            public const int SC_DRAGSIZE_SE = 0xF008;

        }



        public ResizeImage()
        {
            
        }


        public void Resize_movement(MouseEventArgs e, PictureBox Pic)
        {
            if ((e.X < 5) && (e.Y < 5))
            {
                Cursor.Current = Cursors.SizeNWSE;
                _resizeMode = ResizingMode.TopLeft;
            }
            else if ((e.X < 5) && Math.Abs(e.Y - Pic.ClientSize.Height) < 5)
            {
                
                Cursor.Current = Cursors.SizeNESW;
                _resizeMode = ResizingMode.BottomLeft;
            }
            else if (e.X < 5)
            {
                Cursor.Current = Cursors.SizeWE;
                _resizeMode = ResizingMode.Left;
            }
            else
                if (Math.Abs(e.X - Pic.ClientSize.Width) < 5 && (e.Y < 5))
                {
                    Cursor.Current = Cursors.SizeNESW;
                    _resizeMode = ResizingMode.TopRight;
                }
                else
                    if (Math.Abs(e.X - Pic.ClientSize.Width) < 5 && Math.Abs(e.Y - Pic.ClientSize.Height) < 5)
                    {
                        Cursor.Current = Cursors.SizeNWSE;
                        _resizeMode = ResizingMode.BottomRight;
                    }
                    else if (Math.Abs(e.X - Pic.ClientSize.Width) < 5)
                    {
                        Cursor.Current = Cursors.SizeWE;
                        _resizeMode = ResizingMode.Right;
                    }
                    else if (Math.Abs(e.Y - Pic.ClientSize.Height) < 5)
                    {
                        Cursor.Current = Cursors.SizeNS;

                        _resizeMode = ResizingMode.Bottom;
                    }
                    else if (e.Y < 5)
                    {
                        Cursor.Current = Cursors.SizeNS;
                        _resizeMode = ResizingMode.Top;
                    }
                    else
                    {
                        Cursor.Current = Cursors.Default;
                        _resizeMode = ResizingMode.None;
                    }
            //DoResizing(Pic.Handle);
        }


        public void Resize_movement_panel(MouseEventArgs e, Panel panel)
        {
            if ((e.X < 5) && (e.Y < 5))
            {
                Cursor.Current = Cursors.SizeNWSE;
                _resizeMode = ResizingMode.TopLeft;
            }
            else if ((e.X < 5) && Math.Abs(e.Y - panel.ClientSize.Height) < 5)
            {

                Cursor.Current = Cursors.SizeNESW;
                _resizeMode = ResizingMode.BottomLeft;
            }
            else if (e.X < 5)
            {
                Cursor.Current = Cursors.SizeWE;
                _resizeMode = ResizingMode.Left;
            }
            else
                if (Math.Abs(e.X - panel.ClientSize.Width) < 5 && (e.Y < 5))
                {
                    Cursor.Current = Cursors.SizeNESW;
                    _resizeMode = ResizingMode.TopRight;
                }
                else
                    if (Math.Abs(e.X - panel.ClientSize.Width) < 5 && Math.Abs(e.Y - panel.ClientSize.Height) < 5)
                    {
                        Cursor.Current = Cursors.SizeNWSE;
                        _resizeMode = ResizingMode.BottomRight;
                    }
                    else if (Math.Abs(e.X - panel.ClientSize.Width) < 5)
                    {
                        Cursor.Current = Cursors.SizeWE;
                        _resizeMode = ResizingMode.Right;
                    }
                    else if (Math.Abs(e.Y - panel.ClientSize.Height) < 5)
                    {
                        Cursor.Current = Cursors.SizeNS;

                        _resizeMode = ResizingMode.Bottom;
                    }
                    else if (e.Y < 5)
                    {
                        Cursor.Current = Cursors.SizeNS;
                        _resizeMode = ResizingMode.Top;
                    }
                    else
                    {
                        Cursor.Current = Cursors.Default;
                        _resizeMode = ResizingMode.None;
                    }

            //DoResizing(Pic.Handle);
        }


        public void DoResizing(IntPtr ok)
        {


            IntPtr hwnd = ok;
            int nul = 0;


            switch (_resizeMode)
            {
                case ResizingMode.Bottom:
                    NativeCalls.ReleaseCapture(hwnd);
                    NativeCalls.SendMessage(hwnd, NativeCalls.WM_SYSCOMMAND, NativeCalls.SC_DRAGSIZE_S, ref nul);
                    break;
                case ResizingMode.Right:
                    NativeCalls.ReleaseCapture(hwnd);
                    NativeCalls.SendMessage(hwnd, NativeCalls.WM_SYSCOMMAND, NativeCalls.SC_DRAGSIZE_E, ref nul);
                    break;
                case ResizingMode.BottomRight:
                    NativeCalls.ReleaseCapture(hwnd);
                    NativeCalls.SendMessage(hwnd, NativeCalls.WM_SYSCOMMAND, NativeCalls.SC_DRAGSIZE_SE, ref nul);
                    break;

                case ResizingMode.TopRight:
                    NativeCalls.ReleaseCapture(hwnd);
                    NativeCalls.SendMessage(hwnd, NativeCalls.WM_SYSCOMMAND, NativeCalls.SC_DRAGSIZE_NE, ref nul);
                    break;
                case ResizingMode.Top:
                    NativeCalls.ReleaseCapture(hwnd);
                    NativeCalls.SendMessage(hwnd, NativeCalls.WM_SYSCOMMAND, NativeCalls.SC_DRAGSIZE_N, ref nul);
                    break;
                case ResizingMode.TopLeft:
                    NativeCalls.ReleaseCapture(hwnd);
                    NativeCalls.SendMessage(hwnd, NativeCalls.WM_SYSCOMMAND, NativeCalls.SC_DRAGSIZE_NW, ref nul);
                    break;
                case ResizingMode.Left:
                    NativeCalls.ReleaseCapture(hwnd);
                    NativeCalls.SendMessage(hwnd, NativeCalls.WM_SYSCOMMAND, NativeCalls.SC_DRAGSIZE_W, ref nul);
                    break;

                case ResizingMode.BottomLeft:
                    NativeCalls.ReleaseCapture(hwnd);
                    NativeCalls.SendMessage(hwnd, NativeCalls.WM_SYSCOMMAND, NativeCalls.SC_DRAGSIZE_SW, ref nul);
                    break;
                case ResizingMode.None:
                    NativeCalls.ReleaseCapture(hwnd);
                    //NativeCalls.SendMessage(hwnd, NativeCalls.WM_SYSCOMMAND, NativeCalls.SC_DRAGMOVE, ref nul);
                    break;

            }
        }


        
          



    }
}


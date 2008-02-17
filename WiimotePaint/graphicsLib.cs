using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using WiimoteLib;

namespace PaintProgram
{

    class graphicsLib
    {
        const int WIIMOTE_RAW_X = 1023; //values reported according to Wiili
        const int WIIMOTE_RAW_Y = 767;
        int x_dim=640, y_dim=480;       //dimensions of image
        float scale_x=640/WIIMOTE_RAW_X, scale_y=480/WIIMOTE_RAW_Y;

        Bitmap b = new Bitmap(640, 480, PixelFormat.Format24bppRgb);
        Graphics g;
                
        //x and y are image dimensions
        public graphicsLib(int x, int y)
        {
            b = new Bitmap(x,y, PixelFormat.Format24bppRgb);
            g = Graphics.FromImage(b);
            x_dim = x;
            y_dim = y;
            scale_x = x / WIIMOTE_RAW_X;
            scale_y = y / WIIMOTE_RAW_Y;
        }

        public graphicsLib(int x, int y, Bitmap b)
        {
            this.b = b;
            g = Graphics.FromImage(b);
            x_dim = x;
            y_dim = y;
        }

        public Bitmap drawCursorPoints(WiimoteState ws)
        {
            if (ws.IRState.Found1)
                g.DrawEllipse(new Pen(Color.Red), (int)(ws.IRState.RawX1*scale_x), (int)(ws.IRState.RawY1*scale_y), ws.IRState.Size1 + 1, ws.IRState.Size1 + 1);
            if (ws.IRState.Found2)
                g.DrawEllipse(new Pen(Color.Blue), (int)(ws.IRState.RawX2 * scale_x), (int)(ws.IRState.RawY2 * scale_y), ws.IRState.Size2 + 1, ws.IRState.Size2 + 1);
            if (ws.IRState.Found3)
                g.DrawEllipse(new Pen(Color.Yellow), (int)(ws.IRState.RawX3 * scale_x), (int)(ws.IRState.RawY3 * scale_y), ws.IRState.Size3 + 1, ws.IRState.Size3 + 1);
            if (ws.IRState.Found4)
                g.DrawEllipse(new Pen(Color.Orange), (int)(ws.IRState.RawX4 * scale_x), (int)(ws.IRState.RawY4 * scale_y), ws.IRState.Size4 + 1, ws.IRState.Size4 + 1);
            if (ws.IRState.Found1 && ws.IRState.Found2)
                g.DrawEllipse(new Pen(Color.Green), (int)(ws.IRState.RawMidX * scale_x), (int)(ws.IRState.RawMidY * scale_y), 2, 2);
            return b;
        }   

    }
}

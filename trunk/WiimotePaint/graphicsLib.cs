using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using WiimoteLib;

namespace PaintProgram
{
    class graphicsLib
    {
        int x_dim=640, y_dim=480;
        float scale_x, scale_y;
        Bitmap b = new Bitmap(640, 480, PixelFormat.Format24bppRgb);
        Graphics g;

        public void graphicsLib()
        {            
        }

        //x and y are image dimensions
        public void graphicsLib(int x, int y)
        {
            b = new Bitmap(x,y, PixelFormat.Format24bppRgb);
            x_dim = x;
            y_dim = y;
        }

        public void graphicsLib(int x, int y, Bitmap b)
        {
            this.b = b;
            x_dim = x;
            y_dim = y;
        }

        public Bitmap drawCursorPoints(WiimoteState ws)
        {
            if (ws.IRState.Found1)
                g.DrawEllipse(new Pen(Color.Red), (int)(ws.IRState.RawX1 / 4), (int)(ws.IRState.RawY1 / 4), ws.IRState.Size1 + 1, ws.IRState.Size1 + 1);
            if (ws.IRState.Found2)
                g.DrawEllipse(new Pen(Color.Blue), (int)(ws.IRState.RawX2 / 4), (int)(ws.IRState.RawY2 / 4), ws.IRState.Size2 + 1, ws.IRState.Size2 + 1);
            if (ws.IRState.Found3)
                g.DrawEllipse(new Pen(Color.Yellow), (int)(ws.IRState.RawX3 / 4), (int)(ws.IRState.RawY3 / 4), ws.IRState.Size3 + 1, ws.IRState.Size3 + 1);
            if (ws.IRState.Found4)
                g.DrawEllipse(new Pen(Color.Orange), (int)(ws.IRState.RawX4 / 4), (int)(ws.IRState.RawY4 / 4), ws.IRState.Size4 + 1, ws.IRState.Size4 + 1);
            if (ws.IRState.Found1 && ws.IRState.Found2)
                g.DrawEllipse(new Pen(Color.Green), (int)(ws.IRState.RawMidX / 4), (int)(ws.IRState.RawMidY / 4), 2, 2);
        }        

    }
}

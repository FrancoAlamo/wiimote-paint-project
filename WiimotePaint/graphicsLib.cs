using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaintProgram
{
    class graphicsLib
    {
        int x_dim=640, y_dim=480;
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

        public Bitmap drawCursorPoints(int x1, int y1)
        {

        }

        public Bitmap drawCursorPoints(int x1, int y1, int x2, int y2)
        {

        }

        public Bitmap drawCursorPoints(int x1, int y1, int x2, int y2, int x2, int y2)
        {

        }

        public Bitmap drawCursorPoints(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
        {

        }

    }
}

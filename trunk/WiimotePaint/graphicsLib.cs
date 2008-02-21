using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Reflection;
using System.IO;
using System.Resources;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using WiimoteLib;

namespace PaintProgram
{

    class graphicsLib
    {
        const int WIIMOTE_RAW_X = 1023; //values reported according to Wiili
        const int WIIMOTE_RAW_Y = 767;
        int x_dim = 640, y_dim = 480;       //dimensions of image
        float scale_x = 640 / WIIMOTE_RAW_X, scale_y = 480 / WIIMOTE_RAW_Y;
        Image img;
        Graphics g;
        Bitmap b = new Bitmap(1, 1, PixelFormat.Format24bppRgb); // creates pretty much an empty Bitmap to be able to later create graphics
        Bitmap pixel = new Bitmap(100, 200);
        Graphics eraser;  // Makes the eraser graphics which will later be a square used to erase
        Graphics rectangle;
        Graphics circle;


        //x and y are image dimensions
        public graphicsLib()
        {
        }
        public graphicsLib(int x, int y)
        {
            b = new Bitmap(x, y, PixelFormat.Format24bppRgb);
            x_dim = x;
            y_dim = y;
            scale_x = x / WIIMOTE_RAW_X;
            scale_y = y / WIIMOTE_RAW_Y;
        }

        public graphicsLib(int x, int y, Bitmap b)
        {
            this.b = b;
            x_dim = x;
            y_dim = y;
        }

        public Bitmap drawCursorPoints(WiimoteState ws)
        {
            g = Graphics.FromImage(b);
            if (ws.IRState.Found1)
                g.DrawEllipse(new Pen(Color.Red), (int)(ws.IRState.RawX1 * scale_x), (int)(ws.IRState.RawY1 * scale_y), ws.IRState.Size1 + 1, ws.IRState.Size1 + 1);
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

        public Image eraser_function(Image pic, int pos_x, int pos_y, int erasersize_x, int erasersize_y)
        {
            pixel.SetPixel(20, 30, Color.White);
            eraser = Graphics.FromImage(pic);
            eraser.DrawRectangle(new Pen(Color.White), pos_x, pos_y, erasersize_x, erasersize_y);
            eraser.FillRectangle(new SolidBrush(Color.White), pos_x, pos_y, erasersize_x, erasersize_y);
            return pic;
        }

        public Image cut_function(Image pic, int pos_x, int pos_y, int erasersize_x, int erasersize_y)
        {
            pixel.SetPixel(20, 30, Color.White);
            Rectangle rect = new Rectangle(pos_x, pos_y, erasersize_x, erasersize_y);
            rectangle = Graphics.FromImage(pic);
            GraphicsPath p = new GraphicsPath();
            p.StartFigure();
            //rectangle.DrawRectangle(new Pen(Color.Black),
            rectangle.DrawRectangle(new Pen(Color.White), pos_x, pos_y, erasersize_x, erasersize_y);
            rectangle.FillRectangle(new SolidBrush(Color.White), pos_x, pos_y, erasersize_x, erasersize_y);
            p.AddRectangle(rect);
            
            return pic;
        }

        public Image rectangle_function(Image pic, Point initial_pos, int pos_x, int pos_y)
        {
            rectangle = Graphics.FromImage(pic);
            int width = pos_x - initial_pos.X;
            int heigth = pos_y - initial_pos.Y;
            if (width < 0 && heigth < 0)
            {
                width = initial_pos.X - pos_x;
                heigth = initial_pos.Y - pos_y;
                rectangle.DrawRectangle(new Pen(Color.Black), pos_x, pos_y, width, heigth);
            }
            else if (heigth < 0)
            {
                heigth = initial_pos.Y - pos_y;
                rectangle.DrawRectangle(new Pen(Color.Black), initial_pos.X, pos_y, width, heigth);
            }
            else if (width < 0)
            {
                width = initial_pos.X - pos_x;
                rectangle.DrawRectangle(new Pen(Color.Black), pos_x, initial_pos.Y, width, heigth);
            }
            else
            {
                rectangle.DrawRectangle(new Pen(Color.Black), initial_pos.X, initial_pos.Y, width, heigth);
            }
            return pic;
        }
        public Image circle_function(Image pic, Point initial_pos, int pos_x, int pos_y)
        {
            circle = Graphics.FromImage(pic);
            int width = pos_x - initial_pos.X;
            int height = pos_y - initial_pos.Y;
            Rectangle rect;
            if (width < 0 && height < 0)
            {
                width = initial_pos.X - pos_x;
                height = initial_pos.Y - pos_y;
                rect = new Rectangle(pos_x, pos_y, width, height);
            }
            else if (height < 0)
            {
                height = initial_pos.Y - pos_y;
                rect = new Rectangle(pos_x, pos_y, width, height);
            }
            else if (width < 0)
            {
                width = initial_pos.X - pos_x;
                rect = new Rectangle(pos_x, pos_y, width, height);
            }
            else
            {
                rect = new Rectangle(pos_x, pos_y, width, height);
            }

            circle.DrawEllipse(new Pen(Color.Black), rect);
            return pic;
        }

     

        public void setNewBitmap(Bitmap b)
        {
            this.b = b;
        }
        
    }
}
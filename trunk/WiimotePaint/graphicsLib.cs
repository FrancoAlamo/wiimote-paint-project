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
        int x_dim, y_dim;       //dimensions of image
        float scale_x, scale_y;
        //Image img;
        Graphics g;        
        Graphics function;  // Makes the eraser pencil and rectangle graphics which will later 
                                             // be a square used to perform each function

        //x and y are image dimensions
        public graphicsLib()
        {
        }
        public graphicsLib(int x, int y)
        {            
            x_dim = x;
            y_dim = y;
            scale_x = x / WIIMOTE_RAW_X;
            scale_y = y / WIIMOTE_RAW_Y;
        }

        public graphicsLib(int x, int y, Bitmap b)
        {
            
            x_dim = x;
            y_dim = y;
        }


        public Image drawCursorPoints(WiimoteState ws, Image pic)
        {
            Image temppic;
            temppic = (Image)pic.Clone();
            x_dim = 1280; y_dim = 800;       //dimensions of image
            scale_x = 1280 / WIIMOTE_RAW_X; scale_y = 800 / WIIMOTE_RAW_Y;
            g = Graphics.FromImage(temppic);
            
            if (ws.IRState.Found1)
                g.DrawEllipse(new Pen(Color.Red), (int)(ws.IRState.RawX1*scale_x - 142), (int)(ws.IRState.RawY1*scale_y), ws.IRState.Size1 + 1, ws.IRState.Size1 + 1);
            if (ws.IRState.Found2)
                g.DrawEllipse(new Pen(Color.Blue), (int)(ws.IRState.RawX2*scale_x - 142), (int)(ws.IRState.RawY2*scale_y), ws.IRState.Size2 + 1, ws.IRState.Size2 + 1);
            if (ws.IRState.Found3)
                g.DrawEllipse(new Pen(Color.Green), (int)(ws.IRState.RawX3*scale_x - 142), (int)(ws.IRState.RawY3*scale_y), ws.IRState.Size3 + 1, ws.IRState.Size3 + 1);
            if (ws.IRState.Found4)
                g.DrawEllipse(new Pen(Color.Black), (int)(ws.IRState.RawX4*scale_x - 142), (int)(ws.IRState.RawY4*scale_y), ws.IRState.Size4 + 1, ws.IRState.Size4 + 1);
            /*
            if (ws.IRState.Found1 && ws.IRState.Found2)
                g.DrawEllipse(new Pen(Color.Green), (int)(ws.IRState.RawMidX), (int)(ws.IRState.RawMidY), 7, 7);
            */
            return temppic;
        }

         
        public Image eraser_function(Image pic, Point temp, int pos_x, int pos_y, int erasersize_x, int erasersize_y)
        {
            function = Graphics.FromImage(pic);
            function.DrawLine(new Pen(Color.White, (float)erasersize_y), temp.X, temp.Y, pos_x, pos_y);
            return pic;
        }

        public Image cut_function(Image pic, int pos_x, int pos_y, int erasersize_x, int erasersize_y)
        {
            
            Rectangle rect = new Rectangle(pos_x, pos_y, erasersize_x, erasersize_y);
            function = Graphics.FromImage(pic);
            GraphicsPath p = new GraphicsPath();
            p.StartFigure();
            //rectangle.DrawRectangle(new Pen(Color.Black),
            function.DrawRectangle(new Pen(Color.White), pos_x, pos_y, erasersize_x, erasersize_y);
            function.FillRectangle(new SolidBrush(Color.White), pos_x, pos_y, erasersize_x, erasersize_y);
            p.AddRectangle(rect);
            
            return pic;
        }

        public Image pencil_function(Image pic, Point temp, int pos_x, int pos_y, Color chosen)
        {
            function = Graphics.FromImage(pic);
            function.DrawLine(new Pen(chosen), temp.X, temp.Y, pos_x, pos_y);
            return pic;
        }

        public Image paint_function(Image pic, Point temp, int pos_x, int pos_y, Color chosen)
        {
            function = Graphics.FromImage(pic);
            function.DrawLine(new Pen(chosen, 5), temp.X, temp.Y, pos_x, pos_y);
            return pic;
        }

        public Image line_function(Image pic, Point initial_pos, int pos_x, int pos_y, Color chosen)
        {
            Image temppic;
            temppic = (Image)pic.Clone();
            function = Graphics.FromImage(temppic);
            function.DrawLine(new Pen(chosen), initial_pos.X, initial_pos.Y, pos_x, pos_y);
            return pic;
        }

        public Image show_color_chosen(Image pic, Color chosen)
        {
            Graphics colorbox = Graphics.FromImage(pic);
            colorbox.DrawRectangle(new Pen(chosen), 22, 7, 50, 35);
            colorbox.FillRectangle(new SolidBrush(chosen), 22, 7, 50, 35);
            return pic;
        }
        
        //So, Jeff made it to where this creates a square, only problem was it made multiple squares
        //I fixed it by creating a clone of the image being sent in and then everytime it comes into this function
        //it is using the fresh pic, which is what we want to do.
        public Image rectangle_function(Image pic, Point initial_pos, int pos_x, int pos_y, Color chosen, bool filled)
        {
            Image temppic;
            temppic = (Image) pic.Clone();
            function = Graphics.FromImage(temppic);
            int width = pos_x - initial_pos.X;
            int heigth = pos_y - initial_pos.Y;
            if (width < 0 && heigth < 0)
            {
                width = initial_pos.X - pos_x;
                heigth = initial_pos.Y - pos_y;
                function.DrawRectangle(new Pen(chosen), pos_x, pos_y, width, heigth);
                if (filled)
                    function.FillRectangle(new SolidBrush(chosen), pos_x, pos_y, width, heigth);
            }
            else if (heigth < 0)
            {
                heigth = initial_pos.Y - pos_y;
                function.DrawRectangle(new Pen(chosen), initial_pos.X, pos_y, width, heigth);
                if (filled)
                    function.FillRectangle(new SolidBrush(chosen), initial_pos.X, pos_y, width, heigth);
            }
            else if (width < 0)
            {
                width = initial_pos.X - pos_x;
                function.DrawRectangle(new Pen(chosen), pos_x, initial_pos.Y, width, heigth);
                if (filled)
                    function.FillRectangle(new SolidBrush(chosen), pos_x, initial_pos.Y, width, heigth);
            }
            else
            {
                function.DrawRectangle(new Pen(chosen), initial_pos.X, initial_pos.Y, width, heigth);
                if (filled)
                    function.FillRectangle(new SolidBrush(chosen), initial_pos.X, initial_pos.Y, width, heigth);
            }
            return temppic;
        }

        public Image circle_function(Image pic, Point initial_pos, int pos_x, int pos_y, Color chosen)
        {
            Image temppic = (Image) pic.Clone();
            int width = pos_x - initial_pos.X;
            int height = pos_y - initial_pos.Y;
            function = Graphics.FromImage(temppic);
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
                rect = new Rectangle(initial_pos.X, pos_y, width, height);
            }
            else if (width < 0)
            {
                width = initial_pos.X - pos_x;
                rect = new Rectangle(pos_x, initial_pos.Y, width, height);
            }
            else
            {
                rect = new Rectangle(initial_pos.X, initial_pos.Y, width, height);
            }

            function.DrawEllipse(new Pen(chosen), rect);
            return temppic;
        }

        public Image drawCalibration(WiimoteState ws, Image pic)
        {
            
            g = Graphics.FromImage(pic);
            // draw ellipse at center of bitmap for calibration;
             g.DrawEllipse(new Pen(Color.Red), (320), (240), 20, 20);

            // prompt the user 
            // how do i do this????
             return pic;
        }

    }
}
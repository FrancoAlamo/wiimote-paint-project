using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using WiimoteLib;



namespace PaintProgram
{
     //ACTIONS:
    //0) Cursor Points
    //1) CUT
    //2) ZOOM
    //3) ERASER
    //4) BUCKET
    //5) SQUARE
    //6) PENCIL

    class Glove
    {
        //scaling stuff
        const int WIIMOTE_RAW_X = 1023; //values reported according to Wiili
        const int WIIMOTE_RAW_Y = 767;
        int x_dim = 640, y_dim = 480;       //dimensions of image
        float scale_x = 640 / WIIMOTE_RAW_X, scale_y = 480 / WIIMOTE_RAW_Y; 
        WiimoteState ws = new WiimoteState();
        //actual wiimote stuff
        float pos1x, pos2x;
        float pos1y, pos2y;
        //glove stuff for actions
        int action;
        bool clicked;
        int actionSizeX, actionSizeY;
        // graphics stuff
        Graphics g;
        Graphics circle, eraser, pencil, rectangle;  // Makes the eraser pencil and rectangle graphics which will later 
        Image pic;                                  // be a square used to perform each function
        Bitmap b = new Bitmap(1, 1, PixelFormat.Format24bppRgb); // creates pretty much an empty Bitmap to be able to later create graphics
        Bitmap pixel = new Bitmap(100, 200);
        Color pen;
        
     
        //constructors
        public Glove(string hand, Image picture, int actSizeX, int actSizeY, Color penc)
        {
            if (hand == "right")
            {
                pos1x = ws.IRState.RawX1 * scale_x;
                pos2x = ws.IRState.RawX2 * scale_x;
                pos1y = ws.IRState.RawY1 * scale_y;
                pos2y = ws.IRState.RawY2 * scale_y;
            }

            if (hand == "left")
            {
                pos1x = ws.IRState.RawX3 * scale_x;
                pos2x = ws.IRState.RawX4 * scale_x;
                pos1y = ws.IRState.RawY3 * scale_y;
                pos2y = ws.IRState.RawY4 * scale_y;
            }

            graphicsLib gloveActions = new graphicsLib(x_dim, y_dim, b);
            actionSizeX = actSizeX;
            actionSizeY = actSizeY;
            pic = picture;
            pen = penc;
            action = 0;
            clicked = false;
        }

        //get action
        public int getAction()
        {
            return action;
        }

        //get clicked
        public bool getClicked()
        {
            return clicked;
        }

        //return cursor distance
        public float cursorDistance()
        {
            float dx = pos1x - pos2x;
            float dy = pos1y - pos2y;

            return (float) Math.Sqrt((double) dx*dx + (double) dy*dy);
        }

        //update position
        public void doAction()
        {
            b = Bitmap drawCursorPoints(ws);
            switch (action)
            {
              
                        
                case 1:  Image cut_function(pic, pos1x, pos1y, actionSizeX, actionsizeY);
                         break;
                default: break;
            }
        }
    }
}

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

    class Glove
    {
        //stuff because you guys used unnecessary classes in your function definition
        Point Unnec;
        //scaling stuff
        const int WIIMOTE_RAW_X = 1023; //values reported according to Wiili
        const int WIIMOTE_RAW_Y = 767;
        int x_dim = 640, y_dim = 480;       //dimensions of image
        int scale_x = 640 / WIIMOTE_RAW_X, scale_y = 480 / WIIMOTE_RAW_Y; 
        //actual wiimote stuff
        WiimoteState ws = new WiimoteState();
        int pos1x, pos2x;
        int pos1y, pos2y;
        //glove stuff for actions
        int action;
        bool clicked;
        int actionSizeX = 0; 
        int actionSizeY = 0;
        // graphics stuff
        Graphics g;
        Graphics circle, eraser, pencil, rectangle;  // Makes the eraser pencil and rectangle graphics which will later 
        Image pic;                                  // be a square used to perform each function
        Bitmap b = new Bitmap(1, 1, PixelFormat.Format24bppRgb); // creates pretty much an empty Bitmap to be able to later create graphics
        Bitmap pixel = new Bitmap(100, 200);
        Color pen;
        graphicsLib gloveActions;
        
     
        //constructors
        public Glove(string hand, Image picture, int actSizeX, int actSizeY, Color penc)
        {
            if (hand == "right")
            {
                pos1x =  ws.IRState.RawX1 * scale_x;
                pos2x =  ws.IRState.RawX2 * scale_x;
                pos1y =  ws.IRState.RawY1 * scale_y;
                pos2y =  ws.IRState.RawY2 * scale_y;
            }

            if (hand == "left")
            {
                pos1x =  ws.IRState.RawX3 * scale_x;
                pos2x =  ws.IRState.RawX4 * scale_x;
                pos1y =  ws.IRState.RawY3 * scale_y;
                pos2y =  ws.IRState.RawY4 * scale_y;
            }

            gloveActions = new graphicsLib(x_dim, y_dim, b);
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
            //ACTIONS:
            //0) Cursor Points
            //1) CUT done
            //2) ZOOM
            //3) ERASER done
            //4) BUCKET
            //5) SQUARE done
            //6) PENCIL done
            //7) CIRCLE done
            b = gloveActions.drawCursorPoints(ws);
            switch (action)
            {
               //circle_function(Image pic, Point initial_pos, int pos_x, int pos_y, Color chosen)
               //done Image rectangle_function(Image pic, Point initial_pos, int pos_x, int pos_y, Color chosen)    
               //Image pencil_function(Image pic, Point temp, int pos_x, int pos_y, Color chosen)
               //done Image eraser_function(Image pic, Point temp, int pos_x, int pos_y, int erasersize_x, int erasersize_y)
                case 1: gloveActions.cut_function(pic, pos1x, pos1y, actionSizeX, actionSizeY); break;
                case 3: gloveActions.eraser_function(pic, Unnec, pos1x, pos1y, actionSizeX, actionSizeY); break; 
                case 5: gloveActions.rectangle_function(pic, Unnec, pos1x, pos1y, pen); break;
                case 6: gloveActions.pencil_function(pic, Unnec, pos1x, pos1y, pen); break;
                case 7: gloveActions.circle_function(pic, Unnec, pos1x, pos1y, pen); break;
                default: break;
            }
        }
    }
}

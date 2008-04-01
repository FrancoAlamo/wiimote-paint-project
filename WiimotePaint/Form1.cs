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
using System.Runtime.InteropServices; 
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using WiimoteLib;

namespace PaintProgram
{

    public partial class Form1 : Form
    {
        private delegate void UpdateWiimoteStateDelegate(WiimoteChangedEventArgs args);
        private delegate void UpdateExtensionChangedDelegate(WiimoteExtensionChangedEventArgs args);

        //calibration variable set to false only upon entering for the first time
        //bool calibration = false;
        //int offset_x = 0;  // set calibration offsets after ellipses have been drawn
        //int offset_y = 0;

        Graphics eraser;  
        public static int k = 0;
        public int flag;
        public Color chosen = Color.Black;
        public static int erasersize_x, erasersize_y;         
        private Point initial_pos;  //Initial position for LED's 1 and 2
        private Point initial_pos2; //Initial position for LED's 3 and 4
        private Point temp_pos;     //Hold temporary position for LED's 1 and 2
        private Point temp_pos2;    //Hold temporary position for LED's 3 and 4
        Bitmap initial_b, current_b, initial_b2, current_b2;
        bool eraser_click = false;
        bool line_click = false;
        bool fill_click = false;
        bool cut_click = false;
        bool Paintbrush_click = false;
        bool rectangle_click = false;
        bool pencil_click = false;
        bool circle_click = false;
        bool calibration_click = false;
        bool mouseemulation = false;
        bool Colorboxclick = false;
        bool filledrect; // True if rectangle chosen is the fill one

        public const int MOUSEEVENTF_MOVE = 0x01;
        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;
        public const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        public const int MOUSEEVENTF_RIGHTUP = 0x10;
        public const int MOUSEEVENTF_MIDDLEDOWN = 0x20;
        public const int MOUSEEVENTF_MIDDLEUP = 0x40;
        public const int MOUSEEVENTF_ABSOLUTE = 0x8000;

        [DllImport("user32.dll")]
        private static extern void mouse_event(
        long dwFlags, // motion and click options
        long dx, // horizontal position or change
        long dy, // vertical position or change
        long dwData, // wheel movement
        long dwExtraInfo // application-defined information
        );

        static int enter = 0;
        string CurrentFile; // Takes the path from the currently saved or opened file        
        
        Wiimote wm = new Wiimote();
        WiimoteState globalWs;

        Bitmap pixel = new Bitmap(50, 35);
        Bitmap b;
        Graphics g;
        graphicsLib colorbox = new graphicsLib();
        graphicsLib g_lib;

        double separation;   // separation between LED1 and LED2
        double separation2;  // separation between LED3 and LED4
        bool OutofPicBox = false;        
        bool wasSeparated = true;  // Set to True if LED1 and LED2 were separated
        bool wasSeparated2 = true; // Set to True if LED3 and LED4 were separated
        

        public Form1()
        {
            InitializeComponent();
            pb_image2.Size = panel1.Size;
            default_clicks();
            eraser1_panel.ForeColor = Color.Blue;
            eraser1_panel.BackColor = Color.DarkBlue;
            RectUnfilledPnl.ForeColor = Color.Blue;
            RectUnfilledPnl.BackColor = Color.DarkBlue;
            erasersize_x = 4;
            erasersize_y = 4;
            pb_colors.Image = colorbox.show_color_chosen(pixel, Color.Black);
        }

        public void default_clicks()
        {
            eraser_click = false;
            line_click = false;
            Paintbrush_click = false;
            fill_click = false;
            cut_click = false;
            calibration_click = false;
            rectangle_click = false;
            circle_click = false;
            pencil_click = false;
            eraser_box.Visible = false;
            RectangleGrpBox.Visible = false;
            Eraser_btn.FlatStyle = FlatStyle.Standard;
            Line_btn.FlatStyle = FlatStyle.Standard;
            Fill_btn.FlatStyle = FlatStyle.Standard;
            Cut_btn.FlatStyle = FlatStyle.Standard;
            Rectangle_btn.FlatStyle = FlatStyle.Standard;
            Pencil_btn.FlatStyle = FlatStyle.Standard;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            wm.WiimoteChanged += new WiimoteChangedEventHandler(wm_WiimoteChanged);
            b = new Bitmap(800, 600);
            g_lib = new graphicsLib(1280, 800, b);
            g = Graphics.FromImage(b);
            wm.Connect();
            wm.SetReportType(Wiimote.InputReport.IRAccel, true);
            wm.SetLEDs(false, true, true, false);


        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            default_clicks();
            pb_image2.SizeMode = PictureBoxSizeMode.AutoSize;
            pb_image2.Height = b.Height;
            pb_image2.Width = b.Width;
            pb_image2.Image = b;
            eraser1_panel.ForeColor = Color.Blue;
            eraser1_panel.BackColor = Color.DarkBlue;
            erasersize_x = 4;
            erasersize_y = 4;
            RectUnfilledPnl.ForeColor = Color.Blue;
            RectUnfilledPnl.BackColor = Color.DarkBlue;
            pb_colors.Image = colorbox.show_color_chosen(pixel, Color.Black);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e) { }

        private void Open_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Open Image File";
            openFileDialog1.InitialDirectory = "C:\\Documents and Settings";
            openFileDialog1.AddExtension = true;
            openFileDialog1.DefaultExt = "bmp";
            openFileDialog1.Filter = "Bitmap Files (*.bmp)|*.bmp|JPEG Images (*.jpg,*.jpeg)|*.jpg;*.jpeg||";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();

            if (openFileDialog1.FileName == "")
                return;

            pb_image2.SizeMode = PictureBoxSizeMode.StretchImage;
            CurrentFile = openFileDialog1.FileName.ToString();
            b = (Bitmap)Bitmap.FromFile(openFileDialog1.FileName);
            pb_image2.ClientSize = new Size((b.Width), (b.Height));
            pb_image2.Height = b.Height;
            pb_image2.Width = b.Width;
            pb_image2.Image = b;
            panel1.Height = b.Height + (b.Height / 2);
            panel1.Width = b.Width + (b.Width / 2);
            panel1.CreateGraphics();
        }

        //When Save As is clicked, then the Save as dialog is opened where the user can choose what to name
        //the file
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = "C:\\Documents and Settings";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.DefaultExt = "jpg";
            saveFileDialog1.Filter = "Bitmap Files (*.bmp)|*.bmp|JPEG Images (*.jpg)|*.jpg;*.jpeg||";
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.FileName = "";
            saveFileDialog1.ShowDialog();

            // if no file name is given, then clicking save will do nothing until user enters a filename
            if (saveFileDialog1.FileName == "")
                return;
            //save the name of the file chosen in order to use it later with save or any other function
            CurrentFile = saveFileDialog1.FileName.ToString();
            //display the image onto pb_image2
            pb_image2.Image.Save(CurrentFile);

        }

        //When Save is clicked, it will save the file to the current file opened, if a new file, then
        //will prompt the user to choose a filename and save
        private void Save_Click(object sender, EventArgs e)
        {

            saveFileDialog1.InitialDirectory = "C:\\Documents and Settings";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.DefaultExt = "jpg";
            saveFileDialog1.Filter = "Bitmap Files (*.bmp)|*.bmp|JPEG Images (*.jpg)|*.jpg;*.jpeg||";
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.FileName = "";
            //if a new file, then prompt the user to choose a filename to save to
            if (CurrentFile == "")
            {
                saveFileDialog1.ShowDialog();
                CurrentFile = saveFileDialog1.FileName.ToString();
            }

            pb_image2.Image.Save(CurrentFile);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            openFileDialog1.OpenFile();
        }


        //Gives color to the menu bar
        private void pb_image2_Paint(object sender, PaintEventArgs e)
        {
            fileToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            editToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            viewToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            aboutToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            aboutToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {

        }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void saveFileDialog1_FileOk(object sender, EventArgs e) { }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            mouseemulation = true;
            about.ShowDialog();
            mouseemulation = false;
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }

        //Following four "functions" display a little message when the user hovers over the button

        private void Cut_btn_MouseHover(object sender, EventArgs e)
        {
            enter += 1;
            if (enter == 5)
            {
                Cut_btn.Click += new EventHandler(Cut_btn_Click);

                enter = 0;
            }
            toolTip1.SetToolTip(this.Cut_btn, "Cut Tool");

        }

        private void Line_btn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.Line_btn, "Draw Line Tool");
        }

        private void Eraser_btn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.Eraser_btn, "Eraser Tool");
        }

        private void Fill_btn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.Fill_btn, "Fill Tool");
        }


        // Just a temporary fill funtction. Just messing around with it at the moment
        private void Fill_btn_Click(object sender, EventArgs e)
        {
            default_clicks();
            Fill_btn.FlatStyle = FlatStyle.Flat;
            fill_click = true;
            //      Color chosen;
            //      colorDialog1.ShowDialog();
            //      chosen = colorDialog1.Color;
            eraser_box.Visible = false;
            /*try
            {
                // Retrieve the image.
                //   image1 = new Bitmap(@"C:\Documents and Settings\All Users\" 
                //       + @"Documents\My Music\music.bmp", true);

                int x, y;

                // Loop through the images pixels to reset color.
                for (x = 0; x < b.Width; x++)
                {
                    for (y = 0; y < b.Height; y++)
                    {
                        Color pixelColor = b.GetPixel(x, y);
                        Color newColor = Color.FromArgb(pixelColor.G, pixelColor.G, 12);
                        b.SetPixel(x, y, newColor);
                    }
                }

                // Set the PictureBox to display the image.
                pb_image2.Image = b;

                // Display the pixel format in Label1.
                //Label1.Text = "Pixel format: "+image1.PixelFormat.ToString();

            }
            catch (ArgumentException)
            {
                MessageBox.Show("There was an error." +
                   "Check the path to the image file.");
            }*/
        }

        private void Eraser_btn_Click(object sender, EventArgs e)
        {
            default_clicks();
            eraser1_panel.Visible = true;
            eraser2_panel.Visible = true;
            eraser3_panel.Visible = true;
            eraser4_panel.Visible = true;
            eraser_box.Visible = true;
            Eraser_btn.FlatStyle = FlatStyle.Flat;
            eraser_click = true;
            eraser = Graphics.FromImage(b);
        }

        private void Line_btn_Click(object sender, EventArgs e)
        {            
            default_clicks();
            Line_btn.FlatStyle = FlatStyle.Flat;
            line_click = true;
        }

        private void PaintBrushBtn_MouseClick(object sender, MouseEventArgs e)
        {
            default_clicks();
            PaintBrushBtn.FlatStyle = FlatStyle.Flat;
            Paintbrush_click = true;
        }

        private void Cut_btn_Click(object sender, EventArgs e)
        {
            default_clicks();
            cut_click = true;
            Cut_btn.FlatStyle = FlatStyle.Flat;
        }


        private void rectangle_btn_Click(object sender, EventArgs e)
        {
            default_clicks();
            RectUnfilledPnl.Visible = true;
            RectFilledPnl.Visible = true;
            RectangleGrpBox.Visible = true;
            rectangle_click = true;
            Rectangle_btn.FlatStyle = FlatStyle.Flat;
        }

        private void pencil_btn_Click(object sender, EventArgs e)
        {
            default_clicks();
            pencil_click = true;
            Pencil_btn.FlatStyle = FlatStyle.Flat;
        }
        private void Circle_btn_Click(object sender, EventArgs e)
        {
            default_clicks();
            circle_click = true;
            Circle_btn.FlatStyle = FlatStyle.Flat;
        }

        // The following four "functions" highlight the chosen eraser blue and keep the other ones lightgray
        // also sets the size of the eraser
        private void eraser1_panel_MouseClick(object sender, MouseEventArgs e)
        {
            eraser2_panel.ForeColor = Color.LightGray;
            eraser2_panel.BackColor = Color.LightGray;
            eraser3_panel.ForeColor = Color.LightGray;
            eraser3_panel.BackColor = Color.LightGray;
            eraser4_panel.ForeColor = Color.LightGray;
            eraser4_panel.BackColor = Color.LightGray;
            eraser1_panel.ForeColor = Color.Blue;
            eraser1_panel.BackColor = Color.DarkBlue;
            erasersize_x = 4;
            erasersize_y = 4;
        }

        private void eraser2_panel_MouseClick(object sender, MouseEventArgs e)
        {
            eraser1_panel.ForeColor = Color.LightGray;
            eraser1_panel.BackColor = Color.LightGray;
            eraser3_panel.ForeColor = Color.LightGray;
            eraser3_panel.BackColor = Color.LightGray;
            eraser4_panel.ForeColor = Color.LightGray;
            eraser4_panel.BackColor = Color.LightGray;
            eraser2_panel.ForeColor = Color.Blue;
            eraser2_panel.BackColor = Color.DarkBlue;
            erasersize_x = 7;
            erasersize_y = 7;
        }

        private void eraser3_panel_MouseClick(object sender, MouseEventArgs e)
        {
            eraser1_panel.ForeColor = Color.LightGray;
            eraser1_panel.BackColor = Color.LightGray;
            eraser2_panel.ForeColor = Color.LightGray;
            eraser2_panel.BackColor = Color.LightGray;
            eraser4_panel.ForeColor = Color.LightGray;
            eraser4_panel.BackColor = Color.LightGray;
            eraser3_panel.ForeColor = Color.Blue;
            eraser3_panel.BackColor = Color.DarkBlue;
            erasersize_x = 9;
            erasersize_y = 9;
        }

        private void eraser4_panel_MouseClick(object sender, MouseEventArgs e)
        {
            eraser1_panel.ForeColor = Color.LightGray;
            eraser1_panel.BackColor = Color.LightGray;
            eraser2_panel.ForeColor = Color.LightGray;
            eraser2_panel.BackColor = Color.LightGray;
            eraser3_panel.ForeColor = Color.LightGray;
            eraser3_panel.BackColor = Color.LightGray;
            eraser4_panel.ForeColor = Color.Blue;
            eraser4_panel.BackColor = Color.DarkBlue;
            erasersize_x = 12;
            erasersize_y = 12;
        }

        private void RectUnfilledPnl_MouseClick(object sender, MouseEventArgs e)
        {
            RectFilledPnl.ForeColor = Color.LightGray;
            RectFilledPnl.BackColor = Color.LightGray;
            RectUnfilledPnl.ForeColor = Color.Blue;
            RectUnfilledPnl.BackColor = Color.DarkBlue;
            filledrect = false;
        }

        private void RectFilledPnl_MouseClick(object sender, MouseEventArgs e)
        {
            RectUnfilledPnl.ForeColor = Color.LightGray;
            RectUnfilledPnl.BackColor = Color.LightGray;
            RectFilledPnl.ForeColor = Color.Blue;
            RectFilledPnl.BackColor = Color.DarkBlue;
            filledrect = true;
        }

        private void UpdateWiimoteState(WiimoteChangedEventArgs args)
        {
            WiimoteState ws = args.WiimoteState;
            globalWs = ws;
            graphicsLib g_lib = new graphicsLib();
            //ResizeImage k = new ResizeImage();
            int lastIRStateX = ws.IRState.RawX1;  // Keep last state from LED's 1 and 2
            int lastIRStateY = ws.IRState.RawY1;
            int lastIRStateX2 = ws.IRState.RawX3; // Keep last state from LED's 3 and 4
            int lastIRStateY2 = ws.IRState.RawY3;
            int currentIRstateX;                  // Current IR State of LED's 1 and 2
            int currentIRstateY;
            int currentIRstateX2;                 // Current IR State of LED's 3 and 4
            int currentIRstateY2;
            if (ws.IRState.Found1)
            {
                lastIRStateX = ws.IRState.RawX1;
                lastIRStateY = ws.IRState.RawY1;
                if (ws.IRState.Found2)
                {
                    separation = Math.Sqrt(
                            Math.Pow((ws.IRState.RawX1 - ws.IRState.RawX2), 2) +
                            Math.Pow((ws.IRState.RawY1 - ws.IRState.RawY2), 2));
                    currentIRstateX = (int)((ws.IRState.RawX1 + ws.IRState.RawX2) / 2);
                    currentIRstateY = (int)((ws.IRState.RawY1 + ws.IRState.RawY2) / 2);
                    Seplbl.Text = "Sep: " + separation.ToString();
                }
                else
                {
                    separation = 0;
                    currentIRstateX = ws.IRState.RawX1;
                    currentIRstateY = ws.IRState.RawY1;
                }
            }

            else if (ws.IRState.Found2)
            {
                lastIRStateX = ws.IRState.RawX2;
                lastIRStateY = ws.IRState.RawY2;
                separation = 0;
                currentIRstateX = ws.IRState.RawX2;
                currentIRstateY = ws.IRState.RawY2;
            }
            else
            {
                separation = 0;
                currentIRstateX = lastIRStateX;
                currentIRstateY = lastIRStateY;
            }

            if (ws.IRState.Found3)
            {
                lastIRStateX2 = ws.IRState.RawX3;
                lastIRStateY2 = ws.IRState.RawY3;
                if (ws.IRState.Found4)
                {
                    separation2 = Math.Sqrt(
                            Math.Pow((ws.IRState.RawX3 - ws.IRState.RawX4), 2) +
                            Math.Pow((ws.IRState.RawY3 - ws.IRState.RawY4), 2));
                    currentIRstateX2 = (int)((ws.IRState.RawX3 + ws.IRState.RawX4) / 2);
                    currentIRstateY2 = (int)((ws.IRState.RawY3 + ws.IRState.RawY4) / 2);
                    Testlbl.Text = "Sep: " + separation2.ToString();
                }
                else
                {
                    separation2 = 0;
                    currentIRstateX2 = ws.IRState.RawX3;
                    currentIRstateY2 = ws.IRState.RawY3;
                }
            }

            else if (ws.IRState.Found4)
            {
                lastIRStateX2 = ws.IRState.RawX4;
                lastIRStateY2 = ws.IRState.RawY4;
                separation2 = 0;
                currentIRstateX2 = ws.IRState.RawX4;
                currentIRstateY2 = ws.IRState.RawY4;
            }
            else
            {
                separation2 = 0;
                currentIRstateX2 = lastIRStateX2;
                currentIRstateY2 = lastIRStateY2;
            }

            //if (false == OutofPicBox)
            //System.Windows.Forms.Cursor.Position = new System.Drawing.Point((currentIRstateX), (currentIRstateY));
            if (currentIRstateX <= 142)
            {
                currentIRstateX = (int)currentIRstateX * (1280 / 1023);
                currentIRstateY = (int)currentIRstateY * (800 / 767);
                Cursor.Position = new System.Drawing.Point(currentIRstateX, currentIRstateY);
                mouseemulation = true;
            }
            else
            {
                if (Colorboxclick == false)
                {
                    pb_image2.Image = g_lib.drawCursorPoints(ws, b);
                    mouseemulation = false;
                }
                else
                {
                    currentIRstateX = (int)currentIRstateX * (1280 / 1023);
                    currentIRstateY = (int)currentIRstateY * (800 / 767);
                    Cursor.Position = new System.Drawing.Point(currentIRstateX, currentIRstateY);
                }
            }

            //else
            //  System.Windows.Forms.Cursor.Position = new System.Drawing.Point((currentIRstateX), (currentIRstateY));
                       
            Seplbl.Text = "Sep: " + separation.ToString();
            
            lastIRStateX = currentIRstateX;   //Saves values in the case that both LED's (1 and 2) are missing
            lastIRStateY = currentIRstateY;
            lastIRStateX2 = currentIRstateX2; //Saves values in the case that both LED's (3 and 4) are missing
            lastIRStateY2 = currentIRstateY2;
            /*
            if (offset_x == 0 && offset_y == 0)
            {
                //draw calibration circle
                if(flag != 1)
                    pb_image2.Image = g_lib.drawCalibration(ws, b);
                flag = 1;
            }

            if (calibration_click == true)
            {   
                
                    //300 is half the size of the bitmap in the x direction 400 in the y
                    offset_x = currentIRstateX - 320;
                    offset_y = currentIRstateY - 240;
                    Testlbl.Text = offset_x.ToString();
                    Test2lbl.Text = offset_y.ToString();
                    //never set calibration to false again
                    calibration_click = false;
                    b = new Bitmap(800, 600);
                    pb_image2.Image = b;
            }
            */
            if (currentIRstateX > currentIRstateX2)
            {
                currentIRstateX = currentIRstateX2;
                currentIRstateX2 = lastIRStateX;
                currentIRstateY = currentIRstateY2;
                currentIRstateY2 = lastIRStateY;
            }

            if (separation > 80 && mouseemulation == false)
            {
                if (eraser_click)
                {
                    if (wasSeparated)
                    {
                        temp_pos.X = currentIRstateX - 142; temp_pos.Y = currentIRstateY;
                        pb_image2.Image = g_lib.eraser_function(b, temp_pos, (currentIRstateX - 143), (currentIRstateY - 1), erasersize_x, erasersize_y);
                    }
                    else
                    {
                        pb_image2.Image = g_lib.eraser_function(b, temp_pos, (currentIRstateX - 142), (currentIRstateY), erasersize_x, erasersize_y);
                        temp_pos.X = currentIRstateX - 142; temp_pos.Y = currentIRstateY;
                    }
                }

                else if (pencil_click)
                {
                    if (wasSeparated)
                    {
                        temp_pos.X = currentIRstateX - 142; temp_pos.Y = currentIRstateY;
                        pb_image2.Image = g_lib.pencil_function(b, temp_pos, (currentIRstateX - 143), (currentIRstateY - 1), chosen);
                    }
                    else
                    {
                        pb_image2.Image = g_lib.pencil_function(b, temp_pos, (currentIRstateX - 142), (currentIRstateY), chosen);
                        temp_pos.X = currentIRstateX - 142; temp_pos.Y = currentIRstateY;
                    }
                }

                else if (Paintbrush_click)
                {
                    if (wasSeparated)
                    {
                        temp_pos.X = currentIRstateX - 142; temp_pos.Y = currentIRstateY;
                        pb_image2.Image = g_lib.paint_function(b, temp_pos, (currentIRstateX - 143), (currentIRstateY - 1), chosen);
                    }
                    else
                    {
                        pb_image2.Image = g_lib.paint_function(b, temp_pos, (currentIRstateX - 142), (currentIRstateY), chosen);
                        temp_pos.X = currentIRstateX - 142; temp_pos.Y = currentIRstateY;
                    }
                }

                else if (line_click)
                {
                    if (wasSeparated)
                    {
                        initial_b = new Bitmap(b);
                        initial_pos.X = currentIRstateX - 142; initial_pos.Y = currentIRstateY;
                        pb_image2.Image = g_lib.line_function(initial_b, initial_pos, currentIRstateX - 143, currentIRstateY, chosen);
                    }
                    else
                    {
                        current_b = initial_b;
                        pb_image2.Image = g_lib.line_function(initial_b, initial_pos, currentIRstateX - 142, currentIRstateY, chosen);
                    }
                }

                else if (rectangle_click)
                {
                    if (wasSeparated)
                    {
                        initial_b = new Bitmap(b);
                        initial_pos.X = currentIRstateX - 142; initial_pos.Y = currentIRstateY;
                        pb_image2.Image = g_lib.rectangle_function(initial_b, initial_pos, currentIRstateX - 142, currentIRstateY, chosen, filledrect);
                    }
                    else
                    {
                        current_b = initial_b;
                        pb_image2.Image = g_lib.rectangle_function(initial_b, initial_pos, currentIRstateX - 142, currentIRstateY, chosen, filledrect);
                    }
                }

                else if (circle_click)
                {
                    if (wasSeparated)
                    {
                        initial_b = new Bitmap(b);
                        initial_pos.X = currentIRstateX - 142; initial_pos.Y = currentIRstateY;
                        pb_image2.Image = g_lib.circle_function(initial_b, initial_pos, currentIRstateX - 142, currentIRstateY, chosen);
                    }
                    else
                    {
                        current_b = initial_b;
                        pb_image2.Image = g_lib.circle_function(initial_b, initial_pos, currentIRstateX - 142, currentIRstateY, chosen);
                    }
                }
                wasSeparated = false;
                //end
                //}
            }
            else if (separation > 80 && mouseemulation == true)//outside picturebox
            {
                mouse_event(MOUSEEVENTF_LEFTDOWN, currentIRstateX, currentIRstateY, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, currentIRstateX, currentIRstateY, 0, 0);
                wasSeparated = false;
            }
            else
            {
                if (rectangle_click)
                {
                    if (!wasSeparated)
                    {
                        b = (Bitmap)g_lib.rectangle_function(b, initial_pos, currentIRstateX - 142, currentIRstateY, chosen, filledrect);
                        pb_image2.Image = b;
                    }
                }
                else if (circle_click)
                {
                    if (!wasSeparated)
                    {
                        b = (Bitmap)g_lib.circle_function(b, initial_pos, currentIRstateX - 142, currentIRstateY, chosen);
                        pb_image2.Image = b;
                    }
                }
                else if (line_click)
                {
                    if (!wasSeparated)
                    {
                        b = (Bitmap)g_lib.line_function(b, initial_pos, currentIRstateX - 142, currentIRstateY, chosen);
                        pb_image2.Image = b;
                    }
                }

                wasSeparated = true;
            }
            if (separation2 > 80)
            {
                if (eraser_click)
                {
                    if (wasSeparated2)
                    {
                        temp_pos2.X = currentIRstateX2; temp_pos2.Y = currentIRstateY2;
                        pb_image2.Image = g_lib.eraser_function(b, temp_pos2, (currentIRstateX2 - 1), (currentIRstateY2 - 1), erasersize_x, erasersize_y);
                    }
                    else
                    {
                        pb_image2.Image = g_lib.eraser_function(b, temp_pos2, (currentIRstateX2), (currentIRstateY2), erasersize_x, erasersize_y);
                        temp_pos2.X = currentIRstateX2; temp_pos2.Y = currentIRstateY2;
                    }
                }

                else if (pencil_click)
                {
                    if (wasSeparated2)
                    {
                        temp_pos2.X = currentIRstateX2; temp_pos2.Y = currentIRstateY2;
                        pb_image2.Image = g_lib.pencil_function(b, temp_pos2, (currentIRstateX2 - 1), (currentIRstateY2 - 1), chosen);
                    }
                    else
                    {
                        pb_image2.Image = g_lib.pencil_function(b, temp_pos2, (currentIRstateX2), (currentIRstateY2), chosen);
                        temp_pos2.X = currentIRstateX2 - 142; temp_pos2.Y = currentIRstateY2;
                    }
                }

                else if (Paintbrush_click)
                {
                    if (wasSeparated2)
                    {
                        temp_pos2.X = currentIRstateX2; temp_pos2.Y = currentIRstateY2;
                        pb_image2.Image = g_lib.paint_function(b, temp_pos2, (currentIRstateX2 - 1), (currentIRstateY2 - 1), chosen);
                    }
                    else
                    {
                        pb_image2.Image = g_lib.paint_function(b, temp_pos2, (currentIRstateX2), (currentIRstateY2), chosen);
                        temp_pos2.X = currentIRstateX2; temp_pos2.Y = currentIRstateY2;
                    }
                }

                else if (line_click)
                {
                    if (wasSeparated2)
                    {
                        initial_b2 = new Bitmap(b);
                        initial_pos2.X = currentIRstateX2; initial_pos2.Y = currentIRstateY2;
                        pb_image2.Image = g_lib.line_function(initial_b2, initial_pos2, currentIRstateX2, currentIRstateY2, chosen);
                    }
                    else
                    {
                        current_b2 = initial_b2;
                        pb_image2.Image = g_lib.line_function(initial_b2, initial_pos2, currentIRstateX2, currentIRstateY2, chosen);
                    }
                }
            }
            else
                wasSeparated2 = true;


        }

        private void wm_WiimoteChanged(object sender, WiimoteChangedEventArgs args)
        {
            BeginInvoke(new UpdateWiimoteStateDelegate(UpdateWiimoteState), args);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            wm.Disconnect();
        }

        private void pb_colors_Click(object sender, EventArgs e)
        {
            Colorboxclick = true;
            mouseemulation = true;
            colorDialog1.ShowDialog();
            chosen = colorDialog1.Color;
            pb_colors.Image = colorbox.show_color_chosen(pixel, chosen);
            Colorboxclick = false;
        }

        private void pb_image2_MouseEnter(object sender, EventArgs e)
        {
            OutofPicBox = false;
        }

        private void pb_image2_MouseLeave(object sender, EventArgs e)
        {
            OutofPicBox = true;
        }

        private void RectangleGrpBox_Enter(object sender, EventArgs e)
        {

        }






    }
}
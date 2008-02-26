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

        /*--------------------------------------------------------------
        //Franco: let's work on a way to declare these somewhere else
         * Possibly in Form1.Designer.cs?
        ---------------------------------------------------------------*/

        Graphics eraser;  // Makes the eraser graphics which will later be a square used to erase
        public static int k = 0;
        public Color chosen = Color.Black;
        public static int erasersize_x, erasersize_y; // Depending on what size eraser they choose, sets width and height
        private static bool mouse_is_down = false;
        private Point mouse_pos;
        private Point initial_pos;
        private Point temp_pos;
        Bitmap initial_b, current_b;
        bool eraser_click = false;
        bool magnify_click = false;
        bool fill_click = false;
        bool cut_click = false;
        bool rectangle_click = false;
        bool pencil_click = false;
        bool circle_click = false;
        string CurrentFile; // Takes the path from the currently saved or opened file
        Image img;
        // Bitmap b = new Bitmap(1, 1, PixelFormat.Format24bppRgb); // creates pretty much an empty Bitmap to be able to later create graphics
        Bitmap pixel = new Bitmap(50, 35);
        Wiimote wm = new Wiimote();
        Bitmap b = new Bitmap(640, 480);
        Graphics g;
        graphicsLib colorbox = new graphicsLib();
        graphicsLib g_lib = new graphicsLib(640, 480);

        public Form1()
        {
            InitializeComponent();
            pb_image2.Size = panel1.Size;
            default_clicks();
            eraser1_panel.ForeColor = Color.Blue;
            eraser1_panel.BackColor = Color.DarkBlue;
            erasersize_x = 4;
            erasersize_y = 4;
            pb_colors.Image = colorbox.show_color_chosen(pixel, Color.Black);
        }

        public void default_clicks()
        {
            eraser_click = false;
            magnify_click = false;
            fill_click = false;
            cut_click = false;
            rectangle_click = false;
            circle_click = false;
            pencil_click = false;
            eraser_box.Visible = false;
            Eraser_btn.FlatStyle = FlatStyle.Standard;
            Magnify_btn.FlatStyle = FlatStyle.Standard;
            Fill_btn.FlatStyle = FlatStyle.Standard;
            Cut_btn.FlatStyle = FlatStyle.Standard;
            Rectangle_btn.FlatStyle = FlatStyle.Standard;
            Pencil_btn.FlatStyle = FlatStyle.Standard;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //wm.WiimoteChanged += new WiimoteChangedEventHandler(wm_WiimoteChanged);
            //g_lib = new graphicsLib(640, 480, b); //todo: set with method
            //g = Graphics.FromImage(b);
            //wm.Connect();
            //wm.SetReportType(Wiimote.InputReport.IRAccel, true);
            //wm.SetLEDs(false, true, true, false);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            default_clicks();
            b = new Bitmap(640, 480);
            pb_image2.SizeMode = PictureBoxSizeMode.AutoSize;
            pb_image2.Height = b.Height;
            pb_image2.Width = b.Width;
            pb_image2.Image = b;
            eraser1_panel.ForeColor = Color.Blue;
            eraser1_panel.BackColor = Color.DarkBlue;
            erasersize_x = 4;
            erasersize_y = 4;
            pb_colors.Image = colorbox.show_color_chosen(pixel, Color.Black);
        }

        private void Open_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Open Image File";
            openFileDialog1.InitialDirectory = "C:\\Documents and Settings\\EE464\\My Documents\\My Pictures";
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
            saveFileDialog1.InitialDirectory = "C:\\Documents and Settings\\EE464\\My Documents\\My Pictures";
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

            saveFileDialog1.InitialDirectory = "C:\\Documents and Settings\\EE464\\My Documents\\My Pictures";
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

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }

        private void pb_image_Click(object sender, EventArgs e)
        {

        }

        private void pb_image2_Click(object sender, EventArgs e)
        {
            mouse_is_down = true;
        }

        private void pb_image_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            mouse_is_down = true;
        }


        //When the image area is clicked, check which tool is chosen and perform the action
        private void pb_image2_MouseClick(object sender, MouseEventArgs e)
        {
            graphicsLib erase = new graphicsLib();
            graphicsLib pencil = new graphicsLib(); ;
            Point current_pos = Control.MousePosition;
            mouse_is_down = true;
            //if the eraser tool is chosen, then call the erase function
            if (eraser_click == true)
            {
                pb_image2.Image = erase.eraser_function(b, temp_pos, (e.X - 6), (e.Y - 6), erasersize_x, erasersize_y);
            }
            else if (pencil_click == true)
            {
                pb_image2.Image = pencil.pencil_function(b, temp_pos, e.X, e.Y, chosen);
            }
            else if (cut_click)
            {

            }
            

        }

        private void pb_image2_MouseUp(object sender, MouseEventArgs e)
        {
            graphicsLib shape = new graphicsLib();
            graphicsLib erase = new graphicsLib();
            mouse_is_down = false;
            //This will update the image and allow for the rectangles created to stay on screen
            if (rectangle_click)
            {
                b = (Bitmap)shape.rectangle_function(b, initial_pos, e.X, e.Y, chosen);
                pb_image2.Image = b;
            }
            else if (circle_click)
            {
                b = (Bitmap)shape.circle_function(b, initial_pos, e.X, e.Y, chosen);
                pb_image2.Image = b;
            }
            else if (cut_click)
            {
                
            }
            else if (eraser_click)
            {
                pb_image2.Image = erase.eraser_function(b, temp_pos, (e.X - 6), (e.Y - 6), erasersize_x, erasersize_y);
            }
        }

        //As the mouse moves, keep erasing the area it travels through
        private void pb_image2_MouseMove(object sender, MouseEventArgs e)
        {
            graphicsLib erase = new graphicsLib();
            graphicsLib pencil = new graphicsLib();
            graphicsLib shape = new graphicsLib();
            current_b = initial_b;
            ResizeImage k = new ResizeImage();
            //k.DoResizing(pb_image2.Handle);
            k.Resize_movement(e, pb_image2);
            if (mouse_is_down)
            {
                if (eraser_click)
                {
                    pb_image2.Image = erase.eraser_function(b, temp_pos, (e.X - erasersize_x/2), (e.Y - erasersize_y/2), erasersize_x, erasersize_y);
                    temp_pos.X = e.X+6; temp_pos.Y = e.Y-6;
                }
                else if (pencil_click)
                {
                    pb_image2.Image = pencil.pencil_function(b, temp_pos, (e.X), (e.Y), chosen);
                    temp_pos.X = e.X; temp_pos.Y = e.Y;
                }
                else if (rectangle_click)
                {
                    pb_image2.Image = shape.rectangle_function(initial_b, initial_pos, e.X, e.Y, chosen);
                }
                else if (circle_click)
                {
                    pb_image2.Image = shape.circle_function(initial_b, initial_pos, e.X, e.Y, chosen);
                }
            }
        }

        private void pb_image2_MouseDown(object sender, MouseEventArgs e)
        {
            graphicsLib erase = new graphicsLib();
            graphicsLib pencil = new graphicsLib();
            graphicsLib shape = new graphicsLib();
            mouse_is_down = true;
            mouse_pos.X = e.X;
            mouse_pos.Y = e.Y;
            initial_b = new Bitmap(b);
            initial_pos.X = e.X; initial_pos.Y = e.Y;
            temp_pos.X = e.X; temp_pos.Y = e.Y;
            ResizeImage k = new ResizeImage();
            k.DoResizing(pb_image2.Handle);
            //k.Resize_movement(e, pb_image2);
            if (eraser_click)
            {
                pb_image2.Image = erase.eraser_function(b, temp_pos, (e.X - 6), (e.Y - 6), erasersize_x, erasersize_y);
            }
            else if (cut_click)
            {
                
            }
            else if (pencil_click)
            {
                pb_image2.Image = pencil.pencil_function(b, temp_pos, (e.X), (e.Y), chosen);
            }
            else if (rectangle_click)
            {
                pb_image2.Image = shape.rectangle_function(initial_b, initial_pos, e.X, e.Y, chosen);
            }
            else if (circle_click)
            {
                pb_image2.Image = shape.circle_function(initial_b, initial_pos, e.X, e.Y, chosen);
            }

        }


        private void Form1_Resize(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog();
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
            toolTip1.SetToolTip(this.Cut_btn, "Cut Tool");
        }

        private void Magnify_btn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.Magnify_btn, "Magnify Tool");
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
            try
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
            }
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

        private void Magnify_btn_Click(object sender, EventArgs e)
        {
            //Font f = new Font(new FontFamily("Times New Roman"), 10);
            //SolidBrush bT = new SolidBrush(Color.Black);
            //Graphics g = Graphics.FromHwnd(this.Handle);  // <=> g = CreateGraphics();
            //Graphics g = Graphics.FromHwndInternal(this.Handle);

            default_clicks();
            Magnify_btn.FlatStyle = FlatStyle.Flat;
            magnify_click = true;

            eraser_box.Visible = false;

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

        private void UpdateWiimoteState(WiimoteChangedEventArgs args)
        {
            WiimoteState ws = args.WiimoteState;
            pb_image2.Image = g_lib.drawCursorPoints(ws);

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
            colorDialog1.ShowDialog();
            chosen = colorDialog1.Color;
            pb_colors.Image = colorbox.show_color_chosen(pixel, chosen);

        }


        private void pb_image2_MouseEnter(object sender, EventArgs e)
        {
            //     NativeCalls.SendMessage(hwnd, NativeCalls.WM_SYSCOMMAND, NativeCalls.SC_DRAGSIZE_S, ref nul);
         //   ResizablePictureBox modify = new ResizablePictureBox();
            
        }




    }      
   }    


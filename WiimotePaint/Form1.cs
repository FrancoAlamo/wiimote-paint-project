using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PaintProgram
{
    
    public partial class Form1 : Form
    {
        public static int k = 0;
        public static int erasersize_x, erasersize_y;
        private bool mouse_is_down = false;
        private Point mouse_pos;
        Image img;
        Bitmap b = new Bitmap(1, 1, PixelFormat.Format24bppRgb);
        Graphics eraser;
        
        public Form1()
        {
            InitializeComponent();
            
                

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
                

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g;
            g = Graphics.FromImage(b);
            g.DrawEllipse(new Pen(Color.Orange), 200, 200, 300, 200);
            panel1.CreateGraphics();
            // pb_image.Image = b;
           // pb_image.BackgroundImage = pb_image2.Image;
        }

        private void Open_Click(object sender, EventArgs e)
        {
            string CurrentFile;
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
            //img = Image.FromFile(openFileDialog1.FileName);
            pb_image2.ClientSize = new Size((b.Width), (b.Height));
            pb_image2.Height = b.Height;
            pb_image2.Width = b.Width;
            pb_image2.Image = b;
            //pb_color.Image = (Image) img;
            panel1.Height = b.Height + (b.Height/2);
            panel1.Width = b.Width + (b.Width/2);
            panel1.CreateGraphics();
            //panel1.CanSelect = true;
            
            
            
 
        }

        private void btn_load_Click(object sender, System.EventArgs e)
        {

        }

        private void btn_convert_Click(object sender, System.EventArgs e)
        {
            
        }

        private void Save_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C:\\Documents and Settings\\EE464\\My Documents\\My Pictures";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.DefaultExt = "jpg";
            saveFileDialog1.Filter = "Bitmap Files (*.bmp)|*.bmp|JPEG Images (*.jpg)|*.jpg||";
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.ShowDialog();


        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            openFileDialog1.OpenFile();

            
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            fileToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            editToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            viewToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            aboutToolStripMenuItem.ForeColor = System.Drawing.Color.Red;


            
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            

        }

        private void pb_image_Click(object sender, EventArgs e)
        {
            
        }

        private void pb_image_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            mouse_is_down = true;
            
        }


        private void pb_image2_MouseClick(object sender, MouseEventArgs e)
        {
            mouse_is_down = true;

            Point current_pos = Control.MousePosition;
            //pb_image2.Region.Translate((current_pos.X - mouse_pos.X), (current_pos.Y - mouse_pos.Y));
          //  current_pos.X = (mouse_pos.X/6) - (current_pos.X/6); //add this current_pos.Y = current_pos.Y - mouse_pos.Y; //add this
          //  current_pos.Y = (mouse_pos.Y/6) - (current_pos.Y/6);
          //  pb_image2.Location = current_pos;

            if(mouse_is_down == true)
            {
                eraser.DrawRectangle(new Pen(Color.White), e.X - 6, e.Y - 6, erasersize_x, erasersize_y);
                eraser.FillRectangle(new SolidBrush(Color.White), e.X - 6, e.Y - 6, erasersize_x, erasersize_y);
                pb_image2.Image = b;
            }
        }

        private void pb_image2_MouseUp(object sender, MouseEventArgs e)
        {
            mouse_is_down = false;
        }

        private void pb_image2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouse_is_down)
            {
             //   Point current_pos = Control.MousePosition;
                //pb_image2.Region.Translate((current_pos.X - mouse_pos.X), (current_pos.Y - mouse_pos.Y));
             //   current_pos.X = current_pos.X - mouse_pos.X; //add this current_pos.Y = current_pos.Y - mouse_pos.Y; //add this
             //   this.Location = current_pos;
            }
        }

        private void pb_image2_MouseDown(object sender, MouseEventArgs e)
        {
            

            while (mouse_is_down)
            {
                mouse_pos.X = e.X;
                mouse_pos.Y = e.Y;
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

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = "C:\\Documents and Settings\\EE464\\My Documents\\My Pictures";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.DefaultExt = "jpg";
            saveFileDialog1.Filter = "Bitmap Files (*.bmp)|*.bmp|JPEG Images (*.jpg)|*.jpg||";
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.FileName = "";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName == "")
                return;
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

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

        private void Fill_btn_Click(object sender, EventArgs e)
        {
      //      Color chosen;
      //      colorDialog1.ShowDialog();
      //      chosen = colorDialog1.Color;

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
            Bitmap pixel = new Bitmap(100, 200);
            eraser1_panel.Visible = true;
            eraser2_panel.Visible = true;
            eraser3_panel.Visible = true;
            eraser4_panel.Visible = true;
            eraser_box.Visible = true;
            pixel.SetPixel(20, 30, Color.White);
            eraser = Graphics.FromImage(b);
            
            //Color chosen;
            //colorDialog1.ShowDialog();
            //chosen = colorDialog1.Color;
            //panel1.BackColor = chosen;

        }

        private void Magnify_btn_Click(object sender, EventArgs e)
        {
            Font f = new Font(new FontFamily("Times New Roman"), 10);
            SolidBrush bT = new SolidBrush(Color.Black);
            //Graphics g = Graphics.FromHwnd(this.Handle);  // <=> g = CreateGraphics();
            Graphics g = Graphics.FromHwndInternal(this.Handle);
            eraser_box.Visible = false;
            
        }


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

       
   }


    
}

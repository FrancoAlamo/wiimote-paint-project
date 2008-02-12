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
        private bool mouse_is_down = false;
        private Point mouse_pos;
        Image img;
        Bitmap b = new Bitmap(1, 1, PixelFormat.Format24bppRgb);
        
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

        private void button2_Click(object sender, EventArgs e)
        {
            Color chosen;
            colorDialog1.ShowDialog();
            chosen = colorDialog1.Color;
            panel1.BackColor = chosen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g;
            g = Graphics.FromImage(b);
            g.DrawEllipse(new Pen(Color.Orange), 200, 200, 300, 200);
            pb_image2.Image = b;
            pb_image.BackgroundImage = pb_image2.Image;
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
            pb_image2.ClientSize = new Size((b.Width/2), (b.Height/2));
            pb_image2.Image = b;
            //pb_color.Image = (Image) img;
            pb_image2.Height = b.Height;
            pb_image2.Width = b.Width;
            panel1.Height = b.Height/2;
            panel1.Width = b.Width/2;
            panel1.CreateGraphics();
 
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


        private void button4_Click(object sender, EventArgs e)
        {
            DragDropEffects ok = new DragDropEffects();
            pb_image.DoDragDrop(pb_image, ok);
        }

        private void pb_image2_MouseClick(object sender, MouseEventArgs e)
        {
            mouse_is_down = true;

            Point current_pos = Control.MousePosition;
            //pb_image2.Region.Translate((current_pos.X - mouse_pos.X), (current_pos.Y - mouse_pos.Y));
            current_pos.X = current_pos.X - mouse_pos.X; //add this current_pos.Y = current_pos.Y - mouse_pos.Y; //add this
            current_pos.Y = current_pos.Y - mouse_pos.Y;
            pb_image2.Location = current_pos;
        }

        private void pb_image2_MouseUp(object sender, MouseEventArgs e)
        {
            mouse_is_down = false;
        }

        private void pb_image2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouse_is_down)
            {
                Point current_pos = Control.MousePosition;
                //pb_image2.Region.Translate((current_pos.X - mouse_pos.X), (current_pos.Y - mouse_pos.Y));
                current_pos.X = current_pos.X - mouse_pos.X; //add this current_pos.Y = current_pos.Y - mouse_pos.Y; //add this
                this.Location = current_pos;
            }
        }

        private void pb_image2_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_pos.X = e.X;
            mouse_pos.Y = e.Y;
        }

        


    }
}

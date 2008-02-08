using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PaintProgram
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //  Open_Click.Enabled = false;
           // btn_save.Enabled = false;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            
        }

        private void Open_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C:\\Documents and Settings\\EE464\\My Documents\\My Pictures";
            openFileDialog1.AddExtension = true;
            openFileDialog1.DefaultExt = "jpg";
            openFileDialog1.Filter = "Bitmap Files (*.bmp)|*.bmp|JPEG Images (*.jpg,*.jpeg)|*.jpg;*.jpeg||";
            openFileDialog1.ShowDialog();
            Bitmap grays = (Bitmap)pb_color.Image;
            try
            {
                int width = grays.Size.Width;
                int height = grays.Size.Height;
            }
            catch(Exception e) { }
            for (int j = 0; j < height; j++)
            {

                for (int i = 0; i < width; i++)
                {

                    Color col;
                    col = grays.GetPixel(i, j);
                    grays.SetPixel(i, j, Color.FromArgb((col.R + col.G + col.B) / 3, (col.R + col.G + col.B) / 3, (col.R + col.G + col.B) / 3));
                }

            }
            //pb_color.Image = grays; 
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

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            

        }

        private void pb_color_Click(object sender, EventArgs e)
        {

        }


    }
}

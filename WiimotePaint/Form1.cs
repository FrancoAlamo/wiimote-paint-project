using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PaintProgram
{
    
    public partial class Form1 : Form
    {
        public static int k = 0;
        
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
            colorDialog1.ShowDialog();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Open_Click(object sender, EventArgs e)
        {
            string CurrentFile;
            Image img;
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
            

            pb_color.SizeMode = PictureBoxSizeMode.StretchImage;
            CurrentFile = openFileDialog1.FileName.ToString();
            img = Image.FromFile(openFileDialog1.FileName);
            pb_color.Image = img;
            pb_color.ClientSize = new Size((img.Width/2), (img.Height/2));
            //pb_color.Image = (Image) img;
            pb_color.Height = img.Height/2;
            pb_color.Width = img.Width/2;
            panel1.Height = img.Height/2;
            panel1.Width = img.Width/2;
 
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

        private void pb_color_Click(object sender, EventArgs e)
        {

        }

        


    }
}

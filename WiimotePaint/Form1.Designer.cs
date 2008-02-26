namespace PaintProgram
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupbox1 = new System.Windows.Forms.GroupBox();
            this.pb_colors = new System.Windows.Forms.PictureBox();
            this.Circle_btn = new System.Windows.Forms.Button();
            this.Pencil_btn = new System.Windows.Forms.Button();
            this.Rectangle_btn = new System.Windows.Forms.Button();
            this.eraser_box = new System.Windows.Forms.GroupBox();
            this.eraser1_panel = new System.Windows.Forms.Panel();
            this.eraser2_panel = new System.Windows.Forms.Panel();
            this.eraser4_panel = new System.Windows.Forms.Panel();
            this.eraser3_panel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Cut_btn = new System.Windows.Forms.Button();
            this.Eraser_btn = new System.Windows.Forms.Button();
            this.Fill_btn = new System.Windows.Forms.Button();
            this.Magnify_btn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pb_image2 = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.pb_image = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.groupbox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_colors)).BeginInit();
            this.eraser_box.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_image2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_image)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Black;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(941, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.printToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.Open_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.Save_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.printToolStripMenuItem.Text = "Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.quitToolStripMenuItem.Text = "Exit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.cutToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.editToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomInToolStripMenuItem,
            this.zoomOutToolStripMenuItem});
            this.viewToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // zoomInToolStripMenuItem
            // 
            this.zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            this.zoomInToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.zoomInToolStripMenuItem.Text = "Zoom in";
            // 
            // zoomOutToolStripMenuItem
            // 
            this.zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
            this.zoomOutToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.zoomOutToolStripMenuItem.Text = "Zoom out";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // groupbox1
            // 
            this.groupbox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupbox1.Controls.Add(this.pb_colors);
            this.groupbox1.Controls.Add(this.Circle_btn);
            this.groupbox1.Controls.Add(this.Pencil_btn);
            this.groupbox1.Controls.Add(this.Rectangle_btn);
            this.groupbox1.Controls.Add(this.eraser_box);
            this.groupbox1.Controls.Add(this.Cut_btn);
            this.groupbox1.Controls.Add(this.Eraser_btn);
            this.groupbox1.Controls.Add(this.Fill_btn);
            this.groupbox1.Controls.Add(this.Magnify_btn);
            this.groupbox1.Location = new System.Drawing.Point(8, 16);
            this.groupbox1.Name = "groupbox1";
            this.groupbox1.Size = new System.Drawing.Size(78, 654);
            this.groupbox1.TabIndex = 1;
            this.groupbox1.TabStop = false;
            this.groupbox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // pb_colors
            // 
            this.pb_colors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_colors.Location = new System.Drawing.Point(6, 264);
            this.pb_colors.Name = "pb_colors";
            this.pb_colors.Size = new System.Drawing.Size(63, 76);
            this.pb_colors.TabIndex = 4;
            this.pb_colors.TabStop = false;
            this.pb_colors.Click += new System.EventHandler(this.pb_colors_Click);
            // 
            // Circle_btn
            // 
            this.Circle_btn.Location = new System.Drawing.Point(4, 105);
            this.Circle_btn.Name = "Circle_btn";
            this.Circle_btn.Size = new System.Drawing.Size(34, 27);
            this.Circle_btn.TabIndex = 2;
            this.Circle_btn.Text = "Circle";
            this.Circle_btn.UseVisualStyleBackColor = true;
            this.Circle_btn.Click += new System.EventHandler(this.Circle_btn_Click);
            // 
            // Pencil_btn
            // 
            this.Pencil_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Pencil_btn.BackgroundImage")));
            this.Pencil_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Pencil_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Pencil_btn.Location = new System.Drawing.Point(38, 69);
            this.Pencil_btn.Name = "Pencil_btn";
            this.Pencil_btn.Size = new System.Drawing.Size(37, 31);
            this.Pencil_btn.TabIndex = 0;
            this.Pencil_btn.UseVisualStyleBackColor = true;
            this.Pencil_btn.Click += new System.EventHandler(this.pencil_btn_Click);
            // 
            // Rectangle_btn
            // 
            this.Rectangle_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Rectangle_btn.BackgroundImage")));
            this.Rectangle_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Rectangle_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Rectangle_btn.Location = new System.Drawing.Point(1, 69);
            this.Rectangle_btn.Name = "Rectangle_btn";
            this.Rectangle_btn.Size = new System.Drawing.Size(37, 31);
            this.Rectangle_btn.TabIndex = 1;
            this.Rectangle_btn.UseVisualStyleBackColor = true;
            this.Rectangle_btn.Click += new System.EventHandler(this.rectangle_btn_Click);
            // 
            // eraser_box
            // 
            this.eraser_box.Controls.Add(this.eraser1_panel);
            this.eraser_box.Controls.Add(this.eraser2_panel);
            this.eraser_box.Controls.Add(this.eraser4_panel);
            this.eraser_box.Controls.Add(this.eraser3_panel);
            this.eraser_box.Controls.Add(this.label1);
            this.eraser_box.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.eraser_box.Location = new System.Drawing.Point(15, 138);
            this.eraser_box.Name = "eraser_box";
            this.eraser_box.Size = new System.Drawing.Size(50, 120);
            this.eraser_box.TabIndex = 1;
            this.eraser_box.TabStop = false;
            this.eraser_box.Visible = false;
            // 
            // eraser1_panel
            // 
            this.eraser1_panel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("eraser1_panel.BackgroundImage")));
            this.eraser1_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.eraser1_panel.Location = new System.Drawing.Point(13, 15);
            this.eraser1_panel.Name = "eraser1_panel";
            this.eraser1_panel.Size = new System.Drawing.Size(25, 20);
            this.eraser1_panel.TabIndex = 0;
            this.eraser1_panel.Visible = false;
            this.eraser1_panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.eraser1_panel_MouseClick);
            // 
            // eraser2_panel
            // 
            this.eraser2_panel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("eraser2_panel.BackgroundImage")));
            this.eraser2_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.eraser2_panel.Location = new System.Drawing.Point(13, 36);
            this.eraser2_panel.Name = "eraser2_panel";
            this.eraser2_panel.Size = new System.Drawing.Size(25, 20);
            this.eraser2_panel.TabIndex = 0;
            this.eraser2_panel.Visible = false;
            this.eraser2_panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.eraser2_panel_MouseClick);
            // 
            // eraser4_panel
            // 
            this.eraser4_panel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("eraser4_panel.BackgroundImage")));
            this.eraser4_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.eraser4_panel.Location = new System.Drawing.Point(13, 78);
            this.eraser4_panel.Name = "eraser4_panel";
            this.eraser4_panel.Size = new System.Drawing.Size(25, 20);
            this.eraser4_panel.TabIndex = 0;
            this.eraser4_panel.Visible = false;
            this.eraser4_panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.eraser4_panel_MouseClick);
            // 
            // eraser3_panel
            // 
            this.eraser3_panel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("eraser3_panel.BackgroundImage")));
            this.eraser3_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.eraser3_panel.Location = new System.Drawing.Point(13, 57);
            this.eraser3_panel.Name = "eraser3_panel";
            this.eraser3_panel.Size = new System.Drawing.Size(25, 20);
            this.eraser3_panel.TabIndex = 0;
            this.eraser3_panel.Visible = false;
            this.eraser3_panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.eraser3_panel_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // Cut_btn
            // 
            this.Cut_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Cut_btn.Image = ((System.Drawing.Image)(resources.GetObject("Cut_btn.Image")));
            this.Cut_btn.Location = new System.Drawing.Point(1, 7);
            this.Cut_btn.Name = "Cut_btn";
            this.Cut_btn.Size = new System.Drawing.Size(37, 31);
            this.Cut_btn.TabIndex = 0;
            this.Cut_btn.UseVisualStyleBackColor = true;
            this.Cut_btn.Click += new System.EventHandler(this.Cut_btn_Click);
            this.Cut_btn.MouseHover += new System.EventHandler(this.Cut_btn_MouseHover);
            // 
            // Eraser_btn
            // 
            this.Eraser_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Eraser_btn.BackgroundImage")));
            this.Eraser_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Eraser_btn.Location = new System.Drawing.Point(1, 38);
            this.Eraser_btn.Name = "Eraser_btn";
            this.Eraser_btn.Size = new System.Drawing.Size(37, 31);
            this.Eraser_btn.TabIndex = 0;
            this.Eraser_btn.UseVisualStyleBackColor = true;
            this.Eraser_btn.Click += new System.EventHandler(this.Eraser_btn_Click);
            this.Eraser_btn.MouseHover += new System.EventHandler(this.Eraser_btn_MouseHover);
            // 
            // Fill_btn
            // 
            this.Fill_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Fill_btn.BackgroundImage")));
            this.Fill_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Fill_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Fill_btn.Location = new System.Drawing.Point(38, 38);
            this.Fill_btn.Name = "Fill_btn";
            this.Fill_btn.Size = new System.Drawing.Size(37, 31);
            this.Fill_btn.TabIndex = 0;
            this.Fill_btn.UseVisualStyleBackColor = true;
            this.Fill_btn.Click += new System.EventHandler(this.Fill_btn_Click);
            this.Fill_btn.MouseHover += new System.EventHandler(this.Fill_btn_MouseHover);
            // 
            // Magnify_btn
            // 
            this.Magnify_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Magnify_btn.BackgroundImage")));
            this.Magnify_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Magnify_btn.Location = new System.Drawing.Point(38, 7);
            this.Magnify_btn.Name = "Magnify_btn";
            this.Magnify_btn.Size = new System.Drawing.Size(37, 31);
            this.Magnify_btn.TabIndex = 0;
            this.Magnify_btn.UseVisualStyleBackColor = true;
            this.Magnify_btn.Click += new System.EventHandler(this.Magnify_btn_Click);
            this.Magnify_btn.MouseHover += new System.EventHandler(this.Magnify_btn_MouseHover);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.groupBox2.Controls.Add(this.pb_image2);
            this.groupBox2.Location = new System.Drawing.Point(86, 18);
            this.groupBox2.MinimumSize = new System.Drawing.Size(317, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1171, 945);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // pb_image2
            // 
            this.pb_image2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pb_image2.Location = new System.Drawing.Point(6, 9);
            this.pb_image2.Name = "pb_image2";
            this.pb_image2.Size = new System.Drawing.Size(640, 480);
            this.pb_image2.TabIndex = 0;
            this.pb_image2.TabStop = false;
            this.pb_image2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pb_image2_MouseMove);
            this.pb_image2.Click += new System.EventHandler(this.pb_image2_Click);
            this.pb_image2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pb_image2_MouseClick);
            this.pb_image2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pb_image2_MouseDown);
            this.pb_image2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pb_image2_MouseUp);
            this.pb_image2.Paint += new System.Windows.Forms.PaintEventHandler(this.pb_image2_Paint);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel2.Location = new System.Drawing.Point(440, 500);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(100, 100);
            this.panel2.TabIndex = 1;
            // 
            // pb_image
            // 
            this.pb_image.Location = new System.Drawing.Point(0, 0);
            this.pb_image.Name = "pb_image";
            this.pb_image.Size = new System.Drawing.Size(1, 1);
            this.pb_image.TabIndex = 0;
            this.pb_image.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(91, 37);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel1.Size = new System.Drawing.Size(641, 481);
            this.panel1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(941, 671);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupbox1);
            this.Controls.Add(this.groupBox2);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(300, 410);
            this.Name = "Form1";
            this.Text = "WiiPaint";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupbox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_colors)).EndInit();
            this.eraser_box.ResumeLayout(false);
            this.eraser_box.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_image2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupbox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Eraser_btn;
        private System.Windows.Forms.Button Cut_btn;
        private System.Windows.Forms.Button Fill_btn;
        private System.Windows.Forms.Button Magnify_btn;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox eraser_box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel eraser3_panel;
        private System.Windows.Forms.Panel eraser2_panel;
        private System.Windows.Forms.Panel eraser4_panel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel eraser1_panel;
        private System.Windows.Forms.Button Rectangle_btn;
        private System.Windows.Forms.Button Pencil_btn;
        private System.Windows.Forms.PictureBox pb_colors;
        private System.Windows.Forms.Button Circle_btn;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.PictureBox pb_image;
        private System.Windows.Forms.PictureBox pb_image2;
        private System.Windows.Forms.Panel panel1;

        //Wiimote related objects:

    }
}


namespace VoidCraft_MapCreator_v5 {
    partial class MapCreator {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.Tool_Box_Panel_MC = new System.Windows.Forms.Panel();
            this.Map_View_Panel_MC = new System.Windows.Forms.Panel();
            this.Map_Counter_Panel_MC = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zapiszToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wyjścieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informacjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oProgramieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Layer_Selector_MC = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.Zoom_Selector_MC = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripTextBox3 = new System.Windows.Forms.ToolStripTextBox();
            this.Pen_Size_Selector_MC = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.widokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.wyłaczLinieSiatkiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.przełaczNumerowanieLiniiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tool_Box_Panel_MC
            // 
            this.Tool_Box_Panel_MC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Tool_Box_Panel_MC.AutoScroll = true;
            this.Tool_Box_Panel_MC.BackColor = System.Drawing.SystemColors.Menu;
            this.Tool_Box_Panel_MC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Tool_Box_Panel_MC.Location = new System.Drawing.Point(13, 27);
            this.Tool_Box_Panel_MC.Name = "Tool_Box_Panel_MC";
            this.Tool_Box_Panel_MC.Size = new System.Drawing.Size(200, 522);
            this.Tool_Box_Panel_MC.TabIndex = 0;
            this.Tool_Box_Panel_MC.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SelectingTile);
            // 
            // Map_View_Panel_MC
            // 
            this.Map_View_Panel_MC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Map_View_Panel_MC.BackColor = System.Drawing.SystemColors.Menu;
            this.Map_View_Panel_MC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Map_View_Panel_MC.Location = new System.Drawing.Point(257, 60);
            this.Map_View_Panel_MC.Name = "Map_View_Panel_MC";
            this.Map_View_Panel_MC.Size = new System.Drawing.Size(589, 468);
            this.Map_View_Panel_MC.TabIndex = 1;
            this.Map_View_Panel_MC.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Map_View_Panel_MC_MouseDown);
            this.Map_View_Panel_MC.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Map_View_Panel_MC_MouseDown);
            // 
            // Map_Counter_Panel_MC
            // 
            this.Map_Counter_Panel_MC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Map_Counter_Panel_MC.AutoScroll = true;
            this.Map_Counter_Panel_MC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Map_Counter_Panel_MC.Location = new System.Drawing.Point(219, 27);
            this.Map_Counter_Panel_MC.Name = "Map_Counter_Panel_MC";
            this.Map_Counter_Panel_MC.Size = new System.Drawing.Size(653, 522);
            this.Map_Counter_Panel_MC.TabIndex = 2;
            this.Map_Counter_Panel_MC.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Map_Counter_Panel_MC_Scroll);
            this.Map_Counter_Panel_MC.Paint += new System.Windows.Forms.PaintEventHandler(this.MapCreator_Paint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(884, 561);
            this.panel1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.informacjeToolStripMenuItem,
            this.toolStripTextBox1,
            this.Layer_Selector_MC,
            this.toolStripTextBox2,
            this.Zoom_Selector_MC,
            this.toolStripTextBox3,
            this.Pen_Size_Selector_MC});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(884, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.widokToolStripMenuItem,
            this.toolStripSeparator2,
            this.zapiszToolStripMenuItem,
            this.toolStripSeparator1,
            this.wyjścieToolStripMenuItem});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(38, 23);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // zapiszToolStripMenuItem
            // 
            this.zapiszToolStripMenuItem.Name = "zapiszToolStripMenuItem";
            this.zapiszToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.zapiszToolStripMenuItem.Text = "Zapisz";
            this.zapiszToolStripMenuItem.Click += new System.EventHandler(this.zapiszToolStripMenuItem_Click);
            // 
            // wyjścieToolStripMenuItem
            // 
            this.wyjścieToolStripMenuItem.Name = "wyjścieToolStripMenuItem";
            this.wyjścieToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.wyjścieToolStripMenuItem.Text = "Wyjście";
            this.wyjścieToolStripMenuItem.Click += new System.EventHandler(this.wyjścieToolStripMenuItem_Click);
            // 
            // informacjeToolStripMenuItem
            // 
            this.informacjeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oProgramieToolStripMenuItem});
            this.informacjeToolStripMenuItem.Name = "informacjeToolStripMenuItem";
            this.informacjeToolStripMenuItem.Size = new System.Drawing.Size(76, 23);
            this.informacjeToolStripMenuItem.Text = "Informacje";
            // 
            // oProgramieToolStripMenuItem
            // 
            this.oProgramieToolStripMenuItem.Name = "oProgramieToolStripMenuItem";
            this.oProgramieToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.oProgramieToolStripMenuItem.Text = "O programie";
            this.oProgramieToolStripMenuItem.Click += new System.EventHandler(this.oProgramieToolStripMenuItem_Click);
            // 
            // Layer_Selector_MC
            // 
            this.Layer_Selector_MC.Name = "Layer_Selector_MC";
            this.Layer_Selector_MC.Size = new System.Drawing.Size(121, 23);
            this.Layer_Selector_MC.Text = "0";
            this.Layer_Selector_MC.SelectedIndexChanged += new System.EventHandler(this.Layer_Selector_MC_SelectedIndexChanged);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Enabled = false;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox1.Text = "Aktywna warstwa";
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.Enabled = false;
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox2.Text = "Zoom";
            // 
            // Zoom_Selector_MC
            // 
            this.Zoom_Selector_MC.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50",
            "55",
            "60",
            "65",
            "70",
            "75",
            "80",
            "85",
            "90",
            "95",
            "100"});
            this.Zoom_Selector_MC.Name = "Zoom_Selector_MC";
            this.Zoom_Selector_MC.Size = new System.Drawing.Size(121, 23);
            this.Zoom_Selector_MC.Text = "50";
            this.Zoom_Selector_MC.SelectedIndexChanged += new System.EventHandler(this.Zoom_Selector_MC_SelectedIndexChanged);
            // 
            // toolStripTextBox3
            // 
            this.toolStripTextBox3.Enabled = false;
            this.toolStripTextBox3.Name = "toolStripTextBox3";
            this.toolStripTextBox3.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox3.Text = "Rozmiar pędzla";
            // 
            // Pen_Size_Selector_MC
            // 
            this.Pen_Size_Selector_MC.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "10",
            "15",
            "20"});
            this.Pen_Size_Selector_MC.Name = "Pen_Size_Selector_MC";
            this.Pen_Size_Selector_MC.Size = new System.Drawing.Size(121, 23);
            this.Pen_Size_Selector_MC.Text = "0";
            this.Pen_Size_Selector_MC.SelectedIndexChanged += new System.EventHandler(this.Pen_Size_Selector_MC_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // widokToolStripMenuItem
            // 
            this.widokToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wyłaczLinieSiatkiToolStripMenuItem,
            this.przełaczNumerowanieLiniiToolStripMenuItem});
            this.widokToolStripMenuItem.Name = "widokToolStripMenuItem";
            this.widokToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.widokToolStripMenuItem.Text = "Widok";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // wyłaczLinieSiatkiToolStripMenuItem
            // 
            this.wyłaczLinieSiatkiToolStripMenuItem.Name = "wyłaczLinieSiatkiToolStripMenuItem";
            this.wyłaczLinieSiatkiToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.wyłaczLinieSiatkiToolStripMenuItem.Text = "Przełacz linie siatki";
            this.wyłaczLinieSiatkiToolStripMenuItem.Click += new System.EventHandler(this.wyłaczLinieSiatkiToolStripMenuItem_Click);
            // 
            // przełaczNumerowanieLiniiToolStripMenuItem
            // 
            this.przełaczNumerowanieLiniiToolStripMenuItem.Name = "przełaczNumerowanieLiniiToolStripMenuItem";
            this.przełaczNumerowanieLiniiToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.przełaczNumerowanieLiniiToolStripMenuItem.Text = "Przełacz numerowanie linii";
            this.przełaczNumerowanieLiniiToolStripMenuItem.Click += new System.EventHandler(this.przełaczNumerowanieLiniiToolStripMenuItem_Click);
            // 
            // MapCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.Map_View_Panel_MC);
            this.Controls.Add(this.Map_Counter_Panel_MC);
            this.Controls.Add(this.Tool_Box_Panel_MC);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(850, 400);
            this.Name = "MapCreator";
            this.Text = "VoidCraft Map Editor v5";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MapCreator_FormClosing);
            this.Load += new System.EventHandler(this.MapCreator_Load);
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Map_Counter_Panel_MC_Scroll);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MapCreator_Paint);
            this.Resize += new System.EventHandler(this.MapCreator_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Tool_Box_Panel_MC;
        private System.Windows.Forms.Panel Map_View_Panel_MC;
        private System.Windows.Forms.Panel Map_Counter_Panel_MC;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zapiszToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wyjścieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informacjeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oProgramieToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox Layer_Selector_MC;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.ToolStripComboBox Zoom_Selector_MC;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox3;
        private System.Windows.Forms.ToolStripComboBox Pen_Size_Selector_MC;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem widokToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wyłaczLinieSiatkiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem przełaczNumerowanieLiniiToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}
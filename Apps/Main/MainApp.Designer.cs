namespace SOS_Essential.Apps.Main
{
    partial class MainApp
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainApp));
            this.ExitBtnWindow = new System.Windows.Forms.Label();
            this.MinimizeBtnWindow = new System.Windows.Forms.Label();
            this.LogoImg = new ClassicDarkTheme.Dark.DarkPicturebox();
            this.StartButton = new SOS_Essential.CustomControls.AltoButton();
            this.ExitButton = new SOS_Essential.CustomControls.AltoButton();
            this.EnglishFlag = new System.Windows.Forms.PictureBox();
            this.CestinaFlag = new System.Windows.Forms.PictureBox();
            this.LogoPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Train = new ClassicDarkTheme.Dark.DarkPicturebox();
            this.LevelMakerButton = new SOS_Essential.CustomControls.AltoButton();
            ((System.ComponentModel.ISupportInitialize)(this.LogoImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnglishFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CestinaFlag)).BeginInit();
            this.LogoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Train)).BeginInit();
            this.SuspendLayout();
            // 
            // ExitBtnWindow
            // 
            this.ExitBtnWindow.AutoSize = true;
            this.ExitBtnWindow.BackColor = System.Drawing.Color.Firebrick;
            this.ExitBtnWindow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExitBtnWindow.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ExitBtnWindow.Location = new System.Drawing.Point(1148, 1);
            this.ExitBtnWindow.Name = "ExitBtnWindow";
            this.ExitBtnWindow.Size = new System.Drawing.Size(51, 21);
            this.ExitBtnWindow.TabIndex = 5;
            this.ExitBtnWindow.Text = "    X    ";
            this.ExitBtnWindow.Click += new System.EventHandler(this.ExitBtnWindow_Click);
            this.ExitBtnWindow.MouseEnter += new System.EventHandler(this.ExitBtnWindow_MouseEnter);
            this.ExitBtnWindow.MouseLeave += new System.EventHandler(this.ExitBtnWindow_MouseLeave);
            // 
            // MinimizeBtnWindow
            // 
            this.MinimizeBtnWindow.AutoSize = true;
            this.MinimizeBtnWindow.BackColor = System.Drawing.Color.LightGray;
            this.MinimizeBtnWindow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MinimizeBtnWindow.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MinimizeBtnWindow.Location = new System.Drawing.Point(1108, 1);
            this.MinimizeBtnWindow.Name = "MinimizeBtnWindow";
            this.MinimizeBtnWindow.Size = new System.Drawing.Size(40, 21);
            this.MinimizeBtnWindow.TabIndex = 4;
            this.MinimizeBtnWindow.Text = "   -   ";
            this.MinimizeBtnWindow.Click += new System.EventHandler(this.MinimizeBtn_Click);
            this.MinimizeBtnWindow.MouseEnter += new System.EventHandler(this.MinimizeBtn_MouseEnter);
            this.MinimizeBtnWindow.MouseLeave += new System.EventHandler(this.MinimizeBtn_MouseLeave);
            // 
            // LogoImg
            // 
            this.LogoImg.BackColor = System.Drawing.Color.Transparent;
            this.LogoImg.Image = global::SOS_Essential.Properties.Resources.SosGameGIF;
            this.LogoImg.Location = new System.Drawing.Point(410, -25);
            this.LogoImg.Name = "LogoImg";
            this.LogoImg.Size = new System.Drawing.Size(432, 172);
            this.LogoImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoImg.TabIndex = 2;
            this.LogoImg.TabStop = false;
            this.LogoImg.WaitOnLoad = true;
            // 
            // StartButton
            // 
            this.StartButton.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.StartButton.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.StartButton.BackColor = System.Drawing.Color.Transparent;
            this.StartButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StartButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.StartButton.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.StartButton.ForeColor = System.Drawing.Color.Black;
            this.StartButton.Inactive1 = System.Drawing.Color.Gainsboro;
            this.StartButton.Inactive2 = System.Drawing.Color.MediumTurquoise;
            this.StartButton.Location = new System.Drawing.Point(435, 230);
            this.StartButton.Name = "StartButton";
            this.StartButton.Radius = 25;
            this.StartButton.Size = new System.Drawing.Size(337, 65);
            this.StartButton.Stroke = true;
            this.StartButton.StrokeColor = System.Drawing.Color.Black;
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "Play Online";
            this.StartButton.Transparency = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.ExitButton.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.ExitButton.BackColor = System.Drawing.Color.Transparent;
            this.ExitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExitButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ExitButton.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ExitButton.ForeColor = System.Drawing.Color.Black;
            this.ExitButton.Inactive1 = System.Drawing.Color.Gainsboro;
            this.ExitButton.Inactive2 = System.Drawing.Color.MediumTurquoise;
            this.ExitButton.Location = new System.Drawing.Point(435, 380);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Radius = 25;
            this.ExitButton.Size = new System.Drawing.Size(337, 65);
            this.ExitButton.Stroke = true;
            this.ExitButton.StrokeColor = System.Drawing.Color.Black;
            this.ExitButton.TabIndex = 3;
            this.ExitButton.Text = "Exit";
            this.ExitButton.Transparency = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // EnglishFlag
            // 
            this.EnglishFlag.BackColor = System.Drawing.Color.Transparent;
            this.EnglishFlag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EnglishFlag.Image = global::SOS_Essential.Properties.Resources.anglictina;
            this.EnglishFlag.Location = new System.Drawing.Point(929, 230);
            this.EnglishFlag.Name = "EnglishFlag";
            this.EnglishFlag.Size = new System.Drawing.Size(203, 136);
            this.EnglishFlag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.EnglishFlag.TabIndex = 6;
            this.EnglishFlag.TabStop = false;
            this.EnglishFlag.WaitOnLoad = true;
            this.EnglishFlag.Click += new System.EventHandler(this.EnglishFlag_Click);
            // 
            // CestinaFlag
            // 
            this.CestinaFlag.BackColor = System.Drawing.Color.Transparent;
            this.CestinaFlag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CestinaFlag.Image = global::SOS_Essential.Properties.Resources.czechflag;
            this.CestinaFlag.Location = new System.Drawing.Point(64, 230);
            this.CestinaFlag.Name = "CestinaFlag";
            this.CestinaFlag.Size = new System.Drawing.Size(205, 136);
            this.CestinaFlag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CestinaFlag.TabIndex = 7;
            this.CestinaFlag.TabStop = false;
            this.CestinaFlag.WaitOnLoad = true;
            this.CestinaFlag.Click += new System.EventHandler(this.CestinaFlag_Click);
            // 
            // LogoPanel
            // 
            this.LogoPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.LogoPanel.Controls.Add(this.panel2);
            this.LogoPanel.Controls.Add(this.panel1);
            this.LogoPanel.Controls.Add(this.LogoImg);
            this.LogoPanel.Location = new System.Drawing.Point(1, 59);
            this.LogoPanel.Name = "LogoPanel";
            this.LogoPanel.Size = new System.Drawing.Size(1198, 111);
            this.LogoPanel.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1198, 1);
            this.panel2.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1198, 1);
            this.panel1.TabIndex = 3;
            // 
            // Train
            // 
            this.Train.BackColor = System.Drawing.Color.Transparent;
            this.Train.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Train.Image = global::SOS_Essential.Properties.Resources.TrainGif;
            this.Train.Location = new System.Drawing.Point(311, 617);
            this.Train.Name = "Train";
            this.Train.Size = new System.Drawing.Size(592, 103);
            this.Train.TabIndex = 9;
            this.Train.TabStop = false;
            this.Train.WaitOnLoad = true;
            this.Train.Click += new System.EventHandler(this.Train_Click);
            // 
            // LevelMakerButton
            // 
            this.LevelMakerButton.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.LevelMakerButton.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.LevelMakerButton.BackColor = System.Drawing.Color.Transparent;
            this.LevelMakerButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LevelMakerButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.LevelMakerButton.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LevelMakerButton.ForeColor = System.Drawing.Color.Black;
            this.LevelMakerButton.Inactive1 = System.Drawing.Color.Gainsboro;
            this.LevelMakerButton.Inactive2 = System.Drawing.Color.MediumTurquoise;
            this.LevelMakerButton.Location = new System.Drawing.Point(435, 305);
            this.LevelMakerButton.Name = "LevelMakerButton";
            this.LevelMakerButton.Radius = 25;
            this.LevelMakerButton.Size = new System.Drawing.Size(337, 65);
            this.LevelMakerButton.Stroke = true;
            this.LevelMakerButton.StrokeColor = System.Drawing.Color.Black;
            this.LevelMakerButton.TabIndex = 10;
            this.LevelMakerButton.Text = "Level Maker";
            this.LevelMakerButton.Transparency = false;
            this.LevelMakerButton.Click += new System.EventHandler(this.LevelMakerButton_Click);
            // 
            // MainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SOS_Essential.Properties.Resources.backgroundApp;
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Controls.Add(this.LevelMakerButton);
            this.Controls.Add(this.ExitBtnWindow);
            this.Controls.Add(this.MinimizeBtnWindow);
            this.Controls.Add(this.Train);
            this.Controls.Add(this.CestinaFlag);
            this.Controls.Add(this.EnglishFlag);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.LogoPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainApp";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainApp_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.LogoImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnglishFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CestinaFlag)).EndInit();
            this.LogoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Train)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Label ExitBtnWindow;
        public Label MinimizeBtnWindow;
        public ClassicDarkTheme.Dark.DarkPicturebox LogoImg;
        public CustomControls.AltoButton StartButton;
        public CustomControls.AltoButton ExitButton;
        public PictureBox EnglishFlag;
        public PictureBox CestinaFlag;
        public Panel LogoPanel;
        public ClassicDarkTheme.Dark.DarkPicturebox Train;
        private Panel panel2;
        private Panel panel1;
        public CustomControls.AltoButton LevelMakerButton;
    }
}
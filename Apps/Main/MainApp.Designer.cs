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
            ExitBtnWindow = new Label();
            MinimizeBtnWindow = new Label();
            LogoImg = new ClassicDarkTheme.Dark.DarkPicturebox();
            StartButton = new CustomControls.AltoButton();
            ExitButton = new CustomControls.AltoButton();
            EnglishFlag = new PictureBox();
            CestinaFlag = new PictureBox();
            LogoPanel = new Panel();
            panel2 = new Panel();
            panel1 = new Panel();
            Train = new ClassicDarkTheme.Dark.DarkPicturebox();
            LevelMakerButton = new CustomControls.AltoButton();
            ((System.ComponentModel.ISupportInitialize)LogoImg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EnglishFlag).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CestinaFlag).BeginInit();
            LogoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Train).BeginInit();
            SuspendLayout();
            // 
            // ExitBtnWindow
            // 
            ExitBtnWindow.AutoSize = true;
            ExitBtnWindow.BackColor = Color.Firebrick;
            ExitBtnWindow.Cursor = Cursors.Hand;
            ExitBtnWindow.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ExitBtnWindow.Location = new Point(1148, 1);
            ExitBtnWindow.Name = "ExitBtnWindow";
            ExitBtnWindow.Size = new Size(51, 21);
            ExitBtnWindow.TabIndex = 5;
            ExitBtnWindow.Text = "    X    ";
            ExitBtnWindow.Click += ExitBtnWindow_Click;
            ExitBtnWindow.MouseEnter += ExitBtnWindow_MouseEnter;
            ExitBtnWindow.MouseLeave += ExitBtnWindow_MouseLeave;
            // 
            // MinimizeBtnWindow
            // 
            MinimizeBtnWindow.AutoSize = true;
            MinimizeBtnWindow.BackColor = Color.LightGray;
            MinimizeBtnWindow.Cursor = Cursors.Hand;
            MinimizeBtnWindow.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            MinimizeBtnWindow.Location = new Point(1108, 1);
            MinimizeBtnWindow.Name = "MinimizeBtnWindow";
            MinimizeBtnWindow.Size = new Size(40, 21);
            MinimizeBtnWindow.TabIndex = 4;
            MinimizeBtnWindow.Text = "   -   ";
            MinimizeBtnWindow.Click += MinimizeBtn_Click;
            MinimizeBtnWindow.MouseEnter += MinimizeBtn_MouseEnter;
            MinimizeBtnWindow.MouseLeave += MinimizeBtn_MouseLeave;
            // 
            // LogoImg
            // 
            LogoImg.BackColor = Color.Transparent;
            LogoImg.Image = Properties.Resources.SosGameGIF;
            LogoImg.Location = new Point(410, -25);
            LogoImg.Name = "LogoImg";
            LogoImg.Size = new Size(432, 172);
            LogoImg.SizeMode = PictureBoxSizeMode.Zoom;
            LogoImg.TabIndex = 2;
            LogoImg.TabStop = false;
            LogoImg.WaitOnLoad = true;
            // 
            // StartButton
            // 
            StartButton.Active1 = Color.FromArgb(64, 168, 183);
            StartButton.Active2 = Color.FromArgb(36, 164, 183);
            StartButton.BackColor = Color.Transparent;
            StartButton.Cursor = Cursors.Hand;
            StartButton.DialogResult = DialogResult.OK;
            StartButton.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            StartButton.ForeColor = Color.Black;
            StartButton.Inactive1 = Color.Gainsboro;
            StartButton.Inactive2 = Color.MediumTurquoise;
            StartButton.Location = new Point(435, 230);
            StartButton.Name = "StartButton";
            StartButton.Radius = 25;
            StartButton.Size = new Size(337, 65);
            StartButton.Stroke = true;
            StartButton.StrokeColor = Color.Black;
            StartButton.TabIndex = 1;
            StartButton.Text = "Play";
            StartButton.Transparency = false;
            StartButton.Click += StartButton_Click;
            // 
            // ExitButton
            // 
            ExitButton.Active1 = Color.FromArgb(64, 168, 183);
            ExitButton.Active2 = Color.FromArgb(36, 164, 183);
            ExitButton.BackColor = Color.Transparent;
            ExitButton.Cursor = Cursors.Hand;
            ExitButton.DialogResult = DialogResult.OK;
            ExitButton.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            ExitButton.ForeColor = Color.Black;
            ExitButton.Inactive1 = Color.Gainsboro;
            ExitButton.Inactive2 = Color.MediumTurquoise;
            ExitButton.Location = new Point(435, 380);
            ExitButton.Name = "ExitButton";
            ExitButton.Radius = 25;
            ExitButton.Size = new Size(337, 65);
            ExitButton.Stroke = true;
            ExitButton.StrokeColor = Color.Black;
            ExitButton.TabIndex = 3;
            ExitButton.Text = "Exit";
            ExitButton.Transparency = false;
            ExitButton.Click += ExitButton_Click;
            // 
            // EnglishFlag
            // 
            EnglishFlag.BackColor = Color.Transparent;
            EnglishFlag.Cursor = Cursors.Hand;
            EnglishFlag.Image = Properties.Resources.anglictina;
            EnglishFlag.Location = new Point(929, 230);
            EnglishFlag.Name = "EnglishFlag";
            EnglishFlag.Size = new Size(203, 136);
            EnglishFlag.SizeMode = PictureBoxSizeMode.Zoom;
            EnglishFlag.TabIndex = 6;
            EnglishFlag.TabStop = false;
            EnglishFlag.WaitOnLoad = true;
            EnglishFlag.Click += EnglishFlag_Click;
            // 
            // CestinaFlag
            // 
            CestinaFlag.BackColor = Color.Transparent;
            CestinaFlag.Cursor = Cursors.Hand;
            CestinaFlag.Image = Properties.Resources.czechflag;
            CestinaFlag.Location = new Point(64, 230);
            CestinaFlag.Name = "CestinaFlag";
            CestinaFlag.Size = new Size(205, 136);
            CestinaFlag.SizeMode = PictureBoxSizeMode.Zoom;
            CestinaFlag.TabIndex = 7;
            CestinaFlag.TabStop = false;
            CestinaFlag.WaitOnLoad = true;
            CestinaFlag.Click += CestinaFlag_Click;
            // 
            // LogoPanel
            // 
            LogoPanel.BackColor = SystemColors.ControlLight;
            LogoPanel.Controls.Add(panel2);
            LogoPanel.Controls.Add(panel1);
            LogoPanel.Controls.Add(LogoImg);
            LogoPanel.Location = new Point(1, 59);
            LogoPanel.Name = "LogoPanel";
            LogoPanel.Size = new Size(1198, 111);
            LogoPanel.TabIndex = 8;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Black;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1198, 1);
            panel2.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Location = new Point(0, 110);
            panel1.Name = "panel1";
            panel1.Size = new Size(1198, 1);
            panel1.TabIndex = 3;
            // 
            // Train
            // 
            Train.BackColor = Color.Transparent;
            Train.Cursor = Cursors.Hand;
            Train.Image = Properties.Resources.TrainGif;
            Train.Location = new Point(311, 617);
            Train.Name = "Train";
            Train.Size = new Size(592, 103);
            Train.TabIndex = 9;
            Train.TabStop = false;
            Train.WaitOnLoad = true;
            Train.Click += Train_Click;
            // 
            // LevelMakerButton
            // 
            LevelMakerButton.Active1 = Color.FromArgb(64, 168, 183);
            LevelMakerButton.Active2 = Color.FromArgb(36, 164, 183);
            LevelMakerButton.BackColor = Color.Transparent;
            LevelMakerButton.Cursor = Cursors.Hand;
            LevelMakerButton.DialogResult = DialogResult.OK;
            LevelMakerButton.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            LevelMakerButton.ForeColor = Color.Black;
            LevelMakerButton.Inactive1 = Color.Gainsboro;
            LevelMakerButton.Inactive2 = Color.MediumTurquoise;
            LevelMakerButton.Location = new Point(435, 305);
            LevelMakerButton.Name = "LevelMakerButton";
            LevelMakerButton.Radius = 25;
            LevelMakerButton.Size = new Size(337, 65);
            LevelMakerButton.Stroke = true;
            LevelMakerButton.StrokeColor = Color.Black;
            LevelMakerButton.TabIndex = 10;
            LevelMakerButton.Text = "Level Maker";
            LevelMakerButton.Transparency = false;
            LevelMakerButton.Click += LevelMakerButton_Click;
            // 
            // MainApp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.backgroundApp;
            ClientSize = new Size(1200, 720);
            Controls.Add(LevelMakerButton);
            Controls.Add(ExitBtnWindow);
            Controls.Add(MinimizeBtnWindow);
            Controls.Add(Train);
            Controls.Add(CestinaFlag);
            Controls.Add(EnglishFlag);
            Controls.Add(ExitButton);
            Controls.Add(StartButton);
            Controls.Add(LogoPanel);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainApp";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainApp";
            FormClosing += MainApp_FormClosing;
            ((System.ComponentModel.ISupportInitialize)LogoImg).EndInit();
            ((System.ComponentModel.ISupportInitialize)EnglishFlag).EndInit();
            ((System.ComponentModel.ISupportInitialize)CestinaFlag).EndInit();
            LogoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Train).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
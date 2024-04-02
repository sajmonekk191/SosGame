namespace SOS_Essential.Apps.Main.Game.MiniGames
{
    partial class Chests
    {
        /// <summary> 
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód vygenerovaný pomocí Návrháře komponent

        /// <summary> 
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.Chest1 = new System.Windows.Forms.PictureBox();
            this.Chest2 = new System.Windows.Forms.PictureBox();
            this.Chest3 = new System.Windows.Forms.PictureBox();
            this.Chest4 = new System.Windows.Forms.PictureBox();
            this.ChestPanel = new System.Windows.Forms.Panel();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.InfoPanel = new System.Windows.Forms.Panel();
            this.ItemLabel = new System.Windows.Forms.Label();
            this.ItemIcon = new System.Windows.Forms.PictureBox();
            this.ExitBtnWindow = new System.Windows.Forms.Label();
            this.MinimizeBtnWindow = new System.Windows.Forms.Label();
            this.BackButton = new ClassicDarkTheme.Dark.DarkPicturebox();
            this.SkipButton = new SOS_Essential.CustomControls.AltoButton();
            this.ItemPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.Chest1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chest2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chest3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chest4)).BeginInit();
            this.ChestPanel.SuspendLayout();
            this.InfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackButton)).BeginInit();
            this.ItemPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Chest1
            // 
            this.Chest1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Chest1.Image = global::SOS_Essential.Properties.Resources.Treasure;
            this.Chest1.Location = new System.Drawing.Point(99, 15);
            this.Chest1.Name = "Chest1";
            this.Chest1.Size = new System.Drawing.Size(146, 130);
            this.Chest1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Chest1.TabIndex = 0;
            this.Chest1.TabStop = false;
            // 
            // Chest2
            // 
            this.Chest2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Chest2.Image = global::SOS_Essential.Properties.Resources.Treasure;
            this.Chest2.Location = new System.Drawing.Point(396, 15);
            this.Chest2.Name = "Chest2";
            this.Chest2.Size = new System.Drawing.Size(146, 130);
            this.Chest2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Chest2.TabIndex = 1;
            this.Chest2.TabStop = false;
            // 
            // Chest3
            // 
            this.Chest3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Chest3.Image = global::SOS_Essential.Properties.Resources.Treasure;
            this.Chest3.Location = new System.Drawing.Point(99, 163);
            this.Chest3.Name = "Chest3";
            this.Chest3.Size = new System.Drawing.Size(146, 130);
            this.Chest3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Chest3.TabIndex = 2;
            this.Chest3.TabStop = false;
            // 
            // Chest4
            // 
            this.Chest4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Chest4.Image = global::SOS_Essential.Properties.Resources.Treasure;
            this.Chest4.Location = new System.Drawing.Point(396, 163);
            this.Chest4.Name = "Chest4";
            this.Chest4.Size = new System.Drawing.Size(146, 130);
            this.Chest4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Chest4.TabIndex = 3;
            this.Chest4.TabStop = false;
            // 
            // ChestPanel
            // 
            this.ChestPanel.BackColor = System.Drawing.Color.White;
            this.ChestPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ChestPanel.Controls.Add(this.Chest4);
            this.ChestPanel.Controls.Add(this.Chest1);
            this.ChestPanel.Controls.Add(this.Chest3);
            this.ChestPanel.Controls.Add(this.Chest2);
            this.ChestPanel.Location = new System.Drawing.Point(280, 375);
            this.ChestPanel.Name = "ChestPanel";
            this.ChestPanel.Size = new System.Drawing.Size(646, 310);
            this.ChestPanel.TabIndex = 4;
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.InfoLabel.Location = new System.Drawing.Point(255, 12);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(208, 74);
            this.InfoLabel.TabIndex = 5;
            this.InfoLabel.Text = "  Try Your Luck\r\nChoose a Chest!";
            // 
            // InfoPanel
            // 
            this.InfoPanel.BackColor = System.Drawing.Color.White;
            this.InfoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InfoPanel.Controls.Add(this.InfoLabel);
            this.InfoPanel.Location = new System.Drawing.Point(240, 21);
            this.InfoPanel.Name = "InfoPanel";
            this.InfoPanel.Size = new System.Drawing.Size(724, 100);
            this.InfoPanel.TabIndex = 6;
            // 
            // ItemLabel
            // 
            this.ItemLabel.AutoSize = true;
            this.ItemLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ItemLabel.Location = new System.Drawing.Point(97, 30);
            this.ItemLabel.Name = "ItemLabel";
            this.ItemLabel.Size = new System.Drawing.Size(70, 37);
            this.ItemLabel.TabIndex = 6;
            this.ItemLabel.Text = "Item";
            this.ItemLabel.Visible = false;
            // 
            // ItemIcon
            // 
            this.ItemIcon.Cursor = System.Windows.Forms.Cursors.Default;
            this.ItemIcon.Location = new System.Drawing.Point(27, 17);
            this.ItemIcon.Name = "ItemIcon";
            this.ItemIcon.Size = new System.Drawing.Size(64, 64);
            this.ItemIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ItemIcon.TabIndex = 7;
            this.ItemIcon.TabStop = false;
            this.ItemIcon.Visible = false;
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
            this.ExitBtnWindow.TabIndex = 13;
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
            this.MinimizeBtnWindow.TabIndex = 12;
            this.MinimizeBtnWindow.Text = "   -   ";
            this.MinimizeBtnWindow.Click += new System.EventHandler(this.MinimizeBtnWindow_Click);
            this.MinimizeBtnWindow.MouseEnter += new System.EventHandler(this.MinimizeBtnWindow_MouseEnter);
            this.MinimizeBtnWindow.MouseLeave += new System.EventHandler(this.MinimizeBtnWindow_MouseLeave);
            // 
            // BackButton
            // 
            this.BackButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackButton.Image = global::SOS_Essential.Properties.Resources.back;
            this.BackButton.Location = new System.Drawing.Point(20, 20);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(38, 36);
            this.BackButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BackButton.TabIndex = 14;
            this.BackButton.TabStop = false;
            this.BackButton.WaitOnLoad = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // SkipButton
            // 
            this.SkipButton.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.SkipButton.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.SkipButton.BackColor = System.Drawing.Color.Transparent;
            this.SkipButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SkipButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SkipButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SkipButton.ForeColor = System.Drawing.Color.Black;
            this.SkipButton.Inactive1 = System.Drawing.Color.Gainsboro;
            this.SkipButton.Inactive2 = System.Drawing.Color.MediumTurquoise;
            this.SkipButton.Location = new System.Drawing.Point(992, 508);
            this.SkipButton.Name = "SkipButton";
            this.SkipButton.Radius = 25;
            this.SkipButton.Size = new System.Drawing.Size(147, 51);
            this.SkipButton.Stroke = true;
            this.SkipButton.StrokeColor = System.Drawing.Color.Black;
            this.SkipButton.TabIndex = 16;
            this.SkipButton.Text = "Skip";
            this.SkipButton.Transparency = false;
            this.SkipButton.Click += new System.EventHandler(this.SkipButton_Click);
            // 
            // ItemPanel
            // 
            this.ItemPanel.BackColor = System.Drawing.Color.White;
            this.ItemPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ItemPanel.Controls.Add(this.ItemIcon);
            this.ItemPanel.Controls.Add(this.ItemLabel);
            this.ItemPanel.Location = new System.Drawing.Point(481, 207);
            this.ItemPanel.Name = "ItemPanel";
            this.ItemPanel.Size = new System.Drawing.Size(286, 100);
            this.ItemPanel.TabIndex = 17;
            this.ItemPanel.Visible = false;
            // 
            // Chests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ItemPanel);
            this.Controls.Add(this.SkipButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.ExitBtnWindow);
            this.Controls.Add(this.MinimizeBtnWindow);
            this.Controls.Add(this.InfoPanel);
            this.Controls.Add(this.ChestPanel);
            this.Name = "Chests";
            this.Size = new System.Drawing.Size(1200, 700);
            ((System.ComponentModel.ISupportInitialize)(this.Chest1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chest2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chest3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chest4)).EndInit();
            this.ChestPanel.ResumeLayout(false);
            this.InfoPanel.ResumeLayout(false);
            this.InfoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackButton)).EndInit();
            this.ItemPanel.ResumeLayout(false);
            this.ItemPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox Chest1;
        private PictureBox Chest2;
        private PictureBox Chest3;
        private PictureBox Chest4;
        private Panel ChestPanel;
        private Label InfoLabel;
        private Panel InfoPanel;
        private Label ItemLabel;
        private PictureBox ItemIcon;
        private Label ExitBtnWindow;
        private Label MinimizeBtnWindow;
        private ClassicDarkTheme.Dark.DarkPicturebox BackButton;
        public CustomControls.AltoButton SkipButton;
        private Panel ItemPanel;
    }
}

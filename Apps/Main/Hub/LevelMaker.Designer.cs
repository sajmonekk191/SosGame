namespace SOS_Essential.Apps.Main.Lobby
{
    partial class LevelMaker
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
            this.BackButton = new ClassicDarkTheme.Dark.DarkPicturebox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Helplbl = new System.Windows.Forms.Label();
            this.CodeField = new ClassicDarkTheme.Dark.DarkTextbox();
            this.OpenFolderbtn = new SOS_Essential.CustomControls.AltoButton();
            this.SaveFilebtn = new SOS_Essential.CustomControls.AltoButton();
            this.LoadFilebtn = new SOS_Essential.CustomControls.AltoButton();
            ((System.ComponentModel.ISupportInitialize)(this.BackButton)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BackButton
            // 
            this.BackButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackButton.Image = global::SOS_Essential.Properties.Resources.back;
            this.BackButton.Location = new System.Drawing.Point(20, 20);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(38, 36);
            this.BackButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BackButton.TabIndex = 1;
            this.BackButton.TabStop = false;
            this.BackButton.WaitOnLoad = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            this.BackButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BackButton_MouseDown);
            this.BackButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BackButton_MouseUp);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Helplbl);
            this.panel1.Controls.Add(this.CodeField);
            this.panel1.Controls.Add(this.OpenFolderbtn);
            this.panel1.Controls.Add(this.SaveFilebtn);
            this.panel1.Controls.Add(this.LoadFilebtn);
            this.panel1.Location = new System.Drawing.Point(60, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1080, 620);
            this.panel1.TabIndex = 2;
            // 
            // Helplbl
            // 
            this.Helplbl.AutoSize = true;
            this.Helplbl.BackColor = System.Drawing.Color.Gainsboro;
            this.Helplbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Helplbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Helplbl.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Helplbl.Location = new System.Drawing.Point(1048, 583);
            this.Helplbl.Name = "Helplbl";
            this.Helplbl.Size = new System.Drawing.Size(20, 25);
            this.Helplbl.TabIndex = 15;
            this.Helplbl.Text = "?";
            this.Helplbl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Helplbl_MouseDown);
            this.Helplbl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Helplbl_MouseUp);
            // 
            // CodeField
            // 
            this.CodeField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(39)))));
            this.CodeField.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.CodeField.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CodeField.ForeColor = System.Drawing.Color.White;
            this.CodeField.Location = new System.Drawing.Point(30, 20);
            this.CodeField.MaxLength = 32767;
            this.CodeField.Name = "CodeField";
            this.CodeField.OnlyNumbers = false;
            this.CodeField.Size = new System.Drawing.Size(1020, 520);
            this.CodeField.TabIndex = 14;
            this.CodeField.TextStr = "";
            // 
            // OpenFolderbtn
            // 
            this.OpenFolderbtn.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.OpenFolderbtn.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.OpenFolderbtn.BackColor = System.Drawing.Color.Transparent;
            this.OpenFolderbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OpenFolderbtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OpenFolderbtn.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.OpenFolderbtn.ForeColor = System.Drawing.Color.Black;
            this.OpenFolderbtn.Inactive1 = System.Drawing.Color.Gainsboro;
            this.OpenFolderbtn.Inactive2 = System.Drawing.Color.MediumTurquoise;
            this.OpenFolderbtn.Location = new System.Drawing.Point(793, 558);
            this.OpenFolderbtn.Name = "OpenFolderbtn";
            this.OpenFolderbtn.Radius = 20;
            this.OpenFolderbtn.Size = new System.Drawing.Size(217, 41);
            this.OpenFolderbtn.Stroke = true;
            this.OpenFolderbtn.StrokeColor = System.Drawing.Color.Black;
            this.OpenFolderbtn.TabIndex = 13;
            this.OpenFolderbtn.Text = "Open Level Folder";
            this.OpenFolderbtn.Transparency = false;
            this.OpenFolderbtn.Click += new System.EventHandler(this.OpenFolderbtn_Click);
            // 
            // SaveFilebtn
            // 
            this.SaveFilebtn.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.SaveFilebtn.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.SaveFilebtn.BackColor = System.Drawing.Color.Transparent;
            this.SaveFilebtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveFilebtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SaveFilebtn.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SaveFilebtn.ForeColor = System.Drawing.Color.Black;
            this.SaveFilebtn.Inactive1 = System.Drawing.Color.Gainsboro;
            this.SaveFilebtn.Inactive2 = System.Drawing.Color.MediumTurquoise;
            this.SaveFilebtn.Location = new System.Drawing.Point(430, 558);
            this.SaveFilebtn.Name = "SaveFilebtn";
            this.SaveFilebtn.Radius = 20;
            this.SaveFilebtn.Size = new System.Drawing.Size(217, 41);
            this.SaveFilebtn.Stroke = true;
            this.SaveFilebtn.StrokeColor = System.Drawing.Color.Black;
            this.SaveFilebtn.TabIndex = 12;
            this.SaveFilebtn.Text = "Save";
            this.SaveFilebtn.Transparency = false;
            this.SaveFilebtn.Click += new System.EventHandler(this.SaveFilebtn_Click);
            // 
            // LoadFilebtn
            // 
            this.LoadFilebtn.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.LoadFilebtn.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.LoadFilebtn.BackColor = System.Drawing.Color.Transparent;
            this.LoadFilebtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoadFilebtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.LoadFilebtn.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LoadFilebtn.ForeColor = System.Drawing.Color.Black;
            this.LoadFilebtn.Inactive1 = System.Drawing.Color.Gainsboro;
            this.LoadFilebtn.Inactive2 = System.Drawing.Color.MediumTurquoise;
            this.LoadFilebtn.Location = new System.Drawing.Point(75, 558);
            this.LoadFilebtn.Name = "LoadFilebtn";
            this.LoadFilebtn.Radius = 20;
            this.LoadFilebtn.Size = new System.Drawing.Size(217, 41);
            this.LoadFilebtn.Stroke = true;
            this.LoadFilebtn.StrokeColor = System.Drawing.Color.Black;
            this.LoadFilebtn.TabIndex = 11;
            this.LoadFilebtn.Text = "Load";
            this.LoadFilebtn.Transparency = false;
            this.LoadFilebtn.Click += new System.EventHandler(this.LoadFilebtn_Click);
            // 
            // LevelMaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BackButton);
            this.Name = "LevelMaker";
            this.Size = new System.Drawing.Size(1200, 720);
            ((System.ComponentModel.ISupportInitialize)(this.BackButton)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ClassicDarkTheme.Dark.DarkPicturebox BackButton;
        private Panel panel1;
        public CustomControls.AltoButton OpenFolderbtn;
        public CustomControls.AltoButton SaveFilebtn;
        public CustomControls.AltoButton LoadFilebtn;
        private ClassicDarkTheme.Dark.DarkTextbox CodeField;
        private Label Helplbl;
    }
}

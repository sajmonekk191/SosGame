namespace SOS_Essential.Apps.Main.Game
{
    partial class Lobby
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
            this.JoinServer = new System.Windows.Forms.PictureBox();
            this.CreateServer = new System.Windows.Forms.PictureBox();
            this.Createlbl = new System.Windows.Forms.Label();
            this.Connectlbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BackButton = new ClassicDarkTheme.Dark.DarkPicturebox();
            ((System.ComponentModel.ISupportInitialize)(this.JoinServer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreateServer)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackButton)).BeginInit();
            this.SuspendLayout();
            // 
            // JoinServer
            // 
            this.JoinServer.BackColor = System.Drawing.Color.White;
            this.JoinServer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.JoinServer.Image = global::SOS_Essential.Properties.Resources.ConnectServer;
            this.JoinServer.Location = new System.Drawing.Point(689, 8);
            this.JoinServer.Name = "JoinServer";
            this.JoinServer.Size = new System.Drawing.Size(350, 330);
            this.JoinServer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.JoinServer.TabIndex = 1;
            this.JoinServer.TabStop = false;
            this.JoinServer.WaitOnLoad = true;
            this.JoinServer.Click += new System.EventHandler(this.JoinServer_Click);
            this.JoinServer.MouseEnter += new System.EventHandler(this.JoinServer_MouseEnter);
            this.JoinServer.MouseLeave += new System.EventHandler(this.JoinServer_MouseLeave);
            // 
            // CreateServer
            // 
            this.CreateServer.BackColor = System.Drawing.Color.White;
            this.CreateServer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CreateServer.Image = global::SOS_Essential.Properties.Resources.CreateServer;
            this.CreateServer.Location = new System.Drawing.Point(156, 8);
            this.CreateServer.Name = "CreateServer";
            this.CreateServer.Size = new System.Drawing.Size(350, 330);
            this.CreateServer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CreateServer.TabIndex = 0;
            this.CreateServer.TabStop = false;
            this.CreateServer.WaitOnLoad = true;
            this.CreateServer.Click += new System.EventHandler(this.CreateServer_Click);
            this.CreateServer.MouseEnter += new System.EventHandler(this.CreateServer_MouseEnter);
            this.CreateServer.MouseLeave += new System.EventHandler(this.CreateServer_MouseLeave);
            // 
            // Createlbl
            // 
            this.Createlbl.AutoSize = true;
            this.Createlbl.BackColor = System.Drawing.Color.White;
            this.Createlbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Createlbl.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Createlbl.Location = new System.Drawing.Point(226, 130);
            this.Createlbl.Name = "Createlbl";
            this.Createlbl.Size = new System.Drawing.Size(211, 47);
            this.Createlbl.TabIndex = 2;
            this.Createlbl.Text = "Create Server";
            // 
            // Connectlbl
            // 
            this.Connectlbl.AutoSize = true;
            this.Connectlbl.BackColor = System.Drawing.Color.White;
            this.Connectlbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Connectlbl.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Connectlbl.Location = new System.Drawing.Point(735, 130);
            this.Connectlbl.Name = "Connectlbl";
            this.Connectlbl.Size = new System.Drawing.Size(237, 47);
            this.Connectlbl.TabIndex = 3;
            this.Connectlbl.Text = "Connect Server";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.JoinServer);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.CreateServer);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(1, 175);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1198, 347);
            this.panel1.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1201, 1);
            this.panel3.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Location = new System.Drawing.Point(0, 346);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1201, 1);
            this.panel4.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(595, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 347);
            this.panel2.TabIndex = 5;
            // 
            // BackButton
            // 
            this.BackButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackButton.Image = global::SOS_Essential.Properties.Resources.back;
            this.BackButton.Location = new System.Drawing.Point(20, 20);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(38, 36);
            this.BackButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BackButton.TabIndex = 5;
            this.BackButton.TabStop = false;
            this.BackButton.WaitOnLoad = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // Lobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Createlbl);
            this.Controls.Add(this.Connectlbl);
            this.Name = "Lobby";
            this.Size = new System.Drawing.Size(1200, 720);
            ((System.ComponentModel.ISupportInitialize)(this.JoinServer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreateServer)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BackButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private PictureBox JoinServer;
        private PictureBox CreateServer;
        private Label Createlbl;
        private Label Connectlbl;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private ClassicDarkTheme.Dark.DarkPicturebox BackButton;
    }
}

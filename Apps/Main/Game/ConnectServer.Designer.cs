namespace SOS_Essential.Apps.Main.Game
{
    partial class ConnectServer
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
            this.ServerLobby = new System.Windows.Forms.Panel();
            this.AddServer = new System.Windows.Forms.PictureBox();
            this.loading = new SOS_Essential.CustomControls.SpinningCircles();
            this.ReloadServers = new System.Windows.Forms.PictureBox();
            this.ServerList = new System.Windows.Forms.ListBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.ServerListLBL = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.PlayerList = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.UserList = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.BackButton = new ClassicDarkTheme.Dark.DarkPicturebox();
            this.ExitBtnWindow = new System.Windows.Forms.Label();
            this.MinimizeBtnWindow = new System.Windows.Forms.Label();
            this.Playground = new System.Windows.Forms.Panel();
            this.TimeLeftlbl = new System.Windows.Forms.Label();
            this.GameTimer = new MetroFramework.Controls.MetroProgressBar();
            this.AnswersDonelbl = new System.Windows.Forms.Label();
            this.Questionlbl = new System.Windows.Forms.Label();
            this.CoinsImage = new System.Windows.Forms.PictureBox();
            this.Coinslbl = new System.Windows.Forms.Label();
            this.Answer4btn = new SOS_Essential.CustomControls.AltoButton();
            this.Answer3btn = new SOS_Essential.CustomControls.AltoButton();
            this.Answer2btn = new SOS_Essential.CustomControls.AltoButton();
            this.Answer1btn = new SOS_Essential.CustomControls.AltoButton();
            this.CoinsPB = new System.Windows.Forms.PictureBox();
            this.ServerLobby.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddServer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReloadServers)).BeginInit();
            this.PlayerList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackButton)).BeginInit();
            this.Playground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CoinsImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoinsPB)).BeginInit();
            this.SuspendLayout();
            // 
            // ServerLobby
            // 
            this.ServerLobby.BackColor = System.Drawing.Color.White;
            this.ServerLobby.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ServerLobby.Controls.Add(this.AddServer);
            this.ServerLobby.Controls.Add(this.loading);
            this.ServerLobby.Controls.Add(this.ReloadServers);
            this.ServerLobby.Controls.Add(this.ServerList);
            this.ServerLobby.Controls.Add(this.panel4);
            this.ServerLobby.Controls.Add(this.panel5);
            this.ServerLobby.Controls.Add(this.panel6);
            this.ServerLobby.Controls.Add(this.ServerListLBL);
            this.ServerLobby.Controls.Add(this.panel3);
            this.ServerLobby.Location = new System.Drawing.Point(65, 50);
            this.ServerLobby.Name = "ServerLobby";
            this.ServerLobby.Size = new System.Drawing.Size(1068, 624);
            this.ServerLobby.TabIndex = 8;
            // 
            // AddServer
            // 
            this.AddServer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddServer.Image = global::SOS_Essential.Properties.Resources.AddServer;
            this.AddServer.Location = new System.Drawing.Point(946, 32);
            this.AddServer.Name = "AddServer";
            this.AddServer.Size = new System.Drawing.Size(32, 32);
            this.AddServer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AddServer.TabIndex = 8;
            this.AddServer.TabStop = false;
            // 
            // loading
            // 
            this.loading.BackColor = System.Drawing.Color.Transparent;
            this.loading.FullTransparent = true;
            this.loading.Increment = 1F;
            this.loading.Location = new System.Drawing.Point(487, 257);
            this.loading.N = 9;
            this.loading.Name = "loading";
            this.loading.Radius = 2.5F;
            this.loading.Size = new System.Drawing.Size(90, 100);
            this.loading.TabIndex = 7;
            this.loading.Text = "loading";
            this.loading.UseWaitCursor = true;
            this.loading.Visible = false;
            // 
            // ReloadServers
            // 
            this.ReloadServers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReloadServers.Image = global::SOS_Essential.Properties.Resources.Reload;
            this.ReloadServers.Location = new System.Drawing.Point(1003, 32);
            this.ReloadServers.Name = "ReloadServers";
            this.ReloadServers.Size = new System.Drawing.Size(32, 32);
            this.ReloadServers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ReloadServers.TabIndex = 6;
            this.ReloadServers.TabStop = false;
            // 
            // ServerList
            // 
            this.ServerList.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ServerList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ServerList.FormattingEnabled = true;
            this.ServerList.ItemHeight = 15;
            this.ServerList.Location = new System.Drawing.Point(21, 75);
            this.ServerList.Name = "ServerList";
            this.ServerList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ServerList.Size = new System.Drawing.Size(1024, 525);
            this.ServerList.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Location = new System.Drawing.Point(21, 604);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1025, 1);
            this.panel4.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Location = new System.Drawing.Point(20, 20);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1, 585);
            this.panel5.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Black;
            this.panel6.Location = new System.Drawing.Point(1045, 20);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1, 585);
            this.panel6.TabIndex = 3;
            // 
            // ServerListLBL
            // 
            this.ServerListLBL.AutoSize = true;
            this.ServerListLBL.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ServerListLBL.Location = new System.Drawing.Point(469, 32);
            this.ServerListLBL.Name = "ServerListLBL";
            this.ServerListLBL.Size = new System.Drawing.Size(123, 32);
            this.ServerListLBL.TabIndex = 4;
            this.ServerListLBL.Text = "Server List";
            this.ServerListLBL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(20, 20);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1026, 1);
            this.panel3.TabIndex = 0;
            // 
            // PlayerList
            // 
            this.PlayerList.BackColor = System.Drawing.Color.White;
            this.PlayerList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PlayerList.Controls.Add(this.label1);
            this.PlayerList.Controls.Add(this.UserList);
            this.PlayerList.Controls.Add(this.panel2);
            this.PlayerList.Controls.Add(this.panel7);
            this.PlayerList.Controls.Add(this.panel8);
            this.PlayerList.Controls.Add(this.panel9);
            this.PlayerList.Location = new System.Drawing.Point(64, 50);
            this.PlayerList.Name = "PlayerList";
            this.PlayerList.Size = new System.Drawing.Size(1068, 624);
            this.PlayerList.TabIndex = 8;
            this.PlayerList.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(500, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 30);
            this.label1.TabIndex = 7;
            this.label1.Text = "Users";
            // 
            // UserList
            // 
            this.UserList.BackColor = System.Drawing.Color.WhiteSmoke;
            this.UserList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UserList.FormattingEnabled = true;
            this.UserList.HorizontalScrollbar = true;
            this.UserList.ItemHeight = 15;
            this.UserList.Location = new System.Drawing.Point(21, 63);
            this.UserList.Name = "UserList";
            this.UserList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.UserList.Size = new System.Drawing.Size(1024, 540);
            this.UserList.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(1045, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 585);
            this.panel2.TabIndex = 3;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Black;
            this.panel7.Location = new System.Drawing.Point(20, 20);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1, 585);
            this.panel7.TabIndex = 2;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Black;
            this.panel8.Location = new System.Drawing.Point(21, 604);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1025, 1);
            this.panel8.TabIndex = 1;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Black;
            this.panel9.Location = new System.Drawing.Point(20, 20);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1026, 1);
            this.panel9.TabIndex = 0;
            // 
            // BackButton
            // 
            this.BackButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackButton.Image = global::SOS_Essential.Properties.Resources.back;
            this.BackButton.Location = new System.Drawing.Point(20, 20);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(38, 36);
            this.BackButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BackButton.TabIndex = 9;
            this.BackButton.TabStop = false;
            this.BackButton.WaitOnLoad = true;
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
            this.ExitBtnWindow.TabIndex = 11;
            this.ExitBtnWindow.Text = "    X    ";
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
            this.MinimizeBtnWindow.TabIndex = 10;
            this.MinimizeBtnWindow.Text = "   -   ";
            // 
            // Playground
            // 
            this.Playground.BackColor = System.Drawing.Color.White;
            this.Playground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Playground.Controls.Add(this.TimeLeftlbl);
            this.Playground.Controls.Add(this.GameTimer);
            this.Playground.Controls.Add(this.AnswersDonelbl);
            this.Playground.Controls.Add(this.Questionlbl);
            this.Playground.Controls.Add(this.CoinsImage);
            this.Playground.Controls.Add(this.Coinslbl);
            this.Playground.Controls.Add(this.Answer4btn);
            this.Playground.Controls.Add(this.Answer3btn);
            this.Playground.Controls.Add(this.Answer2btn);
            this.Playground.Controls.Add(this.Answer1btn);
            this.Playground.Location = new System.Drawing.Point(48, 41);
            this.Playground.Name = "Playground";
            this.Playground.Size = new System.Drawing.Size(1110, 647);
            this.Playground.TabIndex = 12;
            this.Playground.Visible = false;
            // 
            // TimeLeftlbl
            // 
            this.TimeLeftlbl.AutoSize = true;
            this.TimeLeftlbl.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TimeLeftlbl.ForeColor = System.Drawing.Color.Black;
            this.TimeLeftlbl.Location = new System.Drawing.Point(526, 8);
            this.TimeLeftlbl.Name = "TimeLeftlbl";
            this.TimeLeftlbl.Size = new System.Drawing.Size(53, 13);
            this.TimeLeftlbl.TabIndex = 15;
            this.TimeLeftlbl.Text = "Time Left";
            this.TimeLeftlbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.TimeLeftlbl.Visible = false;
            // 
            // GameTimer
            // 
            this.GameTimer.Location = new System.Drawing.Point(267, 25);
            this.GameTimer.Name = "GameTimer";
            this.GameTimer.Size = new System.Drawing.Size(580, 23);
            this.GameTimer.TabIndex = 14;
            this.GameTimer.Visible = false;
            // 
            // AnswersDonelbl
            // 
            this.AnswersDonelbl.AutoSize = true;
            this.AnswersDonelbl.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AnswersDonelbl.ForeColor = System.Drawing.Color.Black;
            this.AnswersDonelbl.Location = new System.Drawing.Point(33, 23);
            this.AnswersDonelbl.Name = "AnswersDonelbl";
            this.AnswersDonelbl.Size = new System.Drawing.Size(39, 25);
            this.AnswersDonelbl.TabIndex = 13;
            this.AnswersDonelbl.Text = "0/0";
            this.AnswersDonelbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Questionlbl
            // 
            this.Questionlbl.AutoSize = true;
            this.Questionlbl.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Questionlbl.ForeColor = System.Drawing.Color.Black;
            this.Questionlbl.Location = new System.Drawing.Point(506, 186);
            this.Questionlbl.Name = "Questionlbl";
            this.Questionlbl.Size = new System.Drawing.Size(84, 25);
            this.Questionlbl.TabIndex = 12;
            this.Questionlbl.Text = "Question";
            this.Questionlbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CoinsImage
            // 
            this.CoinsImage.Image = global::SOS_Essential.Properties.Resources.Coin;
            this.CoinsImage.Location = new System.Drawing.Point(1052, 14);
            this.CoinsImage.Name = "CoinsImage";
            this.CoinsImage.Size = new System.Drawing.Size(40, 40);
            this.CoinsImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CoinsImage.TabIndex = 11;
            this.CoinsImage.TabStop = false;
            // 
            // Coinslbl
            // 
            this.Coinslbl.AutoSize = true;
            this.Coinslbl.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Coinslbl.Location = new System.Drawing.Point(1024, 23);
            this.Coinslbl.Name = "Coinslbl";
            this.Coinslbl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Coinslbl.Size = new System.Drawing.Size(22, 25);
            this.Coinslbl.TabIndex = 9;
            this.Coinslbl.Text = "0";
            // 
            // Answer4btn
            // 
            this.Answer4btn.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.Answer4btn.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.Answer4btn.BackColor = System.Drawing.Color.Transparent;
            this.Answer4btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Answer4btn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Answer4btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Answer4btn.ForeColor = System.Drawing.Color.Black;
            this.Answer4btn.Inactive1 = System.Drawing.Color.Gainsboro;
            this.Answer4btn.Inactive2 = System.Drawing.Color.MediumTurquoise;
            this.Answer4btn.Location = new System.Drawing.Point(561, 532);
            this.Answer4btn.Name = "Answer4btn";
            this.Answer4btn.Radius = 10;
            this.Answer4btn.Size = new System.Drawing.Size(511, 95);
            this.Answer4btn.Stroke = true;
            this.Answer4btn.StrokeColor = System.Drawing.Color.Black;
            this.Answer4btn.TabIndex = 7;
            this.Answer4btn.Text = "Answer 4";
            this.Answer4btn.Transparency = false;
            // 
            // Answer3btn
            // 
            this.Answer3btn.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.Answer3btn.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.Answer3btn.BackColor = System.Drawing.Color.Transparent;
            this.Answer3btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Answer3btn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Answer3btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Answer3btn.ForeColor = System.Drawing.Color.Black;
            this.Answer3btn.Inactive1 = System.Drawing.Color.Gainsboro;
            this.Answer3btn.Inactive2 = System.Drawing.Color.MediumTurquoise;
            this.Answer3btn.Location = new System.Drawing.Point(33, 532);
            this.Answer3btn.Name = "Answer3btn";
            this.Answer3btn.Radius = 10;
            this.Answer3btn.Size = new System.Drawing.Size(511, 95);
            this.Answer3btn.Stroke = true;
            this.Answer3btn.StrokeColor = System.Drawing.Color.Black;
            this.Answer3btn.TabIndex = 6;
            this.Answer3btn.Text = "Answer 3";
            this.Answer3btn.Transparency = false;
            // 
            // Answer2btn
            // 
            this.Answer2btn.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.Answer2btn.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.Answer2btn.BackColor = System.Drawing.Color.Transparent;
            this.Answer2btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Answer2btn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Answer2btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Answer2btn.ForeColor = System.Drawing.Color.Black;
            this.Answer2btn.Inactive1 = System.Drawing.Color.Gainsboro;
            this.Answer2btn.Inactive2 = System.Drawing.Color.MediumTurquoise;
            this.Answer2btn.Location = new System.Drawing.Point(561, 425);
            this.Answer2btn.Name = "Answer2btn";
            this.Answer2btn.Radius = 10;
            this.Answer2btn.Size = new System.Drawing.Size(511, 95);
            this.Answer2btn.Stroke = true;
            this.Answer2btn.StrokeColor = System.Drawing.Color.Black;
            this.Answer2btn.TabIndex = 5;
            this.Answer2btn.Text = "Answer 2";
            this.Answer2btn.Transparency = false;
            // 
            // Answer1btn
            // 
            this.Answer1btn.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.Answer1btn.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.Answer1btn.BackColor = System.Drawing.Color.Transparent;
            this.Answer1btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Answer1btn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Answer1btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Answer1btn.ForeColor = System.Drawing.Color.Black;
            this.Answer1btn.Inactive1 = System.Drawing.Color.Gainsboro;
            this.Answer1btn.Inactive2 = System.Drawing.Color.MediumTurquoise;
            this.Answer1btn.Location = new System.Drawing.Point(33, 425);
            this.Answer1btn.Name = "Answer1btn";
            this.Answer1btn.Radius = 10;
            this.Answer1btn.Size = new System.Drawing.Size(511, 95);
            this.Answer1btn.Stroke = true;
            this.Answer1btn.StrokeColor = System.Drawing.Color.Black;
            this.Answer1btn.TabIndex = 4;
            this.Answer1btn.Text = "Answer 1";
            this.Answer1btn.Transparency = false;
            // 
            // CoinsPB
            // 
            this.CoinsPB.Image = global::SOS_Essential.Properties.Resources.Coin;
            this.CoinsPB.Location = new System.Drawing.Point(1045, 10);
            this.CoinsPB.Name = "CoinsPB";
            this.CoinsPB.Size = new System.Drawing.Size(50, 50);
            this.CoinsPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CoinsPB.TabIndex = 11;
            this.CoinsPB.TabStop = false;
            // 
            // ConnectServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::SOS_Essential.Properties.Resources.backgroundApp;
            this.Controls.Add(this.ExitBtnWindow);
            this.Controls.Add(this.MinimizeBtnWindow);
            this.Controls.Add(this.Playground);
            this.Controls.Add(this.PlayerList);
            this.Controls.Add(this.ServerLobby);
            this.Controls.Add(this.BackButton);
            this.Name = "ConnectServer";
            this.Size = new System.Drawing.Size(1200, 719);
            this.ServerLobby.ResumeLayout(false);
            this.ServerLobby.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddServer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReloadServers)).EndInit();
            this.PlayerList.ResumeLayout(false);
            this.PlayerList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackButton)).EndInit();
            this.Playground.ResumeLayout(false);
            this.Playground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CoinsImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoinsPB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel ServerLobby;
        private Panel panel6;
        private Panel panel5;
        private Panel panel4;
        private Panel panel3;
        public ClassicDarkTheme.Dark.DarkPicturebox BackButton;
        private Label ServerListLBL;
        private ListBox ServerList;
        private PictureBox ReloadServers;
        public Panel PlayerList;
        private Label label1;
        private ListBox UserList;
        private Panel panel2;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
        private CustomControls.SpinningCircles loading;
        private Label ExitBtnWindow;
        private Label MinimizeBtnWindow;
        public Panel Playground;
        public CustomControls.AltoButton Answer4btn;
        public CustomControls.AltoButton Answer3btn;
        public CustomControls.AltoButton Answer2btn;
        public CustomControls.AltoButton Answer1btn;
        public Label Coinslbl;
        private PictureBox AddServer;
        private PictureBox CoinsPB;
        private PictureBox CoinsImage;
        public Label Questionlbl;
        public Label AnswersDonelbl;
        public Label TimeLeftlbl;
        private MetroFramework.Controls.MetroProgressBar GameTimer;
    }
}

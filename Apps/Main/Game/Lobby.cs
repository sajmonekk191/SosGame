using SOS_Essential.Essentials;

namespace SOS_Essential.Apps.Main.Game
{
    public partial class Lobby : UserControl
    {
        #region Hodnoty
        CreateServer createServerControl;
        ConnectServer connectServerControl;

        ToolTip toolTip = new ToolTip();
        #endregion
        public Lobby()
        {
            InitializeComponent();

            #region Nastaveni Appky
            // Button Design //

            toolTip.SetToolTip(BackButton, "Go back to the previous screen");

            BackButton.MouseDown += BackButton_MouseDown;
            BackButton.MouseUp += BackButton_MouseUp;

            // Button Design //

            // Initialize UserControls //

            // CreateServer
            createServerControl = new CreateServer();
            createServerControl.Dock = DockStyle.Fill;
            this.Controls.Add(createServerControl);
            createServerControl.Show();
            createServerControl.Visible = false;
            // CreateServer

            //JoinServer
            connectServerControl = new ConnectServer();
            connectServerControl.Dock = DockStyle.Fill;
            this.Controls.Add(connectServerControl);
            connectServerControl.Show();
            connectServerControl.Visible = false;
            //JoinServer

            // Initialize UserControls //

            // App Moving //
            this.MouseDown += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    // Zajistěte, že MainAppForm je správně nastaveno
                    if (MainApp.Instance != null)
                    {
                        WindowsAPI.ReleaseCapture();
                        WindowsAPI.SendMessage(MainApp.Instance.Handle, WindowsAPI.WM_NCLBUTTONDOWN, WindowsAPI.HT_CAPTION, 0);
                    }
                }
            };
            //App Moving //
            #endregion
        }

        #region Settings

        // Button Design //

        private void CreateServer_MouseEnter(object sender, EventArgs e)
        {
            CreateServer.BorderStyle = BorderStyle.Fixed3D;
        }

        private void CreateServer_MouseLeave(object sender, EventArgs e)
        {
            CreateServer.BorderStyle = BorderStyle.None;
        }

        private void JoinServer_MouseEnter(object sender, EventArgs e)
        {
            JoinServer.BorderStyle = BorderStyle.Fixed3D;
        }

        private void JoinServer_MouseLeave(object sender, EventArgs e)
        {
            JoinServer.BorderStyle = BorderStyle.None;
        }

        // Button Design //


        // Back Button //

        private void BackButton_MouseDown(object sender, MouseEventArgs e)
        {
            BackButton.Size = new Size(BackButton.Width - 2, BackButton.Height - 2);
            BackButton.Location = new Point(BackButton.Location.X + 1, BackButton.Location.Y + 1);
        }

        private void BackButton_MouseUp(object sender, MouseEventArgs e)
        {
            BackButton.Size = new Size(BackButton.Width + 2, BackButton.Height + 2);
            BackButton.Location = new Point(BackButton.Location.X - 1, BackButton.Location.Y - 1);
        }

        // Back Button //
        #endregion
        #region Other
        private void JoinServer_Click(object sender, EventArgs e)
        {
            // Add and show ConnectServerControl
            if (this.Controls.Contains(connectServerControl))
            {
                MainApp.Instance.ShowHideExitMinimizeBTN(false);
                connectServerControl.Visible = true;
                connectServerControl.BringToFront();
            }
            else
            {
                MessageBox.Show("ConnectServerControl is null, Try to restart App.", "Error");
            }
        }

        private void CreateServer_Click(object sender, EventArgs e)
        {
            // Add and show CreateServerControl
            if (this.Controls.Contains(createServerControl))
            {
                MainApp.Instance.ShowHideExitMinimizeBTN(false);
                createServerControl.Visible = true;
                createServerControl.BringToFront();
            }
            else
            {
                MessageBox.Show("CreateServerControl is null, Try to restart App.", "Error");
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            MainApp.Instance.ShowOrHideControls(true);
            this.Visible = false;
        }
        #endregion
    }
}

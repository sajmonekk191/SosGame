using SOS_Essential.Apps.Main.Game;
using SOS_Essential.Essentials;
using SOS_Essential.Properties;

namespace SOS_Essential.Apps.Main
{
    public partial class MainApp : Form
    {
        public static MainApp Instance { get; private set; }

        Game.Lobby lobbyControl = new Game.Lobby();
        CreateServer server = new CreateServer();
        ConnectServer client = new ConnectServer();
        Lobby.LevelMaker lvlmaker = new Lobby.LevelMaker();

        public MainApp()
        {
            InitializeComponent();
            Instance = this;

            #region Nastaveni Appky
            // Setup UserControls //

            // -- Lobby UserControl --
            lobbyControl.Dock = DockStyle.Fill;
            this.Controls.Add(lobbyControl);
            lobbyControl.Show();
            lobbyControl.Visible = false;
            // -- Lobby UserControl --

            // -- LevelMaker UserControl --
            lvlmaker.Dock = DockStyle.Fill;
            this.Controls.Add(lvlmaker);
            lvlmaker.Show();
            lvlmaker.Visible = false;
            // -- LevelMaker UserControl --
            // Setup UserControls //

            // App Moving //
            this.MouseDown += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    // Zajistìte, že MainAppForm je správnì nastaveno
                    if (Instance != null)
                    {
                        WindowsAPI.ReleaseCapture();
                        WindowsAPI.SendMessage(Instance.Handle, WindowsAPI.WM_NCLBUTTONDOWN, WindowsAPI.HT_CAPTION, 0);
                    }
                }
            };
            //App Moving //
            #endregion
        }

        #region Nastaveni Appky

        // MinizeBox //
        private void MinimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void MinimizeBtn_MouseEnter(object sender, EventArgs e)
        {
            MinimizeBtnWindow.BackColor = Color.Silver;
        }

        private void MinimizeBtn_MouseLeave(object sender, EventArgs e)
        {
            MinimizeBtnWindow.BackColor = Color.LightGray;
        }
        // MinizeBox //

        // ExitButton //

        private void ExitBtnWindow_MouseEnter(object sender, EventArgs e)
        {
            ExitBtnWindow.BackColor = Color.DarkRed;
        }

        private void ExitBtnWindow_MouseLeave(object sender, EventArgs e)
        {
            ExitBtnWindow.BackColor = Color.Firebrick;
        }

        private async void ExitBtnWindow_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // ExitButton //

        // Animace //
        private void Train_Click(object sender, EventArgs e)
        {
            Train.Image = Resources.TrainGif;
        }

        private bool isCzechFlagDisplayed = true;
        private bool isEnglishFlagDisplayed = true;
        private void CestinaFlag_Click(object sender, EventArgs e)
        {
            isCzechFlagDisplayed = !isCzechFlagDisplayed;
            CestinaFlag.Image = isCzechFlagDisplayed ? Resources.czechflag : Resources.anglictina;
        }

        private void EnglishFlag_Click(object sender, EventArgs e)
        {
            isEnglishFlagDisplayed = !isEnglishFlagDisplayed;
            EnglishFlag.Image = isEnglishFlagDisplayed ? Resources.anglictina : Resources.czechflag;
        }
        // Animace //

        // Hide/Show Controls //

        public void ShowOrHideControls(bool show)
        {
            CestinaFlag.Visible = show;
            EnglishFlag.Visible = show;
            LogoImg.Visible = show;
            LogoPanel.Visible = show;
            StartButton.Visible = show;
            ExitButton.Visible = show;
            LevelMakerButton.Visible = show;
            Train.Visible = show;
        }

        public void ShowHideExitMinimizeBTN(bool show)
        {
            this.Invoke(new Action(() =>
            {
                ExitBtnWindow.Visible = show;
                MinimizeBtnWindow.Visible = show;
            }));
        }

        // Hide/Show Controls //

        #endregion nastaveni appky

        // Buttons //

        private async void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            ShowOrHideControls(false);
            lobbyControl.Visible = true;
        }
        private void LevelMakerButton_Click(object sender, EventArgs e)
        {
            ShowOrHideControls(false);
            lvlmaker.Visible = true;
        }

        private async void MainApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (client.client != null)
                {
                    await client.DisconnectFromServer();
                }
                if (server.listener != null)
                {
                    await server.StopServer();
                }
            }
            catch { }
        }

        // Buttons //
    }
}
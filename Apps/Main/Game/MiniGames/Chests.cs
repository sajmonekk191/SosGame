using SOS_Essential.Essentials;

namespace SOS_Essential.Apps.Main.Game.MiniGames
{
    public partial class Chests : UserControl
    {
        #region ChestGame Variables
        private ConnectServer connectServer;
        private Random rng = new Random();
        private Dictionary<PictureBox, string> chestItems = new Dictionary<PictureBox, string>();
        private string item;
        private int defaultWidth;
        #endregion
        public Chests(ConnectServer connectServer)
        {
            InitializeComponent();
            ResetChests();
            this.connectServer = connectServer;
            #region MainSettings

            // Button //
            Chest1.Click += Chest_Click;
            Chest2.Click += Chest_Click;
            Chest3.Click += Chest_Click;
            Chest4.Click += Chest_Click;
            // Button //

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
        // MinizeBox //
        private void MinimizeBtnWindow_Click(object sender, EventArgs e)
        {
            MainApp.Instance.WindowState = FormWindowState.Minimized;
        }

        private void MinimizeBtnWindow_MouseEnter(object sender, EventArgs e)
        {
            MinimizeBtnWindow.BackColor = Color.Silver;
        }

        private void MinimizeBtnWindow_MouseLeave(object sender, EventArgs e)
        {
            MinimizeBtnWindow.BackColor = Color.LightGray;
        }
        // MinizeBox //

        // ExitButton //
        private async void ExitBtnWindow_Click(object sender, EventArgs e)
        {
            Invoke(new MethodInvoker(async delegate
            {
                await connectServer.DisconnectFromServer();
                Application.Exit();
            })); 
        }

        private void ExitBtnWindow_MouseEnter(object sender, EventArgs e)
        {
            ExitBtnWindow.BackColor = Color.DarkRed;
        }

        private void ExitBtnWindow_MouseLeave(object sender, EventArgs e)
        {
            ExitBtnWindow.BackColor = Color.Firebrick;
        }
        // ExitButton //

        // BackButton //

        private async void BackButton_Click(object sender, EventArgs e)
        {
            Invoke(new MethodInvoker(async delegate
            {
                this.Visible = false;
                connectServer.Playground.Visible = false;
                connectServer.PlayerList.Visible = false;
                connectServer.BackColor = Color.Transparent;
                connectServer.BackButton.BackColor = Color.Transparent;
                ResetChests();
                await connectServer.DisconnectFromServer();
            }));
        }

        // BackButton //
        #endregion
        #region ChestGame
        private void AssignRandomItemsToChests()
        {
            List<string> items = new List<string>
        {
            "2x Coins", "3x Coins", "-10% Coins", "-5% Coins", "FreezeEnemy",
            "Freeze", "Star"
        };

            List<PictureBox> chests = new List<PictureBox>
        {
            Chest1, Chest2, Chest3, Chest4
        };
            for (int i = items.Count - 1; i > 0; i--)
            {
                int swapIndex = rng.Next(i + 1);
                string temp = items[i];
                items[i] = items[swapIndex];
                items[swapIndex] = temp;
            }
            for (int i = 0; i < chests.Count; i++)
            {
                string assignedItem = items[i % items.Count];
                chestItems[chests[i]] = assignedItem;
            }
        }

        private async void Chest_Click(object sender, EventArgs e)
        {
            PictureBox clickedChest = sender as PictureBox;
            if (clickedChest != null && chestItems.ContainsKey(clickedChest))
            {
                item = chestItems[clickedChest];
                clickedChest.Image = Properties.Resources.Opened_Treasure;
                UpdateUIForItem(item);
                DisableAllChests();
                CheckUsername();
                switch (item)
                {
                    case "2x Coins":
                        connectServer.coins *= 2;
                        break;
                    case "3x Coins":
                        connectServer.coins *= 3;
                        break;
                    case "-10% Coins":
                        connectServer.coins -= (int)(connectServer.coins * (Math.Abs(10) / 100.0));
                        break;
                    case "-5% Coins":
                        connectServer.coins -= (int)(connectServer.coins * (Math.Abs(5) / 100.0));
                        break;
                    case "FreezeEnemy":
                        await connectServer.SendResponseAsync(connectServer.CreateMessage("FREEZE_ENEMY", $"{connectServer.Username}"), connectServer.stream);
                        break;
                    case "Freeze":
                        await Task.Delay(300);
                        await ApplyFreezeEffect();
                        break;
                    case "Star":
                        connectServer.PointsPerCorrectAnswer++;
                        await connectServer.SendResponseAsync(connectServer.CreateMessage("STAR_ACTIVATED", $"{connectServer.Username}"), connectServer.stream);
                        break;
                }
                if(item == "2x Coins" || item == "3x Coins" || item == "-10% Coins" || item == "-5% Coins") await UpdateCoins();
            }
            await Task.Delay(1300);
            ResetChests();
            this.Visible = false;
        }
        #endregion
        #region Freeze
        private async Task ApplyFreezeEffect()
        {
            Panel freezePanel = new Panel
            {
                Size = this.ClientSize,
                Location = new Point(0, 0),
                BackgroundImage = Properties.Resources.Frozen,
                BackgroundImageLayout = ImageLayout.Zoom,
                BackColor = Color.FromArgb(60, Color.White),
                Visible = true
            };

            Label countdownLabel = new Label
            {
                Size = new Size(100, 50),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 22, FontStyle.Bold),
                ForeColor = Color.Blue,
                BackColor = Color.Transparent,
                Location = new Point(
            (freezePanel.Width - 100) / 2,
            (freezePanel.Height - 50) / 2
            ),
                Text = "10"
            };


            freezePanel.Controls.Add(countdownLabel);
            this.Controls.Add(freezePanel);
            freezePanel.BringToFront();
            connectServer.GameTimerTicker.Stop();
            for (int seconds = 10; seconds > 0; seconds--)
            {
                countdownLabel.Text = seconds.ToString();
                await Task.Delay(1000);
            }
            connectServer.GameTimerTicker.Start();
            this.Controls.Remove(freezePanel);
            freezePanel.Dispose();
        }
        #endregion
        #region Other ChestSettings
        private async Task CheckUsername()
        {
            await connectServer.SendResponseAsync(connectServer.CreateMessage("CHECK_USERNAME", connectServer.Username), connectServer.stream);
            ConnectServer.Message usernameResponse = await connectServer.ReadResponseAsync(connectServer.stream);
            if (usernameResponse.TypeRequest == "UPDATE_USERNAME")
            {
                connectServer.Username = usernameResponse.Data;
            }
        }
        private async Task UpdateCoins()
        {
            await connectServer.SendResponseAsync(connectServer.CreateMessage("ADD_COINS", $"{connectServer.Username} {connectServer.coins}"), connectServer.stream);
            connectServer.Coinslbl.Text = connectServer.coins.ToString();
        }
        private void DisableAllChests()
        {
            foreach (var chest in new[] { Chest1, Chest2, Chest3, Chest4 })
            {
                chest.Enabled = false;
                chest.Cursor = Cursors.Default;
            }
        }

        private void UpdateUIForItem(string item)
        {
            ItemLabel.Text = item;
            ItemLabel.Visible = true;
            ItemIcon.Visible = true;
            ItemPanel.Visible = true;
            SkipButton.Visible = false;

            switch (item)
            {
                case "-10% Coins":
                    ItemIcon.Image = Properties.Resources._10_Coins;
                    break;
                case "-5% Coins":
                    ItemIcon.Image = Properties.Resources._5_Coins;
                    break;
                case "2x Coins":
                    ItemIcon.Image = Properties.Resources._2xMultiplier;
                    break;
                case "3x Coins":
                    ItemIcon.Image = Properties.Resources._3xMultiplier;
                    break;
                case "Star":
                    ItemIcon.Image = Properties.Resources.Star;
                    break;
                case "Stun":
                    ItemIcon.Image = Properties.Resources.Stun;
                    break;
                case "Freeze":
                    ItemIcon.Image = Properties.Resources.Freeze;
                    break;
                case "FreezeEnemy":
                    ItemIcon.Image = Properties.Resources.Freeze;
                    break;
                default:
                    ItemIcon.Image = null;
                    break;
            }
        }
        private void ResetChests()
        {
            Chest1.Image = Properties.Resources.Treasure;
            Chest2.Image = Properties.Resources.Treasure;
            Chest3.Image = Properties.Resources.Treasure;
            Chest4.Image = Properties.Resources.Treasure;

            foreach (var chest in new[] { Chest1, Chest2, Chest3, Chest4 })
            {
                chest.Cursor = Cursors.Hand;
                chest.Enabled = true;
            }

            ItemIcon.Visible = false;
            ItemLabel.Text = null;
            ItemPanel.Visible = false;
            if(defaultWidth > 0)ItemPanel.Width = defaultWidth;
            SkipButton.Visible = true;

            item = null;
            chestItems.Clear();
            AssignRandomItemsToChests();
        }
        #endregion
        #region Other
        private void SkipButton_Click(object sender, EventArgs e)
        {
            ResetChests();
            this.Visible = false;
        }
        #endregion
    }
}

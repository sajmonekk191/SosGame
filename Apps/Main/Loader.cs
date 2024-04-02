using System.Diagnostics;
using System.Net;
using SOS_Essential.Apps.Main.Lobby;
using SOS_Essential.Essentials.User;

namespace SOS_Essential.Apps.Main
{
    public partial class Loader : Form
    {
        LevelMaker levelMaker = new LevelMaker();
        public Loader()
        {
            InitializeComponent();
        }

        private void Loader_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.Visible = true;
            this.ShowInTaskbar = false;
            this.BringToFront();
            pictureBox1.Image = Properties.Resources.LogoM;
            loadlbl.Text = "Vyhledávání Aktualizace...";
            Wait(10);
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    if (!webClient.DownloadString("https://pastebin.com/5LXUPYx7").Contains("Update1"))
                    {
                        if (MessageBox.Show("K dispozici je nová aktualizace !", "Updater", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                        {
                            Process.Start(new ProcessStartInfo("http://127.0.0.1/sos_essential") { UseShellExecute = true });
                            Application.Exit();
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error Code: 1\nNepodařilo se vyhledat aktualizace !\nZkuste restartovat applikaci", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            loadlbl.Text = "Připojování k Účtu...";
            loadlbl.Location = new Point(loadlbl.Location.X + 21, loadlbl.Location.Y);
            Account.JoinAccount(Account.Username, Account.Nickname, Account.XP, Account.Coins);
            Wait(10);
            loadlbl.Text = "Načítání applikace...";
            levelMaker.EnsureGameDataDirectoriesExist();
            Wait(10);
            MainApp main = new MainApp();
            main.Show();

            this.Size = new Size(0, 0);
            this.Hide();
        }
        public void Wait(int time)
        {
            Thread thread = new Thread(delegate ()
            {
                Thread.Sleep(time);
            });
            thread.Start();
            while (thread.IsAlive)
                Application.DoEvents();
        }
    }
}

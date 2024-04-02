using SOS_Essential.Apps.Main.Lobby.AditionalForms;
using SOS_Essential.Essentials;
using System.Text.RegularExpressions;

namespace SOS_Essential.Apps.Main.Lobby
{
    public partial class LevelMaker : UserControl
    {
        private FormImageTooltip tooltipForm;
        ToolTip helpToolTip = new ToolTip();
        public readonly string dataFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SosGameData");
        public LevelMaker()
        {
            InitializeComponent();

            helpToolTip.SetToolTip(this.Helplbl, "Here is how you can use the LevelMaker:\n- Click 'Load' to open an existing .sos file.\n- Edit the level as needed.\n- Click 'Save' to save your changes.\n- Click 'Open Level Folder' to see all levels folder.");
            Image tooltipImage = Properties.Resources.Info;
            tooltipForm = new FormImageTooltip(tooltipImage);
            #region AppMoving
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
        // Back Button //

        private void BackButton_Click(object sender, EventArgs e)
        {
            MainApp.Instance.ShowOrHideControls(true);
            this.Visible = false;
        }

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

        // Help Label Tooltip //
        private void Helplbl_MouseDown(object sender, MouseEventArgs e)
        {
            
            if (e.Button == MouseButtons.Left)
            {
                Point screenPoint = this.PointToScreen(new Point(Helplbl.Left - 90, Helplbl.Top - 110));
                tooltipForm.Location = screenPoint;
                tooltipForm.Show();
            }
        }

        private void Helplbl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                tooltipForm.Hide();
            }
            // Random Right button click :D //
            else if (e.Button == MouseButtons.Right)
            {
                tooltipForm.Hide();

            }
            // Random Right button click :D //
        }
        // Help Label Tooltip //
        #endregion

        private void LoadFilebtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "SOS files (*.sos)|*.sos",
                Title = "Open SOS File",
                InitialDirectory = Directory.Exists(dataFolderPath) ? dataFolderPath : Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) // Fallback to My Documents if the folder doesn't exist
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialog.FileName;
                    string fileContent = File.ReadAllText(filePath);
                    CodeField.TextStr = fileContent;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveFilebtn_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(dataFolderPath))
            {
                DialogResult result = MessageBox.Show("The directory does not exist. Do you want to create it now?", "Directory Not Found", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes) EnsureGameDataDirectoriesExist();
                else return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "SOS files (*.sos)|*.sos",
                Title = "Save SOS File",
                InitialDirectory = dataFolderPath
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = saveFileDialog.FileName;
                    string contentToSave = CodeField.TextStr;
                    File.WriteAllText(filePath, contentToSave);
                    MessageBox.Show("File saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OpenFolderbtn_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(dataFolderPath))
            {
                DialogResult result = MessageBox.Show("The directory does not exist. Do you want to create it now?", "Directory Not Found", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes) EnsureGameDataDirectoriesExist();
                else return;
            }

            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = dataFolderPath,
                    UseShellExecute = true, 
                    Verb = "open"
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to open the directory: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void EnsureGameDataDirectoriesExist()
        {
            string dataFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SosGameData");

            if (!Directory.Exists(dataFolderPath))
            {
                Directory.CreateDirectory(dataFolderPath);
            }

            string[] gameModes = { "Programovani", "Matematika", "IT", "Custom", "Cestina", "Anglictina" };

            foreach (var mode in gameModes)
            {
                string modePath = Path.Combine(dataFolderPath, mode);
                if (!Directory.Exists(modePath))
                {
                    Directory.CreateDirectory(modePath);
                }
            }
        }
    }
}

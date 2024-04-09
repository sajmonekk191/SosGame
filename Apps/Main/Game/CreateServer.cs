// Dodělat pokud je Freeze tak GameTimer pořád jede
// Fixnout .csv 
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using SOS_Essential.Essentials;

namespace SOS_Essential.Apps.Main.Game
{
    public partial class CreateServer : UserControl
    {
        #region ServerInfo
        public class ServerInfo
        {
            public string ServerIP { get; set; }
            public string ServerName { get; set; }
            public string ServerPassword { get; set; }
            public int Players { get; set; } = 0;
            public int MaxPlayers { get; set; }
            public string GameMode { get; set; }
            public bool IsArcade { get; set; }
            public bool IsTimer { get; set; }
            public int TimerValue { get; set; }
        }
        public class Message
        {
            public string TypeRequest { get; set; }
            public string Data { get; set; }
        }
        #endregion
        #region Values
        public bool isServerRunning;
        ServerInfo serverinfo = new ServerInfo();
        public TcpListener listener;
        public readonly List<TcpClient> connectedClients = new List<TcpClient>();
        private object lockObject = new object();

        ToolTip toolTip = new ToolTip();
        private readonly string dataFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SosGameData");
        #endregion
        public CreateServer()
        {
            InitializeComponent();
            InitalizeSettings();
        }
        #region Settings

        // InitalizeData //

        private void InitalizeSettings()
        {
            GameModeSelector.SelectedValueChanged += GameModeSelector_SelectedValueChanged;
            GameTimerslider.SliderValueChanged += GameTimerslider_SliderValueChanged;

            UserList.DrawMode = DrawMode.OwnerDrawFixed;
            UserList.DrawItem += new DrawItemEventHandler(UserList_DrawItem);

            ipTB.Text = GetLocalIPAddress().ToString();

            toolTip.SetToolTip(BackButton, "Go back to the previous screen");

            BackButton.MouseDown += BackButton_MouseDown;
            BackButton.MouseUp += BackButton_MouseUp;


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
        }

        private void GameModeSelector_SelectedValueChanged(object? sender, EventArgs e)
        {
            if (GameModeSelector.SelectedItem != null)
            {
                selectlvlcombobox.Items.Clear();
                string GMString = null;
                switch (GameModeSelector.SelectedItem.ToString())
                {
                    case "Čeština":
                        GMString = "Cestina";
                        PreviewPB.Image = Properties.Resources.cestina;
                        break;
                    case "Matematika":
                        GMString = "Matematika";
                        PreviewPB.Image = Properties.Resources.matematika;
                        break;
                    case "Angličtina":
                        GMString = "Anglictina";
                        PreviewPB.Image = Properties.Resources.anglictina;
                        break;
                    case "Informační Technologie":
                        GMString = "IT";
                        PreviewPB.Image = Properties.Resources.it;
                        break;
                    case "Programování":
                        GMString = "Programovani";
                        PreviewPB.Image = Properties.Resources.programing;
                        break;
                    case "Custom":
                        GMString = "Custom";
                        PreviewPB.Image = Properties.Resources.Random;
                        break;
                    default:
                        GMString = "None";
                        PreviewPB.Image = Properties.Resources.Random;
                        break;
                }
                serverinfo.GameMode = GMString;

                string fullFolderPath = Path.Combine(dataFolderPath, GMString);

                if (Directory.Exists(fullFolderPath))
                {
                    var files = Directory.GetFiles(fullFolderPath, "*.sos");
                    foreach (string file in files)
                    {
                        selectlvlcombobox.Items.Add(Path.GetFileNameWithoutExtension(file));
                    }
                }
                else
                {
                    MessageBox.Show($"The directory for the selected game mode does not exist: {fullFolderPath}", "Directory Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // InitalizeData //

        // Přídání Exit + Minimize btn protože appka nechce disconnect User
        // {

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
            await StopServer();
            Application.Exit();
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

        // Přídání Exit + Minimize btn protože appka nechce disconnect User
        // }

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

        private async void BackButton_Click(object sender, EventArgs e)
        {
            await StopServer();
            UserList.Invoke(new MethodInvoker(delegate
            {
                UserList.Items.Clear();
                MainApp.Instance.ShowHideExitMinimizeBTN(true);
                this.Visible = false;
                ServerLobby.Visible = false;
                CreateServerPanel.Visible = true;
                ServerNameTB.Text = "";
                PasswordTB.Text = "";
                PlayerCountSelector.SelectedItem = null;
                GameModeSelector.SelectedItem = null;
                selectlvlcombobox.SelectedItem = null;
                ArcadeSlider.IsOn = false;
                GameTimerslider.IsOn = false;
            }));
        }

        // Back Button //

        // Start Server //

        private void CreateServerBtn_Click(object sender, EventArgs e)
        {
            StringBuilder missingFields = new StringBuilder();
            bool allFieldsValid = true;

            if (string.IsNullOrWhiteSpace(ServerNameTB.Text))
            {
                missingFields.AppendLine("- Server Name is missing.");
                allFieldsValid = false;
            }
            if (PlayerCountSelector.SelectedItem == null)
            {
                missingFields.AppendLine("- Max Players is not selected.");
                allFieldsValid = false;
            }
            if (GameModeSelector.SelectedItem == null)
            {
                missingFields.AppendLine("- Game Mode is not selected.");
                allFieldsValid = false;
            }
            if (selectlvlcombobox.SelectedItem == null)
            {
                missingFields.AppendLine("- Game Level is not selected.");
                allFieldsValid = false;
            }

            if (allFieldsValid)
            {
                serverinfo.ServerIP = ipTB.Text;
                serverinfo.ServerName = ServerNameTB.Text;
                serverinfo.ServerPassword = PasswordTB.Text;
                serverinfo.MaxPlayers = Convert.ToInt32(PlayerCountSelector.SelectedItem.ToString());
                serverinfo.IsArcade = ArcadeSlider.IsOn;
                serverinfo.IsTimer = GameTimerslider.IsOn;
                serverinfo.TimerValue = Convert.ToInt32(GameTimernumeric.Value);

                StartServer();
                CreateServerPanel.Visible = false;
                ServerLobby.Visible = true;
            }
            else
            {
                MessageBox.Show("Please correct the following fields:\n" + missingFields.ToString(), "Error");
            }
        }

        // Start Server //

        #endregion
        #region Server Common Settings
        public void StartServer()
        {
            IPAddress localIP = GetLocalIPAddress();
            if (localIP == null) return;

            listener = new TcpListener(localIP, 11259);
            listener.Start();
            isServerRunning = true;

            Task.Run(() => AcceptClientsAsync()).ConfigureAwait(false);
        }
        public async Task StopServer()
        {
            try
            {
                foreach (var client in connectedClients.ToList())
                {
                    if (client.Connected)
                    {
                        var stream = client.GetStream();

                        await SendResponseAsync(CreateMessage("DISCONNECTED", ""), stream);

                        stream.Close();
                        client.Close();
                    }
                }

                connectedClients.Clear();
                isServerRunning = false;
                listener?.Stop();
                serverinfo.Players = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while stopping the server: {ex.Message}");
            }
        }



        private IPAddress GetLocalIPAddress()
        {
            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530); // Google's public DNS server
                if (socket.LocalEndPoint is IPEndPoint endPoint)
                {
                    return endPoint.Address;
                }
                return null;
            }
        }

        private void UserList_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.Graphics.FillRectangle(new SolidBrush(SystemColors.Window), e.Bounds);

            string originalText = ((ListBox)sender).Items[e.Index].ToString();
            var parts = originalText.Split(new[] { ' ' }, 2);
            if (parts.Length == 2)
            {
                string formattedText = $"{parts[0]}        Level: {parts[1]}";
                StringFormat stringFormat = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                Brush textBrush = new SolidBrush(SystemColors.WindowText);

                e.Graphics.DrawString(formattedText, e.Font, textBrush, e.Bounds, stringFormat);
            }
        }

        #endregion
        #region Client Main
        private async Task AcceptClientsAsync()
        {
            while (isServerRunning)
            {
                try
                {
                    var client = await listener.AcceptTcpClientAsync();
                    Task.Run(() => HandleClientAsync(client)).ConfigureAwait(false);
                }
                catch (Exception ex) when (ex is ObjectDisposedException || ex is SocketException)
                {
                    Debug.WriteLine($"AcceptClientsAsync exception: {ex.Message}");
                    break;
                }
            }
        }

        private async Task HandleClientAsync(TcpClient client)
        {
            try
            {
                using (client)
                using (var stream = client.GetStream())
                {
                    var buffer = new byte[40480];
                    while (true)
                    {
                        var bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                        if (bytesRead == 0) break;

                        var request = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
                        await ProcessClientRequestAsync(request, stream, client);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"HandleClientAsync exception: {ex.Message}");
            }
        }
        #endregion
        #region Process Client Requests
        private async Task ProcessClientRequestAsync(string request, NetworkStream stream, TcpClient client)
        {
            try
            {
                var message = JsonConvert.DeserializeObject<Message>(request);
                Message response;

                switch (message.TypeRequest)
                {
                    case "GET_SERVER_INFO":
                        response = await GetServerInfoResponse();
                        break;
                    case "TRY_CONNECT":
                        response = await TryConnectAsync(stream);
                        break;
                    case "CONNECT_SERVER":
                        response = await ConnectClient(client, message);
                        break;
                    case "DISCONNECT_SERVER":
                        response = await DisconnectClient(client, message.Data);
                        break;
                    case "CHECK_USERNAME":
                        response = await CheckIfNameLogged(client, message.Data);
                        break;
                    case "USER_LIST":
                        response = await SendUserListToClient(client);
                        break;
                    case "SEND_USER_INFO":
                        response = await SendServerInfoToClient(client, message.Data);
                        break;
                    case "ADD_COINS":
                        response = await AddCoinsToUser(message.Data);
                        break;
                    case "FREEZE_ENEMY":
                        response = await FreezeUsers(client, message.Data);
                        break;
                    case "STAR_ACTIVATED":
                        response = await ActivateUserStar(message.Data);
                        break;
                    case "QUESTION":
                        response = await AddQuestionToUser(message.Data);
                        break;
                    default:
                        response = CreateMessage("UNKNOWN_REQUEST", "");
                        break;
                }
                if (response != null)
                {
                    await SendResponseAsync(response, stream);
                }
            }
            catch (JsonException)
            {
                await SendResponseAsync(CreateMessage("ERROR", "ERROR: Bad request format."), stream);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception in ProcessClientRequestAsync: {ex.Message}");
                await SendResponseAsync(CreateMessage("ERROR", $"ERROR: {ex.Message}"), stream);
            }
        }
        #endregion
        #region QUESTION
        private async Task<Message> AddQuestionToUser(string data)
        {
            var parts = data.Split(new[] { " Questions: " }, StringSplitOptions.None);
            if (parts.Length < 2)
            {
                return CreateMessage("ERROR", "Invalid data format.");
            }

            string username = parts[0];
            string questionInfo = parts[1];

            if (UserList.InvokeRequired)
            {
                UserList.Invoke(new Action(async () => await AddQuestionToUser(data)));
            }
            else
            {
                for (int i = 0; i < UserList.Items.Count; i++)
                {
                    if (UserList.Items[i].ToString().StartsWith(username))
                    {
                        string currentText = UserList.Items[i].ToString();
                        string updatedText;

                        int questionIndex = currentText.IndexOf("Questions:");
                        if (questionIndex != -1)
                        {
                            updatedText = currentText.Substring(0, questionIndex) + "Questions: " + questionInfo;
                        }
                        else
                        {
                            updatedText = currentText + "     Questions: " + questionInfo;
                        }

                        UserList.Items[i] = updatedText;
                        break;
                    }
                }
            }
            return CreateMessage("UPDATE_SUCCESS", "");
        }

        #endregion
        #region STAR_ACTIVATED
        private async Task<Message> ActivateUserStar(string senderName)
        {
            if (UserList.InvokeRequired) UserList.Invoke(new Action(() => ActivateUserStar(senderName)));
            else
            {
                for (int i = 0; i < UserList.Items.Count; i++)
                {
                    if (UserList.Items[i].ToString().Contains(senderName))
                    {
                        string currentText = UserList.Items[i].ToString();
                        string updatedText;
                        if (currentText.Contains("Stars:"))
                        {
                            updatedText = currentText + " ★";
                        }
                        else
                        {
                            updatedText = currentText + "     Stars: ★";
                        }
                        UserList.Items[i] = updatedText;
                        break;
                    }
                }
            }
            return CreateMessage("STAR_ACTIVATED_CONFIRM", "");
        }

        #endregion
        #region FREEZE_ENEMY
        private async Task<Message> FreezeUsers(TcpClient senderClient, string senderName)
        {
            var freezeMessage = CreateMessage("FREEZE", $"You were freezed by {senderName}!");
            foreach (var client in connectedClients)
            {
                if (client != senderClient && client.Connected)
                {
                    NetworkStream broadcastStream = client.GetStream();
                    await SendResponseAsync(freezeMessage, broadcastStream);
                }
            }
            return CreateMessage("FREEZE_SENT", "");
        }

        #endregion
        #region ADD_COINS
        private async Task<Message> AddCoinsToUser(string data)
        {
            var dataParts = data.Split(' ');
            if (dataParts.Length < 2)
            {
                return CreateMessage("ERROR", "Invalid data format.");
            }

            string username = dataParts[0];
            if (!int.TryParse(dataParts[1], out int coinsToAdd))
            {
                return CreateMessage("ERROR", "Invalid coin format.");
            }

            if (UserList.InvokeRequired)
            {
                UserList.Invoke(new Action(() => AddCoinsToUser(data)));
            }
            else
            {
                for (int i = 0; i < UserList.Items.Count; i++)
                {
                    string userDisplayString = UserList.Items[i].ToString();
                    if (userDisplayString.StartsWith(username + " "))
                    {
                        var scoreMatch = Regex.Match(userDisplayString, @"Score: (\d+)");
                        if (!scoreMatch.Success) return CreateMessage("ERROR", "Score not found.");
                        int newCoinsTotal = coinsToAdd;
                        string newUserDisplayString = Regex.Replace(userDisplayString, $@"Score: \d+", $"Score: {newCoinsTotal}");
                        UserList.Items[i] = newUserDisplayString;
                        return CreateMessage("COINS_ADDED", $"Updated coins for {username}.");
                    }
                }


            }
            return CreateMessage("ERROR", $"User {username} not found.");
        }

        #endregion
        #region SEND_USER_INFO
        private async Task<Message> SendServerInfoToClient(TcpClient client, string userInfo)
        {
            var userInfoParts = userInfo.Split(' ');
            if (userInfoParts.Length >= 3)
            {
                var name = userInfoParts[0];
                var level = int.Parse(userInfoParts[1]);
                var score = int.Parse(userInfoParts[2]);

                string formattedUserInfo = $"{name} {level}        Score: {score}";

                this.Invoke((MethodInvoker)delegate
                {
                    UserList.Items.Add(formattedUserInfo);
                });
            }
            return CreateMessage("INFO_RECEIVED", "");
        }

        #endregion
        #region GET_SERVER_INFO
        private async Task<Message> GetServerInfoResponse()
        {
            string passwordStatus = string.IsNullOrEmpty(serverinfo.ServerPassword) ? "False" : "True";
            string responseString = $"IP: {serverinfo.ServerIP}       " +
                                    $"ServerName: {serverinfo.ServerName}          " +
                                    $"Players: {serverinfo.Players}/{serverinfo.MaxPlayers}       " +
                                    $"Gamemode: {serverinfo.GameMode}       " +
                                    $"Arcade: {serverinfo.IsArcade}       " +
                                    $"Timer: {serverinfo.IsTimer} ({serverinfo.TimerValue})       " +
                                    $"Password: {passwordStatus}";

            return CreateMessage("GET_SERVER_INFO", responseString);
        }
        #endregion
        #region USER_LIST
        private async Task<Message> SendUserListToClient(TcpClient client)
        {
            List<string> userListItems = new List<string>();

            if (UserList.InvokeRequired)
            {
                UserList.Invoke(new MethodInvoker(delegate
                {
                    userListItems = UserList.Items.Cast<string>().ToList();
                }));
            }
            else
            {
                userListItems = UserList.Items.Cast<string>().ToList();
            }

            var userListJson = CreateMessage("USER_LIST", JsonConvert.SerializeObject(userListItems));
            return userListJson;
        }
        #endregion
        #region TRY_CONNECT
        private async Task<Message> TryConnectAsync(NetworkStream stream)
        {
            if (!string.IsNullOrEmpty(serverinfo.ServerPassword))
            {
                await SendResponseAsync(CreateMessage("PASSWORD_REQUIRED", ""), stream);

                Message passwordResponse = await ReadResponseAsync(stream);

                if (passwordResponse.TypeRequest == "PASSWORD")
                {
                    bool isAuthorized = CheckPassword(passwordResponse.Data);

                    if (isAuthorized) return CreateMessage("AUTH_SUCCESS", "");
                    else return CreateMessage("ACCESS_DENIED", "");
                }
                else return CreateMessage("UNEXPECTED_RESPONSE", "");

            }
            else return CreateMessage("AUTH_SUCCESS", "");
        }

        private bool CheckPassword(string password)
        {
            return password == serverinfo.ServerPassword;
        }
        #endregion
        #region CONNECT_SERVER / DISCONNECT_SERVER
        private async Task<Message> ConnectClient(TcpClient client, Message message)
        {
            var userData = message.Data;
            Message responseMessage;

            if (!connectedClients.Contains(client))
            {
                connectedClients.Add(client);
                serverinfo.Players++;

                if (UserList.InvokeRequired)
                    UserList.Invoke(new Action(() => { UserList.Items.Add(userData); }));
                else
                    UserList.Items.Add(userData);

                responseMessage = CreateMessage("CONNECTED", "");

                var broadcastMessage = CreateMessage("NEW_USER_CONNECTED", userData);
                foreach (var otherClient in connectedClients)
                {
                    if (otherClient != client)
                    {
                        await SendResponseAsync(broadcastMessage, otherClient.GetStream());
                    }
                }
            }
            else
            {
                responseMessage = CreateMessage("ALREADY_CONNECTED", "");
            }
            return responseMessage;
        }

        private async Task<Message> CheckIfNameLogged(TcpClient client, string userData)
        {
            var parts = userData.Split(' ');
            var username = parts[0];
            var userLevel = parts.Length > 1 ? parts[1] : "";

            string newName = username;
            int userCount = 1;

            while (UserList.Items.Cast<string>().Any(item => item.StartsWith(newName + " ")))
            {
                newName = $"{username}{userCount++}";
            }

            if (newName != username) userData = $"{newName} {userLevel}";

            return CreateMessage("UPDATE_USERNAME", newName);
        }


        private async Task<Message> DisconnectClient(TcpClient client, string username)
        {
            Message responseMessage;
            if (connectedClients.Remove(client))
            {
                serverinfo.Players--;

                if (UserList.InvokeRequired) UserList.Invoke(new Action(() => RemoveUserFromList(username)));
                else RemoveUserFromList(username);

                responseMessage = CreateMessage("DISCONNECTED", "");

                if (connectedClients.Count <= 0 && StartGamebtn.Text == "Stop Game")
                {
                    var stopGameMessage = CreateMessage("STOP_GAME", "");
                    foreach (var client1 in connectedClients.ToList())
                    {
                        if (client.Connected)
                        {
                            try
                            {
                                NetworkStream stream = client.GetStream();
                                await SendResponseAsync(stopGameMessage, stream);
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine($"Failed to send STOP_GAME to a client: {ex.Message}");
                            }
                        }
                    }
                    StartGamebtn.Text = "Start Game";
                }

                var broadcastMessage = CreateMessage("NEW_USER_DISCONNECTED", username);
                foreach (var otherClient in connectedClients)
                {
                    if (otherClient != client)
                    {
                        await SendResponseAsync(broadcastMessage, otherClient.GetStream());
                    }
                }
            }
            else
            {
                responseMessage = CreateMessage("NOT_CONNECTED", "");
            }
            return responseMessage;
        }

        private void RemoveUserFromList(string username)
        {
            for (int i = UserList.Items.Count - 1; i >= 0; i--)
            {
                if (UserList.Items[i].ToString().StartsWith(username))
                {
                    UserList.Items.RemoveAt(i);
                    break;
                }
            }
        }

        #endregion
        #region Send/Read Response
        private async Task SendResponseAsync(Message response, NetworkStream stream)
        {
            string jsonResponse = JsonConvert.SerializeObject(response);
            byte[] responseData = Encoding.UTF8.GetBytes(jsonResponse);
            await stream.WriteAsync(responseData, 0, responseData.Length);
        }

        private async Task<Message> ReadResponseAsync(NetworkStream stream)
        {
            byte[] buffer = new byte[20480];
            int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
            string jsonString = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            return JsonConvert.DeserializeObject<Message>(jsonString);
        }

        private Message CreateMessage(string TypeRequest, string Data)
        {
            var response = new Message
            {
                TypeRequest = TypeRequest,
                Data = Data
            };
            return response;
        }

        #endregion
        #region StartGame
        private async void StartGamebtn_Click(object sender, EventArgs e)
        {
            if (StartGamebtn.Text == "Start Game")
            {
                string selectedLevel = selectlvlcombobox.SelectedItem?.ToString() ?? string.Empty;
                if (!string.IsNullOrEmpty(selectedLevel))
                {
                    string levelPath = Path.Combine(dataFolderPath, serverinfo.GameMode, selectedLevel + ".sos");

                    if (File.Exists(levelPath))
                    {
                        string fileContent = File.ReadAllText(levelPath);
                        var startGameMessage = CreateMessage("START_GAME", fileContent);

                        foreach (var client in connectedClients.ToList())
                        {
                            if (client.Connected)
                            {
                                try
                                {
                                    NetworkStream stream = client.GetStream();
                                    await SendResponseAsync(startGameMessage, stream);
                                    UserList.Items.Clear();
                                }
                                catch (Exception ex)
                                {
                                    Debug.WriteLine($"Failed to send START_GAME to a client: {ex.Message}");
                                }
                            }
                        }
                        StartGamebtn.Text = "Stop Game";
                    }
                    else
                    {
                        MessageBox.Show($"Selected level file not found: {levelPath}", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a level before starting the game.", "Level Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                var stopGameMessage = CreateMessage("STOP_GAME", "");
                foreach (var client in connectedClients.ToList())
                {
                    if (client.Connected)
                    {
                        try
                        {
                            NetworkStream stream = client.GetStream();
                            await SendResponseAsync(stopGameMessage, stream);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"Failed to send STOP_GAME to a client: {ex.Message}");
                        }
                    }
                }
                StartGamebtn.Text = "Start Game";
            }
        }
        #endregion
        #region Other
        private void GameTimerslider_SliderValueChanged(object sender, EventArgs e) { GameTimernumeric.Visible = GameTimerslider.IsOn; }
        private void ConvertToExcel_Click(object sender, EventArgs e)
        {
            StringBuilder csvContent = new StringBuilder();

            csvContent.AppendLine("Name,Score,Questions");

            foreach (string item in UserList.Items)
            {
                string[] userInfo = item.Split(new string[] { "Score: ", "Questions: " }, StringSplitOptions.RemoveEmptyEntries);
                string[] nameParts = userInfo[0].Split(' ');
                string name = nameParts[0];
                string score = userInfo.Length > 1 ? userInfo[1] : "";
                string questions = userInfo.Length > 2 ? userInfo[2] : "";
                csvContent.AppendLine($"{name},{score},{questions}");
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog.FileName = "UserList.csv";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, csvContent.ToString());
                MessageBox.Show("UserList has been exported to CSV successfully!", "Export to CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        #endregion

    }
}

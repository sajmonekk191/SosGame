using Newtonsoft.Json;
using SOS_Essential.Essentials;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using SOS_Essential.Apps.Main.Game.MiniGames;

namespace SOS_Essential.Apps.Main.Game
{
    public partial class ConnectServer : UserControl
    {
        #region Message
        public class Message
        {
            public string TypeRequest { get; set; }
            public string Data { get; set; }
        }
        #endregion
        #region Question Class
        public class Question
        {
            public string QuestionText { get; set; }
            public List<string> Answers { get; set; }
            public List<string> CorrectAnswers { get; set; }
        }

        #endregion
        #region variables
        public TcpClient client;
        public NetworkStream stream;
        public bool connected = false;
        private int currentQuestionIndex = -1;
        private List<Question> questions = new List<Question>();
        private Question currentQuestion;
        private System.Windows.Forms.Timer questionTimer;
        private Chests ChestsControl;
        public Int64 coins;
        public bool IsArcade = false;
        public bool IsTimer = false;
        public int TimerValue;
        private Random rnd = new Random();
        private System.Windows.Forms.Timer GameTimerTicker = new System.Windows.Forms.Timer();
        private System.Timers.Timer updateUserList = new System.Timers.Timer(1000);

        // User //
        public string Username { get; set; }
        public int Level { get; set; }
        public Int64 Score { get; set; }
        public int PointsPerCorrectAnswer { get; set; } = 1;
        // User //
        #endregion
        public ConnectServer()
        {
            InitializeComponent();
            InitializeSettings();
        }
        #region Basic Settings / Network Settings

        private void InitializeSettings()
        {
            this.AddServer.Click += AddServer_Click;
            this.ReloadServers.Click += ReloadServers_Click;
            this.ServerList.MouseDoubleClick += ServerList_MouseDoubleClick;
            this.BackButton.Click += BackButton_Click;
            this.ExitBtnWindow.Click += ExitBtnWindow_Click;
            this.ExitBtnWindow.MouseEnter += ExitBtnWindow_MouseEnter;
            this.ExitBtnWindow.MouseLeave += ExitBtnWindow_MouseLeave;
            this.MinimizeBtnWindow.Click += MinimizeBtnWindow_Click;
            this.MinimizeBtnWindow.MouseEnter += MinimizeBtnWindow_MouseEnter;
            this.MinimizeBtnWindow.MouseLeave += MinimizeBtnWindow_MouseLeave;
            this.Coinslbl.TextChanged += Coinslbl_TextChanged;

            GameTimerTicker.Tick += new EventHandler(GameTimer_Tick);
            updateUserList.Elapsed += updateUserList_Tick;

            UserList.DrawMode = DrawMode.OwnerDrawFixed;
            UserList.DrawItem += new DrawItemEventHandler(UserList_DrawItem);

            ServerList.DrawMode = DrawMode.OwnerDrawFixed;
            ServerList.DrawItem += new DrawItemEventHandler(ServerList_DrawItem);

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

            // Setup User //

            Username = Environment.UserName;
            Level = Essentials.User.Account.Lvl;

            // Setup User //

            // Answer Utilities //

            Answer1btn.Click += AnswerButton_Click;
            Answer2btn.Click += AnswerButton_Click;
            Answer3btn.Click += AnswerButton_Click;
            Answer4btn.Click += AnswerButton_Click;

            questionTimer = new System.Windows.Forms.Timer();
            questionTimer.Interval = 1000;
            questionTimer.Tick += QuestionTimer_Tick;

            // Answer Utilities //

            // Load MiniGame UserControl //
            ChestsControl = new Chests(this);
            ChestsControl.Dock = DockStyle.Fill;
            this.Controls.Add(ChestsControl);
            ChestsControl.Show();
            ChestsControl.Visible = false;
            // Load MiniGame UserControl //

        }
        // Freeze Effect //
        private async Task ApplyFreezeEffect(string data)
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
                    (freezePanel.Height - 100) / 2
                ),
                Text = "5"
            };

            freezePanel.Controls.Add(countdownLabel);

            Label messageLabel = new Label
            {
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.Blue,
                BackColor = Color.Transparent,
                Text = data
            };

            freezePanel.Controls.Add(messageLabel);

            messageLabel.Location = new Point(
                (freezePanel.Width / 2) - (messageLabel.Width / 2),
                countdownLabel.Bottom + 10
            );

            this.Controls.Add(freezePanel);
            freezePanel.BringToFront();

            for (int seconds = 5; seconds >= 0; seconds--)
            {
                countdownLabel.Text = seconds.ToString();
                await Task.Delay(1000);
            }

            this.Controls.Remove(freezePanel);
            freezePanel.Dispose();
        }

        // Free Effect //

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
            Invoke(new MethodInvoker(async delegate
            {
                await DisconnectFromServer();
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

        // Přídání Exit + Minimize btn protože appka nechce disconnect User
        // }

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
        private async void BackButton_Click(object sender, EventArgs e)
        {
            Invoke(new MethodInvoker(async delegate
            {
                MainApp.Instance.ShowHideExitMinimizeBTN(true);
                await DisconnectFromServer();
                ServerList.Items.Clear();
                UserList.Items.Clear();
                questions.Clear();
                PlayerList.Visible = false;
                Playground.Visible = false;
                updateUserList.Stop();
                this.Visible = false;
            }));
        }
        private void ReloadServers_Click(object sender, EventArgs e)
        {
            CheckServers();
        }
        private string GetLocalIPAddress()
        {
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530); // Google's public DNS server
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                return endPoint.Address.ToString();
            }
        }
        #endregion
        #region ServerList Settings

        private void ServerList_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            int index = ServerList.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                ConnectToSelectedServer(index);
            }
        }
        private void ServerList_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();
            e.DrawFocusRectangle();

            string text = ((ListBox)sender).Items[e.Index].ToString();

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            e.Graphics.DrawString(text, e.Font, new SolidBrush(e.ForeColor), e.Bounds, stringFormat);
        }

        private async void ConnectToSelectedServer(int index)
        {
            if (index < 0 || index >= ServerList.Items.Count)
            {
                MessageBox.Show("Invalid selection.");
                return;
            }

            string item = ServerList.Items[index].ToString();

            int playersIndex = item.IndexOf("Players: ") + "Players: ".Length;
            int slashIndex = item.IndexOf("/", playersIndex);
            int maxPlayersIndex = item.IndexOf(" ", slashIndex);
            string currentPlayersString = item.Substring(playersIndex, slashIndex - playersIndex);
            string maxPlayersString = item.Substring(slashIndex + 1, maxPlayersIndex - slashIndex - 1);

            if (int.TryParse(currentPlayersString, out int currentPlayers) &&
                int.TryParse(maxPlayersString, out int maxPlayers) &&
                currentPlayers >= maxPlayers)
            {
                MessageBox.Show("Server is full.", "Server Capacity Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ipStartIndex = item.IndexOf("IP: ") + "IP: ".Length;
            int ipEndIndex = item.IndexOf(" ", ipStartIndex);
            string serverIp = ipEndIndex == -1 ? item.Substring(ipStartIndex) : item.Substring(ipStartIndex, ipEndIndex - ipStartIndex);

            if (!IPAddress.TryParse(serverIp, out var ipAddress))
            {
                MessageBox.Show("Failed to parse server IP address.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!connected)
            {
                try
                {
                    await ConnectToServer(serverIp, 11259);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to connect to server: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                var result = MessageBox.Show("You are already connected to another server! \nDo you want to disconnect from the connected server?", "Connection Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (result == DialogResult.Yes)
                {
                    DisconnectFromServer();
                }
            }
        }



        #endregion
        #region Check Servers

        private void CheckServers()
        {
            Invoke(new Action(() => ServerList.Items.Clear()));
            string baseIp = GetLocalIPAddress().Substring(0, GetLocalIPAddress().LastIndexOf('.') + 1);

            Task.Run(() =>
            {
                Invoke(new Action(() => loading.Visible = true));
                for (int i = 1; i < 254; i++)
                {
                    string currentIp = baseIp + i;
                    ConnectAndRequestServerInfo(currentIp).ConfigureAwait(false);
                }
                Invoke(new Action(() => loading.Visible = false));
            });
        }
        private async Task ConnectAndRequestServerInfo(string ipAddress)
        {
            using (var tempClient = new TcpClient())
            {
                try
                {
                    await tempClient.ConnectAsync(ipAddress, 11259);
                    if (tempClient.Connected)
                    {
                        NetworkStream stream = tempClient.GetStream();

                        await SendResponseAsync(CreateMessage("GET_SERVER_INFO", ""), stream);
                        Message jsonResponse = await ReadResponseAsync(stream);

                        if (jsonResponse != null)
                        {

                            string displayText = jsonResponse.Data;

                            Invoke(new Action(() =>
                            {
                                ServerList.Items.Add(displayText);
                            }));
                        }
                    }
                }
                catch { }
            }
        }
        #endregion
        #region Send/Read Response
        public async Task SendResponseAsync(Message response, NetworkStream stream)
        {
            string jsonResponse = JsonConvert.SerializeObject(response);
            byte[] responseData = Encoding.UTF8.GetBytes(jsonResponse);
            await stream.WriteAsync(responseData, 0, responseData.Length);
        }

        public async Task<Message> ReadResponseAsync(NetworkStream stream)
        {
            byte[] buffer = new byte[40480];
            int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
            string jsonString = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            return JsonConvert.DeserializeObject<Message>(jsonString);
        }
        public Message CreateMessage(string TypeRequest, string Data)
        {
            var response = new Message
            {
                TypeRequest = TypeRequest,
                Data = Data
            };
            return response;
        }

        #endregion
        #region Disconnect User
        public async Task DisconnectFromServer()
        {
            if (!connected || client == null || !client.Connected) return;

            try
            {
                Invoke(new MethodInvoker(async delegate { coins = 0; Coinslbl.Text = coins.ToString(); }));
                if (stream == null)
                {
                    stream = client.GetStream();
                }
                await SendResponseAsync(CreateMessage("DISCONNECT_SERVER", $"{Username}"), stream);
                Message connectResponse = await ReadResponseAsync(stream);
                if (connectResponse.TypeRequest == "DISCONNECTED")
                {
                    stream?.Close();
                    client?.Close();
                    connected = false;
                    updateUserList.Stop();
                    PlayerList.Invoke(new Action(() => { PlayerList.Visible = false; }));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error disconnecting from server: {ex.Message}");
            }
            finally
            {
                try
                {
                    stream?.Close();
                    client?.Close();
                    connected = false;
                    updateUserList.Stop();
                    PlayerList.Invoke(new Action(() => { PlayerList.Visible = false; }));
                }
                catch { }
            }
        }
        private void RemoveUserFromList(string username)
        {
            this.Invoke((MethodInvoker)delegate
            {
                for (int i = UserList.Items.Count - 1; i >= 0; i--)
                {
                    if (UserList.Items[i].ToString().StartsWith(username))
                    {
                        UserList.Items.RemoveAt(i);
                        break;
                    }
                }
            });
        }

        #endregion
        #region Listen Server
        private async Task ListenForServerMessages()
        {
            try
            {
                while (connected && client != null && client.Connected)
                {
                    Message serverMessage = await ReadResponseAsync(stream);

                    if (serverMessage != null)
                    {
                        this.Invoke((MethodInvoker)async delegate
                        {
                            switch (serverMessage.TypeRequest)
                            {
                                case "DISCONNECTED":
                                    #region DISCONNECTED
                                    Playground.Visible = false;
                                    await DisconnectFromServer();
                                    MessageBox.Show("Disconnected from the server successfully.", "Disconnected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    #endregion
                                    break;
                                case "NEW_USER_CONNECTED":
                                    #region NEW_USER_CONNECTED
                                    if (UserList != null && !UserList.IsDisposed)
                                    {
                                        UserList.Items.Add(serverMessage.Data);
                                    }
                                    #endregion
                                    break;
                                case "NEW_USER_DISCONNECTED":
                                    #region NEW_USER_DISCONNECTED
                                    if (UserList != null && !UserList.IsDisposed)
                                    {
                                        RemoveUserFromList(serverMessage.Data);
                                    }
                                    #endregion
                                    break;
                                case "USER_LIST":
                                    #region USER_LIST
                                    List<string> users = JsonConvert.DeserializeObject<List<string>>(serverMessage.Data);
                                    UserList.Items.Clear();
                                    foreach (var user in users)
                                    {
                                        UserList.Items.Add(user);
                                    }
                                    #endregion
                                    break;
                                case "GET_USERNAME":
                                    #region GET_USERNAME
                                    await SendResponseAsync(CreateMessage("GET_USERNAME", $"{Username}"), stream);
                                    #endregion
                                    break;
                                case "FREEZE":
                                    #region FREEZE
                                    await ApplyFreezeEffect(serverMessage.Data);
                                    #endregion
                                    break;
                                case "START_GAME":
                                    #region Start Game
                                    questions = ParseSosContent(serverMessage.Data);
                                    PlayerList.Visible = false;
                                    Playground.Visible = true;
                                    AnswersDonelbl.Visible = true;
                                    if (IsTimer)
                                    {
                                        GameTimer.Visible = true;
                                        TimeLeftlbl.Visible = true;
                                    }
                                    Answer1btn.Visible = Answer2btn.Visible = Answer3btn.Visible = Answer4btn.Visible = true;
                                    await SendResponseAsync(CreateMessage("SEND_USER_INFO", $"{Username} {Level} {Score}"), stream);
                                    coins = 0;
                                    if (questions.Count > 0) StartGame();
                                    else MessageBox.Show("No questions were loaded.", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    #endregion
                                    break;
                                case "STOP_GAME":
                                    #region Stop Game
                                    MessageBox.Show("You were kicked to lobby \nServer Stopped!", "Server Stopped!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    questions.Clear();
                                    PlayerList.Visible = true;
                                    Playground.Visible = false;
                                    this.BackColor = Color.Transparent;
                                    #endregion
                                    break;
                            }
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisconnectFromServer();
            }
        }
        #endregion
        #region ConnectToServer
        public async Task ConnectToServer(string serverIp, int port)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(async () => await ConnectToServer(serverIp, port)));
            }
            else
            {
                try
                {
                    client = new TcpClient();
                    await client.ConnectAsync(serverIp, port);
                    if (client.Connected)
                    {
                        stream = client.GetStream();

                        await SendResponseAsync(CreateMessage("TRY_CONNECT", ""), stream);

                        Message response = await ReadResponseAsync(stream);
                        switch (response.TypeRequest)
                        {
                            case "AUTH_SUCCESS":
                                #region No Password Needed
                                await SendResponseAsync(CreateMessage("CHECK_USERNAME", Username), stream);
                                Message usernameResponse = await ReadResponseAsync(stream);
                                if (usernameResponse.TypeRequest == "UPDATE_USERNAME")
                                {
                                    Username = usernameResponse.Data;
                                    await SendResponseAsync(CreateMessage("CONNECT_SERVER", $"{Username} {Level}"), stream);
                                    Message connectResponse = await ReadResponseAsync(stream);
                                    if (connectResponse.TypeRequest == "CONNECTED")
                                    {
                                        IfArcade();
                                        IfTimer();
                                        connected = true;
                                        PlayerList.Visible = true;
                                        await SendResponseAsync(CreateMessage("USER_LIST", ""), stream);
                                        Task.Run(() => ListenForServerMessages());
                                        MessageBox.Show("Connected to the server successfully.", "Connection Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    }
                                    else
                                    {
                                        MessageBox.Show($"Failed to connect to server after authentication. Server response: {connectResponse.Data}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                #endregion
                                break;
                            case "PASSWORD_REQUIRED":
                                #region Password Check
                                string password = PromptForPassword();
                                await SendResponseAsync(CreateMessage("PASSWORD", $"{password}"), stream);
                                Message finalResponse = await ReadResponseAsync(stream);
                                if (finalResponse.TypeRequest == "AUTH_SUCCESS")
                                {
                                    await SendResponseAsync(CreateMessage("CHECK_USERNAME", Username), stream);
                                    Message usernameResponse1 = await ReadResponseAsync(stream);
                                    if (usernameResponse1.TypeRequest == "UPDATE_USERNAME")
                                    {
                                        Username = usernameResponse1.Data;
                                        await SendResponseAsync(CreateMessage("CONNECT_SERVER", $"{Username} {Level}"), stream);
                                        Message connectResponsePass = await ReadResponseAsync(stream);
                                        if (connectResponsePass.TypeRequest == "CONNECTED")
                                        {
                                            IfArcade();
                                            IfTimer();
                                            connected = true;
                                            PlayerList.Visible = true;
                                            await SendResponseAsync(CreateMessage("USER_LIST", ""), stream);
                                            Task.Run(() => ListenForServerMessages());
                                            MessageBox.Show("Password accepted. Connected to the server successfully.", "Connection Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                        }
                                        else
                                        {
                                            MessageBox.Show("Access Granted but failed to establish connection.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Access Denied: Incorrect password.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                #endregion
                                break;

                            default:
                                MessageBox.Show($"Unexpected server response: {response}", "Server Response", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to connect to server: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
        #region IfArcade
        private async void IfArcade()
        {
            if (!IsArcade)
            {
                await SendResponseAsync(CreateMessage("GET_SERVER_INFO", ""), stream);
                Message jsonResponse = await ReadResponseAsync(stream);

                if (jsonResponse.Data.Contains("Arcade: True"))
                {
                    IsArcade = true;
                }
                else if (jsonResponse.Data.Contains("Arcade: False"))
                {
                    IsArcade = false;
                }
            }
        }
        #endregion
        #region IfTimer
        private async void IfTimer()
        {
            if (!IsTimer)
            {
                await SendResponseAsync(CreateMessage("GET_SERVER_INFO", ""), stream);
                Message jsonResponse = await ReadResponseAsync(stream);

                if (jsonResponse.Data.Contains("Timer: True"))
                {
                    IsTimer = true;
                    var match = Regex.Match(jsonResponse.Data, @"Timer: True \((\d+)\)");
                    if (match.Success)
                    {
                        TimerValue = int.Parse(match.Groups[1].Value);
                    }
                }
                else if (jsonResponse.Data.Contains("Timer: False"))
                {
                    IsTimer = false;
                }
            }
        }

        #endregion
        #region PasswordPrompt
        private string PromptForPassword()
        {
            return Microsoft.VisualBasic.Interaction.InputBox("Enter password:", "Password Required", "", -1, -1);
        }
        #endregion
        #region Convertor
        private List<Question> ParseSosContent(string sosContent)
        {
            List<Question> questionsList = new List<Question>();
            string[] questionBlocks = Regex.Split(sosContent, @"q\d+\s*\{");

            foreach (string block in questionBlocks.Skip(1))
            {
                Question question = new Question();

                Match questionMatch = Regex.Match(block, @"otazka\(""(.+?)""\);");
                if (questionMatch.Success)
                {
                    question.QuestionText = questionMatch.Groups[1].Value;
                }

                Match answersMatch = Regex.Match(block, @"odpovedi\(""(.+?)""\);");
                if (answersMatch.Success)
                {
                    question.Answers = answersMatch.Groups[1].Value.Split(new[] { ", " }, StringSplitOptions.None).ToList();
                }

                MatchCollection correctAnswerMatches = Regex.Matches(block, @"vysledek\(""(.+?)""\);");
                if (correctAnswerMatches.Count != 0)
                {
                    question.CorrectAnswers = new List<string>();
                    foreach (Match match in correctAnswerMatches)
                    {
                        question.CorrectAnswers.AddRange(match.Groups[1].Value.Split(new[] { ", " }, StringSplitOptions.None));
                    }
                }

                if (!string.IsNullOrWhiteSpace(question.QuestionText) &&
                    question.Answers != null && question.Answers.Count == 4 && // Assuming always 4 answers
                    question.CorrectAnswers != null && question.CorrectAnswers.Any())
                {
                    questionsList.Add(question);
                }
            }

            return questionsList;
        }


        #endregion
        #region Game Setup
        private async void AnswerButton_Click(object sender, EventArgs e)
        {
            CustomControls.AltoButton clickedButton = sender as CustomControls.AltoButton;
            Answer1btn.Enabled = Answer2btn.Enabled = Answer3btn.Enabled = Answer4btn.Enabled = false;
            stream = client.GetStream();
            if (currentQuestionIndex == questions.Count -1)
            {
                await SendResponseAsync(CreateMessage("QUESTION", $"{Username} Questions: {currentQuestionIndex + 1}/{currentQuestionIndex + 1}"), stream);
            }
            else
            {
                await SendResponseAsync(CreateMessage("QUESTION", $"{Username} Questions: {currentQuestionIndex + 1}"), stream);
            }
            if (clickedButton != null)
            {
                bool isCorrect = currentQuestion.CorrectAnswers.Contains(clickedButton.Text);
                if (isCorrect)
                {
                    MarkButtonAsCorrect(clickedButton);

                    coins += PointsPerCorrectAnswer;
                    Coinslbl.Text = coins.ToString();

                    await SendResponseAsync(CreateMessage("ADD_COINS", $"{Username} {coins}"), stream);

                    if (IsArcade)
                    {
                        int tryChests = rnd.Next(0, 5);
                        if (tryChests == 1)
                        {
                            if (this.Controls.Contains(ChestsControl))
                            {
                                ChestsControl.Visible = true;
                                ChestsControl.BringToFront();
                            }
                            else MessageBox.Show("MiniGame Control is null, Try to restart App.", "Error");
                        }
                    }
                }
                else
                {
                    MarkButtonAsIncorrect(clickedButton);

                    foreach (var button in new[] { Answer1btn, Answer2btn, Answer3btn, Answer4btn })
                    {
                        if (currentQuestion.CorrectAnswers.Contains(button.Text))
                        {
                            MarkButtonAsCorrect(button);
                        }
                        else
                        {
                            MarkButtonAsIncorrect(button);
                        }
                    }
                }

                if (IsTimer) GameTimerTicker.Stop();
                questionTimer.Start();
            }
        }
        #endregion
        #region OtherSettings for GameSetup
        private void MarkButtonAsCorrect(CustomControls.AltoButton button)
        {
            button.Inactive1 = Color.Green;
            button.Inactive2 = Color.Green;
            button.Active1 = Color.DarkGreen;
            button.Active2 = Color.DarkGreen;
        }

        private void MarkButtonAsIncorrect(CustomControls.AltoButton button)
        {
            button.Inactive1 = Color.Red;
            button.Inactive2 = Color.Red;
            button.Active1 = Color.DarkRed;
            button.Active2 = Color.DarkRed;
        }

        private void SetQuestion(Question question)
        {
            currentQuestion = question;
            UpdateAnswersDoneLabel();
            Questionlbl.Text = question.QuestionText;
            Questionlbl.Width = Playground.Width;
            Size textSize = TextRenderer.MeasureText(Questionlbl.Text, Questionlbl.Font);
            Questionlbl.Left = (Playground.Width - textSize.Width) / 2;
            Questionlbl.TextAlign = ContentAlignment.MiddleCenter;
            Questionlbl.Location = new Point(Questionlbl.Left, 186);
            Answer1btn.Text = question.Answers[0];
            Answer2btn.Text = question.Answers[1];
            Answer3btn.Text = question.Answers[2];
            Answer4btn.Text = question.Answers[3];
        }
        private void UpdateAnswersDoneLabel()
        {
            AnswersDonelbl.Text = $"{currentQuestionIndex + 1} / {questions.Count}";
        }

        private void QuestionTimer_Tick(object sender, EventArgs e)
        {
            questionTimer.Stop();

            LoadNextQuestion();
        }
        private void LoadNextQuestion()
        {
            currentQuestionIndex++;
            if (currentQuestionIndex < questions.Count)
            {
                UpdateAnswersDoneLabel();
                SetQuestion(questions[currentQuestionIndex]);
                ResetAnswerButtons();

                if (IsTimer)
                {
                    GameTimer.Maximum = TimerValue * 100;
                    GameTimer.Value = GameTimer.Maximum;
                    GameTimerTicker.Interval = 10;
                    GameTimerTicker.Start();
                }
            }
            else
            {
                HandleEndOfGame();
            }
        }
        private void ResetAnswerButtons()
        {
            foreach (var button in new[] { Answer1btn, Answer2btn, Answer3btn, Answer4btn })
            {
                button.Active1 = Color.FromArgb(64, 168, 183);
                button.Active2 = Color.FromArgb(36, 164, 183);
                button.Inactive1 = Color.Gainsboro;
                button.Inactive2 = Color.MediumTurquoise;
                button.Enabled = true;
            }
        }
        private async Task HandleEndOfGame()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(async () => await HandleEndOfGame()));
                return;
            }

            Questionlbl.Text = $"All Questions Answered!\nYou collected: {Coinslbl.Text} Points";
            Size textSize = TextRenderer.MeasureText(Questionlbl.Text, Questionlbl.Font);
            int centerLeft = (this.ClientSize.Width - textSize.Width) / 2;
            Questionlbl.Left = centerLeft - 50;

            Coinslbl.Visible = false;
            CoinsImage.Visible = false;
            Answer1btn.Visible = Answer2btn.Visible = Answer3btn.Visible = Answer4btn.Visible = false;
            AnswersDonelbl.Visible = false;
            GameTimer.Visible = false;
            TimeLeftlbl.Visible = false;

            await Task.Delay(2500);

            Playground.Visible = false;
            PlayerList.Visible = true;

            await SendResponseAsync(CreateMessage("USER_LIST", ""), stream);
            updateUserList.Start();
        }
        private void StartGame()
        {
            currentQuestionIndex = -1;

            LoadNextQuestion();
        }
        #endregion
        #region Timers
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (IsTimer)
            {
                if (GameTimer.Value > 0)
                {
                    GameTimer.Value--;
                }
                else
                {
                    GameTimerTicker.Stop();
                    Answer1btn.Enabled = Answer2btn.Enabled = Answer3btn.Enabled = Answer4btn.Enabled = false;
                    foreach (var button in new[] { Answer1btn, Answer2btn, Answer3btn, Answer4btn })
                    {
                        if (currentQuestion.CorrectAnswers.Contains(button.Text))
                        {
                            MarkButtonAsCorrect(button);
                        }
                        else
                        {
                            MarkButtonAsIncorrect(button);
                        }
                    }
                    questionTimer.Start();
                }
            }
        }
        private async void updateUserList_Tick(object sender, EventArgs e) { try { await SendResponseAsync(CreateMessage("USER_LIST", ""), stream); } catch { } }
        #endregion
        #region ConnectExternalServer
        private async void AddServer_Click(object sender, EventArgs e)
        {
            ConnectToExternalServer externalServerForm = new ConnectToExternalServer(this);
            externalServerForm.ShowDialog();
        }
        #endregion
        #region Other
        private void Coinslbl_TextChanged(object sender, EventArgs e)
        {
            Coinslbl.Left = 1035 - (Coinslbl.Text.Length) * 10;
        }
        #endregion
    }
    #region ConnectExternalServer Form
    public partial class ConnectToExternalServer : Form
    {
        public CustomControls.AltoButton Connectbtn;
        private TextBox ServerIPtb;
        private Label ServerIPlabel;
        private ConnectServer connectServer;
        public ConnectToExternalServer(ConnectServer existingConnectServer)
        {
            InitializeComponent();
            this.connectServer = existingConnectServer;
        }

        private async void StartGamebtn_Click(object sender, EventArgs e)
        {
            string ipAddress = ServerIPtb.Text;
            if (string.IsNullOrEmpty(ipAddress))
            {
                MessageBox.Show("Please enter the IP address of the server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            await connectServer.ConnectToServer(ipAddress, 11259);
            this.Close();
        }
        private void InitializeComponent()
        {
            this.Connectbtn = new SOS_Essential.CustomControls.AltoButton();
            this.ServerIPtb = new System.Windows.Forms.TextBox();
            this.ServerIPlabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Connectbtn
            // 
            this.Connectbtn.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.Connectbtn.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.Connectbtn.BackColor = System.Drawing.Color.Transparent;
            this.Connectbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Connectbtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Connectbtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Connectbtn.ForeColor = System.Drawing.Color.Black;
            this.Connectbtn.Inactive1 = System.Drawing.Color.Gainsboro;
            this.Connectbtn.Inactive2 = System.Drawing.Color.MediumTurquoise;
            this.Connectbtn.Location = new System.Drawing.Point(80, 75);
            this.Connectbtn.Name = "Connectbtn";
            this.Connectbtn.Radius = 18;
            this.Connectbtn.Size = new System.Drawing.Size(110, 36);
            this.Connectbtn.Stroke = true;
            this.Connectbtn.StrokeColor = System.Drawing.Color.Black;
            this.Connectbtn.TabIndex = 5;
            this.Connectbtn.Text = "Connect";
            this.Connectbtn.Transparency = false;
            this.Connectbtn.Click += new System.EventHandler(this.StartGamebtn_Click);
            // 
            // ServerIPtb
            // 
            this.ServerIPtb.Location = new System.Drawing.Point(47, 42);
            this.ServerIPtb.Name = "ServerIPtb";
            this.ServerIPtb.Size = new System.Drawing.Size(175, 23);
            this.ServerIPtb.TabIndex = 6;
            // 
            // ServerIPlabel
            // 
            this.ServerIPlabel.AutoSize = true;
            this.ServerIPlabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ServerIPlabel.Location = new System.Drawing.Point(106, 18);
            this.ServerIPlabel.Name = "ServerIPlabel";
            this.ServerIPlabel.Size = new System.Drawing.Size(66, 20);
            this.ServerIPlabel.TabIndex = 7;
            this.ServerIPlabel.Text = "Server IP";
            // 
            // ConnectToExternalServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 133);
            this.Controls.Add(this.ServerIPlabel);
            this.Controls.Add(this.ServerIPtb);
            this.Controls.Add(this.Connectbtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectToExternalServer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect To External Server";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
    #endregion
}

using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace SOS_Essential.Essentials.User
{
    class Account
    {
        private static string connectionString = "Server=localhost;Port=3306;Database=SosGame;Uid=ahoj;Pwd=123;";
        public static string Username = "";
        public static string Nickname = "";
        public static int XP = 0;
        public static int Lvl = 1;
        public static int Coins = 0;

        public static void GetUserData(string username)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT Username, Nickname, Xp, Coins FROM Users WHERE Username = @Username";

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Username", username);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Username = reader["Username"].ToString();
                            Nickname = reader["Nickname"].ToString();
                            XP = reader.GetInt32("Xp");
                            Coins = reader.GetInt32("Coins");

                            Debug.Print("User Data Retrieved: " + Username + ", " + Nickname + ", XP: " + XP + ", Coins: " + Coins);
                        }
                        else
                        {
                            Debug.Print("User not found !");
                            MessageBox.Show("Please try to restart this app", "User not found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch { }
        }


        public static void JoinAccount(string Username, string Nickname, int Xp, int Coins)
        {
            Username = Environment.UserName;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username";

                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, connection);
                    checkCmd.Parameters.AddWithValue("@Username", Username);

                    int existingCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                    // Pokud Nexistuje vytvořit účet
                    if (existingCount == 0)
                    {
                        string insertQuery = "INSERT INTO Users (Username, Nickname, Xp, Coins) VALUES (@Username, @Nickname, @Xp, @Coins); SELECT LAST_INSERT_ID();";

                        MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection);
                        insertCmd.Parameters.AddWithValue("@Username", Username);
                        insertCmd.Parameters.AddWithValue("@Nickname", Nickname);
                        insertCmd.Parameters.AddWithValue("@Xp", Xp);
                        insertCmd.Parameters.AddWithValue("@Coins", Coins);

                        int newAccountId = Convert.ToInt32(insertCmd.ExecuteScalar());

                        Debug.Print("Account created with ID: " + newAccountId + ", Username: " + Username + ", Nickname: " + Nickname + ", Xp: " + Xp + ", Coins: " + Coins);
                    }
                    // Pokud Ano, přihlásit se k účtu
                    else
                    {
                        Debug.Print("Connecting to Account...");
                        GetUserData(Username);
                    }
                }
            }
            catch { }
        }
    }
}

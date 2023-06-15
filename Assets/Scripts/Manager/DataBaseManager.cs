using System.Collections.Generic;
using MySql.Data.MySqlClient;
using UnityEngine;


namespace Assets.Scripts.Manager
{
    public class DataBaseManager : MonoBehaviour
    {

        private MySqlConnection _connection;
        private string _server;
        private string database;
        private string uid;
        private string _password;

        // Start is called before the first frame update
        void Start()
        {
            // 连接数据库
            _server = "localhost";
            database = "test";
            uid = "root";
            _password = "password";
            string connectionString = "SERVER=" + _server + ";" + "DATABASE=" +
                database + ";" + "UID=" + uid + ";" + "PASSWORD=" + _password + ";";
            _connection = new MySqlConnection(connectionString);
            OpenConnection();
        }

        // 打开数据库连接
        private void OpenConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                return;
            }
            _connection.Open();
        }

        // 关闭数据库连接
        private void CloseConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                return;
            }
            _connection.Close();
        }   

        // 插入数据到数据库中
        public void InsertData(string name, int score)
        {
            string query = "INSERT INTO highscore (name, score) VALUES('" + name + "', " + score + ")";
            MySqlCommand cmd = new MySqlCommand(query, _connection);
            cmd.ExecuteNonQuery();
        }

        // 从数据库中查询数据
        public List<HighscoreData> GetHighscores()
        {
            List<HighscoreData> highscores = new List<HighscoreData>();
            string query = "SELECT * FROM highscore ORDER BY score DESC LIMIT 10";
            MySqlCommand cmd = new MySqlCommand(query, _connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                string name = dataReader.GetString("name");
                int score = dataReader.GetInt32("score");
                highscores.Add(new HighscoreData(name, score));
            }

            dataReader.Close();
            return highscores;
        }

        // Update is called once per frame
        void Update()
        {

        }

        // 程序结束时关闭数据库连接
        void OnApplicationQuit()
        {
            CloseConnection();
        }
    }

    public class HighscoreData
    {
        public string name;
        public int score;

        public HighscoreData(string name, int score)
        {
            this.name = name;
            this.score = score;
        }
    }
}
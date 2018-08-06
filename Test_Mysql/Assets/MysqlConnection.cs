using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

public class MysqlConnection : MonoBehaviour
{
    static string host = "localhost";
    static int port = 3306;
    static string username = "root";
    static string password = "";
    static string database = "sa";

    public MySqlConnection conn;

    void Start()
    {
        host = "184.170.221.45";
        database = "lemon";
        password = "hesoyam";
        string connectionString = string.Format("Server={0};Database={1};user id={2};password={3}",
        host, database, username, password);

        conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
        conn.Open();

        string query = "select * from juice";
        MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
        command.ExecuteNonQuery();

        MySqlDataReader myDataReader = command.ExecuteReader();
        while (myDataReader.Read() == true)
        {
            Debug.Log(myDataReader["name"]);
        }
    }

}

using Grpc.Core;
using SzakdolgozatGRPCSzerver;
using MySql.Data.MySqlClient;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using MySqlX.XDevAPI.Relational;
using Microsoft.AspNetCore.Connections;

namespace SzakdolgozatGRPCSzerver.Services
{
    public abstract class AbstractMySQLConnectionHandler
    {
        protected MySqlConnection connection;
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Number + " " + e.Message);
                return false;
            }
        }
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
    public class MySQLConnectonHandlerWithoutDatabase : AbstractMySQLConnectionHandler
    {
        public MySQLConnectonHandlerWithoutDatabase()
        {
            connection = new MySqlConnection("SERVER=localhost;UID=root;password= ;");
        }
        public void createDatabaseIfNotExist()
        {
            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand("CREATE DATABASE IF NOT EXISTS Szakdolgozat_Database;", connection);
                    cmd.ExecuteNonQuery();
                    CloseConnection();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void createTableIfNotExists()
        {
            connection = new MySqlConnection("SERVER=localhost;UID=root;password= ;DATABASE= Szakdolgozat_Database;");
            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand("CREATE TABLE IF NOT EXISTS users (id INT(255),attendance BOOL, hasDined BOOL);", connection);
                    cmd.ExecuteNonQuery();
                    CloseConnection();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
    public class MySQLConnectionHandlerWithDatabase : AbstractMySQLConnectionHandler
    {

        public MySQLConnectionHandlerWithDatabase()
        {
            connection = new MySqlConnection("SERVER=localhost;UID=root;password= ;DATABASE=szakdolgozat_database");
        }
        public void ExecuteMySQLQuery(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            CloseConnection();
        }
        public List<User> QueryToListAllUsersFromDatabase()
        {

            List<User> tmpUserList = new List<User>();
            if (OpenConnection())
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM users", connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    User tmpUser = new User();
                    tmpUser.UserID = reader.GetInt32("id");
                    tmpUser.IsInside = reader.GetBoolean("attendance");
                    tmpUser.CanDine = reader.GetBoolean("hasDined");
                    tmpUserList.Add(tmpUser);
                }
            }
            return tmpUserList;
        }
    }

    public class SzakdolgozatService : SzakdolgozatGreeter.SzakdolgozatGreeterBase
    {
        /*
        private readonly ILogger<SzakdolgozatService> _logger;
        public SzakdolgozatService(ILogger<SzakdolgozatService> logger)
        {
            _logger = logger;
        }
        */

        MySQLConnectionHandlerWithDatabase connectionHandler = new MySQLConnectionHandlerWithDatabase();
        List<User> users = new List<User>();
        public async Task List(Empty e, Grpc.Core.IServerStreamWriter<User> responseStream, Grpc.Core.ServerCallContext context)
        {
            users = connectionHandler.QueryToListAllUsersFromDatabase();
            foreach (var u in users)
            {
                await responseStream.WriteAsync(u);
            }
        }
        //TO-DO
        /*public override Task<Result> AddUser(User user, ServerCallContext context)
        {
            //TO-DO
        }
        public override Task<Result> DeleteUser(User user, ServerCallContext context)
        {
            //TO-DO
        }*/
        public override Task<Result> EnterBuilding(User userRequest, ServerCallContext context)
        {
            if (connectionHandler.OpenConnection())
            {
                connectionHandler.ExecuteMySQLQuery("UPDATE users SET attendance='1' WHERE id='" + userRequest.UserID + "';");
                return Task.FromResult(new Result { Message = "OK!" });
            }
            else
            {
                connectionHandler.CloseConnection();
                return Task.FromResult(new Result { Message = "Database couldn't be reached." });
            }
        }
        public override Task<Result> EnterDiningHall(User userRequest, ServerCallContext context)
        {
            if (connectionHandler.OpenConnection())
            {
                connectionHandler.ExecuteMySQLQuery("UPDATE users SET hasDined='1' WHERE id='" + userRequest.UserID + "';");
                return Task.FromResult(new Result { Message = "OK!" });
            }
            else
            {
                connectionHandler.CloseConnection();
                return Task.FromResult(new Result { Message = "Database couldn't be reached." });
            }
        }
        public override Task<Result> ExitBuilding(User userRequest, ServerCallContext context)
        {
            if (connectionHandler.OpenConnection())
            {
                connectionHandler.ExecuteMySQLQuery("UPDATE users SET attendance='0' WHERE id='"+ userRequest.UserID + "';");
                return Task.FromResult(new Result { Message = "OK!" });
            }
            else
            {
                connectionHandler.CloseConnection();
                return Task.FromResult(new Result { Message = "Database couldn't be reached." });
            }
        }
    }
}
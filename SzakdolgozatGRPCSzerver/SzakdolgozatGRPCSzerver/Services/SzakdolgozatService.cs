using Grpc.Core;
using SzakdolgozatGRPCSzerver;
using MySql.Data.MySqlClient;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using MySqlX.XDevAPI.Relational;

namespace SzakdolgozatGRPCSzerver.Services
{
    public class SzakdolgozatService : SzakdolgozatGreeter.SzakdolgozatGreeterBase
    {
        /*
        private readonly ILogger<SzakdolgozatService> _logger;
        public SzakdolgozatService(ILogger<SzakdolgozatService> logger)
        {
            _logger = logger;
        }
        */

        List<User> users = new List<User>();
        public async Task List(Empty e, Grpc.Core.IServerStreamWriter<User> responseStream, Grpc.Core.ServerCallContext context)
        {
            if (OpenConnection())
            {
                try
                {
                    string query = "SELECT * FROM users";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        User tmpUser = new User();
                        tmpUser.UserID = reader.GetInt32("id");
                        tmpUser.IsInside = reader.GetBoolean("attendance");
                        tmpUser.CanDine = reader.GetBoolean("hasDined");
                        users.Add(tmpUser);
                    }
                    foreach (var u in users)
                    {
                        await responseStream.WriteAsync(u);
                    }
                } catch(MySqlException ex)
                {
                    Console.WriteLine(ex.Number);
                }
            }

        }
        public override Task<Result> AddUser(User user, ServerCallContext context)
        {
            //TO-DO
        }
        public override Task<Result> DeleteUser(User user, ServerCallContext context)
        {
            //TO-DO
        }
        public override Task<Result> EnterBuilding(User userRequest, ServerCallContext context)
        {
            if (this.OpenConnection())
            {
                ExecuteMySQLQuery("UPDATE users SET attendance='1' WHERE id='" + userRequest.UserID + "';");
                return Task.FromResult(new Result { Message = "OK!" });
            }
            else
            {
                CloseConnection();
                return Task.FromResult(new Result { Message = "Database couldn't be reached." });
            }
        }
        public override Task<Result> EnterDiningHall(User userRequest, ServerCallContext context)
        {
            if (this.OpenConnection())
            {
                ExecuteMySQLQuery("UPDATE users SET hasDined='1' WHERE id='" + userRequest.UserID + "';");
                return Task.FromResult(new Result { Message = "OK!" });
            }
            else
            {
                CloseConnection();
                return Task.FromResult(new Result { Message = "Database couldn't be reached." });
            }
        }
        public override Task<Result> ExitBuilding(User userRequest, ServerCallContext context)
        {
            if (this.OpenConnection())
            {
                ExecuteMySQLQuery("UPDATE users SET attendance='0' WHERE id='"+ userRequest.UserID + "';");
                return Task.FromResult(new Result { Message = "OK!" });
            }
            else
            {
                CloseConnection();
                return Task.FromResult(new Result { Message = "Database couldn't be reached." });
            }
        }
        
        #region SQL Connection
        MySqlConnection connection = new MySqlConnection("SERVER=localhost;UID=root;password= ;DATABASE=szakdolgozat_database");
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch(MySqlException e)
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
            catch(MySqlException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public void ExecuteMySQLQuery(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            CloseConnection();
        }
        #endregion
    }
}
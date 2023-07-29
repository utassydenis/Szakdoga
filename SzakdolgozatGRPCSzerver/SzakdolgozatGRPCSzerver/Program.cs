using MySql.Data.MySqlClient;
using SzakdolgozatGRPCSzerver.Services;

namespace SzakdolgozatGRPCSzerver
{
    public class Program
    {
        public static void createDatabaseAndTableIfNotExist()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("SERVER=localhost;UID=root;password= ;");
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("CREATE DATABASE IF NOT EXISTS Szakdolgozat_Database;", connection);
                cmd.ExecuteNonQuery();
                connection.Close();
                connection = new MySqlConnection("SERVER=localhost;UID=root;password= ;DATABASE= Szakdolgozat_Database;");
                connection.Open();
                cmd = new MySqlCommand("CREATE TABLE IF NOT EXISTS users (id INT(255),attendance BOOL, hasDined BOOL);",connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Additional configuration is required to successfully run gRPC on macOS.
            // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

            // Add services to the container.
            builder.Services.AddGrpc();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.MapGrpcService<SzakdolgozatService>();
            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            createDatabaseAndTableIfNotExist();

            app.Run();
        }
    }
}
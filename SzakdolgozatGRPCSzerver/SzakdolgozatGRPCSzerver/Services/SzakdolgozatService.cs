using Grpc.Core;
using SzakdolgozatGRPCSzerver;
using MySql.Data.MySqlClient;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using MySqlX.XDevAPI.Relational;
using Microsoft.AspNetCore.Connections;
using static System.Net.Mime.MediaTypeNames;

namespace SzakdolgozatGRPCSzerver.Services
{

    public class SzakdolgozatService : SzakdolgozatGreeter.SzakdolgozatGreeterBase
    {
        MySqlConnection connection = new MySqlConnection("SERVER=localhost;DATABASE=SzakdolgozatDatabase;UID=root;PASSWORD= ;");

        public override Task<Result> Enter(DoorEvent doorEvent, ServerCallContext context)
        {
            if (!OpenConnection())
            {
                return Task.FromResult(new Result { Message = "Failed to connect to database." });
            }
            if (!CheckCardValidity(doorEvent.CardID))
            {
                CloseConnection();
                return Task.FromResult(new Result { Message = "Invalid card!" });
            }
            if (!CheckIfUserCanEnter(doorEvent))
            {
                CloseConnection();
                return Task.FromResult(new Result { Message = "This user doesn't have access to this door!" });
            }

            MySqlCommand cmd = new MySqlCommand("INSERT INTO door_logs(door_id,card_id,time_entered) "
                + "VALUES('" + doorEvent.DoorID + "','"
                + doorEvent.CardID + "','"
                + eventTimeLog() + "');"
                , connection);
            cmd.ExecuteNonQuery();
            CloseConnection();
            return Task.FromResult(new Result { Message = "OK!" });
        }

        public override Task<Result> Exit(DoorEvent doorEvent, ServerCallContext context)
        {
            if (!OpenConnection())
            {
                return Task.FromResult(new Result { Message = "Failed to connect to database." });
            }
            if (!CheckCardValidity(doorEvent.CardID))
            {
                CloseConnection();
                return Task.FromResult(new Result { Message = "Invalid card!" });
            }
            if (!CheckIfUserCanEnter(doorEvent))
            {
                CloseConnection();
                return Task.FromResult(new Result { Message = "This user doesn't have access to this door!" });
            }

            MySqlCommand cmd = new MySqlCommand("UPDATE door_logs SET time_exited = '" + eventTimeLog() 
                + "' WHERE door_id = '" + doorEvent.DoorID 
                + "' AND card_id = '" + doorEvent.CardID 
                + "' AND time_exited IS NULL AND time_entered = (SELECT MAX(time_entered) FROM door_logs);" 
                , connection);
            cmd.ExecuteNonQuery();
            CloseConnection();
            return Task.FromResult(new Result { Message = "OK!" });
        }

        List<DoorInformation> doorInformationList = new List<DoorInformation>();
        public override async Task ListDoors(Empty e, IServerStreamWriter<DoorInformation> responseStream, ServerCallContext context)
        {
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM doors", connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DoorInformation doorInformation = new DoorInformation();

                    doorInformation.DoorID = int.Parse(reader.GetString("door_id"));
                    doorInformation.DoorName = reader.GetString("door_name");
                    doorInformationList.Add(doorInformation);
                }
            }

            foreach(var information in doorInformationList)
            {
                await responseStream.WriteAsync(information);
            }
        }
        public bool CheckCardValidity(string card_id)
        {
            string logTime = eventTimeLog();
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM card_user WHERE card_id='" + card_id 
                + "' AND start_date <= '"+ logTime 
                + "' AND (expired IS NULL OR expired > '"+logTime+"');"
                ,connection);
            int result = int.Parse(cmd.ExecuteScalar() + "");
            if(result == 1)
            {
                return true;
            }
            return false;
        }
        public string eventTimeLog()
        {
            return DateTime.Now.ToString("yyyy'-'MM'-'dd HH':'mm':'ss");
        }
        public bool CheckIfUserCanEnter(DoorEvent e)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM door_privilige_requirement " +
                "INNER JOIN user_priviliges ON door_privilige_requirement.privilige_level = user_priviliges.privilige_level " +
                "INNER JOIN card_user ON card_user.user_id = user_priviliges.user_id " +
                "WHERE door_privilige_requirement.door_id = '"+ e.DoorID + "'" +
                "AND card_user.card_id = '" + e.CardID +"';", connection);
            
            int result = int.Parse(cmd.ExecuteScalar() + "");
            if(result == 1)
            {
                return true;
            }
            return false;
        }
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return false;
        }
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return false;
        }
    }
}
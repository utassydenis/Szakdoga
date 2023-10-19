using Grpc.Core;
using Microsoft.AspNetCore.Rewrite;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System.Runtime.InteropServices;

namespace SzakdolgozatGRPCSzerver.Services
{

    public class SzakdolgozatService : SzakdolgozatGreeter.SzakdolgozatGreeterBase
    {
        #region Logger
        private readonly ILogger<SzakdolgozatService> _logger;
        public SzakdolgozatService(ILogger<SzakdolgozatService> logger)
        {
            _logger = logger;
        }
        #endregion
        MySqlConnection connection = new MySqlConnection("SERVER=localhost;DATABASE=SzakdolgozatDatabase;UID=root;PASSWORD= ;");
        public Task<Result> CheckDoorUsagePrerequisites(DoorEvent doorEvent)
        {
            string message = "OK!";
            if (!CheckCardValidity(doorEvent.CardInformation.CardID))
            {
                message = "Card:" + doorEvent.CardInformation.CardID +" is invalid!";
                insertErrorIntoDatabase(doorEvent, message);
                return Task.FromResult(new Result { Message = message });
            }
            if (!CheckIfUserHasAccessToDoor(doorEvent))
            {
                message = ("Card:" + doorEvent.CardInformation.CardID + " does not have access to " + doorEvent.DoorInfo.DoorName);
                insertErrorIntoDatabase(doorEvent, message);
                return Task.FromResult(new Result { Message = message });
            }
            if(doorEvent.DoorInfo.DoorID == 5)
            {
                if (CheckIfUserHasEntered(doorEvent.CardInformation.CardID))
                {
                    message = "Card:" + doorEvent.CardInformation.CardID + " was not used to enter.";
                    insertErrorIntoDatabase(doorEvent, message);
                    return Task.FromResult(new Result { Message = message });
                }
                if (!CheckIfUserCanDine(doorEvent))
                {
                    message = "Card:" + doorEvent.CardInformation.CardID + "was already used today.";
                    insertErrorIntoDatabase(doorEvent, message);
                    return Task.FromResult(new Result { Message = message });
                }    
            }
            return Task.FromResult(new Result { Message = "OK!" });
        }
        public override Task<Result> Enter(DoorEvent doorEvent, ServerCallContext context)
        {
            if (!OpenConnection())
            {
                return Task.FromResult(new Result { Message = "Failed to connect to database." });
            }
            Task<Result> testResult = CheckDoorUsagePrerequisites(doorEvent);

            if (testResult.Result.Message == "OK!")
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO door_logs(door_id,card_id,time_entered) "
                + "VALUES('" + doorEvent.DoorInfo.DoorID + "','"
                + doorEvent.CardInformation.CardID + "','"
                + getEventTimeLog() + "');"
                , connection);
                cmd.ExecuteNonQuery();
                CloseConnection();
                return Task.FromResult(new Result { Message = "Card:" + doorEvent.CardInformation.CardID + " was used to enter." });
            }
            else
            {
                CloseConnection();
                return testResult;
            }
        }
        public override Task<Result> Exit(DoorEvent doorEvent, ServerCallContext context)
        {
            if (!OpenConnection())
            {
                return Task.FromResult(new Result { Message = "Failed to connect to database." });
            }
            Task<Result> testResult = CheckDoorUsagePrerequisites(doorEvent);
            if (testResult.Result.Message == "OK!")
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO door_logs(door_id,card_id,time_exited) "
                    + "VALUES('" + doorEvent.DoorInfo.DoorID + "','"
                    + doorEvent.CardInformation.CardID + "','"
                    + getEventTimeLog() + "');"
                    , connection);
                cmd.ExecuteNonQuery();
                CloseConnection();
                return Task.FromResult(new Result { Message = "Card:" + doorEvent.CardInformation.CardID + " was used to exit." });
            }
            else
            {
                CloseConnection();
                return testResult;
            }
        }
        public override Task<Result> EnterExit(DoorEvent doorEvent, ServerCallContext context)
        {
            if (!OpenConnection())
            {
                return Task.FromResult(new Result { Message = "Failed to connect to database." });
            }
            return CheckUserLastActivityAtDoor(doorEvent, context);
        }
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
                    await responseStream.WriteAsync(doorInformation);
                }

            }
            else
            {
                DoorInformation errorDoor = new DoorInformation();
                errorDoor.DoorID = 00;
                errorDoor.DoorName = "Failed to establish connection to database.";
                await responseStream.WriteAsync(errorDoor);
            }
        }

        #region Helper Methods
        public string getEventTimeLog()
        {
            return DateTime.Now.ToString("yyyy'-'MM'-'dd HH':'mm':'ss");
        }
        public string getTodayDate()
        {
            return DateTime.Now.Date.ToString("yyyy'-'MM'-'dd HH':'mm':'ss");
        }
        public bool CheckDatabaseResult(MySqlCommand m)
        {
            int result = int.Parse(m.ExecuteScalar() + "");
            if (result == 1)
            {
                return true;
            }
            return false;
        }
        public bool CheckCardValidity(string card_id)
        {
            string logTime = getEventTimeLog();
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM card_user WHERE card_id='" + card_id
                + "' AND start_date <= '" + logTime
                + "' AND (expired IS NULL OR expired > '" + logTime + "');"
                , connection);
            return CheckDatabaseResult(cmd);
        }
        public bool CheckIfUserHasAccessToDoor(DoorEvent e)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM door_privilige_requirement " +
                "INNER JOIN user_priviliges ON door_privilige_requirement.privilige_level = user_priviliges.privilige_level " +
                "INNER JOIN card_user ON card_user.user_id = user_priviliges.user_id " +
                "WHERE door_privilige_requirement.door_id = '" + e.DoorInfo.DoorID + "'" +
                "AND card_user.card_id = '" + e.CardInformation.CardID + "';", connection);
            return CheckDatabaseResult(cmd);
        }
        public bool CheckIfUserHasEntered(string card_id)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM door_logs " +
                "WHERE card_id ='" + card_id 
                + "' AND time_entered >'" + getTodayDate() + "';"
                ,connection);
            int result = int.Parse(cmd.ExecuteScalar() + "");
            if(result >= 1)
            {
                return true;
            }
            return false;
        }
        public Task<Result> CheckUserLastActivityAtDoor(DoorEvent doorEvent,ServerCallContext context)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT time_entered FROM door_logs " +
                "WHERE card_id = '"+doorEvent.CardInformation.CardID+ "'" +
                "AND door_id= '"+doorEvent.DoorInfo.DoorID+"' " +
                "ORDER BY ID DESC LIMIT 1; "
                , connection);
            var result = cmd.ExecuteScalar();
            CloseConnection();
            if (result == null || result.ToString() == "")
            {
                return Enter(doorEvent, context);
            }
             return Exit(doorEvent, context);
        }
        public bool CheckIfUserCanDine(DoorEvent e)
        {
            string time = DateTime.Now.Date.ToString("yyyy'-'MM'-'dd HH':'mm':'ss");
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM door_logs " +
                "WHERE card_id = '"+ e.CardInformation.CardID +"' " +
                "AND door_id = 5 " +
                "AND time_entered > ' " + time +"';"
                ,connection);
            int result = int.Parse(cmd.ExecuteScalar() + "");
            if(result == 0)
            {
                return true;
            }
            return false;      
        }
        public void insertErrorIntoDatabase(DoorEvent doorEvent,string message)
        {
        MySqlCommand cmd = new MySqlCommand("INSERT INTO card_error_logs (card_id,door_id,error_reason,error_log_time)" 
            + "VALUES('" +doorEvent.CardInformation.CardID +"','"
            + doorEvent.DoorInfo.DoorID  + "','"
            + message +"','" 
            + getEventTimeLog() + "');"
            ,connection);
            cmd.ExecuteNonQuery();
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
                _logger.LogError(ex.Message);
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
                _logger.LogError(ex.Message);
            }
            return false;
        }
        #endregion
    }
}
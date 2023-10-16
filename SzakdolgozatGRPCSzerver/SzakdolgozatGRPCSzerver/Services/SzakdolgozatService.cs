using Grpc.Core;
using MySql.Data.MySqlClient;

namespace SzakdolgozatGRPCSzerver.Services
{

    public class SzakdolgozatService : SzakdolgozatGreeter.SzakdolgozatGreeterBase
    {
        MySqlConnection connection = new MySqlConnection("SERVER=localhost;DATABASE=SzakdolgozatDatabase;UID=root;PASSWORD= ;");

        public Task<Result> CheckDoorUsagePrerequisites(DoorEvent doorEvent)
        {

            if (!CheckCardValidity(doorEvent.CardID))
            {
                return Task.FromResult(new Result { Message = "Invalid card!" });
            }
            if (!CheckIfUserHasAccessToDoor(doorEvent))
            {
                return Task.FromResult(new Result { Message = "This user doesn't have access to this door!" });
            }
            if(doorEvent.DoorID == 5)
            {
                if (!CheckIfUserCanDine(doorEvent))
                {
                    return Task.FromResult(new Result { Message = "This user has already dined today or hasn't properly entered the building" });
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
                + "VALUES('" + doorEvent.DoorID + "','"
                + doorEvent.CardID + "','"
                + getEventTimeLog() + "');"
                , connection);
                cmd.ExecuteNonQuery();
                CloseConnection();
                return testResult;
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
                    + "VALUES('" + doorEvent.DoorID + "','"
                    + doorEvent.CardID + "','"
                    + getEventTimeLog() + "');"
                    , connection);
                cmd.ExecuteNonQuery();
                CloseConnection();
                return testResult;
            }
            else
            {
                CloseConnection();
                return testResult;
            }
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
            //Kezelni ha nincs connection
        }
        public string getEventTimeLog()
        {
            return DateTime.Now.ToString("yyyy'-'MM'-'dd HH':'mm':'ss");
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
                "WHERE door_privilige_requirement.door_id = '" + e.DoorID + "'" +
                "AND card_user.card_id = '" + e.CardID + "';", connection);
            return CheckDatabaseResult(cmd);
        }
        public bool CheckIfUserHasEntered(string card_id)
        {
            string time = DateTime.Now.Date.ToString("yyyy'-'MM'-'dd HH':'mm':'ss");
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM door_logs " +
                "WHERE card_id ='" + card_id 
                + "', AND time_entered >'" + time + "'"
                ,connection);
            int result = int.Parse(cmd.ExecuteScalar() + "");
            if(result >= 1)
            {
                return true;
            }
            return false;

        }
        public bool CheckIfUserCanDine(DoorEvent e)
        {
            if (CheckIfUserHasEntered(e.CardID))
            {
                string time = DateTime.Now.Date.ToString("yyyy'-'MM'-'dd HH':'mm':'ss");
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM door_logs " +
                    "WHERE card_id='" + e.CardID + "', " +
                    "AND door_id = 5 " +
                    "AND time_entered >'" + time + "';");
                int result = int.Parse(cmd.ExecuteScalar() + "");
                if(result == 0)
                {
                    return true;
                }
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
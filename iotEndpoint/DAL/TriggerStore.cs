using iotEndpoint.DTOs;
using Microsoft.Data.Sqlite;

namespace iotEndpoint.DAL
{
    public class TriggerStore
    {
        public TriggerStore()
        {
            _dbLocation = StaticVariable.dbLocation;
        }
        private string _dbLocation;

        public TriggerDTO Store(TriggerDTO trigger)
        {
            //setup the connection to the database
            using (var con = new SqliteConnection(_dbLocation))
            {
                con.Open();

                //open a new command
                using var cmd = new SqliteCommand("INSERT INTO Triggers (DeviceID,SensorID,ActuatorID,Message,TriggerPoint,AboveInclusive) VALUES (@DeviceID,@SensorID,@ActuatorID,@Message,@TriggerPoint,@AboveInclusive) returning ID", con);
                cmd.Parameters.Add(new SqliteParameter("@DeviceID", trigger.DeviceID));
                cmd.Parameters.Add(new SqliteParameter("@SensorID", trigger.SensorID));
                cmd.Parameters.Add(new SqliteParameter("@ActuatorID", trigger.ActuatorID));
                cmd.Parameters.Add(new SqliteParameter("@Message", trigger.Message));
                cmd.Parameters.Add(new SqliteParameter("@TriggerPoint", trigger.TriggerPoint));
                cmd.Parameters.Add(new SqliteParameter("@AboveInclusive", trigger.AboveInclusive));


                //reading 
                using SqliteDataReader reader = cmd.ExecuteReader();
                reader.Read();
                trigger.ID = reader.GetInt32(0);
            }
            return trigger;
        }

        public List<TriggerDTO> GetApplicableTriggers(int DeviceID, int SensorID)
        {
            List<TriggerDTO> triggers = new List<TriggerDTO>();
            using (var con = new SqliteConnection(_dbLocation))
            {
                con.Open();
                using var cmd = new SqliteCommand("SELECT ID, ActuatorID, DeviceID, SensorID, TriggerPoint, Message, AboveInclusive FROM Triggers Where DeviceID = @DeviceID AND SensorID = @SensorID",con);
                cmd.Parameters.Add(new SqliteParameter("@DeviceID", DeviceID));
                cmd.Parameters.Add(new SqliteParameter("@SensorID", SensorID));

                using SqliteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TriggerDTO trigger = new();
                    trigger.ID=reader.GetInt32(0);
                    trigger.ActuatorID = reader.GetInt32(1);
                    trigger.DeviceID = reader.GetInt32(2);
                    trigger.SensorID = reader.GetInt32(3);
                    trigger.TriggerPoint = reader.GetFloat(4);
                    trigger.Message = reader.GetString(5);
                    trigger.AboveInclusive = reader.GetBoolean(6);
                    triggers.Add(trigger);
                }
            }
            return triggers;
        }

    }
}

using iotEndpoint.DTOs;
using iotEndpoint.Objects;
using Microsoft.Data.Sqlite;

namespace iotEndpoint.DAL
{
    /// <summary>
    /// responsible for storing and retreive Actuators in the sqlite database
    /// </summary>
    public class ActuatorStore
    {
        public ActuatorStore()
        {
            _dbLocation = StaticVariable.dbLocation;
        }
        private string _dbLocation;

        public ActuatorDTO Store(ActuatorDTO actuator)
        {
            //setup the connection to the database
            using (var con = new SqliteConnection(_dbLocation))
            {
                con.Open();

                //open a new command
                using var cmd = new SqliteCommand("INSERT INTO Actuators (Name,ComChannel) VALUES (@Name,@ComChannel) returning ID", con);
                cmd.Parameters.Add(new SqliteParameter("@Name", actuator.Name));
                cmd.Parameters.Add(new SqliteParameter("@ComChannel", actuator.MqttChannel));


                //reading 
                using SqliteDataReader reader = cmd.ExecuteReader();
                reader.Read();
                actuator.ID = reader.GetInt32(0);
            }
            return actuator;
        }

        public Actuator Retreive(int actuatorID)
        {
            Actuator actuator = null;
            using (var con = new SqliteConnection(_dbLocation))
            {
                con.Open();
                var cmd = new SqliteCommand("SELECT ID,Name,ComChannel from Actuators where ID = @actuatorID", con);
                cmd.Parameters.Add(new SqliteParameter("@actuatorID", actuatorID));

                using SqliteDataReader reader = cmd.ExecuteReader();
                reader.Read();
                actuator = new(reader.GetInt32(0),reader.GetString(1),reader.GetString(2));

            }
            return actuator;
        }
    }
}

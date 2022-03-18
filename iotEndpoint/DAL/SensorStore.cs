using iotEndpoint.DTOs;
using Microsoft.Data.Sqlite;

namespace iotEndpoint.DAL
{
    public class SensorStore
    {
        public SensorStore()
        {
            _dbLocation = StaticVariable.dbLocation;
        }

        private string _dbLocation;

        public SensorDTO Store(SensorDTO sensor, int deviceID)
        {
            //setup the connection to the database
            using (var con = new SqliteConnection(_dbLocation))
            {
                con.Open();

                //open a new command
                using (var cmd = new SqliteCommand("INSERT INTO Sensors (Name,DeviceID) VALUES (@Name,@DeviceID) returning ID", con))
                {
                    cmd.Parameters.Add(new SqliteParameter("@Name", sensor.Name));
                    cmd.Parameters.Add(new SqliteParameter("@DeviceID", deviceID));


                    //reading 
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        sensor.ID = reader.GetInt32(0);

                    }

                }
            }
            return sensor;
        }
    }


}

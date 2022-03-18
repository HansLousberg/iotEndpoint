using iotEndpoint.DTOs;
using Microsoft.Data.Sqlite;

namespace iotEndpoint.DAL
{
    /// <summary>
    /// responsible for storeing and retreiving measurements from and in the sqlite database
    /// </summary>
    public class MeasurementStore
    {
        public MeasurementStore()
        {
            _dbLocation = StaticVariable.dbLocation;
        }

        private string _dbLocation;

        public void Store(MeasurementDTO Measurement, int deviceID)
        {
            //setup the connection to the database
            using var con = new SqliteConnection(_dbLocation);
            con.Open();

            //open a new command
            using var cmd = new SqliteCommand("INSERT INTO Measurements (DeviceID,SensorID,TimeStamp,Value) VALUES (@DeviceID,@SensorID,@TimeStamp,@Value) returning ID", con);
            cmd.Parameters.Add(new SqliteParameter("@DeviceID", deviceID));
            cmd.Parameters.Add(new SqliteParameter("@SensorID", Measurement.SensorID));
            cmd.Parameters.Add(new SqliteParameter("@TimeStamp", Measurement.DateTime?.Ticks));
            cmd.Parameters.Add(new SqliteParameter("@Value", Measurement.Value));
            
            //executecommand
            using var reader = cmd.ExecuteReader();
            reader.Read();
            Measurement.ID = reader.GetInt32(0);
        }
    }
}

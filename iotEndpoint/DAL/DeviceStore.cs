using iotEndpoint.DTOs;
using Microsoft.Data.Sqlite;

namespace iotEndpoint.DAL
{
    public class DeviceStore
    {
        public DeviceStore()
        {
            _dbLocation = StaticVariable.dbLocation;
        }

        private string _dbLocation;


        public DeviceDTO Store(DeviceDTO device)
        {
            //setup the connection to the database
            using (var con = new SqliteConnection(_dbLocation))
            {
                con.Open();

                //open a new command
                using var cmd = new SqliteCommand("INSERT INTO Devices (Name) VALUES (@Name) returning ID", con);
                cmd.Parameters.Add(new SqliteParameter("@Name", device.Name));

                //reading 
                using SqliteDataReader reader = cmd.ExecuteReader();
                reader.Read();
                device.ID = reader.GetInt32(0);
            }
            return device;
        }
    }
}

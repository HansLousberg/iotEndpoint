namespace iotEndpoint
{
    
    public static class StaticVariable
    {
        //the database location that is used by the application, this should be altered to fetch it eiter from appsettings, or some method to alter it later.
        public const string dbLocation = $"Data Source=C:/Users/Hans/Desktop/Code/iotData.db";
        public const string mqttUri = "192.168.0.103";
    }
}

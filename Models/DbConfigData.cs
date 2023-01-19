namespace DotNetCore_AppConfigurationDemo.Models
{
    public class DbConfigData
    {
        public Dictionary<string, string> connectionstrings { get;set; }
        public Dictionary<string, string> storedprocs { get;set; }
    }
}

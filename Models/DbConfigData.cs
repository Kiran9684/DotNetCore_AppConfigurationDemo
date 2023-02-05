namespace DotNetCore_AppConfigurationDemo.Models
{
    public class DbConfigData
    {
        public Dictionary<string, string> connectionstrings { get;set; }
        public Dictionary<string, string> storedprocs { get;set; }
    }
}

/*
 * Note:
 * The property names in this model that is used to bind config data shd be exactly matching with config json keu names.
 * 
 */
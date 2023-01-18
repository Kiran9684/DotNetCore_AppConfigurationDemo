using Microsoft.AspNetCore.Mvc;

namespace DotNetCore_AppConfigurationDemo.Controllers
{
    public class TestController : Controller
    {
       //Adding dependency injection
        
        private readonly IConfiguration _configuration;
        public TestController(IConfiguration configuration)
        {
            _configuration = configuration; //To access the config data from app settings.json
        }
        public string Index()
        {
            //Reading the configuration data from appsetings.json using _configuration instance
            var myKeyValue = _configuration["MyKey"];
            var title = _configuration["Position:Title"];
            var name = _configuration["Position:Name"];
            var defaultLogLevel = _configuration["Logging:LogLevel:Default"];

            string reult = $"myKeyValue : {myKeyValue}, title : {title}, name : {name}, defaultLogLevel : {defaultLogLevel}";
            
            return reult;
        }
    }
}

/*


 */
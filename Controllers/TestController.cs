using Microsoft.AspNetCore.Mvc;
using DotNetCore_AppConfigurationDemo.Models;

namespace DotNetCore_AppConfigurationDemo.Controllers
{
    public class TestController : Controller
    {
       //Adding dependency injection
        
        private readonly IConfiguration _configuration;
        public  PositionOptions? positionOptions2 { get; private set; }
        public TestController(IConfiguration configuration)
        {
            _configuration = configuration; //To access the config data from app settings.json
        }
        public string Index()
        {
            //Type 1

            //Reading the configuration data from appsetings.json using _configuration instance
            var myKeyValue = _configuration["MyKey"];
            var title = _configuration["Position:Title"];
            var name = _configuration["Position:Name"];
            var defaultLogLevel = _configuration["Logging:LogLevel:Default"];

            string reult = $"myKeyValue : {myKeyValue}, title : {title}, name : {name}, defaultLogLevel : {defaultLogLevel}";
            
            return reult;
        }

        public string Index2()
        {
            //Type 2

            //Creating object to bind config data to the object.
            PositionOptions positionOptions = new PositionOptions();

            //Now Bind method will bind the config data to the object
            _configuration.GetSection(PositionOptions.Position).Bind(positionOptions);


            //Also you can use ConfigurationBinder.Get<T> instead of Bind method, which is more convinient(see code below).
            positionOptions2 = _configuration.GetSection(PositionOptions.Position).Get<PositionOptions>();

            string result = $"Using Bind method:[{positionOptions.Title} and {positionOptions.Name}] || Using Get<T> method:[{positionOptions2.Name} and {positionOptions2.Title}]";
            return result;

            
        }

        public string Index3() 
        {
            //Get section 
            var section0Data = _configuration.GetSection("section0");
            var section2_ssubsection0_data = _configuration.GetSection("section2:subsection0");

            return $"section0Data : {section0Data["key0"]} and {section0Data["key1"]} || section2_ssubsection0_data: {section2_ssubsection0_data["key0"]} and {section2_ssubsection0_data["key1"]}";
        }


    }
}

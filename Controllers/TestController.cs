using Microsoft.AspNetCore.Mvc;
using DotNetCore_AppConfigurationDemo.Models;

namespace DotNetCore_AppConfigurationDemo.Controllers
{
    public class TestController : Controller
    {
       //Adding dependency injection
        
        private readonly IConfiguration _configuration;
        public  PositionOptions? positionOptions2 { get; private set; }
        public MyArrayExample _array { get; private set; }
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

        public string Index4()
        {
            //GetChildren and Exists
            var selection = _configuration.GetSection("section2");
            if (!selection.Exists())
            {
                return "Section does not exist";
            }

            var childern = _configuration.GetSection("section2").GetChildren();
            string s = "";
            foreach(var subsection in childern)
            {
                int i = 0;
                var key1 = subsection.Key + ":key" + i++.ToString();
                var key2 = subsection.Key + ":key" + i.ToString();
                s += key1 + " value: " + selection[key1] + "\n";
                s += key2 + " value: " + selection[key2] + "\n";
            }

            return s;

        }

        public string Index5() 
        {

            _array = _configuration.GetSection("array").Get<MyArrayExample>(); //just hover over Get<T> method you will get clear idea. 
            if (_array == null)
            {
                throw new ArgumentNullException(nameof(_array));
            }
            string s = String.Empty;

            for (int j = 0; j < _array.Entries.Length; j++)
            {
                s += $"Index: {j}  Value:  {_array.Entries[j]} \n";
            }

            return s;
        }

        public string Index6()
        {
            //This method is to read config data into dictionary.
            var myDictionary = _configuration.GetSection("DbConfigData:connectionstrings").Get<Dictionary<string,string>>();

            return "test";

            /*
             * Refer this very use full link
             * https://stackoverflow.com/questions/42846296/how-to-load-appsetting-json-section-into-dictionary-in-net-core
             */
        }
    }
}

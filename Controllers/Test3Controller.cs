using DotNetCore_AppConfigurationDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DotNetCore_AppConfigurationDemo.Controllers
{
    public class Test3Controller : Controller
    {
        public readonly DbConfigData _dbConfigData;

        public Test3Controller(IOptions<DbConfigData> options)
        {
            //Biding config data using IOptions approach. 
            _dbConfigData = options.Value;
        }
        public string Index()
        {
            var data1 = _dbConfigData.connectionstrings;
            var data2 = _dbConfigData.storedprocs;
            return "Test";
        }
    }
}

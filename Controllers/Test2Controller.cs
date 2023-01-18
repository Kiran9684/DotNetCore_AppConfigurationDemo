using DotNetCore_AppConfigurationDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DotNetCore_AppConfigurationDemo.Controllers
{
    public class Test2Controller : Controller
    {
        private readonly PositionOptions _positionOptioins;

        public Test2Controller(IOptions<PositionOptions> options) 
        {
            _positionOptioins = options.Value;
        }

        public string Index()
        {

            return  $"{_positionOptioins.Name} and {_positionOptioins.Title}";
        }
    }
}

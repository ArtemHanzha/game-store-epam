using System.Web.Mvc;
using Task.Contracts.Interfaces;

namespace Task1.Controllers
{
    public class BaseController : Controller
    {
        private readonly ILoggerManager _logger;

        public BaseController(ILoggerManager logger)
        {
            _logger = logger;
        }

        public void LogUserActivity(string action)
        {
            var ip = Request.UserHostAddress;
            var query = Request.QueryString;
            
            _logger.LogInfo($"User: {ip}, query: {query}, triggered: {action}");
        }
    }
}
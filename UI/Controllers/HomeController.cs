using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
  
    public class HomeController : ControllerBase
    {
        
        public HomeController()
        {

        }
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("success");
        }
    }
}

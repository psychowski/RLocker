using System.Web.Http;

namespace RLocker.Controllers
{     
    public class HomeController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Index()
        {
            return Json(new { OK = "Up and running:)" });
        }

        [HttpGet]
        public IHttpActionResult GenerateToken()
        {


            return Json(new { OK = "Up and running:)" });
        }
    }
}

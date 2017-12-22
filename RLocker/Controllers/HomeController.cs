using System.Web.Http;

namespace RLocker.Controllers
{     
    public class HomeController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Index()
        {
            return Json("{ test: 'ala'}");
        }
    }
}

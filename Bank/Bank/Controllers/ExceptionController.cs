using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;


namespace Bank.Controllers
{
    public class ExceptionController : Controller
    {
        [Route("/error")]
        public ActionResult Error()
        {
            var Exception = HttpContext.Features.Get<IExceptionHandlerFeature>();
            return View("Error", Exception.Error);
        }
    }
}

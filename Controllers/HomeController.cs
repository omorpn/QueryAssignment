using Microsoft.AspNetCore.Mvc;
using QueryAssignment.Service;

namespace QueryAssignment.Controllers
{
    [ApiController]
    [Route("/")]

    public class HomeController : Controller
    {
        private readonly HomeService service;
        public HomeController(HomeService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
            //return Content($@"<h1 style=""color:green; font:45px bold; text-align:center ""> Welcome Here </h1>",contentType:"text/html");
        }

        [Route("calculation")]
        [HttpPost]
        public IActionResult Calculations([FromForm]string num1, [FromForm] string num2, [FromForm] string op)
        {

           
            try
            {
                object a = Convert.ChangeType(num1, GetType(num1));
                object b = Convert.ChangeType(num2, GetType(num2));
                

                var result = service.Add(a, b, op);
                return  Content($"<h1>Result is: {result}</h1>",contentType:"text/html");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }
        private Type GetType(string num)
        {
            if (num.Contains("."))
            {
                if (num.Contains("e"))
                {
                    return typeof(double);
                }
                return typeof(float);
            }
           return num.GetType() == typeof(int) ? typeof(int) : throw new Exception("Invalid inputs");
            

            

        }

    }
}

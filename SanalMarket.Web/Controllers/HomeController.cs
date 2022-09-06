using Microsoft.AspNetCore.Mvc;

namespace SanalMarket.Web.Controllers
{
    public class Parametre
    {
        public string Controller { get; set; }
        public string Action { get; set; }

        [FromQuery]
        public string Id { get; set; }
    }

    public class HomeController : Controller
    {
        public string Index()
        {
            return "Hello World!";
        }

        public string Merhaba()
        {
            return "Merhaba Dünya!";
        }

        public ActionResult Contact()
        {
            return Content(@"<html>
                        <head>
                            <title>İletişim</title>
                        </head>
                        <body>
                            <h1>iletisim sayfasi</h1>
                        </body>
                    </html>", "text/html");
        }

        public ActionResult About(Parametre parametre)
        {
            var uyeler = new List<string>()
            {
                "Salih",
                "Ahmet",
                "Engin"
            };

            return View(uyeler);
        }
    }
}

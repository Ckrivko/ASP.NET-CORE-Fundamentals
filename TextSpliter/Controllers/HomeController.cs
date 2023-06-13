using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TextSpliter.Models;

namespace TextSpliter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(TextSplitViewModel model)
        {
            return View(model);
        }

        [HttpPost]
        public IActionResult Split(TextSplitViewModel model)
        {
           model.Text= model.Text.TrimEnd();
            if (!ModelState.IsValid)
            {                              
                return RedirectToAction("Index", new TextSplitViewModel() 
                {
                Text="Aaaaaaaaaaaaaaaaaaaaaaa",
                SplitText="Error!"
                });
            }

            var splitTextArray = model
                    .Text
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();


            model.SplitText = string.Join(Environment.NewLine, splitTextArray);

            return RedirectToAction("Index", model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
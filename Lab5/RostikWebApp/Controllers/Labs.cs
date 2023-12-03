using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace RostikWebApp.Controllers
{
    public class Labs : Controller
    {

        [Authorize]
        public IActionResult Lab1()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public string Lab1(string input_file,string output_file) => RostikClasses.Class1.Lab1Execute(input_file, output_file);
        

        [Authorize]
        public IActionResult Lab2()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public string Lab2(string input_file, string output_file) => RostikClasses.Class2.Lab2Execute(input_file, output_file);


        [Authorize]
        public IActionResult Lab3()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public string Lab3(string input_file, string output_file) => RostikClasses.Class3.Lab3Execute(input_file, output_file);
       
    }
}

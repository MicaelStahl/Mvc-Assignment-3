using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mvc_Assignment_3.Models;

namespace Mvc_Assignment_3.Controllers
{
    public class FeverCheckController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(double temp, string type)
        {

            ViewBag.Fever = CheckFever.Check(temp, type);

            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UI.Models;

// https://github.com/RobinHerbots/Inputmask

namespace UI.Controllers
{
    public class DemoController : Controller
    {
        public DemoController()
        {
            Demo = new DemoModel();
        }

        [BindProperty]
        public DemoModel Demo { get; set; }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult OnSubmit()
        {
            return View("Index", Demo);
        }
    }
}
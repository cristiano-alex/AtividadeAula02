using AtividadeAula02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AtividadeAula02.Controllers
{
    public class HomeController : Controller
    {

        private readonly Context _context;

        public HomeController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.ceps.ToList());
        }


        public IActionResult ApiUtil()
        {
            return View();
        }

        public IActionResult ApiSobre()
        {
            return View();
        }


        public IActionResult CEP()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CEP(CEP c)
        {
            _context.ceps.Add(c);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

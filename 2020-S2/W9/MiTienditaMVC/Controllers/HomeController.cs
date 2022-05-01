﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiTiendita.Models;

namespace MiTiendita.Controllers
{
    public class HomeController : Controller
    {

        public HomeController() // Este es el constructor de la clase HomeController
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            var a = 5;
            var b = 10;
            var c = a * b;
            Console.WriteLine($"A * B es igual a: {c}");

            return View();
        }


        public IActionResult Productos()
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

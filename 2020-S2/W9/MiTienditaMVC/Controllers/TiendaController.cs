using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiTiendita.Models;

namespace MiTiendita.Controllers
{
    public class TiendaController : Controller
    {

        public TiendaController() // Este es el constructor de la clase HomeController
        {

        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Productos()
        {
            

            return View();
        }


    }
}

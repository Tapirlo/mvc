using Microsoft.AspNetCore.Mvc;
using Presentazioni.Models;
using Presentazioni.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentazioni.Controllers
{
    public class AutoreController: Controller
    {
        private Repository repository;
        public AutoreController(Repository r)
        {
            repository = r;
        }
        public IActionResult Aggiunto()
        {
            return View();
        }

        public IActionResult Nonaggiunto()
        {
            return View();
        }

        public IActionResult AggiungiAutore()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AggiungiAutore(Autore autore)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repository.AggiungiAutore(autore);
                    return RedirectToAction("Aggiunto");

                }
                catch (Exception)
                {
                    return RedirectToAction("Nonaggiunto");

                }
            }
            return View(autore);
        }
    }

    
}

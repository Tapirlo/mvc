using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Presentazioni.Models;
using Presentazioni.Models.Database;
using Presentazioni.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentazioni.Controllers
{
    public class PresentazioneController : Controller
    {
        private Repository repository;
        public PresentazioneController(Repository r)
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

        public IActionResult AggiungiPresentazione()
        {
            List<Autore> autori = repository.Autori();
            return View(new PresentazioneModel(autori));
        }

        [HttpPost]
        public IActionResult AggiungiPresentazione(PresentazioneModel presentazione)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Presentazione lapresentazione = presentazione.Presentazione();
                    repository.AggiungiPresentazione(lapresentazione);
                    List<Autore> autori = presentazione.SelectedAutori();

                    foreach(Autore a in autori)
                    {
                        repository.RegistraPresentazione(a, lapresentazione);
                    }
                    return RedirectToAction("Aggiunto");

                }
                catch (Exception)
                {
                    return RedirectToAction("Nonaggiunto");

                }
            }
            return View(presentazione);
        }
        public List<Presentazione> GetPresentazioni([FromQuery]int autore,[FromQuery] DateTime datainizio)
        {
            List<Presentazione> risultato= repository.PresentazioniPerAutoreEData(autore, datainizio);
            return risultato;
        }
        public IActionResult TrovaPresentazioni()
        {
            List<Autore> autori = repository.Autori();
            return View(autori);
        }
    }

}


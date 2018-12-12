using Presentazioni.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentazioni.Models
{
    public class Repository: IDisposable
    {
        private Contesto contesto;

        public void Dispose()
        {
            contesto.Dispose();
        }
        public Repository(Contesto c)
        {
            contesto = c;
        }

        public void AggiungiAutore(Autore autore)
        {
            contesto.Autori.Add(autore);
            contesto.SaveChanges();
        }

        public void AggiungiPresentazione(Presentazione presentazione)
        {
            contesto.Presentazioni.Add(presentazione);
            contesto.SaveChanges();
        }

        public void RegistraPresentazione(Autore a,Presentazione p)
        {
            contesto.Registrazioni.Add(new Registrazione
            {
                Autore = a.Id,
                Presentazione = p.Id
            });

            contesto.SaveChanges();
       
            
        }

        public List<Presentazione> PresentazioniPerAutoreEData(int autore, DateTime data)
        {
            return contesto.Presentazioni.Join(contesto.Registrazioni, x => x.Id, x => x.Presentazione, (x1, x2) => new { Presentazione = x1, Autore = x2.Autore }).Where(x => x.Autore == autore && x.Presentazione.Inizio == data).Select(x => x.Presentazione).ToList();
        }

        public List<Autore> Autori()
        {
            return contesto.Autori.ToList();
        }
    }
}

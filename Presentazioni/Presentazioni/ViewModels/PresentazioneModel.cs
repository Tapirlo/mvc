using Presentazioni.Models.Database;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentazioni.ViewModels
{
    public class PresentazioneModel
    {
        public int Id { get; set; }
        public String Titolo { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }
        public String Livello { get; set; }

        public List<AutoreInserimentoModel> Autori { get; set; }
        public PresentazioneModel()
        {
            
            Autori = new List<AutoreInserimentoModel>();
        }
        public PresentazioneModel(List<Autore> autori)
        {
            Autori = autori.Select(x=>new AutoreInserimentoModel(x,false)).ToList();
        }

        public List<Autore> SelectedAutori()
        {
            return Autori.Where(x => x.Selected).Select(x=>x.Autore()).ToList();
        }
        public Presentazione Presentazione()
        {
            return new Presentazione
            {
                Id = this.Id,
                Titolo = this.Titolo,
                Inizio = this.Inizio,
                Fine = this.Fine,
                Livello = this.Livello
            };
        }
    }
}

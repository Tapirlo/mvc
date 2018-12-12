using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentazioni.Models.Database
{
    public class Presentazione
    {
        public int Id { get; set; }
        public String Titolo { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }
        public String Livello { get; set; }

        public ICollection<Registrazione> Registrazioni { get; set; }

        public Presentazione()
        {

        }

        public override string ToString()
        {
            return  Titolo + " " + Inizio + " " + Fine + " " + Livello;
        }
    }
}

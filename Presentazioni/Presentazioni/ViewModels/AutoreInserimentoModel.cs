using Presentazioni.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentazioni.ViewModels
{
    public class AutoreInserimentoModel
    {

        public int Id { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Telefono { get; set; }
        public String Skill { get; set; }
        public bool Selected { get; set; }

        public AutoreInserimentoModel()
        {
            Selected = false;
        }

        public AutoreInserimentoModel(Autore autore, bool selected)
        {
            Id = autore.Id;
            Nome = autore.Nome;
            Email = autore.Email;
            Telefono = autore.Telefono;
            Skill = autore.Skill;
            Selected = selected;
        }
        public Autore Autore()
        {
            return new Autore(Id, Nome, Email, Telefono, Skill);
        }

    }
}

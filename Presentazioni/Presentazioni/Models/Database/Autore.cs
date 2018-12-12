using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentazioni.Models.Database
{
    public class Autore
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Telefono { get; set; }
        public String Skill { get; set; }

        public ICollection<Registrazione> Registrazioni { get; set; }

        public Autore()
        {

        }

        public Autore(int id,String nome,String email,String telefono,String skill)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefono = telefono;
            Skill = skill;
        }
    }
}

namespace Presentazioni.Models.Database
{
    public class Registrazione
    {
        public int Autore { get; set; }

        public int Presentazione { get; set; }

        public Autore AutoreNavigation { get; set; }

        public Presentazione PresentazioneNavigation { get; set; }

        public Registrazione()
        {

        }
    }
}
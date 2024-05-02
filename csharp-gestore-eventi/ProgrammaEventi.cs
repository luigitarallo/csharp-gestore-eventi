using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    public class ProgrammaEventi
    {
        private string _titolo;
        private List<Evento> eventi;

        public string Titolo
        { get { return _titolo; }
        private set { _titolo = value; }
        }

        public ProgrammaEventi(string titolo)
        {
            Titolo = titolo;
            eventi = new List<Evento>();
        }

        public void AggiungiEvento(Evento nuovoEvento)
        {
            eventi.Add(nuovoEvento);
        }
        public List<Evento> EventiInData(DateTime data)
        {
            List<Evento> eventiInData = new List<Evento>();

            foreach(Evento evento in eventi)
            {
                if(evento.Data.Date == data.Date)
                {
                    eventiInData.Add(evento);
                }
            }
            return eventiInData;
        }

        public static string StampaEventi(List<Evento> listaEventi)
        {
            string output = "";
            foreach (Evento evento in listaEventi)
            {
                output += evento.ToString() + "\n";
            }
            return output;
        }

        public int NumeroEventi()
        {
            return eventi.Count;
        }

        public void SvuotaEventi()
        {
            eventi.Clear();
        }

        public override string ToString()
        {
            string output = $"Nome programma evento: {Titolo}\n";
            foreach(Evento evento in eventi)
            {
                output += evento.ToString() + "\n";
            }
            return output;
        }

    }
}

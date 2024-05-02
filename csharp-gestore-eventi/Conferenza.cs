using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    public class Conferenza : Evento
    {
        private string _relatore;
        private double _prezzo;

        public string Relatore
        {
            get { return _relatore; }
            set { _relatore = value; }
        }

        public double Prezzo
        { 
            get { return _prezzo; } 
            set { _prezzo = value; } 
        }

        public Conferenza(string titolo, DateTime data, int capienzaMax, string relatore, double prezzo) 
            : base(titolo, data, capienzaMax)
        {
            _relatore = relatore;
            _prezzo = prezzo;
        }

        public override string ToString()
        {
            return $"{base.ToString()} - {Relatore} - {Prezzo.ToString("0.00")} euro";
        }
    }
}

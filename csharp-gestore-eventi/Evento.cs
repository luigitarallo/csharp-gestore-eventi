using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    public class Evento
    {
        private string _titolo;
        private DateTime _data;
        private int _capienzaMax;
        private int _postiPrenotati;

        public string Titolo
        {
            get { return this._titolo; }
            set {
                if (string.IsNullOrWhiteSpace(this._titolo))
                    throw new ArgumentException("Il titolo dell'evento non può essere vuoto");
                this._titolo = value; 
            }
        }
        public DateTime Data
        { 
            get { return this._data; } 
            set {
                if (value < DateTime.Today)
                    throw new ArgumentException("Inserisci una data valida");
                this._data = value; 
            } 
        }

        public int CapienzaMax
        { get { return this._capienzaMax;} }

        public int PostiPrenotati
        { get { return this._postiPrenotati;} }

        public Evento(string titolo, DateTime data, int capienzaMax) 
        {
            if (string.IsNullOrWhiteSpace(titolo))
                throw new ArgumentException("Il titolo dell'evento non può essere vuoto");
            
            if (data < DateTime.Now)
                throw new InvalidOperationException("Impossibile aggiungere l'evento, la data è passata");
            
            if (capienzaMax <= 0)
                throw new ArgumentException("La capienza massima deve essere un numero positivo");
            
            this._titolo = titolo;
            this._data = data;
            this._capienzaMax = capienzaMax;
            this._postiPrenotati = 0;
        }

        public void PrenotaPosti(int postiDaPrenotare)
        {
            if (DateTime.Now > Data)
                throw new InvalidOperationException("Impossibile aggiungere posti, l'evento è passato");
            if (postiDaPrenotare <= 0)
                throw new ArgumentException("Il numero di posti da prenotare deve essere positivo");
            if (this._postiPrenotati + postiDaPrenotare > this._capienzaMax)
                throw new InvalidOperationException("Il numero di posti disponibili per l'evento non è sufficiente");
            this._postiPrenotati += postiDaPrenotare;
        }
        public void DisdiciPosti(int postiDaDisdire) 
        {
            if (DateTime.Now > Data)
                throw new InvalidOperationException("Impossibile disdire posti per un evento passato");
            if(postiDaDisdire <= 0)
                throw new ArgumentException("Il numero di posti da disdire deve essere positivo");
            if (this._postiPrenotati + postiDaDisdire < 0)
                throw new InvalidOperationException("Non ci sono abbastanza posti prenotati da poter disdire");
            this._postiPrenotati -= postiDaDisdire;
        }

        public override string ToString()
        {
            return $"{Data.ToString("     dd/MM/yyyy")} - {Titolo}";
        }
    }

}

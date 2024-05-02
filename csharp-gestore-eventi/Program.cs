namespace csharp_gestore_eventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {

                Console.Write("Inserisci il nome dell'evento: ");
                string titolo = Console.ReadLine();
                Console.Write("Inserisci la data dell' evento (formato data gg/MM/yyyy): ");
                DateTime data = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                Console.Write("Inserisci il numero dei posti totali: ");
                int capienzaMax = int.Parse(Console.ReadLine());

                Evento nuovoEvento = new Evento(titolo, data, capienzaMax);

                Console.Write("Vuoi prenotare dei posti per questo evento? (digita 's' per sì / 'n' per no): ");
                string risposta = Console.ReadLine();
                while(risposta.ToLower() == "s")
                {
                    Console.Write("Quanti posti vuoi prenotare? ");
                    int postiDaPrenotare = int.Parse(Console.ReadLine());
                    nuovoEvento.PrenotaPosti(postiDaPrenotare);

                    Console.WriteLine($"Posti prenotati: {nuovoEvento.PostiPrenotati}");
                    Console.WriteLine($"Posti disponibili: {nuovoEvento.CapienzaMax - nuovoEvento.PostiPrenotati}");
                    Console.Write("Vuoi prenotare altri posti? (digita 's' per sì / 'n' per no): ");
                    risposta = Console.ReadLine();
                }

                Console.Write("Vuoi disdire dei posti per questo evento? (digita 's' per sì / 'n' per no): ");
                risposta = Console.ReadLine();
                while(risposta.ToLower() == "s")
                {
                    Console.Write("Quanti posti vuoi disdire? ");
                    int postiDaDisdire = int.Parse(Console.ReadLine());
                    nuovoEvento.DisdiciPosti(postiDaDisdire);
                    Console.WriteLine($"Posti prenotati: {nuovoEvento.PostiPrenotati}");
                    Console.WriteLine($"Posti disponibili: {nuovoEvento.CapienzaMax - nuovoEvento.PostiPrenotati}");
                    Console.Write("Vuoi disdire altri posti? (digita 's' per sì / 'n' per no): ");
                    risposta = Console.ReadLine();
                }
                if(risposta.ToLower() == "n")
                {
                    Console.WriteLine("Ok va bene!");
                    Console.WriteLine($"Posti prenotati: {nuovoEvento.PostiPrenotati}");
                    Console.WriteLine($"Posti disponibili: {nuovoEvento.CapienzaMax - nuovoEvento.PostiPrenotati}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
            }
        }
    }
}

namespace csharp_gestore_eventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Milestone 2
            //try
            //{

            //    Console.Write("Inserisci il nome dell'evento: ");
            //    string titolo = Console.ReadLine();
            //    Console.Write("Inserisci la data dell' evento (formato data gg/MM/yyyy): ");
            //    DateTime data = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            //    Console.Write("Inserisci il numero dei posti totali: ");
            //    int capienzaMax = int.Parse(Console.ReadLine());

            //    Evento nuovoEvento = new Evento(titolo, data, capienzaMax);

            //    Console.Write("Vuoi prenotare dei posti per questo evento? (digita 's' per sì / 'n' per no): ");
            //    string risposta = Console.ReadLine();
            //    while(risposta.ToLower() == "s")
            //    {
            //        Console.Write("Quanti posti vuoi prenotare? ");
            //        int postiDaPrenotare = int.Parse(Console.ReadLine());
            //        nuovoEvento.PrenotaPosti(postiDaPrenotare);

            //        Console.WriteLine($"Posti prenotati: {nuovoEvento.PostiPrenotati}");
            //        Console.WriteLine($"Posti disponibili: {nuovoEvento.CapienzaMax - nuovoEvento.PostiPrenotati}");
            //        Console.Write("Vuoi prenotare altri posti? (digita 's' per sì / 'n' per no): ");
            //        risposta = Console.ReadLine();
            //    }

            //    Console.Write("Vuoi disdire dei posti per questo evento? (digita 's' per sì / 'n' per no): ");
            //    risposta = Console.ReadLine();
            //    while(risposta.ToLower() == "s")
            //    {
            //        Console.Write("Quanti posti vuoi disdire? ");
            //        int postiDaDisdire = int.Parse(Console.ReadLine());
            //        nuovoEvento.DisdiciPosti(postiDaDisdire);
            //        Console.WriteLine($"Posti prenotati: {nuovoEvento.PostiPrenotati}");
            //        Console.WriteLine($"Posti disponibili: {nuovoEvento.CapienzaMax - nuovoEvento.PostiPrenotati}");
            //        Console.Write("Vuoi disdire altri posti? (digita 's' per sì / 'n' per no): ");
            //        risposta = Console.ReadLine();
            //    }
            //    if(risposta.ToLower() == "n")
            //    {
            //        Console.WriteLine("Ok va bene!");
            //        Console.WriteLine($"Posti prenotati: {nuovoEvento.PostiPrenotati}");
            //        Console.WriteLine($"Posti disponibili: {nuovoEvento.CapienzaMax - nuovoEvento.PostiPrenotati}");
            //    }

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Errore: {ex.Message}");
            //}

            // Milestone 4
            try
            {
                Console.Write("Inserisci il nome del tuo programma eventi: ");
                string titoloProgramma = Console.ReadLine();

                ProgrammaEventi programmaEventi = new ProgrammaEventi(titoloProgramma);

                Console.Write("Indica il numero di eventi da inserire: ");
                int numeroEventi = int.Parse(Console.ReadLine());

                for(int i = 0; i < numeroEventi; i++)
                {
                    try
                    {
                        Console.WriteLine($"\nInserisci l'evento {i + 1}/{numeroEventi}");
                        Console.Write("Titolo: ");
                        string titolo = Console.ReadLine();
                        Console.Write("Inserisci la date dell'evento nel formato dd/MM/yyyy: ");
                        DateTime data = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                        Console.Write("Inserisci il numero di posti totali: ");
                        int capienzaMax = int.Parse(Console.ReadLine());

                        Evento nuovoEvento = new Evento(titolo, data, capienzaMax);
                        programmaEventi.AggiungiEvento(nuovoEvento);
                        Console.WriteLine("Evento aggiunto con successo\n");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Errore: {ex.Message}");
                        i--;
                    }
                }
                Console.WriteLine($"Numero totale di eventi nel programma: {programmaEventi.NumeroEventi()}");

                Console.WriteLine($"Ecco il tuo programma eventi: ");
                Console.WriteLine(programmaEventi.ToString());

                Console.Write("\nInserisci una data per sapere Che eventi ci saranno (gg/mm/yyyy): ");
                DateTime dataScelta = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                Console.WriteLine("\nEventi in data scelta:");
                Console.WriteLine(ProgrammaEventi.StampaEventi(programmaEventi.EventiInData(dataScelta)));

                programmaEventi.SvuotaEventi();
                Console.WriteLine("\nTutti gli eventi sono stati eliminati dal programma.");
            }
            catch(Exception ex) 
            { 
                Console.WriteLine($"Errore {ex.Message}"); 
            };
        }
    }
}

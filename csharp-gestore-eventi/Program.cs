using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace csharp_gestore_eventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*-------------
            // MILESTONE 2
            --------------*/
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

            /*--------------
            // MILESTONE 4
            --------------*/

            // Ho cercato di inserire controlli ad ogni singolo input
            // in modo che ad ogni errore il programma non proceda ma richieda
            // di inserire l'input corretto
            try
            {
                string titoloProgramma;
                do
                {
                    Console.Write("Inserisci il nome del tuo programma eventi: ");
                    titoloProgramma = Console.ReadLine();
                    if(string.IsNullOrEmpty(titoloProgramma) )
                    {
                        Console.WriteLine("Il titolo del programma eventi non può essere vuoto. Riprova.");
                    }
                }while (string.IsNullOrWhiteSpace(titoloProgramma));

                ProgrammaEventi programmaEventi = new ProgrammaEventi(titoloProgramma);

                int numeroEventi;
                do
                {
                    Console.Write("Indica il numero di eventi da inserire: ");
                    if (!int.TryParse(Console.ReadLine(), out numeroEventi) || numeroEventi <= 0)
                    {
                        Console.WriteLine("Inserisci un numero valido di eventi (deve essere un intero maggiore di zero).");
                    }
                }
                while (numeroEventi <= 0);

                for (int i = 0; i < numeroEventi; i++)
                {
                    bool inputValido = false;
                    while (!inputValido)
                    {
                        try
                        {
                            Console.WriteLine($"\nInserisci l'evento {i + 1}/{numeroEventi}");
                            // Controllo sul titolo dell'evento

                            string titolo;
                            do
                            {
                                Console.Write("Titolo: ");
                                titolo = Console.ReadLine();
                                if (string.IsNullOrEmpty(titolo))
                                {
                                    Console.WriteLine("Il nome dell'evento non può essere vuoto. Riprova.");
                                }
                            } while (string.IsNullOrWhiteSpace(titolo));

                            // Controllo sulla data dell'evento
                            DateTime data;
                            string inputData;
                            do
                            {
                                Console.Write("Inserisci la data dell'evento nel formato gg/mm/aaaa: ");
                                inputData = Console.ReadLine();
                                if (!DateTime.TryParseExact(inputData, "dd/MM/yyyy", null, DateTimeStyles.None, out data) || data < DateTime.Now)
                                {
                                    Console.WriteLine("La data inserita non è valida, inserisci una data nel formato gg/mm/aaaa e che sia futura");
                                }
                            } while (!DateTime.TryParseExact(inputData, "dd/MM/yyyy", null, DateTimeStyles.None, out data) || data < DateTime.Now);

                            // Controllo sulla capienza massima dell'evento
                            int capienzaMax;
                            do
                            {
                                Console.Write("Inserisci il numero di posti totali: ");
                                if (!int.TryParse(Console.ReadLine(), out capienzaMax))
                                {
                                    Console.WriteLine("Il numero di posti deve essere un numero intero. Riprova.");
                                }
                            } while (capienzaMax <= 0);

                            Evento nuovoEvento = new Evento(titolo, data, capienzaMax);
                            programmaEventi.AggiungiEvento(nuovoEvento);
                            inputValido = true;
                            Console.WriteLine("Evento aggiunto con successo");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Errore: {ex.Message}");
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine($"Errore: {ex.Message}");
                        }
                    }
                    
                }
                Console.Write("Vuoi aggiungere una conferenza? (digita 's' per sì / 'n' per no):");
                string rispostaConferenza = Console.ReadLine();
                if (rispostaConferenza == "s")
                {
                    bool inputValido = false;
                    while (!inputValido)
                    {
                        try
                        {

                            
                            string titolo;
                            do
                            {
                                Console.Write("Inserisci il nome della conferenza: ");
                                titolo = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(titolo))
                                {
                                    Console.WriteLine("Il nome della conferenza non può essere vuoto. Riprova");
                                }
                            } while (string.IsNullOrWhiteSpace(titolo));
                            

                            
                            DateTime data;
                            string inputData;
                            do
                            {
                                Console.Write("Inserisci la data della conferenza nel formato gg/mm/aaaa: ");
                                inputData = Console.ReadLine();
                                if (!DateTime.TryParseExact(inputData, "dd/MM/yyyy", null, DateTimeStyles.None, out data) || data < DateTime.Now)
                                {
                                    Console.WriteLine("La data inserita non è valida, inserisci una data nel formato gg/mm/aaaa e che sia futura");
                                }
                            } while (!DateTime.TryParseExact(inputData, "dd/MM/yyyy", null, DateTimeStyles.None, out data) || data < DateTime.Now);

                            // Controllo sulla capienza massima dell'evento
                            
                            int capienzaMax;
                            do
                            {
                                Console.Write("Inserisci il numero di posti totali: ");
                                if (!int.TryParse(Console.ReadLine(), out capienzaMax))
                                {
                                    Console.WriteLine("Il numero di posti deve essere un numero intero. Riprova.");
                                }
                            } while (capienzaMax <= 0);

                            // Controllo sulla nome del relatore

                            string relatore;
                            do
                            {
                                Console.Write("Inserisci il nome del Relatore: ");
                                relatore = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(relatore))
                                {
                                    Console.WriteLine("Il nome del Relatore non può essere vuoto. Inserisci un nome valido.");
                                }
                            }while(string.IsNullOrWhiteSpace(relatore));

                            // Controllo sul prezzo

                            double prezzo;
                            do
                            {
                                Console.Write("Inserisci il prezzo del biglietto della conferenza: ");
                                if (!double.TryParse(Console.ReadLine(), out prezzo) || prezzo <= 0)
                                {
                                    Console.WriteLine("Inserisci un prezzo valido e positivo");
                                }
                            } while (prezzo <= 0);

                            Conferenza nuovaConferenza = new Conferenza(titolo, data, capienzaMax, relatore, prezzo);
                            programmaEventi.AggiungiEvento(nuovaConferenza);

                            inputValido = true;
                            Console.WriteLine("Conferenza aggiunta con successo");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Errore: {ex.Message}");
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine($"Errore: {ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Errore generico: {ex.Message}");
                        }
                    }
                    
                }

                Console.WriteLine($"Numero totale di eventi nel programma: {programmaEventi.NumeroEventi()}");

                Console.WriteLine($"Ecco il tuo programma eventi: ");
                Console.WriteLine(programmaEventi.ToString());

                DateTime dataScelta;
                string inputDate;
                do
                {
                    Console.Write("\nInserisci una data per sapere che eventi ci saranno (gg/mm/aaaa): ");
                    inputDate = Console.ReadLine();
                    if (!DateTime.TryParseExact(inputDate, "dd/MM/yyyy", null, DateTimeStyles.None, out dataScelta) || dataScelta < DateTime.Now)
                    {
                        Console.WriteLine("La data inserita non è valida, inserisci una data nel formato gg/mm/aaaa e che sia futura");
                    }
                } while (!DateTime.TryParseExact(inputDate, "dd/MM/yyyy", null, DateTimeStyles.None, out dataScelta) || dataScelta < DateTime.Now);

                Console.WriteLine("\nEventi in data scelta:");
                Console.WriteLine(ProgrammaEventi.StampaEventi(programmaEventi.EventiInData(dataScelta)));

                // programmaEventi.SvuotaEventi();
                // Console.WriteLine("\nTutti gli eventi sono stati eliminati dal programma.");
            }
            catch(Exception ex) 
            { 
                Console.WriteLine($"Errore {ex.Message}"); 
            };
        }
    }
}

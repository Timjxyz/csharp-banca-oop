//Inizializzazione
//Sviluppare un’applicazione orientata agli oggetti per gestire i prestiti che una banca concede ai propri clienti.
//La banca è caratterizzata da
//un nome
//un insieme di clienti (una lista)
//un insieme di prestiti concessi ai clienti (una lista)
//I clienti sono caratterizzati da
//nome,
//cognome,
//codice fiscale
//stipendio
//I prestiti sono caratterizzati da
//ID
//intestatario del prestito (il cliente),
//un ammontare,
//una rata,
//una data inizio,
//una data fine.
//Per la banca deve essere possibile:
//aggiungere, modificare e ricercare un cliente.
//aggiungere un prestito.
//effettuare delle ricerche sui prestiti concessi ad un cliente dato il codice fiscale
//sapere, dato il codice fiscale di un cliente, l’ammontare totale dei prestiti concessi.
//sapere, dato il codice fiscale di un cliente, quante rate rimangono da pagare alla data odierna.
//Per i clienti e per i prestiti si vuole stampare un prospetto riassuntivo con tutti i dati che li caratterizzano in un formato di tipo stringa a piacere.


using csharp_banca_oop;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

Banca banca = new Banca();
banca.Nome = "Intesa San Paolo";

Cliente Franco = new Cliente("Franco", "Rossi", "RSSFNC96R17H501I", 3500);
Cliente Cristina = new Cliente("Cristina", "D'avena", "DVNCST80A01F839T", 20000);
Cliente Pippo = new Cliente("Pippo", "Pluto", "PLTPPP80A01F205A", 20000);
banca.clienti.Add(Franco);
banca.clienti.Add(Cristina);
banca.clienti.Add(Pippo);

banca.aggiungiNuovoPrestito(Franco, 2000, 10, new DateTime(2022, 8, 5), new DateTime(2023, 6, 21));
banca.aggiungiNuovoPrestito(Franco, 8000, 10, new DateTime(2021, 8, 5), new DateTime(2022, 12, 21));
banca.aggiungiNuovoPrestito(Cristina, 15000, 36, new DateTime(2022, 10, 12), new DateTime(2024, 11, 23));
banca.aggiungiNuovoPrestito(Pippo, 7000, 36, new DateTime(2022, 9, 12), new DateTime(2024, 10, 23));


banca.stampaClienti(); //lista clienti predefiniti
banca.stampaPrestiti(banca.prestiti);

int counter = 0;
while (counter < 4)
{
    Console.WriteLine("\tBenvenuto in Intesa San Paolo");
    Console.WriteLine("\tSeleziona un opzione: ");
    Console.WriteLine("\t1. Aggiungi nuovo cliente");
    Console.WriteLine("\t2. Modifica cliente registrato");
    Console.WriteLine("\t3. Aggiungi nuovo prestito");
    Console.WriteLine("\t4. Visualizza ammontare totale prestiti cliente");
    Console.WriteLine("\t5. Visualizza prestiti cliente");


    int option = int.Parse(Console.ReadLine());
    switch (option)
    {
        case 1:

            Console.WriteLine("Inserisci il nome:");
            string nome = Console.ReadLine();
            Console.WriteLine("Inserisci il cognome:");
            string cognome = Console.ReadLine();
            Console.WriteLine("Inserisci il codice fiscale:");
            string CFiscale = Console.ReadLine();
            Console.WriteLine("Inserisci lo stipendio:");
            int stipendio = int.Parse(Console.ReadLine());

            //creo un nuovo cliente, doopodichè lo aggiungo alla lista
            Cliente nuovo = new Cliente(nome, cognome, CFiscale, stipendio);
            banca.AggiungiCliente(nuovo);
            banca.stampaClienti();
            counter++;
            break;

        case 2:

            //modifica cliente della lista, tramite codice fiscale
            Console.WriteLine("Ricerca cliente da modificare inserendo il Codice Fiscale");
            string CF = Console.ReadLine();
            banca.ModificaCliente(CF, new Cliente("Germano", "Mosconi", "GRMMCN69M01F205P", 15000));
            counter++;
            break;

        case 3:

            Cliente intestatario = null;
            while (intestatario == null)
            {
                
                Console.WriteLine("Inserisci il codice fiscale del cliente per nuovo prestito ");
                string cercaCF = Console.ReadLine();
                intestatario = banca.cercaCliente(cercaCF);
            }
            Console.WriteLine("Inserisci l'ammontare del prestito");
            int ammontare = int.Parse(Console.ReadLine());
            banca.aggiungiNuovoPrestito(intestatario, ammontare, 15, new DateTime(2022, 8, 5), new DateTime(2023, 6, 21));
            banca.stampaPrestiti(banca.prestiti);
            counter++;
            break;

        case 4:

            Cliente trovato = null;
            while (trovato == null)
            {
                Console.WriteLine("Inserisci il codice fiscale del cliente per visualizzare totale prestiti");
                string cercaCF = Console.ReadLine();
                trovato = banca.cercaCliente(cercaCF);
            }
            double totale = banca.sommaPrestiti(trovato);
            Console.WriteLine("Somma del totale dei prestiti in corso " + totale + "€");
            break;

        case 5:

            Cliente cliente = null;
            while (cliente == null)
            {
                Console.WriteLine("Inserisci il codice fiscale del cliente per visualizzare prestiti attivi");
                string cercaCF = Console.ReadLine();
                cliente = banca.cercaCliente(cercaCF);
            }

            List<Prestito> prestitoList = banca.VisualizzaPrestiti(cliente);
            banca.stampaPrestiti(prestitoList);
            break;

    }

}


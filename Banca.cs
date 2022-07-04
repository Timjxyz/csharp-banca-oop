using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_banca_oop
{
    public class Banca
    {
        public string Nome { get; set; }

        public List<Cliente> clienti = new List<Cliente>();
        public List<Prestito> prestiti = new List<Prestito>();


        public void AggiungiCliente(Cliente cliente)
        {
           
            this.clienti.Add(cliente);
        }

        //metodo per stampare la lista dei clienti
        public void stampaClienti()
        {
            Console.WriteLine("");
            Console.WriteLine("\t**** Lista clienti ****");
            Console.WriteLine("");
            foreach (Cliente cliente in this.clienti)
            {
                Console.WriteLine($"Nome: {cliente.nome} \t Cognome: {cliente.cognome} \t Codice Fiscale: {cliente.codiceFiscale}");
            }
            Console.WriteLine();
        }

        //metodo per stampare lista di prestiti 
        public void stampaPrestiti(List<Prestito> prestiti)
        {
            foreach (Prestito prestito in prestiti)
            {
                Console.WriteLine($"Prestito n. {prestito.ID} Intestato a: {prestito.intestatario.nome} {prestito.intestatario.cognome} totale {prestito.ammontare}€ da pagare in {prestito.rata} rate");
            }
            Console.WriteLine();
        }

        //metodo modifica cliente
        public void ModificaCliente(string vecchioCf, Cliente nuovoCliente)
        {
            foreach (Cliente cliente in this.clienti)
            {
                if (cliente.codiceFiscale == vecchioCf)
                {
                    this.clienti.Remove(cliente);
                    this.clienti.Add(nuovoCliente);
                    Console.WriteLine();
                    Console.WriteLine("I dati del cliente {0} sono stati modificati correttamente", nuovoCliente.nome);
                    Console.WriteLine("");
                    Console.WriteLine("\t***********************");
                    Console.WriteLine("\tLista clienti aggiornata");
                    Console.WriteLine("\t***********************");
                    Console.WriteLine("");
                    this.stampaClienti();
                    return;
                }
            }

        }

        //Metodo per cercare prestiti cliente tramite codice fiscale
        public Cliente cercaCliente(string cercaCodiceFiscale)
        {

            foreach (Cliente cliente in this.clienti)
            {
                if (cliente.codiceFiscale == cercaCodiceFiscale)
                {
                    Console.WriteLine("\t**** Ricerca avvenuta con successo ****");
                    Console.WriteLine("\tElenco prestiti attivi");
                    
                    return cliente;
                }
                
                
            }

            Console.WriteLine("\tRicerca fallita");
            Console.WriteLine("\tNessun utente trovato");
            Console.WriteLine("\tRicontrolla i dati inseriti");
            return null;

        }

        //metodo per visualizzare lista prestiti
        public List<Prestito> VisualizzaPrestiti(Cliente intestatario)
        {
            List<Prestito> prestitiCliente = new List<Prestito>();
            foreach (Prestito prestito in this.prestiti)
            {
                if (prestito.intestatario == intestatario)
                {
                    prestitiCliente.Add(prestito);
                }
            }
            return prestitiCliente;
        }
        //metodo aggiungi nuovo prestito
        public void aggiungiNuovoPrestito(Cliente intestatario, int ammontare, int rata, DateTime inizio, DateTime fine)
        {
            if (this.clienti.Contains(intestatario))
            {
                this.prestiti.Add(new Prestito(intestatario, ammontare, rata, inizio, fine));
            }
            else
            {
                Console.WriteLine("Spiacente, l'utente non è registrato alla piattaforma");
            }
        }
        //metodo per totale somma prestito
        public double sommaPrestiti(Cliente cliente)
        {
            double totale = 0;

            foreach (Prestito prestito in this.prestiti)
            {
                if (prestito.intestatario == cliente)
                {
                    totale += prestito.ammontare;
                }
            }

            return totale;
        }
    }
}

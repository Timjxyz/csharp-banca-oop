using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_banca_oop
{
    internal class Banca
    {
        public string Nome { get; set; }   
        List<Cliente> clienti;
        List<Prestito> prestiti;

        public Banca (string nome)
        {
            this.Nome = nome;
            clienti = new List<Cliente> (); 
            prestiti = new List<Prestito> ();   
        }


        public void StampaNomeBanca()
        {
             Console.WriteLine("\t Benvenuto in "+this.Nome);
        }
        

        public void NuovoCliente(Cliente cliente)
        {
            clienti.Add(cliente);
        }

       

        public static Cliente CreaCliente()
        {
            Banca.StampaTitolo("Creazione nuovo cliente", "Inserisci i dati cliente.");
          
            Console.WriteLine("\t Inserisci il nome ");
            string nome= Console.ReadLine();
            Console.WriteLine("\t Inserisci il cognome ");
            string cognome = Console.ReadLine();
            Console.WriteLine("\t Inserisci il Codice Fiscale ");
            string codiceFiscale = Console.ReadLine();
            
            Cliente nuovo = new Cliente(nome, cognome, codiceFiscale);
           
            return nuovo;
        }
       
        internal void StampaListaClienti()
        {
            Banca.StampaTitolo("Lista clienti","");
            int pos = 1;
            foreach (Cliente cliente in clienti)
            {
                Console.WriteLine("\t"+pos + ")");
                cliente.Stampa();
                pos++;
            }   
        }

        public static  void StampaTitolo(string titolo, string sottotitolo)
        {
            
            Console.WriteLine("\t****{0}****", titolo);
            Console.WriteLine();
            Console.WriteLine("\t"+"**"+sottotitolo+"**");
            Console.WriteLine();
        }
        internal static int RichiediCliente()
        {
            Console.WriteLine("\t Inserisci codice cliente: ");
            int numCliente = int.Parse(Console.ReadLine());
            return numCliente;
        }


        
    }
}

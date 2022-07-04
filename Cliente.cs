using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_banca_oop
{
    public class Cliente
    {
        public string nome { get; set; }
        public string cognome { get; set; }
        public string codiceFiscale { get; private set; }
        public int stipendio;

        public Cliente(string nome, string cognome, string codiceFiscale, int stipendio)
        {
            this.nome = nome;
            this.cognome = cognome;
            this.codiceFiscale = codiceFiscale;
            this.stipendio = stipendio;
        }
    }
}
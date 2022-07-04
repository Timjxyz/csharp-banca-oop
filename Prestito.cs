using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_banca_oop
{
    public class Prestito
    {
        public int ID { get; set; }
        public Cliente intestatario { get; set; }
        public int ammontare { get; set; }
        public int rata { get; set; }
        public DateTime dataInizio { get; set; }
        public DateTime dataFine { get; set; }

        public Prestito(Cliente intestatario, int ammontare, int rata, DateTime dataInizio, DateTime dataFine)
        {
            this.ID = new Random().Next(10000, 99999);
            this.intestatario = intestatario;
            this.ammontare = ammontare;
            this.rata = rata;
            this.dataInizio = dataInizio;
            this.dataFine = dataFine;
        }
    }
}
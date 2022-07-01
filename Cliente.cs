namespace csharp_banca_oop
{
    internal class Cliente
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string CodiceFiscale { get; set; }
        public int Stipendio { get; set; }

        public Cliente(string nome,string Cognome, string CodiceFiscale)
        {
            this.Nome = nome;
            this.Cognome = Cognome;
            this.CodiceFiscale = CodiceFiscale;
        }
        internal void Stampa()
        {
          
            Console.WriteLine($"\t Nome : {this.Nome} \t Cognome : {this.Cognome} \t Codice Fiscale : {this.CodiceFiscale}");
        }
    }
}
using System;

namespace Domain.Model.Entities
{
    public class Marcacao : BaseEntity<int>
    {
        public DateTime DataHora { get; set; }
        public string Descricao { get; set; }
        public Pessoa Pessoa { get; set; }
        
        
    }
}
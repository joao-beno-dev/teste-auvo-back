using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Domain.Model.Entities
{
    public class Pessoa : BaseEntity<string>
    {
        public string Nome
        {
            get
            {
                return Id;
            }

            set
            {
                this.Id = value;
            }
        }
        
        // Usando Notation invés de Fluent
        [InverseProperty("Pessoa")]
        public IList<Marcacao> Marcacoes { get; set; }
    }
}
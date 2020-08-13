using System;

namespace Domain.Model.Model
{
    public class MarcacaoModel
    {
        public DateTime DataHora { get; set; }
        public string Descricao { get; set; }

        public MarcacaoModel(DateTime dataHora, string descricao)
        {
            DataHora = dataHora;
            Descricao = descricao;
        }
    }
}
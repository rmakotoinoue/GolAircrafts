using System;

namespace GolAirCrafts.Domain.Entities
{
    public class Airplane : BaseEntity
    {
        public int CodigoAviao { get; set; }
        public string ModeloAviao { get; set; }
        public int QuantidadePassageiros { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}

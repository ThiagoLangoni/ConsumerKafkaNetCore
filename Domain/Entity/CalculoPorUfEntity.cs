using System;

namespace ConsumerKafka.Domain.Entity
{
    public class CalculoPorUfEntity
    {

        public string UF {get; set;}

        public Int64 QuantidadeBeneficiarios {get; set;}

        public double ValorTotalParcelas {get; set;}

    }
}
using System;
using System.Text;
using System.Collections.Generic;
using ConsumerKafka.Domain.Entity;
using System.Linq;

namespace ConsumerKafka.Domain.Service
{
    public class BolsaFamiliaService
    {
        private List<CalculoPorUfEntity> lista;

        public BolsaFamiliaService()
        {
            lista = new List<CalculoPorUfEntity>();            
        }

        private List<CalculoPorUfEntity> calcularTotaisPorUf(BeneficiarioEntity beneficiario) {
            
            if(!lista.Any(c => c.UF == beneficiario.Uf)) {
                lista.Add(new CalculoPorUfEntity() {
                    UF = beneficiario.Uf,
                    QuantidadeBeneficiarios = 1,
                    ValorTotalParcelas = Double.Parse(beneficiario.ValorParcela)
                });
            } else {

                var index = lista.IndexOf(lista.Find(c=> c.UF == beneficiario.Uf));

                CalculoPorUfEntity calculoPorUf = lista.Find(c=> c.UF == beneficiario.Uf);
                calculoPorUf.QuantidadeBeneficiarios = calculoPorUf.QuantidadeBeneficiarios + 1;
                calculoPorUf.ValorTotalParcelas = calculoPorUf.ValorTotalParcelas + Double.Parse(beneficiario.ValorParcela);
                
                lista[index] = calculoPorUf;
            }

            return lista;
        }


        public void ExibirTotaisBolsaFamilia(BeneficiarioEntity beneficiario) {

            List<CalculoPorUfEntity> listaCalculo = calcularTotaisPorUf(beneficiario);

            StringBuilder consoleTotais = new StringBuilder();

            consoleTotais.Append("|==========================================================|" + Environment.NewLine);
            consoleTotais.Append("|     UF      |     QUATIDADE TOTAL     |    VALOR PARCELA |" + Environment.NewLine);


            foreach (var calculo in listaCalculo)
            {
                consoleTotais.Append(String.Format("|     {0}      |     {1}                    |        {2:C2}                  |" + Environment.NewLine, calculo.UF
                                                                                           ,calculo.QuantidadeBeneficiarios
                                                                                           ,calculo.ValorTotalParcelas));

            }
            consoleTotais.Append("|==========================================================|" + Environment.NewLine); 
            Console.Write(consoleTotais.ToString());
        }
    }
}
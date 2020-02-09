using System;

namespace Domain.Entities
{
    public sealed class Seguro : Base
    {
        private const decimal _margemSeguranca = 3;
        private const decimal _lucro = 5;

        public Seguro(Veiculo veiculo, Segurado segurado)
        {
            Veiculo = veiculo;
            Segurado = segurado;
            Valor = 0;
        }

        public Veiculo Veiculo { get;}
        public Segurado Segurado { get;}
        public decimal Valor { get; private set; }


        public void Calcular()
        {
            var taxaRisco = (Veiculo.Valor * 5) / (Veiculo.Valor * 2);

            var premioRisco = (taxaRisco * Veiculo.Valor) / 100;

            var premioPuro = premioRisco * (1 + (_margemSeguranca / 100));

            var premioComercial = ((_lucro * premioPuro) /100) + premioPuro;

            Valor = Math.Truncate(premioComercial * 100) / 100;
        }
    }
}

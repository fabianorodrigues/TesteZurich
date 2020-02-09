using System;

namespace Domain.Commands.Inputs
{
    public class CalcularSeguroCommand
    {
        public string CPF { get; set; }

        public decimal ValorVeiculo { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }
    }
}

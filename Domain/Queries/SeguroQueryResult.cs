using Domain.Entities;
using System;

namespace Domain.Queries
{
    public class SeguroQueryResult
    {
        public SeguroQueryResult(Seguro seguro)
        {
            Id = seguro.Id;
            Valor = seguro.Valor;
            CPF = seguro.Segurado.CPF;
            ValorVeiculo = seguro.Veiculo.Valor;
            Marca = seguro.Veiculo.Marca;
            Modelo = seguro.Veiculo.Modelo;
        }

        public SeguroQueryResult()
        {

        }

        public Guid Id { get; set; }

        public decimal Valor { get; set; }

        public string CPF { get; set; }

        public decimal ValorVeiculo { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        
    }
}

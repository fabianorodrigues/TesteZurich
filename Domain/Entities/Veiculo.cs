using FluentValidator;

namespace Domain.Entities
{
    public sealed class Veiculo : Base
    {
        public Veiculo(decimal valor, string marca, string modelo)
        {
            Valor = valor;
            Marca = marca;
            Modelo = modelo;

            ValidarVeiculo();
        }


        public decimal Valor { get; }
        public string Marca { get; }
        public string Modelo { get; }

        public void ValidarVeiculo()
        {
            if (Valor <= 0)
                AddNotification(nameof(Valor), "Valor do veículo inválido.");

            if (string.IsNullOrWhiteSpace(Marca))
                AddNotification(nameof(Marca), "Marca do veículo inválida.");

            if (string.IsNullOrWhiteSpace(Modelo))
                AddNotification(nameof(Modelo), "Modelo do veículo inválido.");
        }
    }
}

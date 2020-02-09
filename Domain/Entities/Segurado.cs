using FluentValidator;
using FluentValidator.Validation;

namespace Domain.Entities
{
    public sealed class Segurado : Base
    {
        public Segurado(string nome, string cpf, int idade)
        {
            Nome = nome;
            CPF = cpf;
            Idade = idade;

            ValidarSegurado();
        }

        public string Nome { get; }
        public string CPF { get; }
        public int Idade { get; }

        private void ValidarSegurado()
        {
            if (string.IsNullOrWhiteSpace(Nome))
                AddNotification(nameof(Nome), "Nome do segurado inválido.");

            if (string.IsNullOrWhiteSpace(CPF) || CPF.Length < 11)
                AddNotification(nameof(CPF), "CPF do segurado inválido.");

            if (Idade < 18)
                AddNotification(nameof(Idade), "Idade do segurado inválida.");
        }
    }
}

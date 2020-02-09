using Domain.Entities;
using Domain.Queries;

namespace Domain.Repositories
{
    public interface ISeguroRepository
    {
        void Incluir(Seguro seguro);

        SeguroQueryResult Buscar(string CPF);
    }
}

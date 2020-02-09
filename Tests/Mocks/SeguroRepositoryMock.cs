using Domain.Entities;
using Domain.Queries;
using Domain.Repositories;

namespace Tests.Mocks
{
    public class SeguroRepositoryMock : ISeguroRepository
    {
        public SeguroRepositoryMock()
        {
           
        }

        public SeguroQueryResult Buscar(string CPF)
        {
            return new SeguroQueryResult();
        }

        public void Incluir(Seguro seguro)
        {
            
        }
    }
}

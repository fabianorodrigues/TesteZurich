using Domain.Entities;

namespace Domain.Services
{
    public interface ISeguradoService
    {
        Segurado Buscar(string cpf);
    }
}

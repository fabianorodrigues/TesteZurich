using Domain.Entities;
using Domain.Services;
using Newtonsoft.Json;

namespace Infra.Services
{
    public class SeguradoService : ISeguradoService
    {
        public string Json { get; set; }

        public SeguradoService()
        {
            Json = "{ 'Nome': 'Fabiano', 'CPF': '00000000191', 'Idade': 23 }";
        }

        public SeguradoService(string json)
        {
            Json = json;
        }

        public Segurado Buscar(string cpf)
        {
            return JsonConvert.DeserializeObject<Segurado>(Json); ;
        }
        
    }
}

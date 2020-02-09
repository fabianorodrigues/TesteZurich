using Domain.Entities;
using Domain.Services;
using Newtonsoft.Json;


namespace Tests.Mocks
{
    public class SeguradoServiceMock : ISeguradoService
    {
        public string Json { get; set; }

        public SeguradoServiceMock()
        {
            Json = "{ 'Nome': 'Fabiano', 'CPF': '00000000191', 'Idade': 23 }";
        }

        public SeguradoServiceMock(string json)
        {
            Json = json;
        }

        public Segurado Buscar(string cpf)
        {
            return JsonConvert.DeserializeObject<Segurado>(Json); ;
        }
    }
}

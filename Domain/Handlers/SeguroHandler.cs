using Domain.Commands.Inputs;
using Domain.Commands.Outputs;
using Domain.Entities;
using Domain.Repositories;
using Domain.Services;

namespace Domain.Handlers
{
    public class SeguroHandler
    {
        private readonly ISeguroRepository _repository;
        private readonly ISeguradoService _seguradoService;

        public SeguroHandler(ISeguroRepository repository, ISeguradoService seguradoService)
        {
            _repository = repository;
            _seguradoService = seguradoService;
        }

        public CommandResult Calcular(CalcularSeguroCommand command)
        {
            var segurado = _seguradoService.Buscar(command.CPF);
            var veiculo = new Veiculo(command.ValorVeiculo, command.Marca, command.Modelo);
            

            if (segurado.Invalid)
                return new CommandResult(500, segurado.Notifications);
            else if (veiculo.Invalid)
                return new CommandResult(500, veiculo.Notifications );

            var seguro = new Seguro(veiculo, segurado);

            seguro.Calcular();
            _repository.Incluir(seguro);

            return new CommandResult(200, seguro);
        }

        public CommandResult ObterSeguro(string CPF)
        {
            var segurado = _seguradoService.Buscar(CPF);

            if (segurado.Invalid)
                return new CommandResult(500, segurado.Notifications);

            var queryResult = _repository.Buscar(CPF);

            if(queryResult == null)
                return new CommandResult(200, "O CPF informado não possui um seguro.");

            var veiculo = new Veiculo(queryResult.ValorVeiculo, queryResult.Marca, queryResult.Modelo);

            if (veiculo.Invalid)
                return new CommandResult(500, veiculo.Notifications);

            var seguro = new Seguro(veiculo, segurado);

            return new CommandResult(200, seguro);
        }
    }
}

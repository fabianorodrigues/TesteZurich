using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Commands.Inputs;
using System;
using Domain.Handlers;
using Tests.Mocks;
using Domain.Commands.Outputs;
using Domain.Entities;

namespace Tests
{
    [TestClass]
    public class SeguroHandlerTeste
    {
        private readonly SeguroHandler _handler;

        public SeguroHandlerTeste()
        {
            var repository = new SeguroRepositoryMock();
            var service = new SeguradoServiceMock();
            _handler = new SeguroHandler(repository, service);
        }

        [TestMethod]
        public void Calcular()
        {
            var command = new CalcularSeguroCommand()
            {
                CPF = "00000000191",
                ValorVeiculo = 10000,
                Marca = "Ford",
                Modelo = "Fiesta"
            };

            CommandResult result = _handler.Calcular(command);

            Assert.AreNotEqual(null, result);
            var seguro = result.Value as Seguro;
            Assert.AreEqual(seguro.Valor, Decimal.Parse("270,37"));
        }

        [TestMethod]
        public void ObterSeguro()
        {
            string CPF = "00000000191";

            CommandResult result = _handler.ObterSeguro(CPF);

            Assert.AreNotEqual(null, result);
        }
    }
}

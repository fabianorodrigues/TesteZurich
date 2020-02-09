using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities;
using System;

namespace Tests.Entities
{
    [TestClass]
    public class SeguroTeste
    {
        private readonly Veiculo _veiculo;
        private readonly Segurado _segurado;
        private readonly Seguro _seguro;
        
        public SeguroTeste()
        {
            _veiculo = new Veiculo(10000, "Ford", "Fiesta");
            _segurado = new Segurado("Fabiano", "00000000191", 23);
            _seguro = new Seguro(_veiculo, _segurado);
        }

        [TestMethod]
        public void CriarSeguroValido()
        {  
            Assert.IsTrue(_seguro.IsValid);
        }

        [TestMethod]
        public void RetornarCalculoSeguroValido()
        {
            _seguro.Calcular();
            Assert.AreEqual(_seguro.Valor, Decimal.Parse("270,37"));
        }
    }
}

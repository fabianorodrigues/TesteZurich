using Dapper;
using Domain.Entities;
using Domain.Queries;
using Domain.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace Infra.Repositories
{
    public class SeguroRepository : ISeguroRepository
    {
        private readonly IConfiguration _configuration;

        public SeguroRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").
            GetSection("DefaultConnection").Value;
            return connection;
        }

        public void Incluir(Seguro seguro)
        {
            var connectionString = this.GetConnection();
            var seguroQueryResult = new SeguroQueryResult(seguro);

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = @"INSERT INTO Seguro(Id, Valor, CPF, ValorVeiculo, Marca, Modelo) 
                                VALUES(@Id, @Valor, @CPF, @ValorVeiculo, @Marca, @Modelo);";
                    con.Execute(query, seguroQueryResult);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public SeguroQueryResult Buscar(string CPF)
        {
            var connectionString = this.GetConnection();

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = $"SELECT Id, Valor, CPF, ValorVeiculo, Marca, Modelo FROM Seguro WHERE CPF = {CPF}";
                    return con.Query<SeguroQueryResult>(query).FirstOrDefault();
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}

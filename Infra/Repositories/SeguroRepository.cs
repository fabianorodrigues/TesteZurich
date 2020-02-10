using Dapper;
using Domain.Entities;
using Domain.Queries;
using Domain.Repositories;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Data;
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

        public OracleConnection GetConnection()
        {
            var connectionString = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            var conn = new OracleConnection(connectionString);
            return conn;
        }

        public void Incluir(Seguro seguro)
        {
            var seguroQueryResult = new SeguroQueryResult(seguro);

            using (var con = this.GetConnection())
            {
                try
                {
                    con.Open();
                    con.Execute(@"INSERT INTO TB_SEGURO (ID, VALOR, CPF, VALOR_VEICULO, MARCA, MODELO) 
                                VALUES (:ID, :VALOR, :CPF_SEGURADO, :VALOR_VEICULO, :MARCA, :MODELO)",
                        new
                        {
                            ID = seguroQueryResult.Id,
                            VALOR = seguroQueryResult.Valor,
                            CPF_SEGURADO = seguroQueryResult.CPF,
                            VALOR_VEICULO = seguroQueryResult.ValorVeiculo,
                            MARCA = seguroQueryResult.Marca,
                            MODELO = seguroQueryResult.Modelo

                        });
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public SeguroQueryResult Buscar(string CPF)
        {
            using (var con = this.GetConnection())
            {
                try
                {
                    con.Open();
                    var query = $"SELECT ID, VALOR, CPF, VALOR_VEICULO AS VALORVEICULO, MARCA, MODELO FROM TB_SEGURO WHERE CPF = {CPF}";
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

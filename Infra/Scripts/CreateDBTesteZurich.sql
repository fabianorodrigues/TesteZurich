CREATE DATABASE TesteZurich

CREATE TABLE [dbo].[Seguro](
	[Id] [uniqueidentifier] primary key not NULL,
	[Valor] [decimal](10, 2) NULL,
	[CPF] [varchar](11) NULL,
	[ValorVeiculo] [decimal](10, 2) NULL,
	[Marca] [varchar](50) NULL,
	[Modelo] [varchar](50) NULL
) ON [PRIMARY]
GO


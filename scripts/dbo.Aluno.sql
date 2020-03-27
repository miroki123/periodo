USE [periodo]
GO

/****** Object: Table [dbo].[Aluno] Script Date: 26/03/2020 21:18:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Aluno] (
    [ID]             INT          NOT NULL,
    [Nome]           VARCHAR (80) NULL,
    [DataNascimento] DATETIME     NOT NULL,
    [TurmaID]        INT          NOT NULL
);



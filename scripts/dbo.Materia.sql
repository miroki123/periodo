USE [periodo]
GO

/****** Object: Table [dbo].[Materia] Script Date: 26/03/2020 21:19:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Materia] (
    [ID]      INT          NOT NULL,
    [Nome]    VARCHAR (50) NOT NULL,
    [Peso1]   FLOAT (53)   NOT NULL,
    [Peso2]   FLOAT (53)   NOT NULL,
    [Peso3]   FLOAT (53)   NOT NULL,
    [TurmaID] INT          NOT NULL
);



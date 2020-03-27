USE [periodo]
GO

/****** Object: Table [dbo].[Nota] Script Date: 26/03/2020 21:19:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Nota] (
    [AlunoID]   INT        NOT NULL,
    [MateriaID] INT        NOT NULL,
    [Nota1]     FLOAT (53) NULL,
    [Nota2]     FLOAT (53) NULL,
    [Nota3]     FLOAT (53) NULL,
    [Nota4]     FLOAT (53) NULL,
    [TurmaID]   INT        NOT NULL
);



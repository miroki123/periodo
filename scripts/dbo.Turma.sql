USE [periodo]
GO

/****** Object: Table [dbo].[Turma] Script Date: 26/03/2020 21:19:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Turma] (
    [ID]         INT          NOT NULL,
    [Nome]       VARCHAR (20) NOT NULL,
    [DataInicio] DATETIME     NOT NULL,
    [DataFim]    DATETIME     NOT NULL
);



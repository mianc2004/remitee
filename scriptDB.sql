CREATE DATABASE [RemiteeDB];
GO

USE [RemiteeDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Payer] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Code] VARCHAR (50)  NULL,
    [Name] VARCHAR (255) NULL
);


CREATE TABLE [dbo].[PayerBranch] (
    [Id]               INT              IDENTITY (1, 1) NOT NULL,
    [PayerId]          INT              NULL,
    [Code]             VARCHAR (50)     NULL,
    [Name]             VARCHAR (255)    NULL,
    [FormattedAddress] VARCHAR (255)    NULL,
    [LatitudLongitud]  [sys].[geometry] NULL
);

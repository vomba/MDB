
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/22/2017 14:36:47
-- Generated from EDMX file: C:\Users\ASUS\source\repos\VncMonitor\VncMonitor\MachineDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MachineDB];
GO
IF SCHEMA_ID(N'db') IS NULL EXECUTE(N'CREATE SCHEMA [db]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[MachineSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MachineSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'MachineSet'
CREATE TABLE [db].[MachineSet] (
    [Id] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'MachineSet'
ALTER TABLE [db].[MachineSet]
ADD CONSTRAINT [PK_MachineSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
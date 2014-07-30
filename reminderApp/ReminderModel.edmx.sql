
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/30/2014 16:06:57
-- Generated from EDMX file: C:\projects\reminder\reminderApp\ReminderModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [reminderDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PacientAlarm]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AlarmSet] DROP CONSTRAINT [FK_PacientAlarm];
GO
IF OBJECT_ID(N'[dbo].[FK_DiagnosisAlarm]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AlarmSet] DROP CONSTRAINT [FK_DiagnosisAlarm];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[PacientSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PacientSet];
GO
IF OBJECT_ID(N'[dbo].[DiagnosisSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DiagnosisSet];
GO
IF OBJECT_ID(N'[dbo].[AlarmSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AlarmSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'PacientSet'
CREATE TABLE [dbo].[PacientSet] (
    [PacientId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [SecondName] nvarchar(max)  NULL,
    [Surname] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'DiagnosisSet'
CREATE TABLE [dbo].[DiagnosisSet] (
    [DiagnosisId] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'AlarmSet'
CREATE TABLE [dbo].[AlarmSet] (
    [AlarmId] int IDENTITY(1,1) NOT NULL,
    [Time] datetime  NOT NULL,
    [PacientPacientId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [PacientId] in table 'PacientSet'
ALTER TABLE [dbo].[PacientSet]
ADD CONSTRAINT [PK_PacientSet]
    PRIMARY KEY CLUSTERED ([PacientId] ASC);
GO

-- Creating primary key on [DiagnosisId] in table 'DiagnosisSet'
ALTER TABLE [dbo].[DiagnosisSet]
ADD CONSTRAINT [PK_DiagnosisSet]
    PRIMARY KEY CLUSTERED ([DiagnosisId] ASC);
GO

-- Creating primary key on [AlarmId] in table 'AlarmSet'
ALTER TABLE [dbo].[AlarmSet]
ADD CONSTRAINT [PK_AlarmSet]
    PRIMARY KEY CLUSTERED ([AlarmId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PacientPacientId] in table 'AlarmSet'
ALTER TABLE [dbo].[AlarmSet]
ADD CONSTRAINT [FK_AlarmPacient]
    FOREIGN KEY ([PacientPacientId])
    REFERENCES [dbo].[PacientSet]
        ([PacientId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AlarmPacient'
CREATE INDEX [IX_FK_AlarmPacient]
ON [dbo].[AlarmSet]
    ([PacientPacientId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
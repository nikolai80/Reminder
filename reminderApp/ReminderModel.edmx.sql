
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/28/2014 16:41:21
-- Generated from EDMX file: \\vmware-host\Shared Folders\GitRepo\Reminder\reminderApp\RemaiderModel.edmx
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


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
    [Pacient_PacientId] int  NOT NULL,
    [Diagnosis_DiagnosisId] int  NOT NULL
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

-- Creating foreign key on [Pacient_PacientId] in table 'AlarmSet'
ALTER TABLE [dbo].[AlarmSet]
ADD CONSTRAINT [FK_PacientAlarm]
    FOREIGN KEY ([Pacient_PacientId])
    REFERENCES [dbo].[PacientSet]
        ([PacientId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PacientAlarm'
CREATE INDEX [IX_FK_PacientAlarm]
ON [dbo].[AlarmSet]
    ([Pacient_PacientId]);
GO

-- Creating foreign key on [Diagnosis_DiagnosisId] in table 'AlarmSet'
ALTER TABLE [dbo].[AlarmSet]
ADD CONSTRAINT [FK_DiagnosisAlarm]
    FOREIGN KEY ([Diagnosis_DiagnosisId])
    REFERENCES [dbo].[DiagnosisSet]
        ([DiagnosisId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DiagnosisAlarm'
CREATE INDEX [IX_FK_DiagnosisAlarm]
ON [dbo].[AlarmSet]
    ([Diagnosis_DiagnosisId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
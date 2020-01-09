
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/22/2019 14:02:52
-- Generated from EDMX file: C:\Users\BUSINESS NETWORK\Desktop\Assignment\Assignment\Models\DataB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Assignment];
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

-- Creating table 'UserDetails'
CREATE TABLE [dbo].[UserDetails] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [fullName] nvarchar(max)  NULL,
    [fatherName] nvarchar(max)  NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Subject] nvarchar(max)  NULL,
    [Contact] nvarchar(max)  NOT NULL,
    [dateofJoin] datetime  NOT NULL,
    [Admin] bit  NOT NULL,
    [Staff] bit  NOT NULL,
    [Student] bit  NOT NULL,
    [Manager] bit  NOT NULL
);
GO

-- Creating table 'Competitions'
CREATE TABLE [dbo].[Competitions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [startDate] datetime  NOT NULL,
    [endDate] datetime  NOT NULL,
    [noofSubs] int  NULL,
    [Rules] nvarchar(max)  NULL,
    [Image] nvarchar(max)  NULL,
    [UserDetailsId] int  NOT NULL
);
GO

-- Creating table 'StudentPostings'
CREATE TABLE [dbo].[StudentPostings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Remarks] nvarchar(max)  NULL,
    [Rating] nvarchar(max)  NOT NULL,
    [compName] nvarchar(max)  NULL,
    [awardWin] bit  NOT NULL,
    [noofAwards] int  NULL,
    [Image] nvarchar(max)  NOT NULL,
    [UserDetailsId] int  NOT NULL,
    [CompetitionId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UserDetails'
ALTER TABLE [dbo].[UserDetails]
ADD CONSTRAINT [PK_UserDetails]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Competitions'
ALTER TABLE [dbo].[Competitions]
ADD CONSTRAINT [PK_Competitions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StudentPostings'
ALTER TABLE [dbo].[StudentPostings]
ADD CONSTRAINT [PK_StudentPostings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserDetailsId] in table 'Competitions'
ALTER TABLE [dbo].[Competitions]
ADD CONSTRAINT [FK_UserDetailsCompetition]
    FOREIGN KEY ([UserDetailsId])
    REFERENCES [dbo].[UserDetails]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserDetailsCompetition'
CREATE INDEX [IX_FK_UserDetailsCompetition]
ON [dbo].[Competitions]
    ([UserDetailsId]);
GO

-- Creating foreign key on [UserDetailsId] in table 'StudentPostings'
ALTER TABLE [dbo].[StudentPostings]
ADD CONSTRAINT [FK_UserDetailsStudentPosting]
    FOREIGN KEY ([UserDetailsId])
    REFERENCES [dbo].[UserDetails]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserDetailsStudentPosting'
CREATE INDEX [IX_FK_UserDetailsStudentPosting]
ON [dbo].[StudentPostings]
    ([UserDetailsId]);
GO

-- Creating foreign key on [CompetitionId] in table 'StudentPostings'
ALTER TABLE [dbo].[StudentPostings]
ADD CONSTRAINT [FK_CompetitionStudentPosting]
    FOREIGN KEY ([CompetitionId])
    REFERENCES [dbo].[Competitions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompetitionStudentPosting'
CREATE INDEX [IX_FK_CompetitionStudentPosting]
ON [dbo].[StudentPostings]
    ([CompetitionId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
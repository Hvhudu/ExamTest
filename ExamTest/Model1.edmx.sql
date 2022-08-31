
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/28/2022 17:01:30
-- Generated from EDMX file: C:\Users\Подарок\source\repos\ExamTest\ExamTest\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Exam1];
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

-- Creating table 'AutoSet'
CREATE TABLE [dbo].[AutoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Fabricator] nvarchar(max)  NOT NULL,
    [Model] nvarchar(max)  NOT NULL,
    [ReleaseDate] datetime  NULL,
    [StateNumber] nvarchar(max)  NOT NULL,
    [DriverId] int  NOT NULL
);
GO

-- Creating table 'DriverSet'
CREATE TABLE [dbo].[DriverSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [First_Name] nvarchar(max)  NOT NULL,
    [Last_Name] nvarchar(max)  NOT NULL,
    [Middle_Name] nvarchar(max)  NOT NULL,
    [Photo] tinyint  NOT NULL,
    [Rating] float  NOT NULL
);
GO

-- Creating table 'ClientSet'
CREATE TABLE [dbo].[ClientSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [First_Name] nvarchar(max)  NULL,
    [Last_Name] nvarchar(max)  NULL,
    [Middle_Name] nvarchar(max)  NULL,
    [Phone_Number] nvarchar(max)  NOT NULL,
    [Rating] float  NOT NULL
);
GO

-- Creating table 'OrderSet'
CREATE TABLE [dbo].[OrderSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Adress_From] nvarchar(max)  NOT NULL,
    [Adress_Where] nvarchar(max)  NOT NULL,
    [Time] nvarchar(max)  NOT NULL,
    [Price] nvarchar(max)  NOT NULL,
    [AutoId] int  NOT NULL,
    [DriverId] int  NOT NULL,
    [ClientId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AutoSet'
ALTER TABLE [dbo].[AutoSet]
ADD CONSTRAINT [PK_AutoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DriverSet'
ALTER TABLE [dbo].[DriverSet]
ADD CONSTRAINT [PK_DriverSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ClientSet'
ALTER TABLE [dbo].[ClientSet]
ADD CONSTRAINT [PK_ClientSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderSet'
ALTER TABLE [dbo].[OrderSet]
ADD CONSTRAINT [PK_OrderSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [DriverId] in table 'AutoSet'
ALTER TABLE [dbo].[AutoSet]
ADD CONSTRAINT [FK_DriverAuto]
    FOREIGN KEY ([DriverId])
    REFERENCES [dbo].[DriverSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DriverAuto'
CREATE INDEX [IX_FK_DriverAuto]
ON [dbo].[AutoSet]
    ([DriverId]);
GO

-- Creating foreign key on [AutoId] in table 'OrderSet'
ALTER TABLE [dbo].[OrderSet]
ADD CONSTRAINT [FK_OrderAuto]
    FOREIGN KEY ([AutoId])
    REFERENCES [dbo].[AutoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderAuto'
CREATE INDEX [IX_FK_OrderAuto]
ON [dbo].[OrderSet]
    ([AutoId]);
GO

-- Creating foreign key on [DriverId] in table 'OrderSet'
ALTER TABLE [dbo].[OrderSet]
ADD CONSTRAINT [FK_OrderDriver]
    FOREIGN KEY ([DriverId])
    REFERENCES [dbo].[DriverSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderDriver'
CREATE INDEX [IX_FK_OrderDriver]
ON [dbo].[OrderSet]
    ([DriverId]);
GO

-- Creating foreign key on [ClientId] in table 'OrderSet'
ALTER TABLE [dbo].[OrderSet]
ADD CONSTRAINT [FK_ClientOrder]
    FOREIGN KEY ([ClientId])
    REFERENCES [dbo].[ClientSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientOrder'
CREATE INDEX [IX_FK_ClientOrder]
ON [dbo].[OrderSet]
    ([ClientId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
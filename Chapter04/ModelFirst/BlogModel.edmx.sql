
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/01/2018 11:30:11
-- Generated from EDMX file: F:\study\git\ASP.NETMVC5wzkfzm\Chapter04\ModelFirst\BlogModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BlogDb];
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

-- Creating table 'BlogSet'
CREATE TABLE [dbo].[BlogSet] (
    [Id] uniqueidentifier  NOT NULL,
    [OwnerId] uniqueidentifier  NOT NULL,
    [Caption] nvarchar(max)  NOT NULL,
    [DateCreated] datetime  NOT NULL
);
GO

-- Creating table 'BlogArticleSet'
CREATE TABLE [dbo].[BlogArticleSet] (
    [Id] uniqueidentifier  NOT NULL,
    [BloagId] uniqueidentifier  NOT NULL,
    [Subject] nvarchar(max)  NOT NULL,
    [Body] nvarchar(max)  NOT NULL,
    [DateCreated] datetime  NOT NULL,
    [DateModified] datetime  NOT NULL,
    [Blog_Id] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'BlogSet'
ALTER TABLE [dbo].[BlogSet]
ADD CONSTRAINT [PK_BlogSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BlogArticleSet'
ALTER TABLE [dbo].[BlogArticleSet]
ADD CONSTRAINT [PK_BlogArticleSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Blog_Id] in table 'BlogArticleSet'
ALTER TABLE [dbo].[BlogArticleSet]
ADD CONSTRAINT [FK_BlogBlogArticle]
    FOREIGN KEY ([Blog_Id])
    REFERENCES [dbo].[BlogSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BlogBlogArticle'
CREATE INDEX [IX_FK_BlogBlogArticle]
ON [dbo].[BlogArticleSet]
    ([Blog_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
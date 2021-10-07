
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/07/2021 03:58:56
-- Generated from EDMX file: C:\Users\husyd\source\repos\Levis\Levis\ModelEntity.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [shop];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[shopModelStoreContainer].[Article]', 'U') IS NOT NULL
    DROP TABLE [shopModelStoreContainer].[Article];
GO
IF OBJECT_ID(N'[shopModelStoreContainer].[Cart]', 'U') IS NOT NULL
    DROP TABLE [shopModelStoreContainer].[Cart];
GO
IF OBJECT_ID(N'[shopModelStoreContainer].[Order]', 'U') IS NOT NULL
    DROP TABLE [shopModelStoreContainer].[Order];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CartSet'
CREATE TABLE [dbo].[CartSet] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Article'
CREATE TABLE [dbo].[Article] (
    [Id] int  NOT NULL,
    [Name] varchar(50)  NULL,
    [description] nchar(10)  NULL,
    [price] float  NULL,
    [ImagePath] varchar(50)  NULL
);
GO

-- Creating table 'Cart1Set'
CREATE TABLE [dbo].[Cart1Set] (
    [Id] varchar(10)  NOT NULL,
    [Article_id] int  NULL,
    [Article_name] varchar(50)  NULL,
    [Article_price] float  NULL,
    [Article_Qty] int  NULL,
    [Article_imagePath] varchar(50)  NULL,
    [User_Id] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Order'
CREATE TABLE [dbo].[Order] (
    [Id] int  NOT NULL,
    [Article_id] int  NULL,
    [Article_Name] varchar(50)  NULL,
    [User__id] int  NULL,
    [Date] varchar(50)  NULL,
    [Order_price] float  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'CartSet'
ALTER TABLE [dbo].[CartSet]
ADD CONSTRAINT [PK_CartSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Article'
ALTER TABLE [dbo].[Article]
ADD CONSTRAINT [PK_Article]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Cart1Set'
ALTER TABLE [dbo].[Cart1Set]
ADD CONSTRAINT [PK_Cart1Set]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Order'
ALTER TABLE [dbo].[Order]
ADD CONSTRAINT [PK_Order]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

INSERT INTO Article
(Id, Name, description , price , ImagePath)
VALUES
(10, 'Nike', 'Description de Nike' , 124 , 'https://cdn.shopify.com/s/files/1/0646/1285/products/Capri-Castagna-Lowtop-Men-Koio-1_1200x.progressive.png.jpg),
(14, 'Adidas', 'Description de Adidas' , 150 , 'https://assets.adidas.com/images/w_600,f_auto,q_auto/65a66d7d1b6544fd85e7a998000b49cb_9366/Runfalcon_Shoes_Black_F36218.jpg'),
(17, 'Philipp plein', 'Description de Philipp' , 900 , 'https://i.pinimg.com/236x/bc/38/3f/bc383f4284a624f6bd815a1093b0fa15.jpg'),
(16, 'Lacost', 'Description de Lacost' , 250 , 'https://i.pinimg.com/236x/bc/38/3f/bc383f4284a624f6bd815a1093b0fa15.jpg'),
(10, 'Jordans', 'Description de Jordans' , 300 , 'https://i.pinimg.com/236x/bc/38/3f/bc383f4284a624f6bd815a1093b0fa15.jpg'),

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

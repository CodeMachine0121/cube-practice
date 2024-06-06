create database CubeDB

create table [dbo].[CurrencyName] (
    [Id]         INT           NOT NULL IDENTITY (1,1),
    [CreatedOn]  DATETIME      NOT NULL,
    [CreatedBy]  NVARCHAR(50)  NOT NULL,
    Code VARCHAR(4) NOT NULL,
    ChineseName NVARCHAR(100) NOT NULL
)

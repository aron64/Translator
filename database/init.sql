USE master;
GO
IF DB_ID(N'TRANSLATOR') IS NOT NULL
DROP DATABASE TRANSLATOR;
GO
CREATE DATABASE TRANSLATOR
--COLLATE Latin1_General_100_CS_AS_SC;
GO
USE TRANSLATOR;
GO
CREATE TABLE dictionary
(
    English nvarchar(255),
    Hungarian nvarchar(255),
    Spanish nvarchar(255),
    Chinese nvarchar(255),
    Portugese nvarchar(255)
);
go

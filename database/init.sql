USE master;
GO
IF DB_ID(N'TRANSLATOR') IS NOT NULL
DROP DATABASE TRANSLATOR;
GO
CREATE DATABASE TRANSLATOR;
GO
USE TRANSLATOR;
GO
CREATE TABLE dictionary
(
    English text,
    Hungarian text,
    Spanish text,
    Chinese text,
    Portugese text
);
go

USE [C:\REPOS\COONOR-GLEASON-INDIVIDUAL-WORK\WEBAPPLICATION1\WEBAPPLICATION1\APP_DATA\DVDS.MDF]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_insertDvd]
	@title varchar(50),
@releaseDate int,
@director nvarchar(50),
@rating nvarchar(50),
@notes nvarchar(50)

AS
INSERT INTO DVDS (TITLE, ReleaseDate, Director, Rating, Notes)
VALUES (@TITLE, @releaseDate, @director, @RATING, @notes)
select @@IDENTITY

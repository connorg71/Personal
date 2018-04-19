USE [C:\REPOS\COONOR-GLEASON-INDIVIDUAL-WORK\WEBAPPLICATION1\WEBAPPLICATION1\APP_DATA\DVDS.MDF]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_updateDvd]
	@title varchar(50),
@releaseDate int,
@director nvarchar(50),
@rating nvarchar(50),
@notes nvarchar(50),
@id int
AS
update dvds set title = @title, ReleaseDate = @releaseDate, Director = @director, rating = @rating, notes = @notes where id = @id

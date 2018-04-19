USE [C:\REPOS\COONOR-GLEASON-INDIVIDUAL-WORK\WEBAPPLICATION1\WEBAPPLICATION1\APP_DATA\DVDS.MDF]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[sp_getDvd]
		@id = 1

SELECT	@return_value as 'Return Value'

GO

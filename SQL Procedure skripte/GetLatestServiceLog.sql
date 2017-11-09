-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Nikola Dukic
-- Create date: 9. NOV 2017.
-- Description:	Procedura koja vraca poslednji log za dati ID servisa
-- =============================================
CREATE PROCEDURE GetLatestServiceLog(@ClientServiceID INT)
AS
BEGIN
	SELECT *
	FROM ServiceLog
	WHERE LogID = 
	(
		SELECT MAX(LogID) 
		FROM ServiceLog 
		WHERE ClientServiceID = @ClientServiceID
	)
END
GO

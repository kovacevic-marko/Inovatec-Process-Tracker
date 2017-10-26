USE [InovatecDB]
GO

/****** Object:  StoredProcedure [dbo].[GetLatestServiceLogByID]    Script Date: 26-Oct-17 1:54:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetLatestServiceLogByID](@id int) 
AS
BEGIN
	select top 1 status from tb_service_log
	where @id=service_id
	order by date desc	
END
GO



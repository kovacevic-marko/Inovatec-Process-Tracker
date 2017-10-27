USE [InovatecDB]
GO

/****** Object:  StoredProcedure [dbo].[GetLatestServiceLogByID]    Script Date: 27-Oct-17 12:16:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetLatestServiceLogByID](@id int) 
AS
BEGIN
	if exists(select service_id from tb_service_log where @id=service_id)
	begin
		select top 1 status from tb_service_log
		where @id=service_id
		order by date desc	
	end
	else
	begin
		declare @status bit;
		set @status=0;
		select @status as status;
	end	
END
GO



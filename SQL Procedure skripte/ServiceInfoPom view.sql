--pomocni pogled za ServiceInfo

USE [InovatecDB]
GO

/****** Object:  View [dbo].[ServicesInfoPom]    Script Date: 27-Oct-17 12:09:41 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create view [dbo].[ServicesInfoPom]
as
 select * from tb_service_log log1
 where log1.date = (
 	select MAX(log2.date) 
 	from tb_service_log log2
 	where log2.service_id = log1.service_id
 )
GO



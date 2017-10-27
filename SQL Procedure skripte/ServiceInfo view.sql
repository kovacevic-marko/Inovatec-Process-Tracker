--pogled koji vraca listu svih servisa (id,ime, poslednji status i datum poslednjeg statusa)
-- ako servis ne postoji u tabeli log onda vraca datum i status kao null;
USE [InovatecDB]
GO

/****** Object:  View [dbo].[ServicesInfo]    Script Date: 27-Oct-17 12:10:40 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE view [dbo].[ServicesInfo]
as
	select s1.id,s1.name, s2.status, s2.date
	from
	tb_service s1 left join ServicesInfoPom s2 on s1.id=s2.service_id  
GO



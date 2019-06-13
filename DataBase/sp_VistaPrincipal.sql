USE CORRESPONDENCIA
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author, ALEJANDRO GARCIA ALVAREZ>
-- Create date: <Create Date,26/02/2019>
-- Description:	<Description,CREA UN SELECT PARA ARROJAR LAS CONSULTAS  DE LA VISTA PRINCIAL>
-- =============================================
CREATE PROCEDURE sp_SelectVistaPincipal 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ENVIADO,FECHACAPTURA,EXISTEFISICAMENTE,RECIBIDO,NOMBREDESTINO,DIRECCIONDESTINO,NOMBREREMITENTE,CARGO,[DIRECCION ORIGEN],TIPODOCUMENTO
		 FROM dbo.VistaPrincipal 
		 ORDER BY   ENVIADO, FechaCaptura ASC 
		 		
END
GO



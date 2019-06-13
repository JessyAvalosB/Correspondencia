USE CORRESPONDENCIA
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author, ALEJANDRO GARCIA ALVAREZ>
-- Create date: <Create Date, 26/02/2019>
-- Description:	<Description, MOSTRARA UN SELECT DEPENDIENDO QUE USUARIO INICIE SESION PARA MOSTRAR LOS DATOS CORRESPONDIENTES>
-- =============================================
CREATE PROCEDURE sp_SelectVistaDestinatario
	-- Add the parameters for the stored procedure here
	@ID_DESTINATARIO INT 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * 
	FROM VISTADESTINO 
		WHERE ID_DESTINATARIO=@ID_DESTINATARIO 
				AND [FECHA DE ENVIO] IS NOT NULL
END
GO



EXEC sp_SelectVistaDestinatario 2
EXEC sp_SelectVistaDestinatario 4
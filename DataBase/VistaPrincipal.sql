/*** Vista pra la tabla a mostrar en la pagina de la secretaria principal***/
USE CORRESPONDENCIA
GO

CREATE VIEW VistaPrincipal AS
	Select D.TURNADO AS "Enviado",D.FECHA_CAPTURA AS "FechaCaptura", D.COPIA_FISICA AS "ExisteFisicamente", 
		D.ESTADO As "Recibido",CU.NOMBRE+' '+CU.APELLIDO_PATERNO AS "NombreDestino",CD.NOMBRE AS "DireccionDestino", CR.NOMBRE+' '+CR.APELLIDO_PATERNO AS "NombreRemitente",
			CR.CARGO AS "Cargo",CO.NOMBRE AS "Direccion origen",CT.TIPO As "TipoDocumento"
			FROM ((((((TBL_DOCUMENTOS AS D 
				JOIN CAT_USUARIO AS CU 
					ON D.ID_DESTINATARIO=CU.ID_USUARIO)
				JOIN CAT_DIRECCION AS CD
					ON CD.ID_DIRECCION=CU.ID_DIRECCION)
				JOIN CAT_REMITENTES AS  CR
					ON CR.ID_REMITENTE=D.ID_REMITENTE)
				JOIN CAT_ORIGENES AS CO
					ON CO.ID_ORIGEN = CR.ID_ORIGEN)
				JOIN CAT_TIPO AS CT 
					ON CT.ID_TIPO=D.ID_TIPO_DOC)
					);

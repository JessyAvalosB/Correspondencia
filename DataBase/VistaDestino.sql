/*** Esta vista esta creada para para los usuarios dstino, es decir aquellos usuarios a los cuales se les mandara la correspondencia***/
USE CORRESPONDENCIA
GO
CREATE VIEW VistaDestino AS
	Select D.FECHA_ENVIO AS "Fecha de envio",CU.NOMBRE+' '+CU.APELLIDO_PATERNO AS "Recibio",CU.CORREO AS "Correo recibio", CU.TELEFONO AS "Telefono recibio",CD.NOMBRE AS "Direccion", CR.NOMBRE+' '+CR.APELLIDO_PATERNO AS "Nombre remitente",
			CR.CARGO AS "Cargo",CO.NOMBRE AS "Direccion origen",CT.TIPO As "Tipo Documento", D.ID_DESTINATARIO AS"ID_DESTINATARIO"
			FROM ((((((TBL_DOCUMENTOS AS D 
				JOIN CAT_USUARIO AS CU 
					ON D.ID_CARGA_USUARIO=CU.ID_USUARIO)
				JOIN CAT_DIRECCION AS CD
					ON CD.ID_DIRECCION=CU.ID_DIRECCION)
				JOIN CAT_REMITENTES AS  CR
					ON CR.ID_REMITENTE=D.ID_REMITENTE)
				JOIN CAT_ORIGENES AS CO
					ON CO.ID_ORIGEN = CR.ID_ORIGEN)
				JOIN CAT_TIPO AS CT 
					ON CT.ID_TIPO=D.ID_TIPO_DOC)
					);
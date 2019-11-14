using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Correspondencia.Models.Documents;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using Correspondencia.Models;

namespace Correspondencia.DB
{
    public class DB
    {

        SqlConnection connection = new SqlConnection("Server=DESKTOP-HKUPQ77;Initial Catalog=SEDER-Mensajeria;Integrated Security = True");

        SqlCommand cmd;
        /*
        public List<SignatoryModel> getSignatory()
        {
            List<SignatoryModel> lista = new List<SignatoryModel>();
            lista = connection.Query<SignatoryModel>("select ID_REMITENTE, ID_ORIGEN, NOMBRE, APELLIDO_PATERNO, APELLIDO_MATERNO, CARGO, CORREO, TELEFONO from CAT_REMITENTES").ToList();

            return lista;
        }
        */
        public List<DocumentModel> getDocuments()
        {
            List<DocumentModel> documents = new List<DocumentModel>();
            using (connection)
            {
                connection.Open();

                cmd = new SqlCommand("sp_SelectVistaPincipal", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    documents.Add(DocumentConvertorHome(dr));
                }

                connection.Close();
            }
            
            return documents;
        }
        public static DocumentModel DocumentConvertorHome(IDataReader reader)
        {

            DocumentModel documentModel = new DocumentModel();

            documentModel.ID_DOCUMENTO = Convert.ToString(reader["ID_DOCUMENTO"]);

            if (Convert.ToInt32(reader["TURNADO"]) == 0)
            {
                documentModel.TURNADO = "No";
            }
            else
            {
                documentModel.TURNADO = "Si";
            }

            if (Convert.ToInt32(reader["COPIA_FISICA"]) == 0)
            {
                documentModel.COPIA_FISICA = "No";
            }
            else
            {
                documentModel.COPIA_FISICA = "Si";
            }

            if (Convert.ToInt32(reader["ESTADO"]) == 0)
            {
                documentModel.ESTADO = "No";
            }
            else
            {
                documentModel.ESTADO = "Si";
            }
            
            documentModel.FECHA_CAPTURA = Convert.ToDateTime(reader["FECHA_CAPTURA"]);

            documentModel.DESTINO = Convert.ToString(reader["DESTINO"]);

            documentModel.FIRMANTE = Convert.ToString(reader["FIRMANTE"]);

            documentModel.CARGO = Convert.ToString(reader["CARGO"]);

            documentModel.ORIGEN = Convert.ToString(reader["ORIGEN"]);

            documentModel.TIPO = Convert.ToString(reader["TIPO"]);

            return documentModel;

        }
        public List<DocTypeModel> getDocType()
        {
            List<DocTypeModel> docTypes = new List<DocTypeModel>();

            docTypes = connection.Query<DocTypeModel>("select * from CAT_TIPO").ToList();

            return docTypes;
        }
        public List<DocDestinationModel> getDocDestination()
        {
            List<DocDestinationModel> docDestinations = new List<DocDestinationModel>();

            docDestinations = connection.Query<DocDestinationModel>("select * from CAT_DIRECCION").ToList();

            return docDestinations;
        }
        public List<DocSignatoryModel> getDocSignatories()
        {
            List<DocSignatoryModel> docSignatories = new List<DocSignatoryModel>();

            docSignatories = connection.Query<DocSignatoryModel>("select ID_REMITENTE, NOMBRE+' '+APELLIDO_PATERNO+' '+APELLIDO_MATERNO as NOMBRE  from CAT_REMITENTES").ToList();

            return docSignatories;
        }
        public void insertDocument(AddDocModel addDoc)
        {
          
            using (connection)
            {
                connection.Open();

                cmd = new SqlCommand("sp_InsertDocumento", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_REM", addDoc.ID_REM);
                cmd.Parameters.AddWithValue("@ID_DIR", addDoc.ID_DIR);
                cmd.Parameters.AddWithValue("@ID_TIP", addDoc.ID_TIP);
                cmd.Parameters.AddWithValue("@FOLIO", addDoc.FOLIO);
                cmd.Parameters.AddWithValue("@TURNADO", addDoc.TURNADO);
                cmd.Parameters.AddWithValue("@ESTADO", addDoc.ESTADO);
                cmd.Parameters.AddWithValue("@RESUMEN", addDoc.RESUMEN);
                cmd.Parameters.AddWithValue("@PDF", addDoc.PDF);
                cmd.Parameters.AddWithValue("@COPIA", addDoc.COPIA);

                cmd.ExecuteNonQuery();

                }
                connection.Close();
            }

        public List<DocumentDetails> getDocDetails(string id)
        {
            int idDoc = Convert.ToInt32(id);
            List<DocumentDetails> details = new List<DocumentDetails>();

            using (connection)
            {
                connection.Open();

                cmd = new SqlCommand("sp_SelectVistaDetallada", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_DOCUMENTO", idDoc);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    details.Add(DocumentConvertorDetails(dr));
                }

                connection.Close();
            }

            return details;
    }
        public static DocumentDetails DocumentConvertorDetails(IDataReader reader)
        {
            DocumentDetails details = new DocumentDetails();

            details.FOLIO = Convert.ToString(reader["FOLIO"]);
            details.IMAGEN = Convert.ToString(reader["IMAGEN"]);
            details.NOMBRE = Convert.ToString(reader["NOMBRE"]);
            details.ORIGEN = Convert.ToString(reader["ORIGEN"]);
            details.TELEFONO = Convert.ToString(reader["TELEFONO"]);
            details.TIPO = Convert.ToString(reader["TIPO"]);
            details.ID_DOCUMENTO = Convert.ToString(reader["ID_DOCUMENTO"]);
            details.FECHA_CAPTURA = Convert.ToString(reader["FECHA_CAPTURA"]);
            if (Convert.ToInt32(reader["ESTADO"]) == 0)
            {
                details.ESTADO = "No";
            }
            else
            {
                details.ESTADO = "Si";
            }
            details.CARGO = Convert.ToString(reader["CARGO"]);
            if (Convert.ToInt32(reader["COPIA_FISICA"]) == 0)
            {
                details.COPIA_FISICA = "No";
            }
            else
            {
                details.COPIA_FISICA = "Si";
            }
            details.CORREO = Convert.ToString(reader["CORREO"]);
            details.DIRECCION = Convert.ToString(reader["DIRECCION"]);
            details.RESPUESTA = Convert.ToString(reader["RESPUESTA"]);
            details.RESUMEN = Convert.ToString(reader["RESUMEN"]);

            return details;
        }

        //Codigo hecho por otros

        public List<DocUser> obtenerusuario(String usuario, String contraseña)
        {
            connection.Open();

            cmd = new SqlCommand("sp_login", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            List<SqlParameter> parametros = new List<SqlParameter>();

            cmd.Parameters.AddWithValue("@Usuario", usuario);
            cmd.Parameters.AddWithValue("@Contraseña", contraseña);




            //cmd.Parameters.Add(parametros.ToArray());

            SqlDataReader dr = cmd.ExecuteReader();


            DocUser usuarioAc = new DocUser();
            List<DocUser> ArrayUsers = new List<DocUser>();
            while (dr.Read())
            {
                usuarioAc.ID_USUARIO = Convert.ToInt32(dr["ID_USUARIO"]);
                usuarioAc.ID_DIRECCION = Convert.ToInt32(dr["ID_DIRECCION"]);
                usuarioAc.TIPO_USUARIO = Convert.ToInt32(dr["TIPO_USUARIO"]);
                usuarioAc.NOMBRE = Convert.ToString(dr["NOMBRE"]);
                usuarioAc.APELLIDO_PATERNO = Convert.ToString(dr["APELLIDO_PATERNO"]);
                usuarioAc.APELLIDO_MATERNO = Convert.ToString(dr["APELLIDO_MATERNO"]);
                usuarioAc.CORREO = Convert.ToString(dr["CORREO"]);
                usuarioAc.TELEFONO = Convert.ToString(dr["TELEFONO"]);
                ArrayUsers.Add(usuarioAc);
            }

            connection.Close();

            return ArrayUsers;
        }



        public List<DocDependencia> getDependencias()
        {
            connection.Open();

            cmd = new SqlCommand("sp_getDependenciaOrigen", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            List<SqlParameter> parametros = new List<SqlParameter>();






            //cmd.Parameters.Add(parametros.ToArray());

            SqlDataReader dr = cmd.ExecuteReader();
            DocDependencia DependenciaAc;
            List<DocDependencia> ArrayDependecias = new List<DocDependencia>();
            while (dr.Read())
            {
                DependenciaAc = new DocDependencia();
                DependenciaAc.ID_ORIGEN = Convert.ToInt32(dr["ID_ORIGEN"]);

                DependenciaAc.NOMBRE = Convert.ToString(dr["NOMBRE"]);

                ArrayDependecias.Add(DependenciaAc);
            }

            connection.Close();

            return ArrayDependecias;
        }



        public void setFirmante(DocRemitentes Firmante)
        {
            connection.Open();

            cmd = new SqlCommand("sp_InsertRemitentesOrigen", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            List<SqlParameter> parametros = new List<SqlParameter>();

            cmd.Parameters.AddWithValue("@NOMBRE", Firmante.NOMBRE);
            cmd.Parameters.AddWithValue("@APELLIDOP", Firmante.APELLIDO_PATERNO);
            cmd.Parameters.AddWithValue("@APELLIDOM", Firmante.APELLIDO_MATERNO);
            cmd.Parameters.AddWithValue("@CARGO", Firmante.CARGO);
            cmd.Parameters.AddWithValue("@CORRE0", Firmante.CORREO);
            cmd.Parameters.AddWithValue("@TELEFONO", Firmante.TELEFONO);
            cmd.Parameters.AddWithValue("@NOMBREO", Firmante.NOMBREORIGEN);





            //cmd.Parameters.Add(parametros.ToArray());

            SqlDataReader dr = cmd.ExecuteReader();



        }


        public List<DocumentDetails> getDocumentoYear(String año, int tipo)
        {

            connection.Open();

            cmd = new SqlCommand("sp_Busqueda", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            List<DocumentDetails> parametros = new List<DocumentDetails>();

            cmd.Parameters.AddWithValue("@año", año);
            cmd.Parameters.AddWithValue("@tipo", tipo);






            return parametros;

        }




        public List<DocRemitentes> getEditarFirmantes()
        {
            connection.Open();

            cmd = new SqlCommand("sp_getRemitentes", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            List<SqlParameter> parametros = new List<SqlParameter>();






            //cmd.Parameters.Add(parametros.ToArray());

            SqlDataReader dr = cmd.ExecuteReader();


            DocRemitentes FirmanteAc;
            List<DocRemitentes> ArrayFirmante = new List<DocRemitentes>();
            while (dr.Read())
            {
                FirmanteAc = new DocRemitentes();

                FirmanteAc.ID_REMITENTE = Convert.ToInt32(dr["ID_REMITENTE"]);

                FirmanteAc.ID_ORIGEN = Convert.ToInt32(dr["ID_ORIGEN"]);
                FirmanteAc.NOMBREORIGEN = Convert.ToString(dr["NOMBREORIGEN"]);
                FirmanteAc.NOMBRE = Convert.ToString(dr["NOMBRE"]);
                FirmanteAc.APELLIDO_PATERNO = Convert.ToString(dr["APELLIDO_PATERNO"]);
                FirmanteAc.APELLIDO_MATERNO = Convert.ToString(dr["APELLIDO_MATERNO"]);
                FirmanteAc.CARGO = Convert.ToString(dr["CARGO"]);
                FirmanteAc.CORREO = Convert.ToString(dr["CORREO"]);
                FirmanteAc.TELEFONO = Convert.ToString(dr["TELEFONO"]);
                ArrayFirmante.Add(FirmanteAc);
            }

            connection.Close();

            return ArrayFirmante;
        }


        public void setEditFirmante(DocRemitentes Firmante)
        {
            connection.Open();

            cmd = new SqlCommand("sp_UdateRemitentesOrigen", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            List<SqlParameter> parametros = new List<SqlParameter>();

            cmd.Parameters.AddWithValue("@NOMBRE", Firmante.NOMBRE);
            cmd.Parameters.AddWithValue("@APELLIDOP", Firmante.APELLIDO_PATERNO);
            cmd.Parameters.AddWithValue("@APELLIDOM", Firmante.APELLIDO_MATERNO);
            cmd.Parameters.AddWithValue("@CARGO", Firmante.CARGO);
            cmd.Parameters.AddWithValue("@CORRE0", Firmante.CORREO);
            cmd.Parameters.AddWithValue("@TELEFONO", Firmante.TELEFONO);
            cmd.Parameters.AddWithValue("@ID_REMITENTE", Firmante.ID_REMITENTE);
            cmd.Parameters.AddWithValue("@ID_ORIGEN", Firmante.ID_ORIGEN);





            //cmd.Parameters.Add(parametros.ToArray());

            SqlDataReader dr = cmd.ExecuteReader();



        }

    }
}

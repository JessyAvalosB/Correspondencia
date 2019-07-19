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
                    documents.Add(DocumentConvertor(dr));
                }

                connection.Close();
            }
            
            return documents;
        }
        public static DocumentModel DocumentConvertor(IDataReader reader)
        {

            DocumentModel documentModel = new DocumentModel();
            
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
        }
    }

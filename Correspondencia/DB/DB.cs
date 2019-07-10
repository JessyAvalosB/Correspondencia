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

        SqlConnection connection = new SqlConnection("Server=tcp:seder.database.windows.net,1433;Initial Catalog=SEDER-Mensajeria;Persist Security Info=False;User ID=SEDER-A;Password=Local123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

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
            
            if (Convert.ToInt32(reader["ENVIADO"]) == 0)
            {
                documentModel.ENVIADO = "No";
            }
            else
            {
                documentModel.ENVIADO = "Si";
            }

            if (Convert.ToInt32(reader["EXISTEFISICAMENTE"]) == 0)
            {
                documentModel.EXISTEFISICAMENTE = "No";
            }
            else
            {
                documentModel.EXISTEFISICAMENTE = "Si";
            }

            if (Convert.ToInt32(reader["RECIBIDO"]) == 0)
            {
                documentModel.RECIBIDO = "No";
            }
            else
            {
                documentModel.RECIBIDO = "Si";
            }
            
            documentModel.FECHACAPTURA = Convert.ToDateTime(reader["FECHACAPTURA"]);

            documentModel.NOMBREDESTINO = Convert.ToString(reader["NOMBREDESTINO"]);

            documentModel.DIRECCIONDESTINO = Convert.ToString(reader["DIRECCIONDESTINO"]);

            documentModel.NOMBREREMITENTE = Convert.ToString(reader["NOMBREREMITENTE"]);

            documentModel.CARGO = Convert.ToString(reader["CARGO"]);

            documentModel.DIRECCIONORIGEN = Convert.ToString(reader["DIRECCIONORIGEN"]);

            documentModel.TIPODOCUMENTO = Convert.ToString(reader["TIPODOCUMENTO"]);

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
    }
}

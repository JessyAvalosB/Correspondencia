using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Correspondencia.Models;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace Correspondencia.DB
{
    public class DB
    {

        SqlConnection connection = new SqlConnection("Server=tcp:seder.database.windows.net,1433;Initial Catalog=SEDER-Mensajeria;Persist Security Info=False;User ID=SEDER-A;Password=Local123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        SqlCommand cmd;



        public List<SignatoryModel> getSignatory()
        {
            List<SignatoryModel> lista = new List<SignatoryModel>();
            lista = connection.Query<SignatoryModel>("select ID_REMITENTE, ID_ORIGEN, NOMBRE, APELLIDO_PATERNO, APELLIDO_MATERNO, CARGO, CORREO, TELEFONO from CAT_REMITENTES").ToList();

            return lista;
        }

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
            }
            
            return documents;
        }

        public static DocumentModel DocumentConvertor(IDataReader reader)
        {
            DocumentModel documentModel = new DocumentModel();

            documentModel.ENVIADO = Convert.ToInt32(reader["ENVIADO"]);
            documentModel.FECHACAPTURA = Convert.ToDateTime(reader["FECHACAPTURA"]);
            documentModel.EXISTEFISICAMENTE = Convert.ToInt32(reader["EXISTEFISICAMENTE"]);
            documentModel.RECIBIDO = Convert.ToInt32(reader["RECIBIDO"]);
            documentModel.NOMBREDESTINO = Convert.ToString(reader["NOMBREDESTINO"]);
            documentModel.DIRECCIONDESTINO = Convert.ToString(reader["DIRECCIONDESTINO"]);
            documentModel.NOMBREREMITENTE = Convert.ToString(reader["NOMBREREMITENTE"]);
            documentModel.CARGO = Convert.ToString(reader["CARGO"]);
            documentModel.DIRECCIONORIGEN = Convert.ToString(reader["DIRECCIONORIGEN"]);
            documentModel.TIPODOCUMENTO = Convert.ToString(reader["TIPODOCUMENTO"]);


            return documentModel;
        }
    }
}

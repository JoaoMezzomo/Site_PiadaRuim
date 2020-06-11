using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Xml;
using System.Web.Configuration;
using System.Data;

namespace SitePiadaRuim.classes
{
    public class Data
    {
        protected string BuscarConnectionString() 
        {
            return WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString.ToString();
        }

        protected bool ExecutarComandoDataBase(string query) 
        {
            bool retorno = true;
            string connectionString = BuscarConnectionString();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                retorno = false;
            }

            return retorno;
        }

        public DataSet ExecutarSelectDataBase(string query) 
        {
            DataSet dataSet = new DataSet();

            try
            {
                string connectionString = BuscarConnectionString();

                SqlConnection connection = new SqlConnection(connectionString);

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                dataAdapter.Fill(dataSet);

            }
            catch (Exception ex)
            {
                string teste = ex.Message;
            }
            return dataSet;
        }
    }
}
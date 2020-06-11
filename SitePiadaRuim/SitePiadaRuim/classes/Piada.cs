using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SitePiadaRuim.classes
{
    public class Piada : Data
    {
        public int ID_Data;
        public string Piada_Data;

        public static List<Piada> Lista() 
        {
            List<Piada> piadas = new List<Piada>();

            string query = "SELECT * FROM PIADAS";

            Data data = new Data();

            DataSet dataSet = data.ExecutarSelectDataBase(query);

            if (dataSet.Tables.Count > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    Piada piadaItem = new Piada();

                    piadaItem.ID_Data = Convert.ToInt32(row["ID"]);
                    piadaItem.Piada_Data = row["PIADA"].ToString();
                    piadas.Add(piadaItem);
                }
            }

            return piadas;
        }

        public bool Inserir() 
        {
            bool retorno = true;

            string query = $"INSERT INTO PIADAS (PIADA) VALUES ('{Piada_Data}')";

            retorno = ExecutarComandoDataBase(query);

            return retorno;
        }

        public bool Remover() 
        {
            bool retorno = true;

            string query = $"DELETE FROM PIADAS WHERE ID = {ID_Data}";

            retorno = ExecutarComandoDataBase(query);

            return retorno;
        }

        public bool Alterar() 
        {
            bool retorno = true;

            string query = $"UPDATE PIADAS SET PIADA = 'PIADA' WHERE ID = {ID_Data}";

            retorno = ExecutarComandoDataBase(query);

            return retorno;
        }
    }
}
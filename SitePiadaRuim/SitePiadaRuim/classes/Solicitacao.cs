using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SitePiadaRuim.classes
{
    public class Solicitacao : Data
    {
        public int ID_Data;
        public string Piada_Data;

        public static List<Solicitacao> Lista()
        {
            List<Solicitacao> solicitacoes = new List<Solicitacao>();

            string query = "SELECT * FROM SOLICITACOES";

            Data data = new Data();

            DataSet dataSet = data.ExecutarSelectDataBase(query);

            if (dataSet.Tables.Count > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    Solicitacao solicitacaoItem = new Solicitacao();

                    solicitacaoItem.ID_Data = Convert.ToInt32(row["ID"]);
                    solicitacaoItem.Piada_Data = row["PIADA"].ToString();
                    solicitacoes.Add(solicitacaoItem);
                }
            }

            return solicitacoes;
        }

        public bool Inserir()
        {
            bool retorno = true;

            string query = $"INSERT INTO SOLICITACOES (PIADA) VALUES ('{Piada_Data}')";

            retorno = ExecutarComandoDataBase(query);

            return retorno;
        }

        public bool Remover()
        {
            bool retorno = true;

            string query = $"DELETE FROM SOLICITACOES WHERE ID = {ID_Data}";

            retorno = ExecutarComandoDataBase(query);

            return retorno;
        }
    }
}
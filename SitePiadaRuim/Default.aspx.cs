using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Services;
using SitePiadaRuim.classes;

namespace SitePiadaRuim
{
    public partial class Default : System.Web.UI.Page
    {
        List<Piada> Piadas = new List<Piada>();
        int Quantidade;
        int IndexPiada;

        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarInformacoes();
        }

        private void CarregarInformacoes() 
        {
            Piadas.Clear();

            try
            {
                Piadas = Piada.Lista();

                Quantidade = Piadas.Count();

                lblQuantidade.Text = Quantidade + " piadas registradas!";
            }
            catch (Exception)
            {
                MostrarMensagem("Não foi possível carregar as piadas cadastradas.");
            }
        }

        private void  BuscarPiada() 
        {
            try
            {
                Random random = new Random();

                IndexPiada = random.Next(Quantidade);

                string piada = Piadas[IndexPiada].Piada_Data;

                if (piada[0] == '\r' && piada[1] == '\n')
                {
                    piada = piada.Remove(0, 2);
                }

                txtPiada.Text = piada;

                txtSorteio.Text = (IndexPiada + 1).ToString();
            }
            catch (Exception)
            {
                MostrarMensagem("Não foi possível carregar uma nova piada.");
            }
        }

        protected void btnGerarPiada_Click(object sender, EventArgs e)
        {
            BuscarPiada();
        }

        private void MostrarMensagem(string mensagem)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", $"alert('{mensagem}');", true);
        }
    }
}
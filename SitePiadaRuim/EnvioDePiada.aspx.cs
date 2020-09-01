using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using SitePiadaRuim.classes;

namespace SitePiadaRuim
{
    public partial class EnvioDePiada : System.Web.UI.Page
    {
        public static string Senha = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMensagem.Text = "";

                if (!string.IsNullOrEmpty(txtPiada.Text))
                {
                    txtPiada.Text = "";
                }
            }
        }

        private void EnviarPiada() 
        {
            Solicitacao solicitacao = new Solicitacao();

            solicitacao.Piada_Data = txtPiada.Text;

            if (!solicitacao.Inserir())
            {
                MostrarMensagem("Não foi possível enviar a piada. Tente novamente mais tarde.");
            }
            else
            {
                lblMensagem.Text = "Piada enviada com sucesso!";
                txtPiada.Text = "";
            }
        }

        protected void btnEnviarPiada_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPiada.Text))
            {
                Senha = "";
                MostrarMensagem("Digite sua piada.");
            }
            else if (txtPiada.Text == "admdaspiadas") 
            {
                Senha = "admdaspiadas";
                Response.Redirect("Solicitacoes.aspx");
            }
            else
            {
                Senha = "";
                EnviarPiada();
            }
        }

        private void MostrarMensagem(string mensagem) 
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", $"alert('{mensagem}');", true);
        }
    }
}
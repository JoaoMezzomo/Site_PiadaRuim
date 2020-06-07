using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

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
            string piada = txtPiada.Text;

            string pathPiada = Server.MapPath("\\solicitacoes");

            pathPiada += "\\Piada_" + DateTime.Now.ToString("dd_MM_yyy_HH_mm_ss") + ".txt";

            bool nomeUnico = false;
            int incremento = 1;

            while (!nomeUnico)
            {
                if (!File.Exists(pathPiada))
                {
                    nomeUnico = true;
                }
                else
                {
                    pathPiada = pathPiada.Replace(".txt", "_" + incremento + ".txt");
                    incremento++;
                }
            }


            using (StreamWriter writer = File.CreateText(pathPiada))
            {
                writer.Write(piada);
            }

            lblMensagem.Text = "Piada enviada com sucesso!";
            txtPiada.Text = "";
        }

        protected void btnEnviarPiada_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPiada.Text))
            {
                Senha = "";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Digite sua piada.');", true);
            }
            else if (txtPiada.Text == "1030jwml1030jwml") 
            {
                Senha = "1030jwml1030jwml";
                Response.Redirect("Solicitacoes.aspx");
            }
            else
            {
                Senha = "";
                EnviarPiada();
            }
        }
    }
}
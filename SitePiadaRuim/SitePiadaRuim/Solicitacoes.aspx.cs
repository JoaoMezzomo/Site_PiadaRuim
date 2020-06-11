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
    public partial class Solicitacoes : System.Web.UI.Page
    {
        List<Solicitacao> Solicitacoess = new List<Solicitacao>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (EnvioDePiada.Senha != "admdaspiadas")
            {
                Response.Redirect("EnvioDePiada.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    BuscarArquivos();
                }
            }
        }

        private void BuscarArquivos() 
        {
            try
            {
                ddlSolicitacoes.Items.Clear();

                txtPiada.Text = "";

                ListItem itemZero = new ListItem();

                ddlSolicitacoes.Items.Add(itemZero);

                Solicitacoess.Clear();

                Solicitacoess = Solicitacao.Lista();

                foreach (Solicitacao solicitacaoItem in Solicitacoess)
                {
                    ListItem item = new ListItem();

                    item.Value = solicitacaoItem.Piada_Data;

                    item.Text = solicitacaoItem.ID_Data.ToString();

                    ddlSolicitacoes.Items.Add(item);
                }

                ddlSolicitacoes.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MostrarMensagem("Não foi possível buscar as solicitações de piadas.");
            }
        }

        private void Salvar() 
        {
            Piada piada = new Piada();

            piada.Piada_Data = txtPiada.Text;

            if (!piada.Inserir())
            {
                MostrarMensagem("Não foi possível salvar a piada.");
            }
        }

        private void Excluir() 
        {
            Solicitacao solicitacao = new Solicitacao();

            solicitacao.ID_Data = Convert.ToInt32(ddlSolicitacoes.SelectedItem.Text);

            if (solicitacao.Remover())
            {
                MostrarMensagem("Não foi possível excluir a piada.");
            }

            BuscarArquivos();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Salvar();

            txtPiada.Text = "Piada Cadastrada!";

            ddlSolicitacoes.SelectedIndex = 0;
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            Excluir();

            txtPiada.Text = "Piada Excluída";
        }

        protected void ddlSolicitacoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string piada = "";

            if (ddlSolicitacoes.SelectedIndex != 0)
            {
                piada = ddlSolicitacoes.SelectedValue;
            }

            txtPiada.Text = piada;
        }

        protected void btnSalvarExcluir_Click(object sender, EventArgs e)
        {
            Salvar();
            Excluir();

            txtPiada.Text = "Piada Cadastrada";
        }

        private void MostrarMensagem(string mensagem)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", $"alert('{mensagem}');", true);
        }
    }
}
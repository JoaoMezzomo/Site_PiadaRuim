using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace SitePiadaRuim
{
    public partial class Solicitacoes : System.Web.UI.Page
    {
        string PathDiretorio;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (EnvioDePiada.Senha != "1030jwml1030jwml")
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
            ddlSolicitacoes.Items.Clear();

            txtPiada.Text = "";

            PathDiretorio = Server.MapPath("\\solicitacoes");

            ListItem itemZero = new ListItem();

            ddlSolicitacoes.Items.Add(itemZero);

            if (Directory.Exists(PathDiretorio))
            {
                DirectoryInfo diretorio = new DirectoryInfo(PathDiretorio);

                FileInfo[] arquivos = diretorio.GetFiles();

                foreach (FileInfo arquivo in arquivos)
                {
                    ListItem item = new ListItem();

                    item.Value = arquivo.FullName;

                    item.Text = arquivo.Name;

                    ddlSolicitacoes.Items.Add(item);
                }
            }

            ddlSolicitacoes.SelectedIndex = 0;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            string pathArquivoPiadas = Server.MapPath("\\piadas\\Piadas.txt");

            string piada = txtPiada.Text;

            if (piada[0] == '\r' && piada[1] == '\n')
            {
                piada = piada.Remove(0, 2);
            }

            piada = "\r\n|\r\n" + piada;

            using (StreamWriter writer = File.AppendText(pathArquivoPiadas))
            {
                writer.Write(piada);
            }

            txtPiada.Text = "Piada Cadastrada!";
            ddlSolicitacoes.SelectedIndex = 0;
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            if (File.Exists(ddlSolicitacoes.SelectedValue))
            {
                File.Delete(ddlSolicitacoes.SelectedValue);
                BuscarArquivos();
            }

            txtPiada.Text = "Piada Excluída";
        }

        protected void ddlSolicitacoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string piada = "";

            if (ddlSolicitacoes.SelectedIndex != 0)
            {
                if (File.Exists(ddlSolicitacoes.SelectedValue))
                {
                    piada = File.ReadAllText(ddlSolicitacoes.SelectedValue);
                }
            }

            txtPiada.Text = piada;
        }
    }
}
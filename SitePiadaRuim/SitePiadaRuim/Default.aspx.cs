using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Services;

namespace SitePiadaRuim
{
    public partial class Default : System.Web.UI.Page
    {
        string[] Piadas;
        int Quantidade;
        int IndexPiada;

        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarInformacoes();
        }

        private void CarregarInformacoes() 
        {
            Piadas = File.ReadAllText(Server.MapPath("\\piadas\\Piadas.txt")).Split('|');

            Quantidade = Piadas.Count();

            lblQuantidade.Text = Quantidade + " piadas registradas!";
        }

        private void  BuscarPiada() 
        {
            Random random = new Random();

            IndexPiada = random.Next(Quantidade);

            string piada = Piadas[IndexPiada];

            if (piada[0] == '\r' && piada[1] == '\n')
            {
                piada = piada.Remove(0, 2);
            }

            txtPiada.Text = piada;

            txtSorteio.Text = (IndexPiada + 1).ToString();
        }

        protected void btnGerarPiada_Click(object sender, EventArgs e)
        {
            BuscarPiada();
        }
    }
}
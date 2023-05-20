using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnimeTrabalho
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack){
                AtualizarListView();
            }
        }

		private void AtualizarListView()
		{
			List<Anime> animes = AnimeDAO.listarAnimes();
			lvAnimes.DataSource = animes;
			lvAnimes.DataBind();    
		}

		/*
		private void AtualizarLvAnimes(List<Anime> animes)
		{
			lvAnimes.DataSource = animes;
			lvAnimes.DataBind();
		}
		*/

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            Anime anime = new Anime();
            {
                anime.nome = txtNome.Text;
                anime.nota = decimal.Parse(txtNota.Text);
                anime.ano = int.Parse(txtAno.Text);
                anime.qnt_ep = int.Parse(txtQntEp.Text);
                anime.sinopse = txtSinopse.Text;
            };

            AnimeDAO.Adicionar(anime);
            AtualizarListView();

            LimparCampos();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            Anime anime = new Anime
            {
                id = id,
                nome = txtNome.Text,
                nota = decimal.Parse(txtNota.Text),
                ano = int.Parse(txtAno.Text),
                qnt_ep = int.Parse(txtQntEp.Text),
                sinopse = txtSinopse.Text
            };

            AnimeDAO.Atualizar(anime);
            AtualizarListView();

            LimparCampos();
            DesabilitarEdicao();
        }

      protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            DesabilitarEdicao();
        }


        private void LimparCampos()
        {
            txtId.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtNota.Text = string.Empty;
            txtAno.Text = string.Empty;
            txtQntEp.Text = string.Empty;
            txtSinopse.Text = string.Empty;
        }

        private void HabilitarEdicao()
        {
            btnAdicionar.Enabled = false;
            btnEditar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void DesabilitarEdicao()
        {
            btnAdicionar.Enabled = true;
            btnEditar.Enabled = false;
            btnCancelar.Enabled = false;
        }


        protected void lvAnimes_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandArgument != null)
            {
                int id = Convert.ToInt32(e.CommandArgument);

                if (e.CommandName == "Delete")
                {
                    AnimeDAO.Excluir(id);
                    AtualizarListView();
                }
                else if (e.CommandName == "Update")
                {
                    Anime anime = AnimeDAO.BuscarPorId(id);
                    if (anime != null)
                    {
                        txtId.Text = anime.id.ToString();
                        txtNome.Text = anime.nome;
                        txtNota.Text = anime.nota.ToString();
                        txtAno.Text = anime.ano.ToString();
                        txtQntEp.Text = anime.qnt_ep.ToString();
                        txtSinopse.Text = anime.sinopse;

                        HabilitarEdicao();
                    }
                }
            }
        }

		protected void lvAnimes_ItemDeleting(object sender, ListViewDeleteEventArgs e)
		{
			// Nada, kkk
		}

        protected void lvAnimes_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            // Nada, kkk
        }
    }
}

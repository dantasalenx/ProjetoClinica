using System;
using BLL.Model;
using DataAccessLayer.Persistence;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace View.Pages
{
    public partial class CidadeCadastro : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMensagem.Text = "Iniciando cadastro: ";
            bindEstados();
        }


        public void btnCadastrarCidade(object sender, EventArgs e)
        {
            try
            {
                Cidade cidade = new Cidade();
                cidade.Descricao = descricao.Text;
                cidade.IdEstado = Int32.Parse(idEstado.SelectedValue);

                CidadeDal cidadeDal = new CidadeDal();
                cidadeDal.Salvar(cidade);

                idEstado.Text = "";
                descricao.Text = "";

                string msg = "Cidade " + cidade.Descricao +
                             " cadastrada com sucesso.";

                lblMensagem.Text = msg;
                lblMensagem.Attributes.CssStyle.Add("color", "green");
               

            }
            catch (Exception erro)
            {
                throw new Exception("Erro.");
            }
        }

        public void bindEstados()
        {
            EstadoDal estadoDal = new EstadoDal();
            List<Estado> listaEstado = new List<Estado>();

            listaEstado = estadoDal.Listar();

            foreach(var estado in listaEstado)
            {
                idEstado.Items.Insert(0, new ListItem(estado.Nome, estado.Id.ToString()));
            }
        }
    }
}

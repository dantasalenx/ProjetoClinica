using System;
using BLL.Model;
using DataAccessLayer.Persistence;
using System.Web;
using System.Web.UI;
namespace View.Pages
{
    public partial class EstadoCadastro : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMensagem.Text = "Iniciando cadastro: ";
        }


        protected void btnCadastrarEstado(object sender, EventArgs e)
        {
            try{
                Estado estado = new Estado();
                estado.Nome = nome.Text;
                estado.Sigla = sigla.Text;

                EstadoDal estadoDal = new EstadoDal();
                estadoDal.Salvar(estado);

                nome.Text = "";
                sigla.Text = "";

                string msg = "Estado " + estado.Nome +
                             " cadastrado com sucesso.";

                lblMensagem.Text = msg;
                lblMensagem.Attributes.CssStyle.Add("color", "green");

            }
            catch (Exception erro){
                throw new Exception("Erro.");
            }
        }
    }
}

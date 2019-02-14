using System;
using BLL.Model;
using DataAccessLayer.Persistence;
using System.Web;
using System.Web.UI;
namespace View.Pages
{
    public partial class EspecialidadeCadastro : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMensagem.Text = "Iniciando cadastro: ";
        }

                      
        protected void btnCadastrarEspecialidade(object sender, EventArgs e)
        {
            try{
                Especialidade especialidade = new Especialidade();
                especialidade.Descricao = descricao.Text;

                EspecialidadeDal especialidadeDal = new EspecialidadeDal();
                especialidadeDal.Salvar(especialidade);

                descricao.Text = "";

                string msg = "Especialidade " + especialidade.Descricao +
                             " cadastrada com sucesso.";

                lblMensagem.Text = msg;
                lblMensagem.Attributes.CssStyle.Add("color", "green");

            }
            catch (Exception erro){
                lblMensagem.Text = erro.ToString();
            }
        }
    }
}

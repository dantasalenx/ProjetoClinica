using System;
using System.Web;
using System.Web.UI;
using BLL.Model;
using DataAccessLayer.Persistence;

namespace View.Pages
{

    public partial class EspecialidadePesquisa : System.Web.UI.Page
    {
        public void btnPesquisaPorId(object sender, EventArgs e)
        {

            int id_especialidade = Int32.Parse(idEspecialidade.Text);

            lblMensagem.Text = "";

            EspecialidadeDal especialidadeDal = new EspecialidadeDal();
            Especialidade especialidade = new Especialidade();
            especialidade = especialidadeDal.PesquisarPorId(id_especialidade);


            if (especialidade.Id != 0)
            {
                nomeEspecialidade.Text = especialidade.Descricao;
            }
            else
            {
                nomeEspecialidade.Text = "";
                lblMensagem.Text = "Especialidade nao encontrado";
            }
        }
    }
}
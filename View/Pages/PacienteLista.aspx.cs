using System;
using System.Web;
using System.Web.UI;
using BLL.Model;
using DataAccessLayer.Persistence;
using System.Data;

namespace View.Pages
{

    public partial class PacienteLista : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            //PacienteDal pacienteDal = new PacienteDal();
            //gridListaPaciente.DataSource = pacienteDal.Listar();
            //gridListaPaciente.DataBind();

        }

        public void btnPesquisarPaciente(object sender, EventArgs e)
        {
            string nomePaciente = nome.Text;
            PacienteDal pacienteDal = new PacienteDal();

            gridListaPaciente.DataSource = pacienteDal.ListarPorNome(nomePaciente);
            gridListaPaciente.DataBind();
        }
    }
}
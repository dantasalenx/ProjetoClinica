using System;
using BLL.Model;
using DataAccessLayer.Persistence;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace View.Pages
{
    public partial class MedicoCadastro : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMensagem.Text = "Iniciando cadastro: ";
            bindEspecialidade();
        }


        public void btnCadastrarMedico(object sender, EventArgs e)
        {
            try
            {
                Medico medico = new Medico();
                medico.Nome = nome.Text;
                medico.IdEspecialidade = Int32.Parse(idEspecialidade.SelectedValue);
                medico.CRM = crm.Text;

                MedicoDal medicoDal = new MedicoDal();
                medicoDal.Salvar(medico);

                idEspecialidade.Text = "";
                nome.Text = "";
                crm.Text = "";

                string msg = "Medico " + medico.Nome +
                             " cadastrado com sucesso.";

                lblMensagem.Text = msg;
                lblMensagem.Attributes.CssStyle.Add("color", "green");


            }
            catch (Exception erro)
            {
                throw new Exception("Erro.");
            }
        }

        public void bindEspecialidade()
        {
            EspecialidadeDal especialidadeDal = new EspecialidadeDal();
            List<Especialidade> listaEspecialidade = new List<Especialidade>();

            listaEspecialidade = especialidadeDal.Listar();

            foreach (var especialidade in listaEspecialidade)
            {
                idEspecialidade.Items.Insert(0, new ListItem(especialidade.Descricao, especialidade.Id.ToString()));
            }
        }
    }
}

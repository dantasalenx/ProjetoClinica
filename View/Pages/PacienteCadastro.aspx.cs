using System;
using BLL.Model;
using DataAccessLayer.Persistence;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace View.Pages
{
    public partial class PacienteCadastro : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMensagem.Text = "Iniciando cadastro: ";
            bindCidade();
        }


        public void btnCadastrarPaciente(object sender, EventArgs e)
        {
            try
            {
                Paciente paciente = new Paciente();
                paciente.Nome = nome.Text;
                paciente.IdCidade = Int32.Parse(idCidade.SelectedValue);

                PacienteDal pacienteDal = new PacienteDal();
                pacienteDal.Salvar(paciente);

                idCidade.Text = "";
                nome.Text = "";

                string msg = "Paciente " + paciente.Nome +
                             " cadastrado com sucesso.";

                lblMensagem.Text = msg;
                lblMensagem.Attributes.CssStyle.Add("color", "green");


            }
            catch (Exception erro)
            {
                lblMensagem.Text = erro.ToString();
            }
        }

        public void bindCidade()
        {
            CidadeDal cidadeDal = new CidadeDal();
            List<Cidade> listaCidade = new List<Cidade>();

            listaCidade = cidadeDal.Listar();

            foreach (var cidade in listaCidade)
            {
                idCidade.Items.Insert(0, new ListItem(cidade.Descricao, cidade.Id.ToString()));
            }
        }
    }
}

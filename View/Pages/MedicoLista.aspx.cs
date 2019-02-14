﻿using System;
using System.Web;
using System.Web.UI;
using BLL.Model;
using DataAccessLayer.Persistence;
using System.Data;

namespace View.Pages
{

    public partial class MedicoLista : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            //MedicoDal medicoDal = new MedicoDal();
            //gridListaMedico.DataSource = medicoDal.Listar();
            //gridListaMedico.DataBind();

        }

        public void btnPesquisarMedico(object sender, EventArgs e)
        {
            string nomeMedico = nome.Text;
            MedicoDal medicoDal = new MedicoDal();

            gridListaMedico.DataSource = medicoDal.ListarPorNome(nomeMedico);
            gridListaMedico.DataBind();
        }
    }
}
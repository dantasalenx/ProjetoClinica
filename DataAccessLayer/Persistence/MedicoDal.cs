using System;
using MySql.Data.MySqlClient;
using BLL.Model;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer.Persistence
{
    public class MedicoDal : Conexao
    {
        public void Salvar(Medico medico)
        {
            try
            {
                var sql = "INSERT INTO medico(idEspecialidade, nome, crm, dtCadastro)" +
                          "VALUES (@idEspecialidade, @nome, @crm, CURRENT_TIMESTAMP())";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idEspecialidade", medico.IdEspecialidade);
                command.Parameters.AddWithValue("@nome", medico.Nome);
                command.Parameters.AddWithValue("@crm", medico.CRM);

                command.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao registrar dado." + erro.Message + erro.ToString());
            }
            finally
            {
            }
        }

        public List<Medico> Listar()
        {
            try
            {
                var sql = "SELECT * FROM medico";
                command = new MySqlCommand(sql, connection);
                dataReader = command.ExecuteReader();

                List<Medico> listaMedico = new List<Medico>();

                while (dataReader.Read())
                {
                    Medico medico = new Medico();
                    medico.Id = Convert.ToInt32(dataReader["id"]);
                    medico.Nome = dataReader["nome"].ToString();
                    medico.CRM = dataReader["crm"].ToString();
                    medico.DtCadastro = dataReader["dtCadastro"].ToString();
                }

                return listaMedico;

            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao registrar dado." + erro.Message + erro.ToString());
            }
            finally
            {
            }
        }

        public DataTable ListarPorNome(string nome)
        {
            try
            {
                var sql = "SELECT * FROM medico WHERE nome LIKE '%" + @nome + "%' ";
                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@nome", nome);
                dataReader = command.ExecuteReader();

                List<Medico> listaMedico = new List<Medico>();
                List<Especialidade> listaEspecialidade = new List<Especialidade>();

                while (dataReader.Read())
                {
                    Medico medico = new Medico();
                    EspecialidadeDal especialidadeDal = new EspecialidadeDal();

                    medico.Id = Convert.ToInt32(dataReader["id"]);
                    medico.IdEspecialidade = Convert.ToInt32(dataReader["idEspecialidade"]);

                    medico.Especialidade = especialidadeDal.PesquisarPorId(medico.IdEspecialidade);

                    medico.Nome = dataReader["nome"].ToString();
                    medico.CRM = dataReader["crm"].ToString();
                    medico.DtCadastro = dataReader["dtCadastro"].ToString();

                    listaMedico.Add(medico);
                }

                DataTable dataTable = new DataTable();

                dataTable.Columns.Add("idMedico");
                dataTable.Columns.Add("medico");
                dataTable.Columns.Add("especialidade");
                dataTable.Columns.Add("crm");

                foreach (var medico in listaMedico)
                {
                    dataTable.Rows.Add(medico.Id, medico.Nome, medico.Especialidade.Descricao, medico.CRM);
                }

                return dataTable;

            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao registrar dado." + erro.Message + erro.ToString());
            }
            finally
            {
            }
        }

        public MedicoDal()
        {
        }


    }
}

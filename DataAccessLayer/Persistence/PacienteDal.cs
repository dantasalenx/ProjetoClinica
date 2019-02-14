using System;
using MySql.Data.MySqlClient;
using BLL.Model;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer.Persistence
{
    public class PacienteDal : Conexao
    {
        public void Salvar(Paciente paciente)
        {
            try
            {
                var sql = "INSERT INTO paciente(idCidade, nome, dtCadastro)" +
                          "VALUES (@idCidade, @nome, CURRENT_TIMESTAMP())";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idCidade", paciente.IdCidade);
                command.Parameters.AddWithValue("@nome", paciente.Nome);

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

        public List<Paciente> Listar()
        {
            try
            {
                var sql = "SELECT * FROM paciente";
                command = new MySqlCommand(sql, connection);
                dataReader = command.ExecuteReader();

                List<Paciente> listaPaciente = new List<Paciente>();

                while (dataReader.Read())
                {
                    Paciente paciente = new Paciente();
                    paciente.Id = Convert.ToInt32(dataReader["id"]);
                    paciente.Nome = dataReader["nome"].ToString();
                    paciente.DtCadastro = dataReader["dtCadastro"].ToString();

                    listaPaciente.Add(paciente);
                }

                return listaPaciente;

            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao registrar dado." + erro.Message + erro.ToString());
            }
            finally
            {
            }
        }

        public PacienteDal()
        {
        }

        public DataTable ListarPorNome(string nome)
        {
            try
            {
                var sql = "SELECT * FROM paciente WHERE nome LIKE '%" + @nome + "%' ";
                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@nome", nome);
                dataReader = command.ExecuteReader();

                List<Paciente> listaPaciente = new List<Paciente>();
                List<Cidade> listaCidade = new List<Cidade>();

                while (dataReader.Read())
                {
                    Paciente paciente = new Paciente();
                    CidadeDal cidadeDal = new CidadeDal();

                    paciente.Id = Convert.ToInt32(dataReader["id"]);
                    paciente.IdCidade = Convert.ToInt32(dataReader["idCidade"]);

                    paciente.Cidade = cidadeDal.PesquisarPorId(paciente.IdCidade);

                    paciente.Nome = dataReader["nome"].ToString();
                    paciente.DtCadastro = dataReader["dtCadastro"].ToString();

                    listaPaciente.Add(paciente);
                }

                DataTable dataTable = new DataTable();

                dataTable.Columns.Add("idPaciente");
                dataTable.Columns.Add("paciente");
                dataTable.Columns.Add("cidade");

                foreach (var paciente in listaPaciente)
                {
                    dataTable.Rows.Add(paciente.Id, paciente.Nome, paciente.Cidade.Descricao);
                }

                return dataTable;

            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao registrar dado." + erro.Message + erro.ToString());
            }
        }
    }
}

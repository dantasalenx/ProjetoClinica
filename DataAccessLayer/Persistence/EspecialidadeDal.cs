﻿using System;
using MySql.Data.MySqlClient;
using BLL.Model;
using System.Collections.Generic;

namespace DataAccessLayer.Persistence
{
    public class EspecialidadeDal : Conexao
    {
        public void Salvar(Especialidade especialidade)
        {
            try
            {
                var sql = "INSERT INTO especialidade(descricao, dtCadastro)" +
                          "VALUES (@descricao, CURRENT_TIMESTAMP())";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@descricao", especialidade.Descricao);
                command.Parameters.AddWithValue("@dtCadastro", especialidade.DtCadastro);
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

        public List<Especialidade> Listar()
        {
            try
            {
                var sql = "SELECT * FROM especialidade";
                command = new MySqlCommand(sql, connection);
                dataReader = command.ExecuteReader();

                List<Especialidade> listaEspecialidade = new List<Especialidade>();

                while (dataReader.Read())
                {
                    Especialidade especialidade = new Especialidade();
                    especialidade.Id = Convert.ToInt32(dataReader["id"]);
                    especialidade.Descricao = dataReader["descricao"].ToString();
                    especialidade.DtCadastro = dataReader["dtCadastro"].ToString();

                    listaEspecialidade.Add(especialidade);
                }


                return listaEspecialidade;

            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao registrar dado." + erro.Message + erro.ToString());
            }
            finally
            {
            }
        }

        public List<Especialidade> ListarPorNome(string descricao)
        {
            try
            {
                var sql = "SELECT * FROM especialidade WHERE descricao LIKE '%" + @descricao + "%' ";
                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@descricao", descricao);
                dataReader = command.ExecuteReader();

                List<Especialidade> listaEspecialidade = new List<Especialidade>();

                while (dataReader.Read())
                {
                    Especialidade especialidade = new Especialidade();
                    especialidade.Id = Convert.ToInt32(dataReader["id"]);
                    especialidade.Descricao = dataReader["descricao"].ToString();
                    especialidade.DtCadastro = dataReader["dtCadastro"].ToString();

                    listaEspecialidade.Add(especialidade);
                }

                return listaEspecialidade;

            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao registrar dado." + erro.Message + erro.ToString());
            }
            finally
            {
            }
        }

        public Especialidade PesquisarPorId(int id)
        {
            try
            {
                var sql = "SELECT * FROM especialidade WHERE id = @id";
                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                dataReader = command.ExecuteReader();

                Especialidade especialidade = new Especialidade();

                if (dataReader.Read())
                {
                    especialidade.Id = Convert.ToInt32(dataReader["id"]);
                    especialidade.Descricao = dataReader["descricao"].ToString();
                }
                return especialidade;
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao consultar dado " + erro.Message + erro.ToString());
            }
            finally
            {
            }
        }

        public EspecialidadeDal()
        {
        }
    }
}

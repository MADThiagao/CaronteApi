using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using CaronteCore.Models;
using CaronteCore.Models.DTO;
using CaronteApi.Interfaces;
using CaronteCore.Models.Enum;
using CaronteCore.Utils;


namespace CaronteApi.Repository
{
    public class UsuarioRepository : IUsuarioRepository

    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["Conexao"].ConnectionString;

        public void Adicionar(Usuario entidade)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Usuario entidade)
        {
            throw new NotImplementedException();
        }

        public Usuario Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> BuscarTodos(int id)
        {
            throw new NotImplementedException();
        }

        public void Remover(Usuario entidade)
        {
            throw new NotImplementedException();
        }

        public Usuario Logar(LoginDTO login)
        {
            try
            {
                using (SqlConnection conexao = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("usp_UsuarioLogar", conexao))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Login", login.Login);
                    cmd.Parameters.AddWithValue("@Senha", login.Senha);

                    conexao.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                        if (reader.HasRows)
                            while (reader.Read())
                            {
                                return new Usuario()
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("IdUsuario")),
                                    Nome = reader.GetString(reader.GetOrdinal("Nome")),
                                    Login = reader.GetString(reader.GetOrdinal("Login")),
                                    Senha = reader.GetString(reader.GetOrdinal("Senha")),
                                    DataCriacao = reader.GetDateTime(reader.GetOrdinal("DataCriacao")),
                                    DataAlteracao = MetodoExtensao.BuscarValor<DateTime>(reader, "DataAlteracao"),
                                    Status = reader.GetString(reader.GetOrdinal("Status"))
                                };
                            }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using CaronteCore.Models;
using CaronteApi.Interfaces;
using CaronteCore.Utils;
using CaronteCore.Models.DTO;

namespace CaronteApi.Repository
{
    public class LancamentoRepository : ILancamentoRepository
    {

        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["Conexao"].ConnectionString;

        public void Adicionar(Lancamento entidade)
        {
            using (SqlConnection conexao = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("usp_LancamentoAdicionar", conexao) { CommandType = CommandType.StoredProcedure })
            {

                cmd.Parameters.AddWithValue("@IdUsuario", entidade.IdUsuario);

                if (entidade.IdCategoria != null)
                    cmd.Parameters.AddWithValue("@IdCategoria", entidade.IdCategoria);
                cmd.Parameters.AddWithValue("@Descricao", entidade.Descricao);
                cmd.Parameters.AddWithValue("@Tipo", entidade.Tipo);
                cmd.Parameters.AddWithValue("@Valor", entidade.Valor);
                cmd.Parameters.AddWithValue("@Data", entidade.Data);

                try
                {
                    conexao.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    throw;
                }
            }
        }

        public void Atualizar(Lancamento entidade)
        {
            using (SqlConnection conexao = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("usp_LancamentoAtualizar", conexao) { CommandType = CommandType.StoredProcedure })
            {

                cmd.Parameters.AddWithValue("@IdLancamento", entidade.Id);
                cmd.Parameters.AddWithValue("@IdUsuario", entidade.IdUsuario);
                if (entidade.IdCategoria != null)
                    cmd.Parameters.AddWithValue("@IdCategoria", entidade.IdCategoria);
                cmd.Parameters.AddWithValue("@Descricao", entidade.Descricao);
                cmd.Parameters.AddWithValue("@Tipo", entidade.Tipo);
                cmd.Parameters.AddWithValue("@Valor", entidade.Valor);
                cmd.Parameters.AddWithValue("@Data", entidade.Data);

                try
                {
                    conexao.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    throw;
                }
            }
        }

        public Lancamento Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Lancamento> BuscarTodos(int id)
        {
            List<Lancamento> lista = new List<Lancamento>();
            try
            {
                using (SqlConnection conexao = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("usp_LancamentoBuscarTodos", conexao) { CommandType = CommandType.StoredProcedure })
                {
                    cmd.Parameters.AddWithValue("@IdUsuario", id);

                    conexao.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                        if (reader.HasRows)
                            while (reader.Read())
                            {
                                lista.Add(new Lancamento()
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Idlancamento")),
                                    IdCategoria = MetodoExtensao.BuscarValor<int>(reader, "IdCategoria"),
                                    IdUsuario = reader.GetInt32(reader.GetOrdinal("IdUsuario")),
                                    Descricao = reader.GetString(reader.GetOrdinal("Descricao")),
                                    Tipo = reader.GetString(reader.GetOrdinal("Tipo")),
                                    Valor = reader.GetDecimal(reader.GetOrdinal("Valor")),
                                    Data = reader.GetDateTime(reader.GetOrdinal("Data")),
                                    Status = reader.GetString(reader.GetOrdinal("Status"))
                                });
                            }
                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return lista;
        }

        public void Remover(Lancamento entidade)
        {
            using (SqlConnection conexao = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("usp_LancamentoRemover", conexao) { CommandType = CommandType.StoredProcedure })
            {

                cmd.Parameters.AddWithValue("@IdUsuario", entidade.IdUsuario);
                cmd.Parameters.AddWithValue("@IdLancamento", entidade.Id);

                try
                {
                    conexao.Open();
                    cmd.ExecuteReader();
                }
                catch (SqlException)
                {
                    throw;
                }
            }
        }

        public List<GraficoLinhaDTO> GraficoLinha(int IdUsuario)
        {

            List<GraficoLinhaDTO> lista = new List<GraficoLinhaDTO>();

            try
            {
                using (SqlConnection conexao = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("usp_LancamentoGraficoLinha", conexao) { CommandType = CommandType.StoredProcedure })
                {
                    cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);

                    conexao.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                        if (reader.HasRows)
                            while (reader.Read())
                            {
                                lista.Add(new GraficoLinhaDTO()
                                {
                                    Dia = reader.GetInt32(reader.GetOrdinal("Dia")),
                                    ValorAtual = MetodoExtensao.BuscarValor<decimal>(reader, "ValorAtual"),
                                    ValorProjecao = MetodoExtensao.BuscarValor<decimal>(reader, "ValorProjecao")
                                });
                            }
                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return lista;

        }

        public List<GraficoDonutDTO> GraficoDonut(int IdUsuario)
        {
            List<GraficoDonutDTO> lista = new List<GraficoDonutDTO>();

            try
            {
                using (SqlConnection conexao = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("usp_LancamentoGraficoDonuts", conexao) { CommandType = CommandType.StoredProcedure })
                {
                    cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);

                    conexao.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                        if (reader.HasRows)
                            while (reader.Read())
                            {
                                lista.Add(new GraficoDonutDTO()
                                {
                                    CategoriaId = reader.GetInt32(reader.GetOrdinal("Id")),
                                    CategoriaDescricao = reader.GetString(reader.GetOrdinal("Descricao")),
                                    Total = MetodoExtensao.BuscarValor<decimal>(reader, "Total")
                                });
                            }
                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return lista;
        }

        public List<Lancamento> BuscarMensal(int IdUsuario)
        {
            List<Lancamento> lista = new List<Lancamento>();
            try
            {
                using (SqlConnection conexao = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("usp_LancamentoBuscarMensal", conexao) { CommandType = CommandType.StoredProcedure })
                {
                    cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);

                    conexao.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                        if (reader.HasRows)
                            while (reader.Read())
                            {
                                lista.Add(new Lancamento()
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Idlancamento")),
                                    IdCategoria = MetodoExtensao.BuscarValor<int>(reader, "IdCategoria"),
                                    IdUsuario = reader.GetInt32(reader.GetOrdinal("IdUsuario")),
                                    Descricao = reader.GetString(reader.GetOrdinal("Descricao")),
                                    Tipo = reader.GetString(reader.GetOrdinal("Tipo")),
                                    Valor = reader.GetDecimal(reader.GetOrdinal("Valor")),
                                    Data = reader.GetDateTime(reader.GetOrdinal("Data")),
                                    Status = reader.GetString(reader.GetOrdinal("Status"))
                                });
                            }
                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return lista;
        }
    }

    /*
public IEnumerable<LancamentoDTO> Select(LancamentoSelectDTO lancamentoSelectDTO)
{
List<LancamentoDTO> lancamentos = new List<LancamentoDTO>();

SqlConnection conexao = new SqlConnection(_connectionString);
SqlCommand sql = new SqlCommand(Resource.LancamentoResource.SelectLancamento, conexao);
sql.Parameters.AddWithValue("@IdUsuario", lancamentoSelectDTO.IdUsuario);
sql.Parameters.AddWithValue("@dataini", lancamentoSelectDTO.Dataini.ToString("yyyy-MM-dd"));
sql.Parameters.AddWithValue("@datafim", lancamentoSelectDTO.Datafim.ToString("yyyy-MM-dd"));


try
{
   conexao.Open();
   SqlDataReader reader = sql.ExecuteReader(CommandBehavior.CloseConnection);

   if (reader.HasRows)
       while (reader.Read())
       {
           lancamentos.Add(
               new LancamentoDTO
               {
                   IdLancamento = (int)reader["IdLancamento"],
                   Valor = Convert.ToDecimal(reader["Valor"]),
                   Tipo = Convert.ToChar(reader["Tipo"]),
                   Data = Convert.ToDateTime(reader["Data"]),
                   Descricao = Convert.ToString(reader["Descricao"])
               }
           );
       }
   else
       lancamentos = null;

}
catch (SqlException)
{
   throw;
}
finally
{
   conexao.Close();
}

return lancamentos;
}


public string Insert(LancamentoInserirDTO lancamento)
{
string resultado = null;

SqlConnection conexao = new SqlConnection(_connectionString);

conexao.Open();
SqlTransaction transacao = conexao.BeginTransaction(IsolationLevel.ReadCommitted);

try
{
   SqlCommand sql = new SqlCommand(Resource.LancamentoResource.InsereLancamento, conexao, transacao);
   sql.Parameters.AddWithValue("@IdUsuario", lancamento.usuarioDTO.IdUsuario);
   sql.Parameters.AddWithValue("@Valor", lancamento.Valor);
   sql.Parameters.AddWithValue("@Tipo", lancamento.Tipo);
   sql.Parameters.AddWithValue("@Data", lancamento.Data.ToString("yyyy-MM-dd"));//Convert.ToDateTime(lancamento.Data));
   sql.Parameters.AddWithValue("@Descricao", lancamento.Descricao);
   sql.Parameters.AddWithValue("@IdCategoria", lancamento.IdCategoria);
   sql.ExecuteNonQuery();
   transacao.Commit();
   resultado = "sucesso";
}
catch (SqlException)
{
   transacao.Rollback();
   throw;
}
finally
{
   conexao.Close();
}

return resultado;
}

public string Update(LancamentoInserirDTO lancamento)
{
string resultado = null;

SqlConnection conexao = new SqlConnection(_connectionString);

conexao.Open();
SqlTransaction transacao = conexao.BeginTransaction(IsolationLevel.ReadCommitted);

try
{
   SqlCommand sql = new SqlCommand(Resource.LancamentoResource.UpdateLancamento, conexao, transacao);
   sql.Parameters.AddWithValue("@IdLancamento", lancamento.IdLancamento);
   sql.Parameters.AddWithValue("@Valor", lancamento.Valor);
   sql.Parameters.AddWithValue("@Tipo", lancamento.Tipo);
   sql.Parameters.AddWithValue("@Data", lancamento.Data.ToString("yyyy-MM-dd"));
   sql.Parameters.AddWithValue("@Descricao", lancamento.Descricao);
   sql.Parameters.AddWithValue("@IdCategoria", lancamento.IdCategoria);
   sql.Parameters.AddWithValue("@IdUsuario", lancamento.usuarioDTO.IdUsuario);
   sql.ExecuteNonQuery();
   transacao.Commit();
   resultado = "sucesso";
}
catch (SqlException)
{
   transacao.Rollback();
   throw;
}
finally
{
   conexao.Close();
}

return resultado;
}

public string Delete(LancamentoDTO lancamento)
{

string resultado = null;

SqlConnection conexao = new SqlConnection(_connectionString);

conexao.Open();
SqlTransaction transacao = conexao.BeginTransaction(IsolationLevel.ReadCommitted);

try
{
   SqlCommand sql = new SqlCommand(Resource.LancamentoResource.DeleteLancamento, conexao, transacao);
   sql.Parameters.AddWithValue("@IdLancamento", lancamento.IdLancamento);
   sql.ExecuteNonQuery();
   transacao.Commit();
   resultado = "sucesso";
}
catch (SqlException)
{
   transacao.Rollback();
   throw;
}
finally
{
   conexao.Close();
}

return resultado;
}

public LancamentoInserirDTO SelectEdit(int Idlancamento)
{
LancamentoInserirDTO lancamento = null;

SqlConnection conexao = new SqlConnection(_connectionString);
SqlCommand sql = new SqlCommand(Resource.LancamentoResource.SelectOneLancamento, conexao);
sql.Parameters.AddWithValue("@IdLancamento", Idlancamento);

try
{
   conexao.Open();
   SqlDataReader reader = sql.ExecuteReader(CommandBehavior.CloseConnection);

   if (reader.HasRows)
       while (reader.Read())
       {
           lancamento = new LancamentoInserirDTO
           {
               IdLancamento = Convert.ToInt32(reader["IdLancamento"]),
               IdCategoria = reader["IdCategoria"] == null ? Convert.ToInt32(reader["IdCategoria"]) : 1,
               Valor = Convert.ToDecimal(reader["Valor"]),
               Tipo = Convert.ToChar(reader["Tipo"]),
               Data = Convert.ToDateTime(reader["Data"]),
               Descricao = Convert.ToString(reader["Descricao"])
           };

       }
}
catch (SqlException)
{
   throw;
}
finally
{
   conexao.Close();
}

return lancamento;
}*/
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using CaronteApi.Interfaces;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using CaronteCore.Models;

namespace CaronteApi.Repository
{

    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["Conexao"].ConnectionString;

        public void Adicionar(Categoria entidade)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Categoria entidade)
        {
            throw new NotImplementedException();
        }

        public Categoria Buscar(int id)
        {
            throw new NotImplementedException();
        }

        

        public IEnumerable<Categoria> BuscarTodos(int id)
        {
            throw new NotImplementedException();
        }

        public Categoria Remover(int id)
        {
            throw new NotImplementedException();
        }


        /*
       public void Delete(CategoriaDTO categoria)
       {

           using (SqlConnection conexao = new SqlConnection(_connectionString))

           using (SqlCommand cmd = new SqlCommand("usp_CategoriaDelete", conexao))
           {
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@IdCategoria", categoria.IdCategoria);

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

       public void Insert(CategoriaDTO categoria)
       {
           using (SqlConnection conexao = new SqlConnection(_connectionString))

           using (SqlCommand cmd = new SqlCommand("usp_CategoriaInsert", conexao))
           {
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@Descricao", categoria.Descricao);
               cmd.Parameters.AddWithValue("@IdUsuario", categoria.IdUsuario);

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

       public IEnumerable<CategoriaDTO> Select(int IdUsuario)
       {
           List<CategoriaDTO> listaCategorias = new List<CategoriaDTO>();

           try
           {
               using (SqlConnection conexao = new SqlConnection(_connectionString))
               {
                   using (SqlCommand cmd = new SqlCommand("usp_CategoriaSelectPorUsuario", conexao))
                   {
                       cmd.CommandType = CommandType.StoredProcedure;
                       cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);

                       conexao.Open();

                       using (SqlDataReader reader = cmd.ExecuteReader())
                       {
                           if (reader.HasRows)
                               while (reader.Read())
                               {
                                   listaCategorias.Add(
                                       new CategoriaDTO
                                       {
                                           IdCategoria = reader.GetInt32(reader.GetOrdinal("IdCategoria")),
                                           Descricao = reader.GetString(reader.GetOrdinal("Descricao")),
                                           IdUsuario = IdUsuario
                                       });
                               }
                       }
                   }
               }

           }
           catch (SqlException)
           {
               throw;
           }

           return listaCategorias;
       }

       public CategoriaDTO SelectOne(int IdCategoria)
       {

           CategoriaDTO categoriaSelectDTO = null;

           try
           {
               using (SqlConnection conexao = new SqlConnection(_connectionString))
               {
                   using (SqlCommand cmd = new SqlCommand("usp_CategoriaSelectOne", conexao))
                   {
                       cmd.CommandType = CommandType.StoredProcedure;
                       cmd.Parameters.AddWithValue("@IdCategoria", IdCategoria);

                       conexao.Open();

                       using (SqlDataReader reader = cmd.ExecuteReader())
                       {
                           if (reader.HasRows)
                               while (reader.Read())
                               {
                                   categoriaSelectDTO = new CategoriaDTO()
                                   {
                                       IdCategoria = reader.GetInt32(reader.GetOrdinal("IdCategoria")),
                                       Descricao = reader.GetString(reader.GetOrdinal("Descricao"))
                                   };
                               }
                       }
                   }
               }

           }
           catch (SqlException)
           {
               throw;
           }

           return categoriaSelectDTO;
       }

       public void Update(CategoriaDTO categoria)
       {
           using (SqlConnection conexao = new SqlConnection(_connectionString))

           using (SqlCommand cmd = new SqlCommand("usp_CategoriaUpdate", conexao))
           {
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@IdCategoria", categoria.IdCategoria);
               cmd.Parameters.AddWithValue("@Descricao", categoria.Descricao);
               cmd.Parameters.AddWithValue("@IdUsuario", categoria.IdUsuario);

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


       public IEnumerable<CategoriaDTO> SelectEx(int IdUsuario)
       {
           List<CategoriaDTO> listaCategorias = new List<CategoriaDTO>();

           try
           {
               using (SqlConnection conexao = new SqlConnection(_connectionString))
                   using (SqlCommand cmd = new SqlCommand("usp_CategoriaSelectEx", conexao))
                   {
                       cmd.CommandType = CommandType.StoredProcedure;
                       cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);

                       conexao.Open();

                       using (SqlDataReader reader = cmd.ExecuteReader())
                           if (reader.HasRows)
                               while (reader.Read())
                               {
                                   listaCategorias.Add(
                                       new CategoriaDTO
                                       {
                                           IdCategoria = reader.GetInt32(reader.GetOrdinal("IdCategoria")),
                                           Descricao = reader.GetString(reader.GetOrdinal("Descricao")),
                                           IdUsuario = IdUsuario
                                       });
                               }
                   }
           }
           catch (SqlException)
           {
               throw;
           }

           return listaCategorias;
       }*/
    }
}
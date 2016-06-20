using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CaronteApi.Interfaces;
using CaronteApi.Repository;
using CaronteCore.Models;

namespace CaronteApi.Controllers
{
    public class CategoriaController : ApiController
    {
        private ICategoriaRepository repository = null;

        public CategoriaController()
        {
            this.repository = new CategoriaRepository();
        }

        public CategoriaController(ICategoriaRepository repository)
        {
            this.repository = repository;
        }


        [HttpGet]
        [Route("api/Categoria/{IdUsuario}/BuscarTodos")]
        public IHttpActionResult BuscarTodos(int IdUsuario)
        {
            IEnumerable<Categoria> lista = repository.BuscarTodos(IdUsuario);
            if (lista == null)
                return NotFound();

            return Ok(lista);
        }

        [HttpPost]
        [Route("api/Categoria/Adicionar")]
        public void Adicionar(Categoria categoria)
        {
            repository.Adicionar(categoria);
        }

        [HttpPost]
        [Route("api/Categoria/Remover")]
        public void Remover(Categoria categoria)
        {
            repository.Remover(categoria);
        }

        [HttpPost]
        [Route("api/Categoria/Atualizar")]
        public void Atualizar(Categoria categoria)
        {
            repository.Atualizar(categoria);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CaronteApi.Interfaces;
using CaronteApi.Repository;

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
        /*
        [HttpPost]
        [Route("api/Categoria/select")]
        public IHttpActionResult SelecionaCategorias(UsuarioDTO Usuario)
        {
            IEnumerable<CategoriaDTO> listaDeCategorias = repository.Select(Usuario.IdUsuario);
            if (listaDeCategorias.Equals(0))
                return NotFound();

            return Ok(listaDeCategorias);
        }


        [HttpGet]
        [Route("api/Categoria/{IdCategoria}")]
        public IHttpActionResult SelectOneCategoria(int IdCategoria)
        {
            var categoria = repository.SelectOne(IdCategoria);
            if (categoria == null)
                return NotFound();

            return Ok(categoria);
        }

        [HttpPost]
        public IHttpActionResult InsertCategoria(CategoriaDTO categoria)
        {
            repository.Insert(categoria);

            return Ok();
        }

        [HttpPost]
        [Route("api/Categoria/delete")]
        public IHttpActionResult DeleteCategoria(CategoriaDTO categoria)
        {
            repository.Delete(categoria);

            return Ok();
        }

        [HttpPost]
        [Route("api/Categoria/update")]
        public IHttpActionResult updateCategoria(CategoriaDTO categoria)
        {
            repository.Update(categoria);

            return Ok();
        }

        [HttpPost]
        [Route("api/Categoria/select/Ex")]
        public IHttpActionResult SelecionaCategoriasEx(UsuarioDTO Usuario)
        {
            IEnumerable<CategoriaDTO> listaDeCategorias = repository.SelectEx(Usuario.IdUsuario);
            if (listaDeCategorias.Equals(0))
                return NotFound();

            return Ok(listaDeCategorias);
        }
        */
    }
}

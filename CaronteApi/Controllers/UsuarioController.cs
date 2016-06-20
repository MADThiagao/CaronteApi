using CaronteCore.Models;
using CaronteCore.Models.DTO;
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
    public class UsuarioController : ApiController
    {

        private IUsuarioRepository repository = null;

        public UsuarioController() 
        {
            this.repository = new UsuarioRepository();
        }

        public UsuarioController(IUsuarioRepository repository)
        {
            this.repository = repository;
        }

        [Route("api/usuario/Logar")]
        [HttpPost]
        public IHttpActionResult Logar(LoginDTO login)
        {

            Usuario usuario = repository.Logar(login);
            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }



    }
}

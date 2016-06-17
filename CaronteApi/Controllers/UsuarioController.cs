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



        /* [Route("id:int")]
         public IHttpActionResult getUsuario(int id)
         {
             var usuario = repository.GetById(id);
             if (usuario == null)
                 return NotFound();

             return Ok(usuario);
         }

        [Route("api/usuario")]
        public IEnumerable<Usuario> getAllUsuarios()
        {
            var usuarios = repository.GetAll();

            return usuarios;
        }*/

        /*[Route("api/usuario/autoriza/{login}_{senha}")]
        public IHttpActionResult getValidaUsuario(string login, string senha)
        {
            var usuario = repository.ValidaAutorizacao(login, senha);
            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }*/

        /*   [Route("api/usuario/autoriza/{login}_{senha}")]
           //public IHttpActionResult getValidaUsuario(UsuarioValidaDTO usuario)
           public IHttpActionResult getValidaUsuario(string login, string senha)
           {
               UsuarioLoginDTO teste = new UsuarioLoginDTO()
               {
                   Login = login,
                   Senha = senha
               };

              var usuario = repository.UsuarioLogin(teste);
              if (usuario == null)
                  return NotFound();

              return Ok(usuario);
          }*/




        /*[Route("api/usuario/login/{login}")]
        public bool getValidaLogin(string login)
        {
            var existe = repository.validaLogin(login);

            return existe;
        }*/

        /* [HttpPost]
         //[Route("api/usuario/salvar/{usuario}")]
         public IHttpActionResult postInsereUsuario(Usuario usuario)
         {
             var resultado = repository.Insert(usuario);
             if (resultado == null)
                 return NotFound();           

             return Ok(resultado);
         }*/


    }
}

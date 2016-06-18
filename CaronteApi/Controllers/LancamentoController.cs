using System.Collections.Generic;
using System.Web.Http;
using CaronteApi.Interfaces;
using CaronteApi.Repository;
using CaronteCore.Models;
using CaronteCore.Models.DTO;

namespace CaronteApi.Controllers
{
    public class LancamentoController : ApiController
    {

        private ILancamentoRepository repository = null;

        public LancamentoController()
        {
            this.repository = new LancamentoRepository();
        }

        public LancamentoController(ILancamentoRepository repository)
        {
            this.repository = repository;
        }

        //[Route("api/Lancamento/{IdUsuario}/BuscarTodos/{Id}")]
        //public IHttpActionResult BuscarTodos(int IdUsuario, int Id)

        [HttpGet]
        [Route("api/Lancamento/{IdUsuario}/BuscarTodos")]
        public IHttpActionResult BuscarTodos(int IdUsuario)
        {
            IEnumerable<Lancamento> lista = repository.BuscarTodos(IdUsuario);
            if (lista == null)
                return NotFound();

            return Ok(lista);
        }

        [HttpGet]
        [Route("api/Lancamento/{IdUsuario}/Buscar/{Id}")]
        public IHttpActionResult Buscar(int IdUsuario, int Id)
        {
            Lancamento lancamento = repository.Buscar(Id);
            if (lancamento == null)
                return NotFound();

            return Ok(lancamento);
        }

        [HttpPost]
        [Route("api/Lancamento/Adicionar")]
        public void Adicionar(Lancamento lancamento)
        {
            repository.Adicionar(lancamento);
        }

        [HttpPost]
        [Route("api/Lancamento/RecuperarGraficoLinha")]
        public List<GraficoLinhaDTO> RecuperarGraficoLinha(Usuario usuario)
        {
            return repository.GraficoLinha(usuario.Id);
        }


        /*
        private ILancamentoRepository repository = null;

        public LancamentoController() 
        {
            this.repository = new LancamentoRepository();
        }

        public LancamentoController(ILancamentoRepository repository)
        {
            this.repository = repository;
        }
        */
        /*
                [Route("api/Lancamento/select")]
                [HttpPost]
                public IHttpActionResult SelectLancamento(LancamentoSelectDTO lancamentoSelectDTO)
                {
                    IEnumerable <LancamentoDTO> lancamentoDTO = repository.Select(lancamentoSelectDTO);
                    if (lancamentoDTO == null)
                        return NotFound();

                    return Ok(lancamentoDTO);
                }

                [HttpPost]
                //[Route("api/Lancamento/{LancamentoInserirDTO}")]
                public IHttpActionResult InsereLancamento(LancamentoInserirDTO lancamento)
                {
                    var resultado = repository.Insert(lancamento);
                    if (resultado == null)
                        return NotFound();

                    return Ok();
                }

                [Route("api/Lancamento/update/")]
                [HttpPost]
                public IHttpActionResult UpdateLancamento(LancamentoInserirDTO lancamento)
                {
                    var resultado = repository.Update(lancamento);
                    if (resultado == null)
                        return NotFound();

                    return Ok();
                }

                [Route("api/Lancamento/{IdLancamento}")]
                [HttpGet]
                public IHttpActionResult SelectOneLancamento(int IdLancamento)
                {
                    var lancamento = repository.SelectEdit(IdLancamento);
                    if (lancamento == null)
                        return NotFound();

                    return Ok(lancamento);
                }

                [Route("api/Lancamento/delete/")]
                [HttpPost]
                public IHttpActionResult DeleteLancamento(LancamentoDTO Lancamento)
                {
                    var resultado = repository.Delete(Lancamento);
                    if (resultado == null)
                        return NotFound();

                    return Ok();
                }

                /*
                // rever route ~/
                [Route("api/Lancamento/{IdUsuario}")]
                public IEnumerable<Lancamento> getAllLancamentos(int IdUsuario)
                {
                    return repository.GetAll(IdUsuario);             
                }*/



        /*
        [HttpPost]
        [Route("api/Lancamento/update/{lancamento}")]
        public IHttpActionResult postUpdateLancamento(Lancamento lancamento)
        {
            var resultado = repository.Update(lancamento);
            if (resultado == null)
                return NotFound();

            return Ok(resultado);
        }


        [Route("api/Lancamento/Delete/{id}")]
        public IHttpActionResult getDeleteLancamento(int IdLancamento)
        {
            var resultado = repository.Delete(IdLancamento);
            if (resultado == null)
                return NotFound();

            return Ok(resultado);  
        }
        */
    }
}

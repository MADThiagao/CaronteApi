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

        [HttpGet]
        [Route("api/Lancamento/{IdUsuario}/BuscarMensal")]
        public IHttpActionResult BuscarMensal(int IdUsuario)
        {
            IEnumerable<Lancamento> lista = repository.BuscarMensal(IdUsuario);
            if (lista == null)
                return NotFound();

            return Ok(lista);
        }

        [HttpPost]
        [Route("api/Lancamento/Adicionar")]
        public void Adicionar(Lancamento lancamento)
        {
            repository.Adicionar(lancamento);
        }

        [HttpPost]
        [Route("api/Lancamento/Remover")]
        public void Remover(Lancamento lancamento)
        {
            repository.Remover(lancamento);
        }

        [HttpPost]
        [Route("api/Lancamento/Atualizar")]
        public void Atualizar(Lancamento lancamento)
        {
            repository.Atualizar(lancamento);
        }

        [HttpPost]
        [Route("api/Lancamento/RecuperarGraficoLinha")]
        public List<GraficoLinhaDTO> RecuperarGraficoLinha(Usuario usuario)
        {
            return repository.GraficoLinha(usuario.Id);
        }

        [HttpPost]
        [Route("api/Lancamento/RecuperarGraficoDonut")]
        public List<GraficoDonutDTO> RecuperarGraficoDonut(Usuario usuario)
        {
            return repository.GraficoDonut(usuario.Id);
        }

    }
}

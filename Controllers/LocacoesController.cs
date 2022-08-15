using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoAPI.Data;
using ProjetoAPI.Models;

namespace ProjetoAPI.Controllers
{
    [Route("api/v1/[Controller]")]
    [ApiController]
    public class LocacoesController : ControllerBase
    {
        private readonly ApplicationDbContext database;
        public LocacoesController(ApplicationDbContext database){
            this.database = database;
        }

        [HttpGet]
        public IActionResult Get(){
            var listaLocacoes = database.Locacoes.Include(cliente => cliente.Cliente).Include(filme => filme.Filme);
            return Ok(listaLocacoes);
        }

        [HttpGet("{id}")]
        public IActionResult GetLocacaoPorId(int id){
            var locacaoPorId = database.Locacoes.Include(cliente => cliente.Cliente).Include(filme => filme.Filme).First(l => l.Id == id);
            if (locacaoPorId.Status != true){
                Response.StatusCode = 404;
                return new ObjectResult(new { info = "Locação não encontrada!"});
            } else {
                return Ok(locacaoPorId);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]LocacaoTemp locacaoTemp){
            
            Locacao locacao = new Locacao();

            locacao.Cliente = database.Clientes.First(c => c.Id == locacaoTemp.ClienteId);
            locacao.Filme = database.Filmes.First(f => f.Id == locacaoTemp.FilmeId);
            
            if (locacao.Cliente.Disponivel == false){
                Response.StatusCode = 403;
                return new ObjectResult(new { info = "Cliente já tem filme alugado!"});
            }

            if (locacao.Filme.Disponivel == false){
                Response.StatusCode = 403;
                return new ObjectResult(new { info = "Este filme já está alugado!"});
            }

            locacao.DataLocacao = DateTime.Now;
            locacao.DataDevolucao = locacaoTemp.DataDevolucao;
            locacao.Status = true;
            locacao.Filme.Disponivel = false;
            locacao.Cliente.Disponivel = false;
            database.Locacoes.Add(locacao);
            database.SaveChanges();
            Response.StatusCode = 201;
            return new ObjectResult(new { info = "Locação criada com sucesso!"});
        }

        [HttpPost("{id}/devolucao")]
        public IActionResult PostDevolucao([FromRoute]int id){
            var devolucao = database.Locacoes.Include(cliente => cliente.Cliente).Include(filme => filme.Filme).First(d => d.Id == id);
            if (devolucao.Status != true){
                Response.StatusCode = 403;
                return new ObjectResult(new { info = "Devolução já realizada!"});
            } else {
                devolucao.Cliente.Disponivel = true;
                devolucao.Filme.Disponivel = true;
                devolucao.Status = false;
                database.SaveChanges();
                Response.StatusCode = 201;
                return new ObjectResult(new { info = "Devolução realizada com sucesso!"});
            }
        }

        [HttpPatch]
        public IActionResult Patch([FromBody] Locacao locacao)
        {
            if (locacao.Id >= 0){
                try {
                    var l = database.Locacoes.First(locacaoTemp => locacaoTemp.Id == locacao.Id);

                    if (l != null){
                        l.Cliente = locacao.Cliente != null ? locacao.Cliente : l.Cliente;
                        l.Filme = locacao.Filme != null ? locacao.Filme : l.Filme;
                        l.DataLocacao = locacao.DataLocacao != null ? locacao.DataLocacao : l.DataLocacao;
                        l.DataDevolucao = locacao.DataDevolucao != null ? locacao.DataDevolucao : l.DataDevolucao;
                        database.SaveChanges();
                        return Ok("Registro de locação atualizado com sucesso!");
                    } else {
                        Response.StatusCode = 404;
                        return new ObjectResult(new { info = "Registro de locação não encontrado!"});
                    }
                } catch (Exception) {
                    Response.StatusCode = 404;
                    return new ObjectResult(new { info = "Registro de locação não encontrado!"});
                }
            } else {
                Response.StatusCode = 404;
                return new ObjectResult(new { info = "Registro de locação não encontrado!"});
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            var locacao = database.Locacoes.Include(cliente => cliente.Cliente).Include(filme => filme.Filme).First(l => l.Id == id);
            if (locacao.Id == id){
                locacao.Status = false;
                database.SaveChanges();
                return Ok("Registro de locação excluído com sucesso!");
            } else {
                Response.StatusCode = 404;
                return new ObjectResult(new { info = "Registro de locação não encontrado!"});
            }
        }

        public class LocacaoTemp 
        {
            public int ClienteId { get; set; }
            public int FilmeId { get; set; }
            public DateTime DataLocacao { get; set; }
            public DateTime DataDevolucao { get; set; }
        }
    }
}
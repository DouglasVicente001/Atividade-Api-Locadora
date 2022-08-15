using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProjetoAPI.Data;
using ProjetoAPI.Models;

namespace ProjetoAPI.Controllers
{
        
    [Route("api/v1/[Controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private readonly ApplicationDbContext database;
        public FilmesController(ApplicationDbContext database){
            this.database = database;
        }

        [HttpGet]
        public IActionResult Get(){
            var listaFilmes = database.Filmes.Where(f => f.Disponivel == true && f.Status == true).ToList();
            return Ok(listaFilmes);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id){
            try {
                Filme filmePorId = database.Filmes.First(f => f.Id == id);
                return Ok(filmePorId);
            } catch (Exception) {
                Response.StatusCode = 404;
                return new ObjectResult(new { info = "Filme não encontrado!"});
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] FilmeTemp filmeTemp){

            Filme filme = new Filme();

            filme.Titulo = filmeTemp.Titulo;
            filme.Genero = filmeTemp.Genero;
            filme.Disponivel = filmeTemp.Disponivel = true;
            filme.Status = filmeTemp.Status = true;
            database.Filmes.Add(filme);
            database.SaveChanges();
            Response.StatusCode = 201;
            return new ObjectResult(new { info = "Filme adicionado com sucesso!"});
        }

        [HttpPatch]
        public IActionResult Patch([FromBody] Filme filme)
        {
            if (filme.Id >= 0) {
                try {
                    var f = database.Filmes.First(FilmeTemp => FilmeTemp.Id == filme.Id);

                    if (f != null){
                        f.Titulo = filme.Titulo != null ? filme.Titulo : f.Titulo;
                        f.Genero = filme.Genero != null ? filme.Genero : f.Genero;
                        f.Disponivel = filme.Disponivel != false ? filme.Disponivel : f.Disponivel;
                        f.Status = filme.Status != false ? filme.Status : f.Status;
                        database.SaveChanges();
                        return Ok("Filme atualizado com sucesso!");
                    } else {
                        Response.StatusCode = 404;
                        return new ObjectResult(new { info = "Id não existe!"});
                    }
                } catch (Exception) {
                    Response.StatusCode = 404;
                    return new ObjectResult(new { info = "Filme não encontrado!"});
                }
            } else {
                Response.StatusCode = 404;
                return new ObjectResult(new { info = "Filme não encontrado!"});
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            try {
                Filme filme = database.Filmes.First(f => f.Id == id);
                filme.Status = false;
                database.SaveChanges();
                return Ok("Filme excluído com sucesso!");
            } catch (Exception) {
                Response.StatusCode = 404;
                return new ObjectResult(new { info = "Filme não encontrado!"});
            }
        }

        public class FilmeTemp 
        {
            public string Titulo { get; set; }
            public string Genero { get; set; }
            public bool Disponivel { get; set; }
            public bool Status { get; set; }
        }
    }
}
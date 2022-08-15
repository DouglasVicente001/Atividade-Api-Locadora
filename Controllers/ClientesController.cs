using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProjetoAPI.Data;
using ProjetoAPI.Models;

namespace ProjetoAPI.Controllers
{
    [Route("api/v1/[Controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ApplicationDbContext database;

        public ClientesController(ApplicationDbContext database){
            this.database = database;
        }

        [HttpGet]
        public IActionResult Get(){
            var clientes = database.Clientes.Where(c => c.Status == true).ToList();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id){
            try {
                Cliente cliente = database.Clientes.First(c => c.Id == id);
                return Ok(cliente);
            } catch (Exception) {
                Response.StatusCode = 404;
                return new ObjectResult(new { info = "Id Não encontrado" });
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] ClienteTemp cTemp){

            Cliente cliente = new Cliente();

            cliente.Nome = cTemp.Nome;
            cliente.Email = cTemp.Email;
            cliente.Telefone = cTemp.Telefone;
            cliente.Cpf = cTemp.Cpf;
            cliente.Status = cTemp.Status = true;
            database.Clientes.Add(cliente);
            database.SaveChanges();
            Response.StatusCode = 201;
            return new ObjectResult("");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            try {
                Cliente cliente = database.Clientes.First(c => c.Id == id);
                cliente.Status = false;
                database.SaveChanges();
                return Ok();
            } catch (Exception) {
                Response.StatusCode = 404;
                return new ObjectResult(new { info = "Id Não encontrado" });
            }
        }

        [HttpPatch]
        public IActionResult Patch([FromBody] Cliente cliente){
            if (cliente.Id >= 0) {
                try {
                    var c = database.Clientes.First(ctemp => ctemp.Id == cliente.Id);

                    if (c != null) {
                        c.Nome = cliente.Nome != null ? cliente.Nome : c.Nome;
                        c.Email = cliente.Email != null ? cliente.Email : c.Email;
                        c.Telefone = cliente.Telefone != null ? cliente.Telefone : c.Telefone;
                        c.Cpf = cliente.Cpf != null ? cliente.Cpf : c.Cpf;
                        c.Status = cliente.Status != false ? cliente.Status : c.Status;
                        c.Disponivel = cliente.Disponivel != false ? cliente.Disponivel : c.Disponivel;
                        database.SaveChanges();
                        return Ok("Editado com sucesso");
                    } else {
                        Response.StatusCode = 404;
                        return new ObjectResult(new { info = "Id do cliente inválido" });
                    }
                } catch (Exception) {
                    Response.StatusCode = 404;
                    return new ObjectResult(new { info = "Id do cliente inválido" });
                }
            } else {
                Response.StatusCode = 404;
                return new ObjectResult(new { info = "Id do cliente inválido" });
            }
        }

        public class ClienteTemp
        {
            public string Nome { get; set; }
            public string Email { get; set; }
            public string Senha { get; set; }
            public string Telefone { get; set; }
            public string Cpf { get; set; }
            public bool Disponivel { get; set; }
            public bool Status { get; set; }
        }
    }
}
using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;

namespace APICatalogo.Controllers
{


    [Route("[controller]")]
    [ApiController]

    public class ProdutosController : ControllerBase
    {

        //1° passo injetar uma instancia do appdbContext na pasta context no CONSTRUTOR

        private readonly AppDbContext _context;

        //Gerado o CONSTRUTOR Da instancia da classe appdbcontext.
        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult <IEnumerable<Produto>> Get()
        {
            var produtos = _context.Produtos.ToList();
            //e se for null?

            if(produtos is null)
            {
                return NotFound("Produtos não encontrados");
            }
            return produtos;
        }
    }
}

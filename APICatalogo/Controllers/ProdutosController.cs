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
        [HttpGet("{id:int}", Name ="ObterPoduto")]

        public ActionResult<Produto> Get(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);

            if(produto is null)
            {
                return NotFound("Produto não encontrado");
            }
            return produto;
        }
        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if (produto is null)

                return BadRequest();

            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto", 
                new { id = produto.ProdutoId }, produto);
            
        }

        [HttpPut("{id:int}")]
       public ActionResult Put(int id, Produto produto)
        {
            if(id != produto.ProdutoId)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(produto);
        }

    }
}

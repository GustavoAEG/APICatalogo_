using APICatalogo.Context;
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
    }
}

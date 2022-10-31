using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;

namespace APICatalogo.Controllers;

[Route("[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProdutosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Produto>> Get()
    {
        var produtos = _context.Produtos.Take(32).ToList();
        try
        {
            if (produtos is null)
            {
                return NotFound("Produtos não encontrados.");
            }
            return produtos;
        }
        catch (Exception)
        {

            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema!");
        }
        
        
    }

    [HttpGet("{id:int}", Name = "ObterProduto")]
    public ActionResult<Produto> Get(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
        try
        {
            if (produto == null)
            {
                return NotFound("Produto não encontrado.");
            }
            return produto;
        }
        catch (Exception)
        {

            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema!");
        }
      
    }

    [HttpPost]
    public ActionResult Post(Produto produto)
    {
        try
        {
            if (produto == null)
            {
                return BadRequest("Produto Inválido");
            }

            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto",
                new { id = produto.ProdutoId }, produto);
        }
        catch (Exception)
        {

            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema!");
        }
       
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Produto produto)
    {
        try
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest("Código de produto Inválido");
            }

            _context.Entry(produto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(produto);
        }
        catch (Exception)
        {

            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema!");
        }
       
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
        try
        {
            if (produto is null)
            {
                return NotFound("Produto não localizado.");
            }

            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return Ok(produto);
        }
        catch (Exception)
        {

            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema!");
        }
        
    }
}

using APIProdutos.Context;
using APIProdutos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIProdutos.Controllers;

[Route("[controller]")]
[ApiController]
public class ProdutosController : Controller
{
    private readonly AppDbContext _context;

    public ProdutosController(AppDbContext contexto)
    {
        _context = contexto;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Produto>> Get()
    {
        var produtos = _context.Produtos.Take(5).AsNoTracking().ToList();

        if (produtos is null) return BadRequest("Tivemos um erro na requisição.");

        return produtos;
    }

    [HttpGet("{id:int}")]
    public ActionResult<Produto> Get(int id)
    {
        var produto = _context.Produtos.Find(id);

        if (produto is null) return BadRequest("Tivemos um erro na requisição.");

        return produto;
    }

    [HttpPost]
    public ActionResult Post(Produto produto)
    {
        if (produto is null) return BadRequest("Erro no corpo da requisição, envie um produto válido.");

        try
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return Ok(produto);
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar produto.");
        }
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Produto produto)
    {
        if (produto is null) return BadRequest("Erro no corpo da requisição, envie um produto válido.");

        var produtoFind = _context.Produtos.Find(id);
        if (produtoFind is null) return NotFound("Não encontramos nenhum produto com esse ID.");

        try
        {
            produtoFind.Tipo = produto.Tipo;
            produtoFind.Estoque = produto.Estoque;
            produtoFind.Descricao = produto.Descricao;
            produtoFind.Valor = produto.Valor;
            produtoFind.Tamanho = produto.Tamanho;

            _context.Produtos.Update(produtoFind);
            _context.SaveChanges();
            return Ok(produtoFind);
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar produto.");
        }
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var produto = _context.Produtos.Find(id);

        if (produto is null) return NotFound("Não encontramos nenhum produto com esse ID.");

        try
        {
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return Ok(produto);
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar produto.");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using WebAPI.Mongodb.Model;
using WebAPI.Mongodb.Repository.Pessoa;

namespace WebAPI.Mongodb.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PessoaController : ControllerBase
{
    private readonly IPessoaRepository _repository;

    public PessoaController(IPessoaRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pessoa>>> FindAll()
    {
        var products = await _repository.GetPessoas();
        return Ok(products);
    }

    [HttpPost]
    public async Task<ActionResult<Pessoa>> Create([FromBody] Pessoa dto)
    {
        if (dto is null) return BadRequest();
        var product = await _repository.CreateAsync(dto);
        return Ok(product);
    }
}
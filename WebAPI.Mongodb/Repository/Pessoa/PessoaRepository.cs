using Microsoft.EntityFrameworkCore;
using WebAPI.Mongodb.Data.SQLSERVERContext;

namespace WebAPI.Mongodb.Repository.Pessoa;

public class PessoaRepository : IPessoaRepository
{
    private readonly SQLSERVERContext _context;

    public PessoaRepository(SQLSERVERContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Model.Pessoa>> GetPessoas()
    {
        return await _context.Pessoas.ToListAsync();
    }

    public async Task<Model.Pessoa> CreateAsync(Model.Pessoa dto)
    {
        _context.Pessoas.Add(dto);
        await _context.SaveChangesAsync();
        return dto;
    }
}
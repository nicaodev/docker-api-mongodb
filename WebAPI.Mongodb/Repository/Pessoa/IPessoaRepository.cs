
using WebAPI.Mongodb.Model;

namespace WebAPI.Mongodb.Repository.Pessoa;

public interface IPessoaRepository
{
    Task<IEnumerable<Model.Pessoa>> GetPessoas();

    Task<Model.Pessoa> CreateAsync(Model.Pessoa dto);
}
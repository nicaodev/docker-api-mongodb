using Microsoft.EntityFrameworkCore;
using WebAPI.Mongodb.Model;

namespace WebAPI.Mongodb.Data.SQLSERVERContext;

public class SQLSERVERContext : DbContext
{
    public SQLSERVERContext(DbContextOptions<SQLSERVERContext> options) : base(options)
    {
        this.Database.EnsureCreated();
    }

    public DbSet<Pessoa> Pessoas { get; set; }
}
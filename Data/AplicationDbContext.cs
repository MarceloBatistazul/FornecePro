using FornecePro.Models;
using Microsoft.EntityFrameworkCore;

namespace FornecePro.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<CadastroModels> Cadastros { get; set; }
    }
}

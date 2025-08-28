using Microsoft.EntityFrameworkCore;
using SudokuSolver.WebApi.Models;

namespace SudokuSolver.WebApi.Data
{
    public class SudokuDbContext : DbContext
    {
        public SudokuDbContext(DbContextOptions<SudokuDbContext> options)
            : base(options)
        {
        }

        public DbSet<Solver> Solvers { get; set; }
    }
}

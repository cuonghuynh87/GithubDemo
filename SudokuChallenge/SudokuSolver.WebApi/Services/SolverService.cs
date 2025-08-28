using Microsoft.EntityFrameworkCore;
using SudokuSolver.WebApi.Data;
using SudokuSolver.WebApi.Models;
using System.Text;

namespace SudokuSolver.WebApi.Services
{
    public class SolverService : ISolverService
    {
        private readonly SudokuDbContext _context;

        public SolverService(SudokuDbContext context) => _context = context;

        public async Task<IList<Solver>> GetSolvers()
        {
            return await _context.Solvers.ToListAsync();
        }

        public async Task<int> AddSolver(List<int[]> solvers)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var solver in solvers)
            {
                foreach (var item in solver)
                {
                    sb.Append(item.ToString()); 
                }
            }

            var model = new Solver
            {
                Result = sb.ToString(),
                CreatedDate = DateTime.Now
            };

            _context.Solvers.Add(model);
            var result = await _context.SaveChangesAsync();

            return result;
        }       
    }
}

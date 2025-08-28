using SudokuSolver.WebApi.Models;
using System.Numerics;

namespace SudokuSolver.WebApi.Services
{
    public interface ISolverService
    {
        Task<IList<Solver>> GetSolvers();
        Task<int> AddSolver(List<int[]> solvers);
    }
}

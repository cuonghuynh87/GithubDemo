using Microsoft.AspNetCore.Mvc;
using SudokuSolver.WebApi.Models;
using SudokuSolver.WebApi.Services;

namespace SudokuSolver.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SolverController : ControllerBase
    {
        private readonly ISolverService _solverService;

        public SolverController(ISolverService solverService) => this._solverService = solverService;

        [HttpGet]
        public async Task<IList<Solver>> GetSolvers()
        {
            return await _solverService.GetSolvers();
        }

        [HttpPost("Add")]

        public async Task<ActionResult<int>> AddSolver(List<int[]> solvers)
        {
            return await _solverService.AddSolver(solvers);
        }
    }
}

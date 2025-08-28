using Moq;
using SudokuSolver.WebApi.Controllers;
using SudokuSolver.WebApi.Models;
using SudokuSolver.WebApi.Services;
using Xunit;

namespace SudokuSolver.Test
{
    public class SolverControllerTest
    {
        private Mock<ISolverService> _mockSolverService;

        public SolverControllerTest()
        {
            _mockSolverService = new Mock<ISolverService>();
        }

        [Fact]
        public async Task GetSolvers_HaveData_ReturnSolvers()
        {
            // Arrange
            var solvers = new List<Solver>
            {
                new Solver
                {
                    Id = 1,
                    Result = "235147689146389257789526134314258796527691348698473512451862973872935461963714825",
                    CreatedDate = DateTime.Now,
                },
                new Solver
                {
                    Id = 2,
                    Result = "123456789459187236678239145214365897395718462786924351531642978847591623962873514",
                    CreatedDate = DateTime.Now
                }
            };
            _mockSolverService.Setup(x => x.GetSolvers()).ReturnsAsync(solvers);
            var controller = new SolverController(_mockSolverService.Object);

            // Act
            var result = await controller.GetSolvers();

            // Assert
            _mockSolverService.Verify(r => r.GetSolvers());
            Assert.Equal(result.Count, 2);
        }

        [Fact]
        public async Task GetSolvers_EmptyData_ReturnEmptySolvers()
        {
            // Arrange
            var solvers = new List<Solver>();

            _mockSolverService.Setup(x => x.GetSolvers()).ReturnsAsync(solvers);
            var controller = new SolverController(_mockSolverService.Object);

            // Act
            var result = await controller.GetSolvers();

            // Assert
            _mockSolverService.Verify(r => r.GetSolvers());
            Assert.Equal(result.Count, 0);
        }

        [Fact]
        public async Task GetSolvers_ServiceInvalid_ControllerNull()
        {
            // Arrange
            _mockSolverService.Setup(x => x.GetSolvers()).Throws<ArgumentNullException>();

            // Act
            var controller = new SolverController(_mockSolverService.Object);

            // Assert
            Assert.Null(controller.HttpContext);
        }

        [Fact]
        public async Task AddSolvers_ListSolverValid_AddSuccess()
        {
            // Arrange
            var solvers = new List<int[]>
            {
                new int[]
                {
                    2,3,5,1,4,7,6,8,9
                },
                new int[]
                {
                    1,4,6,3,8,9,2,5,7
                },
                new int[]
                {
                    7,8,9,5,2,6,1,3,4
                },
                new int[]
                {
                    3,1,4,2,5,8,7,9,6
                },
                new int[]
                {
                    5,2,7,6,9,1,3,4,8
                },
                new int[]
                {
                    6,9,8,4,7,3,5,1,2
                },
                 new int[]
                {
                    4,5,1,8,6,2,9,7,3
                },
                  new int[]
                {
                    8,7,2,9,3,5,4,6,1
                },
                   new int[]
                {
                    9,6,3,7,1,4,8,2,5
                },
            };

            _mockSolverService.Setup(x => x.AddSolver(solvers)).ReturnsAsync(1);
            var controller = new SolverController(_mockSolverService.Object);

            // Act
            var result = await controller.AddSolver(solvers);

            // Assert
            _mockSolverService.Verify(r => r.AddSolver(solvers));
            Assert.Equal(result.Value, 1);
        }

        [Fact]
        public async Task AddSolvers_ListSolverInvalid_AddFailed()
        {
            // Arrange
            var solvers = new List<int[]>
            {
                new int[]
                {
                    1,2,3,4,5,6,7,8,9
                },
                new int[]
                {
                    1,2,3,4,5,6,7,8,9
                },
            };

            _mockSolverService.Setup(x => x.AddSolver(solvers)).ReturnsAsync(0);
            var controller = new SolverController(_mockSolverService.Object);

            // Act
            var result = await controller.AddSolver(solvers);

            // Assert
            _mockSolverService.Verify(r => r.AddSolver(solvers));
            Assert.Equal(result.Value, 0);
        }
    }
}

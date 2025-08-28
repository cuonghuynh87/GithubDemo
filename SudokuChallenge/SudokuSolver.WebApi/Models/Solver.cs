using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SudokuSolver.WebApi.Models
{
    public class Solver
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(81)]
        public string Result {  get; set; } 
        public DateTime CreatedDate { get; set; }
    }
}

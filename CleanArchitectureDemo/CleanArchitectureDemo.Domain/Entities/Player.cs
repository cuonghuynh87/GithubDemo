using CleanArchitectureDemo.Domain.Common;

namespace CleanArchitectureDemo.Domain.Entities;

public class Player : BaseEntity<int>
{
    public string Name { get; set; } = default!;
    public int ShirtNo { get; set; } = default!;
    public int ClubId { get; set; } = default!;
    public string PhotoUrl { get; set; } = default!;
    public DateTime? BirthDate { get; set; }
}
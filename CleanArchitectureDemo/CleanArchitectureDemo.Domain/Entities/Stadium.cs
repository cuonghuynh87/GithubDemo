using CleanArchitectureDemo.Domain.Common;

namespace CleanArchitectureDemo.Domain.Entities;

public class Stadium : BaseEntity<int>
{
    public string Name { get; set; } = default!;
    public string PhotoUrl { get; set; } = default!;
    public int Capacity { get; set; } = default!;
    public int BuiltYear { get; set; } = default!;
    public int PitchLength { get; set; } = default!;
    public int PitchWidth { get; set; } = default!;
    public string Phone { get; set; } = default!;
    public string AddressLine1 { get; set; } = default!;
    public string AddressLine2 { get; set; } = default!;
    public string AddressLine3 { get; set; } = default!;
    public string City { get; set; } = default!;
    public string PostalCode { get; set; } = default!;
    public int CountryId { get; set; } = default!;
    public Country Country { get; set; } = default!;
    public IList<Club> Clubs { get; set; } = new List<Club>();
}
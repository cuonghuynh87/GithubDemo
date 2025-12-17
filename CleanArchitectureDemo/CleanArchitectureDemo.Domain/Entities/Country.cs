using CleanArchitectureDemo.Domain.Common;

namespace CleanArchitectureDemo.Domain.Entities;

public class Country : BaseEntity<int>
{
    public string Name { get; set; } = default!;
    public string TwoLetterIsoCode { get; set; } = default!;
    public string ThreeLetterIsoCode { get; set; } = default!;
    public string FlagUrl { get; set; } = default!;
    public int DisplayOrder { get; set; } = default!;
    public IList<Player> Players { get; set; } = new List<Player>();
    public IList<Stadium> Stadiums { get; set; } = new List<Stadium>();
}
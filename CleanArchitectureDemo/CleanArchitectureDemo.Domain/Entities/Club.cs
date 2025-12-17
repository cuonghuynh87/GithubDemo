using CleanArchitectureDemo.Domain.Common;

namespace CleanArchitectureDemo.Domain.Entities;

public class Club : BaseEntity<int>
{
    public string Name { get; set; } = default!;
    public string PhotoUrl { get; set; } = default!;
    public string WebsiteUrl { get; set; } = default!;
    public string FacebookUrl { get; set; } = default!;
    public string TwitterUrl { get; set; } = default!;
    public string YoutubeUrl { get; set; } = default!;
    public string InstagramUrl { get; set; } = default!;
    public int StadiumId { get; set; } = default!;
    public Stadium Stadium { get; set; } = default!;
    public IList<Player> Players { get; set; } = new List<Player>();
}
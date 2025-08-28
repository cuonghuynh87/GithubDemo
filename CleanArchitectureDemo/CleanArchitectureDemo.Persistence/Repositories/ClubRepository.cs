using CleanArchitectureDemo.Application.Interfaces.Repositories;
using CleanArchitectureDemo.Domain.Entities;

namespace CleanArchitectureDemo.Persistence.Repositories;

public class ClubRepository : IClubRepository
{
    private readonly IGenericRepository<Club> _repository;

    public ClubRepository(IGenericRepository<Club> repository) 
    {
        _repository = repository;
    } 
}
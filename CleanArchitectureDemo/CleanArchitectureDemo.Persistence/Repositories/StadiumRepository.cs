using CleanArchitectureDemo.Application.Interfaces.Repositories;
using CleanArchitectureDemo.Domain.Entities;

namespace CleanArchitectureDemo.Persistence.Repositories;

public class StadiumRepository : IStadiumRepository
{
    private readonly IGenericRepository<Stadium> _repository;

    public StadiumRepository(IGenericRepository<Stadium> repository) 
    {
        _repository = repository;
    } 
}
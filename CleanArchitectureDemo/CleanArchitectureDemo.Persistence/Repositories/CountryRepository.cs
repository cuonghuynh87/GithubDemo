using CleanArchitectureDemo.Application.Interfaces.Repositories;
using CleanArchitectureDemo.Domain.Entities;

namespace CleanArchitectureDemo.Persistence.Repositories;

public class CountryRepository : ICountryRepository
{
    private readonly IGenericRepository<Country> _repository;

    public CountryRepository(IGenericRepository<Country> repository) 
    {
        _repository = repository;
    } 
}
using CleanArchitectureDemo.Application.Interfaces.Repositories;
using CleanArchitectureDemo.Domain.Common;
using CleanArchitectureDemo.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureDemo.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly DbSet<T> _dbSet;

    public GenericRepository(ApplicationDbContext dbContext)
    {
        _dbSet = dbContext.Set<T>();
    }

    public IQueryable<T> Entities => _dbSet;

    public async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public Task<T> UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        return Task.FromResult(entity);
    }

    public Task<bool> DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        return Task.FromResult(true);
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }
}
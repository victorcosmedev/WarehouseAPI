using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WarehouseAPI.Domain.Entities;
using WarehouseAPI.Infra.Data.AppData;

namespace WarehouseAPI.Domain.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id);
    Task<T?> GetByExternalIdAsync(Guid externalId);
    void AddAsync(T entity);
    void RemoveAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
}

public class Repository<T> : IRepository<T> where T : CoreEntity
{
    private readonly ApplicationContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(ApplicationContext context, DbSet<T> dbSet)
    {
        _context = context;
        _dbSet = dbSet;
    }

    public void AddAsync(T entity)
    {
        _dbSet.Add(entity);
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet
            .Where(predicate)
            .ToListAsync();
    }

    public Task<IEnumerable<T>> GetAllAsync()
    {
        return _dbSet.ToList();
    }

    public async Task<T?> GetByExternalIdAsync(Guid externalId)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.ExternalId.Equals(externalId));
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async void RemoveAsync(T entity)
    {
        await _dbSet.FindAsync(entity);
    }
}

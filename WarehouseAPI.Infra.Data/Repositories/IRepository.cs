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

    public Repository(ApplicationContext context)
    {
        _context = context;
    }

    public void AddAsync(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>()
            .Where(predicate)
            .ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T?> GetByExternalIdAsync(Guid externalId)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(x => x.ExternalId.Equals(externalId));
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async void RemoveAsync(T entity)
    {
        await _context.Set<T>().FindAsync(entity);
    }
}

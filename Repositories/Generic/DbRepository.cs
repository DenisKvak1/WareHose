using System.Diagnostics;
using Abstract;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Generic;

public class DbRepository<T> : IDbRepository<T> where T:class, IDbEntity
{
    protected DbContext _context;
    public DbRepository(DbContext context)
    {
        _context = context;
    }
    
    public IQueryable<T> AllItems => _context.Set<T>();
    
    public async Task<List<T>> ToListAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<bool> AddItemAsync(T item)
    {
        await _context.Set<T>().AddAsync(item);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<int> AddItemsAsync(IEnumerable<T> items)
    {
        await _context.Set<T>().AddRangeAsync(items);
        return await _context.SaveChangesAsync();
    }

    public async Task<T?> GetItemAsync(Guid id)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> UpdateItemAsync(T item)
    {
        _context.Update(item);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteItemAsync(Guid id)
    {
        T? item = await _context.Set<T>().FirstOrDefaultAsync(x=>x.Id == id);
        if (item == null) return false;

        _context.Set<T>().Remove(item);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> IsExistAsync(Guid id)
    {
        return await _context.Set<T>().AnyAsync(x => x.Id == id);
    }
    
    public async Task<int> SaveChangesAsync()
    {
        try
        {
           return await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            return -1;
        }
    }
}
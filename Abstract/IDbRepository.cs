namespace Abstract;

public interface IDbRepository<T> where T:class, IDbEntity
{
    Task<bool> IsExistAsync(Guid id);
    IQueryable<T> AllItems { get; }
    Task<List<T>> ToListAsync();
    Task<bool> AddItemAsync(T item);
    Task<int> AddItemsAsync(IEnumerable<T> items);
    Task<T?> GetItemAsync(Guid id);
    Task<bool> UpdateItemAsync(T item);
    Task<bool> DeleteItemAsync(Guid id);
    Task<int> SaveChangesAsync();
}
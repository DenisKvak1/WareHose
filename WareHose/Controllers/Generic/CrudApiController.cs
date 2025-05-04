using System.Reflection;
using Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Authorize]
[Route("api/[controller]")]
public class CrudApiController<TRepository, TEntity> : ControllerBase
    where TRepository : IDbRepository<TEntity>
    where TEntity : class, IDbEntity
{
    protected readonly TRepository _repository;

    public CrudApiController(TRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public virtual async Task<ActionResult<IEnumerable<TEntity>>> Get()
    {
        var list = await _repository.ToListAsync();
        return Ok(list);
    }

    [HttpGet("{id}")]
    public virtual async Task<ActionResult<TEntity>> Get(Guid id)
    {
        var entity = await _repository.GetItemAsync(id);
        if (entity == null)
            return NotFound($"Entity with ID {id} not found.");

        return Ok(entity);
    }

    [HttpPost("create")]
    public virtual async Task<ActionResult> Create([FromBody] TEntity entity)
    {
        CleanNavigationProperties(entity);
        entity.Id = Guid.NewGuid();
        
        var success = await _repository.AddItemAsync(entity);
        if (!success)
            return StatusCode(500, "Error while creating entity.");

        await _repository.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity);
    }

    [HttpPut]
    public virtual async Task<ActionResult> Put([FromBody] TEntity entity)
    {
        if (entity == null)
            return BadRequest("Entity is null.");
        CleanNavigationProperties(entity);

        var exists = await _repository.IsExistAsync(entity.Id);
        if (!exists)
            return NotFound($"Entity with ID {entity.Id} not found.");

        var success = await _repository.UpdateItemAsync(entity);
        if (!success)
            return StatusCode(500, "Error while updating entity.");

        await _repository.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("{id}")]
    public virtual async Task<ActionResult> Delete(Guid id)
    {
        var exists = await _repository.IsExistAsync(id);
        if (!exists)
            return NotFound($"Entity with ID {id} not found.");

        var success = await _repository.DeleteItemAsync(id);
        if (!success)
            return StatusCode(500, "Error while deleting entity.");

        await _repository.SaveChangesAsync();
        return Ok();
    }

    public static void CleanNavigationProperties<T>(T entity)
    {
        if (entity == null) return;

        var entityType = typeof(DbEntity);

        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var prop in properties)
        {
            if (!prop.CanWrite) continue;

            var propType = prop.PropertyType;

            if (entityType.IsAssignableFrom(propType))
            {
                prop.SetValue(entity, null);
                continue;
            }

            if (propType.IsGenericType && typeof(IEnumerable<>).IsAssignableFrom(propType.GetGenericTypeDefinition()) ||
                propType.GetInterfaces()
                    .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICollection<>)))
            {
                var innerType = propType.GetGenericArguments().FirstOrDefault();
                if (innerType != null && entityType.IsAssignableFrom(innerType))
                {
                    prop.SetValue(entity, null);
                }
            }
        }
    }
}
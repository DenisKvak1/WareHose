using Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WareHose.Controllers.Generic;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class ReadApiController<TRepository, TEntity> : ControllerBase
    where TRepository : IDbRepository<TEntity>
    where TEntity : class, IDbEntity
{
    protected readonly TRepository _repository;

    public ReadApiController(TRepository repository)
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
}
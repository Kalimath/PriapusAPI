using MbDevelopment.Greenmaster.Core.Botanical;
using Microsoft.EntityFrameworkCore;

namespace MbDevelopment.Greenmaster.DataAccess.Services;

public class SpeciesQueryService : ISpeciesQueryService
{
    private readonly BotanicalContext _dbContext;
    public SpeciesQueryService(BotanicalContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Task Add(Species newObject)
    {
        throw new NotImplementedException();
    }

    public Task<Species> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Species>> GetAll()
    {
        return _dbContext.Species.ToListAsync();
    }

    public Task Update(Species updatedObject)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsWithId(int id)
    {
        throw new NotImplementedException();
    }
}
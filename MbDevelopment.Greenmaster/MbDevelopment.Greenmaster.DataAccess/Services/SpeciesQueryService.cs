using MbDevelopment.Greenmaster.Core.Botanical;
using Microsoft.EntityFrameworkCore;

namespace MbDevelopment.Greenmaster.DataAccess.Services;

public class SpeciesQueryService(BotanicalContext dbContext) : ISpeciesQueryService
{
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
        return dbContext.Species.ToListAsync();
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
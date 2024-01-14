using MbDevelopment.Greenmaster.Core.Botanical;
using MbDevelopment.Greenmaster.DataAccess.Base;
using Microsoft.EntityFrameworkCore;

namespace MbDevelopment.Greenmaster.DataAccess.Services;

public class GeneraQueryService(BotanicalContext botanicalContext) : IGeneraQueryService
{
    public readonly BotanicalContext BotanicalContext = botanicalContext ?? throw new ArgumentNullException(nameof(botanicalContext));

    public Task Add(Genus newObject)
    {
        throw new NotImplementedException();
    }

    public Task<Genus> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Genus>> GetAll()
    {
        return botanicalContext.Genera.ToListAsync();
    }

    public Task Update(Genus updatedObject)
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
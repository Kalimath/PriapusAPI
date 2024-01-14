using MbDevelopment.Greenmaster.Core.Botanical;
using Microsoft.EntityFrameworkCore;

namespace MbDevelopment.Greenmaster.DataAccess.Services;

public class GeneraQueryService(BotanicalContext botanicalContext) : IGeneraQueryService
{
    public readonly BotanicalContext BotanicalContext = botanicalContext ?? throw new ArgumentNullException(nameof(botanicalContext));

    public Task Add(Genus newObject)
    {
        throw new NotImplementedException();
    }

    public async Task<Genus?> GetById(int id)
    {
        return await botanicalContext.Genera.FindAsync(id);
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
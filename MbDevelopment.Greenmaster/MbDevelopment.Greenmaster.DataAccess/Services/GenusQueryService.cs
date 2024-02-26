using MbDevelopment.Greenmaster.Core.Botanical;
using Microsoft.EntityFrameworkCore;

namespace MbDevelopment.Greenmaster.DataAccess.Services;

public class GenusQueryService : IGenusQueryService
{
    private readonly BotanicalContext _botanicalContext;

    public GenusQueryService(BotanicalContext botanicalContext)
    {
        _botanicalContext = botanicalContext ?? throw new ArgumentNullException(nameof(botanicalContext));
    }

    public Task Add(Genus genus)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(genus);
            _botanicalContext.Genera.Add(genus);
            return _botanicalContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Genus?> GetById(int id)
    {
        return await _botanicalContext.Genera.FindAsync(id);
    }

    public Task<List<Genus>> GetAll()
    {
        return _botanicalContext.Genera.ToListAsync();
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
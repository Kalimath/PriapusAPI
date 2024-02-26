using MbDevelopment.Greenmaster.Core.Botanical;
using Microsoft.EntityFrameworkCore;
using static System.String;
using static MbDevelopment.Greenmaster.Core.HelperMethods.Validators;

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
            ThrowIfNull(genus);
            ValidateGenus(genus);
            _botanicalContext.Genera.Add(genus);
            return _botanicalContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private static void ValidateGenus(Genus genus)
    {
        if (IsInvalidId(genus.Id))
            throw new ArgumentOutOfRangeException(nameof(genus.Id), "Id must be greater than zero");
        if(IsNullOrEmpty(genus.LatinName)) 
            throw new ArgumentNullException(nameof(genus.LatinName), "{nameof(genus.LatinName)} cannot be null or empty");
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
using MbDevelopment.Greenmaster.Core.Botanical;
using MbDevelopment.Greenmaster.DataAccess.Base;
using Microsoft.EntityFrameworkCore;

namespace MbDevelopment.Greenmaster.DataAccess.Services;

public interface ICommonNamesQueryService : IQueryService<CommonName, int>
{
}

public class CommonNamesQueryService : ICommonNamesQueryService
{
    private readonly BotanicalContext _botanicalContext;
    
    public CommonNamesQueryService(BotanicalContext botanicalContext)
    {
        _botanicalContext = botanicalContext ?? throw new ArgumentNullException(nameof(botanicalContext));
    }
    
    public Task Add(CommonName newObject)
    {
        throw new NotImplementedException();
    }

    public Task<CommonName?> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<CommonName>> GetAll()
    {
        return _botanicalContext.CommonNames.ToListAsync();
    }

    public Task Update(CommonName updatedObject)
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
using MbDevelopment.Greenmaster.Core.Botanical;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MbDevelopment.Greenmaster.DataAccess.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;

namespace MbDevelopment.Greenmaster.DataAccess.Tests.Services.GeneraQueryServiceTests;

public class GetByIdShould
{
    private readonly List<Genus> _someGenera;
    private readonly Genus _someGenus;
    private readonly Mock<BotanicalContext> _mockContext;
    private readonly Genus _someOtherGenus;


    public GetByIdShould()
    {
        _someGenus = new Genus { Id = 1, LatinName = "Hedera"};
        _someOtherGenus = new Genus { Id = 2, LatinName = "Hosta"};
        _someGenera = new List<Genus>
        {
            _someGenus, _someOtherGenus
        };
        _mockContext = new Mock<BotanicalContext>();
        
        
        
    }

    [Fact(Skip = "Not Implemented")]
    public async Task GetEmployees_WhenCalled_ReturnsEmployeeListAsync()
    {
        _mockContext.Setup(x => x.Genera.FindAsync(_someGenus.Id).Result).Returns(_someGenus);
        var service = GetQueryService();
        
        var result = await service.GetById(_someGenus.Id);
        
        Assert.NotNull(result);
        Assert.Equal(_someGenus, result);
    }

    private GeneraQueryService GetQueryService()
    {
        return new GeneraQueryService(_mockContext.Object);
    }
}
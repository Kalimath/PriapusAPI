using MbDevelopment.Greenmaster.DataAccess.Tests.Helpers;

namespace MbDevelopment.Greenmaster.DataAccess.Tests.Services;

public interface IGetByIdShould
{
    Task ReturnExpected_WhenFound();
    Task ReturnNull_WhenNotFound();
}
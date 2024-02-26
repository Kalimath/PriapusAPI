namespace MbDevelopment.Greenmaster.Core.HelperMethods;

public static class Validators
{
    public static bool IsInvalidId(int id) => id <= 0;
    public static bool IsInvalidGuid(Guid guid) => guid == Guid.Empty;
}
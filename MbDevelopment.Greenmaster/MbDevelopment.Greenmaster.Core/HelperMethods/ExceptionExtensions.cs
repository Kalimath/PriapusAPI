namespace MbDevelopment.Greenmaster.Core.HelperMethods;

public static class ExceptionExtensions
{
    /// <summary>
    /// Throws an exception if <paramref name="suspect"/> is null.
    /// </summary>
    /// <param name="suspect"></param>
    /// <exception cref="ArgumentNullException"> when null</exception>
    public static void ThrowIfNull(object suspect) => ArgumentNullException.ThrowIfNull(suspect, nameof(suspect));
}
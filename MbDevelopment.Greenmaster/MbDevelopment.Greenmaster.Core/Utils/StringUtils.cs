namespace MbDevelopment.Greenmaster.Core.Utils;

public static class StringUtils
{
    public static bool LinkMustBeAUri(string? link)
    {
        return !string.IsNullOrWhiteSpace(link)
               && Uri.TryCreate(link, UriKind.Absolute, out var outUri)
               && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps);
    }
}
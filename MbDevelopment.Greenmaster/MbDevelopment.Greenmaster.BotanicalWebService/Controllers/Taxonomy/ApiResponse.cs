namespace MbDevelopment.Greenmaster.BotanicalWebService.Controllers.Taxonomy;

public class ApiResponse<T> : ApiResponse where T : class
{
    public bool Ok { get; set; }
    public string Error { get; set; }
    public T Data { get; set; }
}

public class ApiResponse
{
    public bool Ok { get; set; }
    public string Error { get; set; } = string.Empty;
}
using System.ComponentModel.DataAnnotations;
using MbDevelopment.Greenmaster.Core;

namespace MbDevelopment.Greenmaster.BotanicalWebService;

public class CommonName
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string[] UsedByLanguages { get; set; } = {LanguageIsoCodes.English};
}
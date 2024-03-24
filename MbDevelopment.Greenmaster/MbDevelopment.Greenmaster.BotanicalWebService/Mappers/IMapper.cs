namespace MbDevelopment.Greenmaster.BotanicalWebService.Mappers;

public interface IMapper<TModel, TDto>
{
    TDto? ToDto(TModel model);
    TModel FromDto(TDto dto);
}
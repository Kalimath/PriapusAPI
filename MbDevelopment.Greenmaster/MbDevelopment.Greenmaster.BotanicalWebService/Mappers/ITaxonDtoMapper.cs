using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Mappers;

public interface ITaxonDtoMapper<TModel, TDto> 
    where TModel : class 
    where TDto : class
{
    TDto ToDto(TModel model);
    BasicTaxonDto ToBasicDto(TModel model);
    TModel FromDto(TDto dto);
    //BasicTaxonDto MapBasicParentTaxon(TModel model);
}
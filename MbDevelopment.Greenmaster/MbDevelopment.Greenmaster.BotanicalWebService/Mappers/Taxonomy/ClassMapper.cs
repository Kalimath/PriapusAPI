using HashidsNet;
using MbDevelopment.Greenmaster.Contracts.Dtos;
using MbDevelopment.Greenmaster.Core.Taxonomy;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Mappers.Taxonomy;

public class ClassMapper : IMapper<TaxonClass, ClassDto>
{
    private readonly IHashids _hashids;

    public ClassMapper(IHashids hashids)
    {
        _hashids = hashids ?? throw new ArgumentNullException(nameof(hashids));
    }

    public ClassDto? ToDto(TaxonClass model)
    {
        return new ClassDto()
        {
            Id = _hashids.Encode(model.Id),
            Name = model.LatinName,
            Description = model.Description,
            Phylum = MapParentTaxon(model)!
        };
    }

    public TaxonClass FromDto(ClassDto dto)
    {
        return new TaxonClass()
        {
            Id = _hashids.DecodeSingle(dto.Id),
            LatinName = dto.Name,
            Description = dto.Description
            //Phylum not mapped
        };
    }

    private PhylumDto MapParentTaxon(TaxonClass model)
    {
        return new PhylumDto
        {
            Id = _hashids.Encode(model.PhylumId)
        };
    }
}
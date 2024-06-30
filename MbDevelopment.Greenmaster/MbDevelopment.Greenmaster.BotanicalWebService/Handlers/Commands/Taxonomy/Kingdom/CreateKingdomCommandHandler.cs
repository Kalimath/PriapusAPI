using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Kingdom;
using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Commands.Taxonomy.Kingdom;

public class CreateKingdomCommandHandler : IRequestHandler<CreateKingdomCommand, KingdomDto>
{
    private readonly IRepository<TaxonKingdom> _repository;
    private readonly KingdomTaxonDtoMapper _taxonDtoMapper;
    
    public CreateKingdomCommandHandler(IRepository<TaxonKingdom> repository, IHashids hashids)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _taxonDtoMapper = new KingdomTaxonDtoMapper(hashids) ?? throw new ArgumentNullException(nameof(hashids));
    }
    public async Task<KingdomDto> Handle(CreateKingdomCommand request, CancellationToken cancellationToken)
    {
        if(_repository.Exists(x => x.LatinName == request.Name)) throw new ArgumentException($"Kingdom with name: {request.Name} already exists");
        _repository.Add(new TaxonKingdom {LatinName = request.Name, Description = request.Description});
        await _repository.SaveChangesAsync(cancellationToken);
        
        var createdItem = _repository.Query(x => x.LatinName == request.Name && x.Description == request.Description).FirstOrDefault();
        if (createdItem == null) throw new Exception("Failed to get created kingdom");
        return _taxonDtoMapper.ToDto(createdItem);
    }
}
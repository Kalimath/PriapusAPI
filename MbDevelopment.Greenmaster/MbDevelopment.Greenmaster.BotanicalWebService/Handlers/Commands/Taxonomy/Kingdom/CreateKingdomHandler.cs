using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Kingdom;
using MbDevelopment.Greenmaster.Contracts.Dtos;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Commands.Taxonomy.Kingdom;

public class CreateKingdomHandler : IRequestHandler<CreateKingdomCommand, KingdomDto>
{
    private readonly IRepository<TaxonKingdom> _repository;
    private readonly KingdomMapper _mapper;
    
    public CreateKingdomHandler(IRepository<TaxonKingdom> repository, IHashids hashids)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = new KingdomMapper(hashids) ?? throw new ArgumentNullException(nameof(hashids));
    }
    public async Task<KingdomDto> Handle(CreateKingdomCommand request, CancellationToken cancellationToken)
    {
        _repository.Add(new TaxonKingdom {LatinName = request.LatinName, Description = request.Description});
        await _repository.SaveChangesAsync(cancellationToken);
        
        var createdItem = _repository.Query(x => x.LatinName == request.LatinName && x.Description == request.Description).FirstOrDefault();
        if (createdItem == null) throw new Exception("Failed to get created kingdom");
        return _mapper.ToDto(createdItem)!;
    }
}
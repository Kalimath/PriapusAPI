using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Kingdom;
using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Commands.Taxonomy.Kingdom;

public class UpdateKingdomCommandHandler : IRequestHandler<UpdateKingdomCommand, KingdomDto>
{
    private readonly IRepository<TaxonKingdom> _repository;
    private readonly IHashids _hashids;
    private readonly KingdomTaxonDtoMapper _taxonDtoMapper;

    public UpdateKingdomCommandHandler(IRepository<TaxonKingdom> repository, IHashids hashids)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _hashids = hashids ?? throw new ArgumentNullException(nameof(hashids));
        _taxonDtoMapper = new KingdomTaxonDtoMapper(hashids) ?? throw new ArgumentNullException(nameof(hashids));
    }

    public async Task<KingdomDto> Handle(UpdateKingdomCommand request, CancellationToken cancellationToken)
    {
        //validation in pipeline
        var rawId = _hashids.DecodeSingle(request.Id);
        var requestedKingdom = await _repository.GetAsync(k => k.Id == rawId, cancellationToken);
        if (requestedKingdom == null) throw new KeyNotFoundException($"Kingdom with id {request.Id} not found");
        
        UpdateModel(requestedKingdom, request);

        _repository.Update(requestedKingdom);
        await _repository.SaveChangesAsync(cancellationToken);
        
        return _taxonDtoMapper.ToDto(requestedKingdom)!;
    }

    private static void UpdateModel(TaxonKingdom kingdom, UpdateKingdomCommand request)
    {
        kingdom.LatinName = request.Name;
        kingdom.Description = request.Description;
    }
}
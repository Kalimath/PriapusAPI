using FluentValidation;
using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Phylum;
using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Commands.Taxonomy.Phylum;

public class UpdatePhylumCommandHandler : IRequestHandler<UpdatePhylumCommand, PhylumDto>
{
    private readonly IRepository<TaxonPhylum> _phylumRepo;
    private readonly IRepository<TaxonKingdom> _kingdomRepo;
    private readonly IHashids _hashids;
    private readonly PhylumTaxonDtoMapper _taxonDtoMapper;
    
    public UpdatePhylumCommandHandler(IRepository<TaxonPhylum> phylumRepo, IRepository<TaxonKingdom> kingdomRepo, IHashids hashids)
    {
        _phylumRepo = phylumRepo ?? throw new ArgumentNullException(nameof(phylumRepo));
        _kingdomRepo = kingdomRepo ?? throw new ArgumentNullException(nameof(kingdomRepo));
        _hashids = hashids ?? throw new ArgumentNullException(nameof(hashids));
        _taxonDtoMapper = new PhylumTaxonDtoMapper(hashids) ?? throw new ArgumentNullException(nameof(hashids));
    }
    
    public async Task<PhylumDto> Handle(UpdatePhylumCommand request, CancellationToken cancellationToken)
    {
        var rawPhylumId = _hashids.DecodeSingle(request.Id);
        var rawKingdomId = _hashids.DecodeSingle(request.KingdomId);
       
        var requestedPhylum = await _phylumRepo.GetAsync(k => k.Id == rawPhylumId, cancellationToken);
        if (requestedPhylum == null) throw new ValidationException($"Phylum with id {request.Id} not found");
       
        var requestedKingdom = await _kingdomRepo.GetAsync(k => k.Id == rawKingdomId, cancellationToken);
        if (requestedKingdom == null) throw new ValidationException($"Kingdom with id {request.KingdomId}");
       
        UpdateModel(requestedPhylum, request, requestedKingdom);

        _phylumRepo.Update(requestedPhylum);
        await _phylumRepo.SaveChangesAsync(cancellationToken);
       
        return _taxonDtoMapper.ToDto(requestedPhylum)!;
    }

    private static void UpdateModel(TaxonPhylum phylum, UpdatePhylumCommand request, TaxonKingdom kingdom)
    {
        phylum.LatinName = request.Name;
        phylum.Description = request.Description;
        phylum.KingdomId = kingdom.Id;
        phylum.Kingdom = kingdom;
    }
}
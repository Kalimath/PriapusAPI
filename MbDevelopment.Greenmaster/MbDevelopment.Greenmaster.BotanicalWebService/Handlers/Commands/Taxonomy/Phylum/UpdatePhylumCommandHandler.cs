using FluentValidation;
using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Phylum;
using MbDevelopment.Greenmaster.Contracts.Dtos;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Commands.Taxonomy.Phylum;

public class UpdatePhylumCommandHandler : IRequestHandler<UpdatePhylumCommand, PhylumDto>
{
    private readonly IRepository<Core.Taxonomy.TaxonPhylum> _phylumRepo;
    private readonly IRepository<Core.Taxonomy.TaxonKingdom> _kingdomRepo;
    private readonly IHashids _hashids;
    private readonly PhylumMapper _mapper;
    
    public UpdatePhylumCommandHandler(IRepository<Core.Taxonomy.TaxonPhylum> phylumRepo, IRepository<Core.Taxonomy.TaxonKingdom> kingdomRepo, IHashids hashids)
    {
        _phylumRepo = phylumRepo ?? throw new ArgumentNullException(nameof(phylumRepo));
        _kingdomRepo = kingdomRepo ?? throw new ArgumentNullException(nameof(kingdomRepo));
        _hashids = hashids ?? throw new ArgumentNullException(nameof(hashids));
        _mapper = new PhylumMapper(hashids) ?? throw new ArgumentNullException(nameof(hashids));
    }
    
    public async Task<PhylumDto> Handle(UpdatePhylumCommand request, CancellationToken cancellationToken)
    {
        var decodedId = _hashids.DecodeSingle(request.Id);
        var decodedKingdomId = _hashids.DecodeSingle(request.KingdomId);
       
        var phylum = await _phylumRepo.GetAsync(k => k.Id == decodedId, cancellationToken);
        if (phylum == null) throw new ValidationException($"Phylum with id {request.Id} not found");
       
        var kingdom = await _kingdomRepo.GetAsync(k => k.Id == decodedKingdomId, cancellationToken);
        if (kingdom == null) throw new ValidationException($"Kingdom with id {request.KingdomId}");
       
        UpdateModel(phylum, request, kingdom);

        _phylumRepo.Update(phylum);
        await _phylumRepo.SaveChangesAsync(cancellationToken);
       
        return _mapper.ToDto(phylum)!;
    }

    private static void UpdateModel(Core.Taxonomy.TaxonPhylum phylum, UpdatePhylumCommand request, Core.Taxonomy.TaxonKingdom kingdom)
    {
        phylum.LatinName = request.Name;
        phylum.Description = request.Description;
        phylum.KingdomId = kingdom.Id;
        phylum.Kingdom = kingdom;
    }
}
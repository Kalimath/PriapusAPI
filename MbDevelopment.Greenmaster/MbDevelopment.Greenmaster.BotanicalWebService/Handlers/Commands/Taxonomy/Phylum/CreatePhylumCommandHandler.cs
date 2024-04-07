using FluentValidation;
using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Phylum;
using MbDevelopment.Greenmaster.Contracts.Dtos;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Commands.Taxonomy.Phylum;

public class CreatePhylumCommandHandler : IRequestHandler<CreatePhylumCommand, PhylumDto>
{
    private readonly IRepository<TaxonPhylum> _phylumRepo;
    private readonly IRepository<TaxonKingdom> _kingdomRepo;
    private readonly IHashids _hashids;
    private readonly PhylumMapper _mapper;

    public CreatePhylumCommandHandler(IRepository<TaxonPhylum> phylumRepo, IRepository<TaxonKingdom> kingdomRepo, IHashids hashids)
    {
        _phylumRepo = phylumRepo ?? throw new ArgumentNullException(nameof(phylumRepo));
        _kingdomRepo = kingdomRepo ?? throw new ArgumentNullException(nameof(kingdomRepo));
        _hashids = hashids ?? throw new ArgumentNullException(nameof(hashids));
        _mapper = new PhylumMapper(hashids) ?? throw new ArgumentNullException(nameof(hashids));
    }
    
    public async Task<PhylumDto> Handle(CreatePhylumCommand request, CancellationToken cancellationToken)
    {
        var rawKingdomId = _hashids.DecodeSingle(request.KingdomId);
        var kingdom = await _kingdomRepo.GetAsync(x => x.Id == rawKingdomId, cancellationToken);
        if (kingdom == null) throw new ValidationException("Kingdom not found");
        var phylum = new TaxonPhylum
        {
            LatinName = request.Name,
            Description = request.Description,
            Kingdom = kingdom
        };
        _phylumRepo.Add(phylum);
        await _phylumRepo.SaveChangesAsync(cancellationToken);
        var createdItem = _phylumRepo.Query(x => x.LatinName == request.Name && x.Description == request.Description).FirstOrDefault();
        if (createdItem == null) throw new Exception("Failed to get created phylum");
        return _mapper.ToDto(createdItem)!;
    }
}
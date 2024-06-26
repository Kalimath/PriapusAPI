using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Phylum;
using MbDevelopment.Greenmaster.Contracts.Dtos.Taxonomy;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Commands.Taxonomy.Phylum;

public class DeletePhylumCommandHandler : IRequestHandler<DeletePhylumCommand, PhylumDto>
{
    private readonly IRepository<TaxonPhylum> _phylumRepo;
    private readonly IHashids _hashids;
    private readonly PhylumTaxonDtoMapper _taxonDtoMapper;

    public DeletePhylumCommandHandler(IRepository<TaxonPhylum> phylumRepo, IHashids hashids)
    {
        _phylumRepo = phylumRepo ?? throw new ArgumentNullException(nameof(phylumRepo));
        _hashids = hashids ?? throw new ArgumentNullException(nameof(hashids));
        _taxonDtoMapper = new PhylumTaxonDtoMapper(hashids) ?? throw new ArgumentNullException(nameof(hashids));
    }

    public async Task<PhylumDto> Handle(DeletePhylumCommand request, CancellationToken cancellationToken)
    {
        var decodedId = _hashids.DecodeSingle(request.Id);
        var phylum = await _phylumRepo.GetAsync(phylum => phylum.Id == decodedId, cancellationToken);
        if (phylum == null) throw new KeyNotFoundException($"Phylum with id: {decodedId} not found");
        
        _phylumRepo.Delete(phylum);
        await _phylumRepo.SaveChangesAsync(cancellationToken);
        return new PhylumDto
        {
            Id = request.Id,
            Name = phylum.LatinName,
            Description = phylum.Description,
            Kingdom = new KingdomDto
            {
                Id = _hashids.Encode(phylum.KingdomId),
                Name = null!,
                Description = null!
            }
        };
    }
}
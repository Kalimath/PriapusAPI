using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers;
using MbDevelopment.Greenmaster.Contracts.Commands.TaxonKingdom;
using MbDevelopment.Greenmaster.Contracts.Dtos;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Handlers.Commands.TaxonKingdom;

public class DeleteKingdomHandler : IRequestHandler<DeleteKingdomCommand, KingdomDto>
{
    private readonly IRepository<Core.Taxonomy.TaxonKingdom> _repository;
    private readonly IHashids _hashids;
    private readonly KingdomMapper _mapper;

    public DeleteKingdomHandler(IRepository<Core.Taxonomy.TaxonKingdom> repository, IHashids hashids)
    {
        _repository = repository;
        _hashids = hashids;
        _mapper = new KingdomMapper(hashids);
    }
    
    public async Task<KingdomDto> Handle(DeleteKingdomCommand request, CancellationToken cancellationToken)
    {
        var decodedId = _hashids.DecodeSingle(request.Id);
        var kingdom = await _repository.GetAsync(i => i.Id == decodedId, cancellationToken);
        if (kingdom == null) throw new KeyNotFoundException($"Kingdom with id {request.Id} not found");
        _repository.Delete(kingdom);
        await _repository.SaveChangesAsync(cancellationToken);
        return _mapper.ToDto(kingdom)!;
    }
}
using HashidsNet;
using MbDevelopment.Greenmaster.BotanicalWebService.Mappers;
using MbDevelopment.Greenmaster.Contracts.WebApi.Taxonomy.Dtos;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.CQRS.Commands.Handlers;

public class UpdateKingdomHandler : IRequestHandler<UpdateKingdomCommand, KingdomDto>
{
    private readonly IRepository<TaxonKingdom> _repository;
    private readonly IHashids _hashids;
    private readonly KingdomMapper _mapper;

    public UpdateKingdomHandler(IRepository<TaxonKingdom> repository, IHashids hashids)
    {
        _repository = repository;
        _hashids = hashids;
        _mapper = new KingdomMapper(hashids);
    }

    public async Task<KingdomDto> Handle(UpdateKingdomCommand request, CancellationToken cancellationToken)
    {
        //validation in pipeline
        var rawId = _hashids.DecodeSingle(request.Id);
        var kingdom = await _repository.GetAsync(k => k.Id == rawId, cancellationToken);
        if (kingdom == null) throw new KeyNotFoundException($"Kingdom with id {request.Id} not found");
        
        kingdom.LatinName = request.Name;
        kingdom.Description = request.Description;
        
        _repository.Update(kingdom);
        await _repository.SaveChangesAsync(cancellationToken);
        
        return _mapper.ToDto(kingdom)!;
        
        
        
        
        
        /*ValidationResult result = await new UpdateAccessoryCommandValidator().ValidateAsync(request);
        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }

        Accessory accessory = await _repository.GetAsync(a => a.Id == request.Id);

        if (!string.IsNullOrEmpty(request.Name)) accessory.Name = request.Name;
        if (!string.IsNullOrEmpty(request.Description)) accessory.Description = request.Description;
        if (request.Available) accessory.Available = request.Available;

        _repository.Update(accessory);
        await _repository.SaveChangesAsync();

        return _accessoriesDxos.MapAccessoryDto(accessory);*/
    }
}
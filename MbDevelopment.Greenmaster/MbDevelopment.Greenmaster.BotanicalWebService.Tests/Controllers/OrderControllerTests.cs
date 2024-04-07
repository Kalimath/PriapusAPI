using MbDevelopment.Greenmaster.BotanicalWebService.Controllers.Taxonomy;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Order;
using MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Order;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Tests.Controllers;

public class OrderControllerTests : ControllerTestBase
{
    const string SomeName = "some name";
    const string SomeDesc = "some description";
    
    [Fact]
    public override void GetById_CallsMediatr_WithGetByIdQuery()
    {
        _ = Controller.Get(SomeHashedId);

        Mediator.Received(1).Send(Arg.Is<GetOrderByIdQuery>(x => x.Id == SomeHashedId));
    }
    [Fact]
    public override void GetAll_CallsMediatr_WithGetAllQuery()
    {
        _ = Controller.GetAll();

        Mediator.Received(1).Send(Arg.Any<GetAllOrdersQuery>());
    }
    [Fact]
    public override void Create_CallsMediatr_WithCreateCommand()
    {
        var command = new CreateOrderCommand(SomeName, SomeDesc, SomeHashedId);
        
        _ = Controller.Create(command);

        Mediator.Received(1).Send(Arg.Is<CreateOrderCommand>(x => 
            x.Name == SomeName && 
            x.Description == SomeDesc && 
            x.ClassId == SomeHashedId)
        );
    }
    [Fact]
    public override void Update_CallsMediatr_WithUpdateCommand()
    {
        var hashedClassId = HashIds.Encode(4854);
        
        var command = new UpdateOrderCommand(SomeHashedId, SomeName, SomeDesc, hashedClassId);
        
        _ = Controller.Update(command);

        Mediator.Received(1).Send(Arg.Is<UpdateOrderCommand>(x => 
            x.Id == SomeHashedId && 
            x.Name == SomeName && 
            x.Description == SomeDesc && 
            x.ClassId == hashedClassId)
        );
    }
    [Fact]
    public override void Delete_CallsMediatr_WithDeleteCommand()
    {
        _ = Controller.Delete(new DeleteOrderCommand(SomeHashedId));

        Mediator.Received(1).Send(Arg.Is<DeleteOrderCommand>(x => x.Id == SomeHashedId));
    }

    [Fact]
    public override void Ctor_ThrowsArgumentNullException_WhenMediatorIsNull()
    {
        OrderController Act() => new(null!);
        
        Assert.Throws<ArgumentNullException>(Act);
    }
}
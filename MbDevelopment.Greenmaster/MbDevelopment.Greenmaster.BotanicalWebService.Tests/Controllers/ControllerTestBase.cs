using MbDevelopment.Greenmaster.BotanicalWebService.Controllers.Taxonomy;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Tests.Controllers;

public abstract class ControllerTestBase
{
    
    protected const string SomeHashedId = "mkewobhuiqbnq";
    protected const int SomeRawId = 1207;
    protected readonly IMediator Mediator;
    protected readonly OrderController Controller;
    protected readonly IHashids HashIds;

    protected ControllerTestBase()
    {
        Mediator = Substitute.For<IMediator>();
        Controller = new OrderController(Mediator);
        HashIds = Substitute.For<IHashids>();
        
        HashIds.Encode(SomeRawId).Returns(SomeHashedId);
    }

    public abstract void GetById_CallsMediatr_WithGetByIdQuery();
    public abstract void GetAll_CallsMediatr_WithGetAllQuery();
    public abstract void Create_CallsMediatr_WithCreateCommand();
    public abstract void Update_CallsMediatr_WithUpdateCommand();
    public abstract void Delete_CallsMediatr_WithDeleteCommand();
    public abstract void Ctor_ThrowsArgumentNullException_WhenMediatorIsNull();
}
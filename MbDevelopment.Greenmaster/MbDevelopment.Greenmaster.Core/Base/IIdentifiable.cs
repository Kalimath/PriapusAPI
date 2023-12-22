namespace MbDevelopment.Greenmaster.Core.Base;

public interface IIdentifiable<T>
{
    public T Id { get; set; }
}
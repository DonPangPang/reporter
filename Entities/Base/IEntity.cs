namespace Reporter.Entities.Base;

public interface IEntity
{
    public Guid Id { get; set; }

    public DateTime CreateTime { get; set; }
}

public abstract class EntityBase : IEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreateTime { get; set; } = DateTime.Now;
}
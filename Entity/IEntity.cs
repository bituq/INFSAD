namespace Entities;

public interface IEntity
{
    public int Attack { get; set; }
    public int Defence { get; set; }

    public void Interact(IEntity entity);
}
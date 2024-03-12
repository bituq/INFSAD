namespace Cards.States;

public interface ICardState
{
    public ACard Card { get; set; }
    public void Draw();
    public void Discard();
    public void Play();
    public void SetIdle();
}

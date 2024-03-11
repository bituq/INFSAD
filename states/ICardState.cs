namespace Cards.States;

public interface ICardState
{
    public void Draw();
    public void Discard();
    public void Play();
    public void SetIdle();
    public void Tap();
    public void Untap();
}

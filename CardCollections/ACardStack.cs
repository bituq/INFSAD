namespace Cards.Collections;

public abstract class ACardStack
{
    protected readonly Stack<ACard> cards = new();
    public IReadOnlyCollection<ACard> Cards => cards;
    public void Push(ACard card) => cards.Push(card);
    public ACard Pop() => cards.Pop();
    
}
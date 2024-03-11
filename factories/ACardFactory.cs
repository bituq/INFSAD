using Cards.States;

namespace Cards.Factories;

public abstract class ACardFactory<T1, T2>
    where T1 : ACard<T2>
    where T2 : ICardState
{
    public abstract T1 CreateCard(Color color);
}

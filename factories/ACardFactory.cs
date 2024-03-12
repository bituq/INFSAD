using Colors;

namespace Cards.Factories;

public abstract class ACardFactory<T>
    where T : ACard
{
    public abstract T CreateCard(Color color);
}

using Cards.States;

namespace Cards.Factories;

public abstract class APermanentFactory : ACardFactory<APermanent, IPermanentState>
{
    protected readonly Player owner;

    public APermanentFactory(Player owner)
    {
        this.owner = owner;
    }
}

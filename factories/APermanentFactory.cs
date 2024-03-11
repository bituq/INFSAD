using Cards.States;

namespace Cards.Factories;

public abstract class APermanentFactory : ACardFactory<APermanent>
{
    protected readonly Player owner;

    public APermanentFactory(Player owner)
    {
        this.owner = owner;
    }
}

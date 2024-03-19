using Cards.States;

namespace Cards;

public abstract class APermanent : ACard
{
    public bool IsTapped { get; private set; }

    public virtual bool Tap()
    {
        if (State is not PlayedState)
        {
            Console.WriteLine("Cannot tap while in " + State.GetType().Name);
            return false;
        }

        Console.WriteLine($"{this} has been tapped.");

        IsTapped = true;
        return true;
    }

    public virtual bool Untap()
    {
        if (State is not PlayedState)
        {
            Console.WriteLine("Cannot untap while in " + State.GetType().Name);
            return false;
        }

        Console.WriteLine($"{this} has been untapped.");

        IsTapped = false;
        return true;
    }
}

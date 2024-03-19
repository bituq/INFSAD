using Cards;
using Entities;

namespace Phases.States;

public class MainPhase : IPhaseState<EndingPhase>
{
    public Turn Turn { get; private set; }

    public MainPhase(Turn turn)
    {
        Console.WriteLine("In main phase");

        Turn = turn;
    }

    public void Attack(IEntity from, IEntity to)
    {
        from.Interact(to);
    }

    public void PlayCard(ACard card)
    {
        card.State.Play();
    }

    public EndingPhase Next()
    {
        return new EndingPhase(Turn);
    }
}

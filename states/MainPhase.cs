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

    public bool PlayCard(ACard card)
    {
        var lands = Turn.Player.GetUnusedTappedLands(card.Color);

        if (lands.Count < card.Cost)
        {
            Console.WriteLine($"Not enough energy to play {card}");
            return false;
        }

        for (int i = 0; i < card.Cost; i++)
            lands[i].Used = true;

        card.State.Play();
        Console.WriteLine($"Played {card}");
        return true;
    }

    public EndingPhase Next()
    {
        return new EndingPhase(Turn);
    }
}

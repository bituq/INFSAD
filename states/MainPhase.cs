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

    public bool UseLand(Land land)
    {
        if (land.IsTapped)
            return false;

        land.Tap();
        return true;
    }

    public bool PlayCard(Land card)
    {
        Console.WriteLine($"Played {card}");
        card.State.Play();
        return true;
    }

    public bool PlayCard(ACard card, IEntity? target = null) {
        if (!UseLands(card))
            return false;

        card.State.Play();
        Console.WriteLine($"Played {card}");

        if (card is ICardWithEffect cardWithEffect && cardWithEffect.Effect != null)
        {
            if (cardWithEffect.IsContinuous || !cardWithEffect.EffectUsed)
                cardWithEffect.Effect.Activate(new EffectParameters() { turn = Turn, target = target });

            if (cardWithEffect.IsInstantaneous)
                DiscardCard(card);
        }

        return true;
    }

    private bool UseLands(ACard card)
    {
        var lands = Turn.Player.GetUnusedTappedLands(card.Color);

        if (lands.Count < card.Cost)
        {
            Console.WriteLine($"Not enough energy to play {card}");
            return false;
        }

        for (int i = 0; i < card.Cost; i++)
            lands[i].Used = true;

        return true;
    }

    public void DiscardCard(ACard card)
    {
        card.State.Discard();
    }

    public EndingPhase Next()
    {
        return new EndingPhase(Turn);
    }
}

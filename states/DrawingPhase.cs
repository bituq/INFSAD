using Cards;

namespace Phases.States;

public class DrawingPhase : IPhaseState<MainPhase>
{
    public Turn Turn { get; private set; }

    public DrawingPhase(Turn turn)
    {
        Turn = turn;

        Console.WriteLine("In drawing phase.");

        DrawCard(1);
    }

    public MainPhase Next()
    {
        return new MainPhase(Turn);
    }

    public List<ACard> DrawCard(int count = 1)
    {
        List<ACard> cards = new();

        for (int i = 0; i < count; i++)
        {
            if (Turn?.Player.Deck.Count == 0)
                break;
            cards.Add(Turn?.Player.Deck.First());
            Turn?.Player?.Deck?.First()?.State?.Draw();
        }

        return cards;
    }
}
using Cards;

namespace Phases.States;

public class PreparationPhase : IPhaseState<DrawingPhase>
{
    public Turn Turn { get; private set; }

    public PreparationPhase(Turn turn)
    {
        Turn = turn;
        
        Console.WriteLine("In preparation phase.");
        
        foreach (ACard card in turn.Player.Battlefield)
            if (card is APermanent permanent && permanent.IsTapped)
            {
                permanent.Untap();
                if (permanent is Land land)
                    land.Used = false;
            }
    }

    public DrawingPhase Next()
    {
        return new DrawingPhase(Turn);
    }
}

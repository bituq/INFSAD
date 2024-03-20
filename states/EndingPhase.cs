namespace Phases.States;

public class EndingPhase : IPhaseState<PreparationPhase>
{
    public Turn Turn { get; private set; }

    public EndingPhase(Turn turn)
    {
        Turn = turn;
    }

    public PreparationPhase Next()
    {
        return Turn.Opponent.StartTurn(Turn.Player);
    }
}
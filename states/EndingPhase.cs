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
        Turn.State = new PreparationPhase(Turn);
        return Turn.State;
    }
}
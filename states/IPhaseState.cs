namespace Phases.States;

public interface IPhaseState<NextPhase>
{
    public NextPhase Next();
}

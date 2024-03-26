using Entities;
using Phase.States;
using Phases;

public struct EffectParameters
{
    public required Turn turn;
    public IEntity? target;
    public AttackPhase? attackPhase;
}
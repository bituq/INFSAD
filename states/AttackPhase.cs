using Cards;
using Entities;
using Phases;
using Phases.States;

namespace Phase.States;

public class AttackPhase : IPhaseState<MainPhase>
{
    private MainPhase mainPhase;
    private IEntity from;
    private IEntity to;
    private bool countered;

    public AttackPhase(MainPhase mainPhase, IEntity from, IEntity to)
    {
        this.mainPhase = mainPhase;
        this.from = from;
        this.to = to;
    }

    public void Counter()
    {
        countered = true;
    }

    public bool PlaySpell(Spell spell)
    {
        spell.State.Play();

        if (spell.Effect != null)
        {
            if (spell.IsContinuous || !spell.EffectUsed)
                spell.Effect.Activate(
                    new EffectParameters() { turn = mainPhase.Turn, attackPhase = this }
                );

            if (spell.IsInstantaneous)
                spell.State.Discard();
        }
        return true;
    }

    public MainPhase Next()
    {
        if (!countered)
        {
            Console.WriteLine("ÇOUNTERED;");
            from.Interact(to);
        }
        return mainPhase;
    }
}

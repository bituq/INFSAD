using CardGame;
using Phases.States;

namespace Phases;

public class Turn
{
    readonly Player player;
    PreparationPhase state;

    public Turn(Player player)
    {
        this.player = player;
        State = new PreparationPhase(this);
    }

    public Player Player => player;

    public PreparationPhase State { get => state; set => state = value; }
}

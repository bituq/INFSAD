using CardGame;
using Phases.States;

namespace Phases;

public class Turn
{
    public Player Player { get; private set; }
    public Player Opponent { get; private set; }
    PreparationPhase state;

    public Turn(Player player, Player opponent)
    {
        Player = player;
        Opponent = opponent;
        State = new PreparationPhase(this);
    }

    public PreparationPhase State
    {
        get => state;
        set => state = value;
    }
}

using Cards.States;

namespace Cards;

public class Land : APermanent
{
    public override required IPermanentState State { get; set; }
}

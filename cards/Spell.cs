using Cards.States;

namespace Cards;

public class Spell : ACard, ICardWithEffect
{
    public Effect Effect { get; set; }
    public bool IsInstantaneous { get; set; } = false;
    public bool IsContinuous { get; set; } = false;
}

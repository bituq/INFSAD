using Cards.States;

namespace Cards;

public class Spell : ACard
{
    private List<Effect> effects = new();
    public bool IsInstantaneous { get; set; }

    public List<Effect> Effects
    {
        get => effects;
        set => effects = value;
    }
}

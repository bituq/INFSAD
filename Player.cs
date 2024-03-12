using Cards;
using Cards.Collections;

namespace CardGame;

public class Player
{
    private readonly string name;
    public  int lives = 10;

    public Pool Pool { get; private set; }
    public CardCollection Deck { get; private set; } = new();
    public CardCollection Hand { get; private set; } = new();
    public CardCollection DiscardPile { get; private set; } = new();
    public CardCollection Battlefield { get; private set; } = new();
    public EnergyPool EnergyPool { get; private set; } = new();

    public Player(string name, IEnumerable<ACard> pool)
    {
        this.name = name;
        Pool = new(this, pool);
    }

    public void Attack(Player opponent, Creature creature)
    {
        opponent.lives -= creature.GetAttackValue();
    }

    public override string ToString()
    {
        return name;
    }
}

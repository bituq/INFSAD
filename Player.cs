using Cards;
using Cards.Collections;
using Cards.States;
using Entities;

namespace CardGame;

public class Player : IEntity
{
    private readonly string name;
    private int defence;

    public int Lives { get; set; } = 10;
    public Pool Pool { get; private set; }
    public CardCollection Deck { get; private set; } = new();
    public CardCollection Hand { get; private set; } = new();
    public CardCollection DiscardPile { get; private set; } = new();
    public CardCollection Battlefield { get; private set; } = new();
    public EnergyPool EnergyPool { get; private set; } = new();
    public int Attack { get; set; }
    public int Defence
    {
        get => defence;
        set
        {
            defence = value;
            if (value < 0)
                Lives += value;
        }
    }

    public Player(string name, IEnumerable<ACard> pool)
    {
        this.name = name;
        Pool = new(this, pool);
    }

    public void Draw(ACard card)
    {
        card.State.Draw();
    }

    public void Play(ACard card)
    {
        card.State.Play();
    }

    public void Discard(ACard card)
    {
        card.State.Discard();
    }

    public void ToDeck(ACard card)
    {
        card.State.SetIdle();
    }

    public override string ToString()
    {
        return name;
    }

    public void Interact(IEntity entity)
    {
        entity.Defence -= Attack;
        Defence -= entity.Attack;
    }
}

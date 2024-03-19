using System.Collections;
using Cards;
using Cards.Collections;
using Colors;
using Entities;
using Phases;

namespace CardGame;

public class Player : IEntity
{
    private readonly string name;
    private int defence;
    private readonly Pool pool = new();

    Turn turn;
    public int Lives { get; set; } = 10;
    public CardCollection Deck { get; private set; } = new();
    public CardCollection Hand { get; private set; } = new();
    public CardCollection DiscardPile { get; private set; } = new();
    public CardCollection Battlefield { get; private set; } = new();
    public Pool Pool => pool.GetInstance();
    public int Attack { get; set; }
    public int Defence
    {
        get => defence;
        set
        {
            if (defence > value)
                Console.WriteLine($"{this} was attacked");

            defence = value;
            if (value < 0)
                Lives += value;
        }
    }

    public Player(string name, IEnumerable<ACard> pool)
    {
        this.name = name;
        Pool.AssignCards(this, pool);
    }

    public List<Land> GetUnusedTappedLands(AColor color)
    {
        List<Land> lands = new();

        foreach (ACard card in Battlefield)
        {
            if (card is Land land)
            {
                if (land.Color.GetType() == color.GetType() && !land.Used && land.IsTapped)
                {
                    lands.Add(land);
                }
            }
        }

        return lands;
    }

    public Turn StartTurn()
    {
        turn = new Turn(this);
        return turn;
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

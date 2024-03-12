using Cards;
using Cards.Collections;

namespace CardGame;

class Player
{
    private string name;
    private int lives = 10;

    public Stack<ACard> Deck { get; set; } = new();
    public Stack<ACard> Hand { get; set; } = new();
    public Stack<ACard> DiscardPile { get; set; } = new();
    public List<ACard> Battlefield { get; set; } = new();
    public EnergyPool EnergyPool { get; set; } = new();

    public Player(string name, Deck deck)
    {
        this.name = name;
    }

    public void Draw()
    {
        Deck.DrawCard();
    }

    public void Play(Card card)
    {
        hand.RemoveCard(card);
        battlefield.AddCard(card);
    }

    public void Discard(Card card)
    {
        battlefield.RemoveCard(card);
        discardPile.AddCard(card);
    }

    public void Attack(Player opponent, Creature creature)
    {
        opponent.lives -= creature.GetAttackValue();
    }
}

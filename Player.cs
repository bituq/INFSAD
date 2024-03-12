using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace CardGame;
class Player 
{
    private string name;
    private int lives = 10;
    private Deck deck;
    private Hand hand = new Hand();
    private DiscardPile discardPile = new DiscardPile();
    private Battlefield battlefield = new Battlefield();
    private EnergyPool energyPool = new EnergyPool();

    public Deck Deck { get => this.deck; }
    public Hand Hand { get => this.hand; }
    public DiscardPile DiscardPile { get => this.discardPile; }
    public Battlefield Battlefield { get => this.battlefield; }
    public EnergyPool EnergyPool { get => this.energyPool; }

    public Player(string name, Deck deck)
    {
        this.name = name;
        this.deck = deck;
        
    }
    public void Draw()
    {
        deck.DrawCard();
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
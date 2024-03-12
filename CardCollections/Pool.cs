using CardGame;
using Cards.States;

namespace Cards.Collections;

public class Pool
{
    private readonly Dictionary<ACard, CardCollection?> cards = new();
    private readonly Player player;

    public Pool(Player player, IEnumerable<ACard> cards)
    {
        this.player = player;

        foreach (ACard card in cards)
        {
            RegisterCard(card);
            this.cards.Add(card, null);
            card.State = new IdleState() { Card = card }; // This will automatically move the card to the player's deck.
        }
    }

    private void RegisterCard(ACard card)
    {
        if (cards.ContainsKey(card))
            return; // Do not assign the event

        card.OnStateChanged += CardStateChanged(card);
    }

    private void DisposeCard(ACard card)
    {
        card.OnStateChanged -= CardStateChanged(card);
    }

    public void Dispose()
    {
        foreach (ACard card in cards.Keys)
            DisposeCard(card);

        cards.Clear();
    }

    private ACard.ChangeState CardStateChanged(ACard card)
    {
        return (state) =>
        {
            // Only attempt to remove the card if it already exists in the dictionary
            if (cards.TryGetValue(card, out CardCollection? currentCollection))
                currentCollection?.Remove(card);

            if (state is DiscardState)
            {
                SetCardCollection(player.DiscardPile, card);
                Console.WriteLine($"{card} is moved to {player}'s discard pile.");
            }
            else if (state is DrawnState)
            {
                SetCardCollection(player.Hand, card);
                Console.WriteLine($"{card} is moved to {player}'s hand.");
            }
            else if (state is IdleState)
            {
                SetCardCollection(player.Deck, card);
                Console.WriteLine($"{card} is moved to {player}'s deck.");
            }
            else if (state is PlayedState)
            {
                SetCardCollection(player.Battlefield, card);
                Console.WriteLine($"{card} is moved to {player}'s battlefield.");
            }
        };
    }

    private void SetCardCollection(CardCollection collection, ACard card)
    {
        collection.Push(card);
        cards[card] = collection;
    }
}

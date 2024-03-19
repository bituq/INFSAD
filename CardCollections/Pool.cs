using CardGame;
using Cards.States;
using Singleton;

namespace Cards.Collections;

public class Pool : ASingleton<Pool>
{
    private readonly Dictionary<ACard, (Player, CardCollection?)> cards = new();

    public void AssignCards(Player player, IEnumerable<ACard> cards)
    {
        foreach (ACard card in cards)
        {
            RegisterCard(card);
            this.cards.Add(card, (player, null));
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
            if (cards.TryGetValue(card, out (Player, CardCollection?) currentCollection))
                currentCollection.Item2?.Remove(card);

            Player player = currentCollection.Item1;

            if (state is DiscardState)
            {
                SetCardCollection(player.DiscardPile, card);
                Console.WriteLine($"{card} is moved to {player}'s discard pile.");
            }
            else if (state is DrawnState)
            {
                if (player.Deck.Count == 0)
                {
                    player.Lives = 0;
                    Console.WriteLine($"{player} is killed because their deck is empty");
                    return;
                }
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
        cards[card] = (cards[card].Item1, collection);
    }
}

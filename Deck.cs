namespace CardGame
{
    public class Deck
    {
        private Stack<Card> cards = new Stack<Card>();
        private Hand? hand;
        public Hand? Hand { get => hand; set => hand = value; }

        public void CreateDeck(int size = 30)
        {
            for (int i = 0; i < size; i++)
            {
                cards.Push(new Card("Card" + i));
            }
        }
        
        public void DrawCard()
        {
            if (cards.Count > 0)
                Hand?.AddCard(cards.Pop());
        }

        public void RemoveCard(Card card)
        {
            if(cards.Any())
                cards.Pop();
        }
    }
}
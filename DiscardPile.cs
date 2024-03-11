namespace CardGame
{
    public class DiscardPile
    {
        private Stack<Card> cards = new Stack<Card>();
        
        public void AddCard(Card card)
        {
            cards.Push(card);
        }
    }
}
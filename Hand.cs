namespace CardGame
{
    public class Hand
    {
        private Stack<Card> cards = new Stack<Card>();

        public void CreateHand(int size = 7)
        {
            for (int i = 0; i < size; i++)
            {
                cards.Push(new Card("Card" + i));
            }
        }
        
        public void AddCard(Card card)
        {
            cards.Push(card);
        }

        public void RemoveCard(Card card)
        {
            cards.Pop();
        }
    }
}
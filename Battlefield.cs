namespace CardGame
{
    public class Battlefield
    {
        private List<Card> cards = new List<Card>();

        public List<Card> GetCards()
        {
            return this.cards;
        }
        public void AddCard(Card card)
        {
            cards.Add(card);
        }
        public void RemoveCard(Card card)
        {
            cards.Remove(card);
        }
    }
}
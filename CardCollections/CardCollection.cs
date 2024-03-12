using System.Collections;

namespace Cards.Collections;

public class CardCollection : ICollection<ACard>
{
    protected List<ACard> cards = new();
    public IReadOnlyCollection<ACard> Cards => cards;

    public int Count => cards.Count;

    public bool IsReadOnly => true;

    public void Push(ACard item)
    {
        cards.Add(item);
    }

    public ACard? Pop()
    {
        if (cards.Count > 0)
        {
            ACard temp = cards[cards.Count - 1];
            cards.RemoveAt(cards.Count - 1);
            return temp;
        }
        else
            return default;
    }

    public bool Remove(ACard item)
    {
        return cards.Remove(item);
    }

    public void Clear()
    {
        cards.Clear();
    }

    public void Add(ACard item)
    {
        Push(item);
    }

    public bool Contains(ACard item)
    {
        return cards.Contains(item);
    }

    public void CopyTo(ACard[] array, int arrayIndex)
    {
        cards.CopyTo(array, arrayIndex);
    }

    public IEnumerator<ACard> GetEnumerator()
    {
        return Cards.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return cards.GetEnumerator();
    }

    public ACard this[int i]
    {
        get => cards[i];
    }
}

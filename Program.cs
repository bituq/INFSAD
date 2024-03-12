using CardGame;
using Cards;
using Cards.Factories;

CreatureFactory creatures = new();
SpellFactory spells = new();

Player player =
    new(
        "Dylan",
        new List<ACard>()
        {
            creatures.CreateCard(new(), 2, 1, 5),
            spells.CreateInstantCard(new(), 4, Array.Empty<Effect>()),
            spells.CreateCard(new(), 2, Array.Empty<Effect>())
        }
    );

ACard card = player.Deck.First();

player.Draw(card);
player.Discard(card);
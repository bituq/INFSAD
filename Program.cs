using CardGame;
using Cards;
using Cards.Factories;
using Cards.States;

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

player.Deck[0].State = new DrawnState() { Card = player.Deck[0] };

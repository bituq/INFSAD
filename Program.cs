using CardGame;
using Cards;
using Cards.Factories;

CreatureFactory creatures = new();
SpellFactory spells = new();

Creature card1 = creatures.CreateCard(new(), 2, 1, 5);

Player dylan =
    new(
        "Dylan",
        new List<ACard>()
        {
            card1,
            spells.CreateInstantCard(new(), 4, Array.Empty<Effect>()),
            spells.CreateCard(new(), 2, Array.Empty<Effect>())
        }
    );

Creature card2 = creatures.CreateCard(new(), 1, 3, 2);
Player joy = new("Joy", new List<ACard>() { card2 });


card1.State.Draw();
card1.State.Play();

card2.State.Draw();
card2.State.Play();

Console.WriteLine($"Card1: {card1.Attack} {card1.Defence}, Card2: {card2.Attack} {card2.Defence}");

card2.Interact(card1);

Console.WriteLine($"Card1: {card1.Attack} {card1.Defence}, Card2: {card2.Attack} {card2.Defence}");

card2.Interact(card1);

Console.WriteLine($"Card1: {card1.Attack} {card1.Defence}, Card2: {card2.Attack} {card2.Defence}");

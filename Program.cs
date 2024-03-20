using CardGame;
using Cards;
using Cards.Factories;
using Colors;
using Phases;
using Phases.States;

CreatureFactory creatures = new();
SpellFactory spells = new();

Creature card1 = creatures.CreateCard(new Green(), 2, 1, 5);

Player dylan =
    new(
        "Dylan",
        new List<ACard>()
        {
            card1,
            spells.CreateInstantCard(new Blue(), 4, new Effect((turn) => {})),
            spells.CreateCard(new Red(), 2, new Effect((turn) => {}))
        }
    );

Creature card2 = creatures.CreateCard(new Blue(), 1, 3, 2);
Player joy = new("Joy", new List<ACard>() { card2 });


Turn dylansTurn = dylan.StartTurn();
PreparationPhase dpp = dylansTurn.State;

DrawingPhase drawingPhase = dpp.Next();
drawingPhase.DrawCard(3);

MainPhase mainPhase = drawingPhase.Next();
mainPhase.PlayCard(card1);
mainPhase.Attack(card1, joy);
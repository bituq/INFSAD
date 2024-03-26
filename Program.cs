using CardGame;
using Cards;
using Cards.Factories;
using Colors;
using Phases;
using Phases.States;

CreatureFactory creatures = new();
LandFactory lands = new();
SpellFactory spells = new();

Land aroldLand1 = lands.CreateCard(new Blue());
Land aroldLand2 = lands.CreateCard(new Blue());
Land aroldLand3 = lands.CreateCard(new Green());
Creature aroldCreature1 = creatures.CreateCard(new Blue(), 2, 2, 2, new(par => { 
    par.turn.Opponent.Hand[new Random().Next(0, par.turn.Opponent.Hand.Count - 1)].State.Discard();
}));
Spell aroldSpell1 = spells.CreateInstantCard(new Green(), 1, new (par => {
    if (par.target != null)
    {
        par.target.Attack += 3;
        par.target.Defence += 3;
    }
}, par => {
    if (par.target != null)
    {
        par.target.Attack -= 3;
        par.target.Defence -= 3;
    }
}));
Spell bryceSpell1 = spells.CreateInstantCard(new Red(), 1, new (par => {
    par.attackPhase?.Counter();
}));

Player arold =
    new(
        "Arold",
        new List<ACard>()
        {
            aroldLand1,
            aroldLand2,
            aroldLand3,
            aroldCreature1,
            spells.CreateCard(new Blue()),
            spells.CreateCard(new Blue()),
            spells.CreateCard(new Red()),
            spells.CreateCard(new Red()),
            spells.CreateCard(new Red()),
            spells.CreateCard(new Red()),
            spells.CreateCard(new Red()),
            spells.CreateCard(new Red()),
            spells.CreateCard(new Red()),
        }
    );

Land bryceLand1 = lands.CreateCard(new Green());
Land bryceLand2 = lands.CreateCard(new Green());

Player bryce =
    new(
        "Bryce",
        new List<ACard>()
        {
            bryceLand1,
            bryceLand2,
            spells.CreateCard(new Green()),
            spells.CreateCard(new Green()),
            spells.CreateCard(new Red()),
            spells.CreateCard(new Red()),
            spells.CreateCard(new Red()),
            spells.CreateCard(new Red()),
            spells.CreateCard(new Red()),
            spells.CreateCard(new Red()),
            spells.CreateCard(new Red()),
            spells.CreateCard(new Red()),
            spells.CreateCard(new Red()),
        }
    );

// Arold
PreparationPhase phase1 = arold.StartTurn(bryce);
DrawingPhase phase2 = phase1.Next();

phase2.DrawCard(8);
Console.WriteLine($"{phase2.Turn.Player} gets a card from the deck");
Console.WriteLine($"{phase2.Turn.Player} has {phase2.Turn.Player.Hand.Count} cards.");

MainPhase phase3 = phase2.Next();
phase3.PlayCard(aroldLand1);
phase3.PlayCard(aroldLand2);

// Bryce
DrawingPhase phase4 = phase3.Next().Next().Next();
phase4.DrawCard(7);

Console.WriteLine(
    $"{phase3.Turn.Player} has {phase3.Turn.Player.Hand.Count} cards in hand, {phase3.Turn.Player.Battlefield.Where(card => card is Land).Count()} lands on the floor, {phase3.Turn.Player.Lives} lives."
);
Console.WriteLine(
    $"{phase3.Turn.Opponent} has {phase3.Turn.Opponent.Hand.Count} cards, {phase3.Turn.Opponent.Battlefield.Count} cards on the floor, {phase3.Turn.Opponent.Lives} lives."
);

phase4.DrawCard();
Console.WriteLine($"{phase4.Turn.Player} has {phase4.Turn.Player.Hand.Count} cards.");

MainPhase phase5 = phase4.Next();
phase5.PlayCard(bryceLand1);

Console.WriteLine(
    $"{phase5.Turn.Player} has {phase5.Turn.Player.Hand.Count} cards in hand, {phase5.Turn.Player.Battlefield.Where(card => card is Land).Count()} lands on the floor, {phase5.Turn.Player.Lives} lives."
);
Console.WriteLine(
    $"{phase5.Turn.Opponent} has {phase5.Turn.Opponent.Hand.Count} cards, {phase5.Turn.Opponent.Battlefield.Where(card => card is Land).Count()} lands on the floor, {phase5.Turn.Opponent.Lives} lives."
);

// Arold
DrawingPhase phase6 = phase5.Next().Next().Next();
phase6.DrawCard();
Console.WriteLine($"{phase6.Turn.Player} has {phase6.Turn.Player.Hand.Count} cards in hand");

MainPhase phase7 = phase6.Next();
phase7.PlayCard(aroldLand3);
phase7.UseLand(aroldLand1);
phase7.UseLand(aroldLand2);
phase7.PlayCard(aroldCreature1);

Console.WriteLine(
    $"{phase7.Turn.Player} has {phase7.Turn.Player.Hand.Count} cards in hand, {phase7.Turn.Player.Battlefield.Where(card => card is Land land && land.Used).Count()} used lands on the floor {phase7.Turn.Player.Battlefield.Where(card => card is Land land && !land.Used).Count()} land played {phase7.Turn.Player.Battlefield.Where(card => card is Creature).Count()} creatures played, {phase7.Turn.Player.Lives} lives."
);
Console.WriteLine(
    $"{phase7.Turn.Opponent} has {phase7.Turn.Opponent.Hand.Count} cards, {phase7.Turn.Opponent.Battlefield.Where(card => card is Land).Count()} lands on the floor, {phase7.Turn.Opponent.Lives} lives."
);


// Bryce
DrawingPhase phase8 = phase7.Next().Next().Next();
phase8.DrawCard();
Console.WriteLine(
    $"{phase8.Turn.Player} has {phase8.Turn.Player.Hand.Count} cards in hand, {phase8.Turn.Player.Battlefield.Where(card => card is Land).Count()} lands on the floor, {phase8.Turn.Player.Lives} lives."
);

// Arold
DrawingPhase phase9 = phase8.Next().Next().Next().Next();
phase9.DrawCard();
Console.WriteLine($"{phase9.Turn.Player} has {phase9.Turn.Player.Hand.Count} cards in hand");

MainPhase phase10 = phase9.Next();
phase10.UseLand(aroldLand3);
var aroldSpell1Counter = phase10.PlayCard(aroldSpell1, aroldCreature1);
Console.WriteLine($"{aroldCreature1.Attack} {aroldCreature1.Defence}");
MainPhase phase11 = phase10.Attack(aroldCreature1, bryce).Next();
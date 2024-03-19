using Cards.States;
using Entities;

namespace Cards;

public class Creature : APermanent, IEntity, ICardWithEffect
{
    
    private int attack;
    private int defence;

    public int Attack
    {
        get => attack;
        set
        {
            attack = value;

            if (value < 0)
                State.Discard();
        }
    }

    public int Defence
    {
        get => defence;
        set
        {
            defence = value;

            if (value < 0)
                State.Discard();
        }
    }

    public Effect Effect { get; set; }
    public bool IsInstantaneous { get; set; } = false;
    public bool IsContinuous { get; set; } = false;

    public void Interact(IEntity entity)
    {
        if (State is not PlayedState)
        {
            Console.WriteLine($"{this} cannot interact with {entity} because {this} is in {this.State}.");
            return;
        }

        entity.Defence -= Attack;
        Defence -= entity.Attack;
    }

    public void Interact(Creature creature)
    {
        if (creature.State is not PlayedState)
        {
            Console.WriteLine($"{this} cannot interact with creature {creature} because {creature} is in {creature.State}.");
            return;
        }
        Interact(creature as IEntity);
    }
}

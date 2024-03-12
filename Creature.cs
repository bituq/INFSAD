namespace CardGame;
public class Creature
{
    private int AttackValue;
    private int DefenseValue;
    public int GetAttackValue()
    {
        return AttackValue;
    }
    public int GetDefenseValue()
    {
        return DefenseValue;
    }
    public Creature(int attack, int defense)
    {
        AttackValue = attack;
        DefenseValue = defense;
    }
}
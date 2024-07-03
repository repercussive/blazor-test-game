namespace MyFirstBlazorApp.Logic;

public class Hero : Character
{
    public int DiceRoll { get; private set; } = 0;

    public Hero(string name, int healthPoints) : base(name, healthPoints, 0)
    {
    }

    public override void Attack()
    {
        base.Attack();
    }

    public void RollDice()
    {
        DiceRoll = new Random().Next(1, 6);
        AttackPower = DiceRoll;
    }
}

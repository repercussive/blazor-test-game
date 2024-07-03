namespace MyFirstBlazorApp.Logic;

public class Monster : Character
{
    public Monster(string name, int healthPoints, int attackPower, Hero heroOpponent)
        : base(name, healthPoints, attackPower)
    {
        CurrentOpponent = heroOpponent;
    }
}

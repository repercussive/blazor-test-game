namespace MyFirstBlazorApp.Logic;

public class Hero : IHealth
{
    public string Name { get; set; }
    public int HealthPoints { get; set; }
    public int MaxHealthPoints { get; set; }
    public int DiceRoll { get; set; } = 0;
    public Monster CurrentOpponent { get; set; }

    public Hero(string name, int healthPoints)
    {
        Name = name;
        HealthPoints = healthPoints;
        MaxHealthPoints = healthPoints;
        CurrentOpponent = new Monster("Placeholder", -1, -1, this);
    }

    public void Attack()
    {
        CurrentOpponent.TakeDamage();
    }

    public void RollDice()
    {
        DiceRoll = new Random().Next(1, 6);
    }
}

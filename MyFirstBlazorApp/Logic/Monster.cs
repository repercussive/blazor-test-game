namespace MyFirstBlazorApp.Logic;

public class Monster : IHealth
{
    public string Name { get; set; }
    public int HealthPoints { get; set; }
    public int MaxHealthPoints { get; set; }
    public int AttackPower { get; private set; }
    public Hero Hero { get; set; }

    public Monster(string name, int healthPoints, int attackPower, Hero hero)
    {
        Name = name; 
        HealthPoints = healthPoints;
        AttackPower = attackPower;
        Hero = hero;
        MaxHealthPoints = healthPoints;
    }
}

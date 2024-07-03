namespace MyFirstBlazorApp.Logic;

public class Character
{
    public string Name { get; protected set; }
    public int HealthPoints { get; protected set; }
    public int MaxHealthPoints { get; protected set; }
    public int AttackPower { get; protected set; }
    public Character? CurrentOpponent { get; set; }

    public Character(string name, int healthPoints, int attackPower)
    {
        Name = name;
        HealthPoints = healthPoints;
        MaxHealthPoints = healthPoints;
        AttackPower = attackPower;
    }

    public virtual void Attack()
    {
        CurrentOpponent.TakeDamage(AttackPower);
    }

    public void Heal(int healAmount)
    {
        HealthPoints = Math.Min(MaxHealthPoints, HealthPoints + healAmount);
    }

    public void TakeDamage(int damage)
    {
        HealthPoints = Math.Max(0, HealthPoints - damage);
    }
}

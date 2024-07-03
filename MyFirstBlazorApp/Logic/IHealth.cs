namespace MyFirstBlazorApp.Logic;

public interface IHealth
{
    public int HealthPoints { get; set; }
    public int MaxHealthPoints { get; set; }

    public void Heal(int healAmount)
    {
        HealthPoints = Math.Min(MaxHealthPoints, HealthPoints + healAmount);
    }

    public void TakeDamage(int damage)
    {
        HealthPoints = Math.Max(0, HealthPoints - damage);
    }
}

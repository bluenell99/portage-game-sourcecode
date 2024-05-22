public class Mana : Stat, IDamageable
{
    public void TakeDamage(int amount)
    {
        UpdateStat(-amount);
    }
}
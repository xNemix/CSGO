namespace CSGO;

public class CounterTerrorist
{
    public bool IsDead { get; private set; }

    public CounterTerrorist()
    {
        IsDead = false;
    }
    public bool DefuseBomb()
    {
        if (IsDead) return false;
        Console.WriteLine("CT har defusa bomba");
        return true;
    }

    public void KillTerrorist(Terrorist[] terrorists, int index, bool isBombPlanted)
    {
        if (IsDead) return;
        if (!IsSuccessful(5)) return;
        terrorists[index].Kill();
        Console.WriteLine("CT drepte en terrorist");
    }
    
    
    private bool IsSuccessful(int maxValue)
    {
        Random rand = new Random();

        return rand.Next(0, maxValue) == 2;
    }

    public void Kill()
    {
        IsDead = true;
    }
}
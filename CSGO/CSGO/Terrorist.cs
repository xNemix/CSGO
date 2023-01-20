namespace CSGO;

public class Terrorist
{
    public bool IsDead { get; private set; }

    public Terrorist()
    {
        IsDead = false;
    }
    public void KillCounterTerrorist(CounterTerrorist[] counterTerrorists, int index)
    {
        if(IsDead) return;
        var isSuccessful = IsSuccessful(7);
        if (!isSuccessful)  return;
        counterTerrorists[index].Kill();
        Console.WriteLine("T drepte en CT");
    }
    
    
    public bool FindBombSite()
    {
        return IsSuccessful(10);
    }

    public bool PlantBomb()
    {
        var hasFoundBombSite = FindBombSite();
        if (!hasFoundBombSite) return false;
        Console.WriteLine("En Terrorist har funnet bombsite A");
        Console.WriteLine("bomben har blitt plantet");
        return true;
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
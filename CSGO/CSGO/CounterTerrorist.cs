namespace CSGO;

public class CounterTerrorist
{
    public bool IsDead { get; private set; }

    public void DefuseBomb(Round round)
    {
        if (IsDead) return;
        round.SetBombToDefused();
        Console.WriteLine("CT har defusa bomba");
    }

    public void KillTerrorist(Terrorist t, Round round)
    {
        if (IsDead) return;
        if (!round.IsBombPlanted)
        {
            if (IsSuccessful(5))
            {
                t.Kill();
                Console.WriteLine("CT drepte en terrorist");
            }
        }
        else
        {
            if (IsSuccessful(3))
            {
                t.Kill();
                Console.WriteLine("CT drepte en terrorist");
            }
        }
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
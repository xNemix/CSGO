namespace CSGO;

public class Terrorist
{
    public bool IsDead { get; private set; }


    public void KillCounterTerrorist(CounterTerrorist ct)
    {
        if(IsDead) return;
        var isSuccessful = IsSuccessful(7);
        if (isSuccessful) ct.Kill();
    }
    
    
    public bool FindBombSite()
    {
        return !IsDead && IsSuccessful(10);
    }

    public void PlantBomb(Round round)
    {
        if (IsDead && !FindBombSite()) return;
        round.SetBombActive();
    }

    public void DoRandomAction(CounterTerrorist counterTerrorist, Round round)
    {
        var hasFoundBombSite = FindBombSite();
        if(hasFoundBombSite) Console.WriteLine("En Terrorist har funnet bombsite A");
        if (hasFoundBombSite && !round.IsBombPlanted && !round.IsRoundFinished)
        {
            PlantBomb(round);
        }
        if(!counterTerrorist.IsDead)
        {
            KillCounterTerrorist(counterTerrorist);
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
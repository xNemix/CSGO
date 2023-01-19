namespace CSGO;

public class Terorist
{
    public bool IsDead { get; set; }


    public void KillCounterTerrorist(CounterTerrorist ct)
    {
        var isSuccessful = IsSuccessful(7);
        if (isSuccessful) ct.IsDead = true;
    }
    
    
    public bool FindBombSite()
    {
        return IsSuccessful(10);
    }

    public void PlantBomb()
    {
        if (!FindBombSite()) return;
        int timer = 5;
        for (int i = 5; i > 0; i--)
        {
            timer--;
            Thread.Sleep(1000);
        }

        if (timer == 0) Round.IsBombPlanted = true;

        if (Round.IsBombPlanted)
        {
                
        }
    }

    private bool IsSuccessful(int maxValue)
    {
        Random rand = new Random();

        return rand.Next(0, maxValue) == 2;
    }
}
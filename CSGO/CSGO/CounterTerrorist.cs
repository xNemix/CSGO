namespace CSGO;

public class CounterTerrorist
{
    public bool IsDead { get; set; }

    public void DefuseBomb()
    {
        Round.IsBombPlanted = false;
    }

    public void KillTerrorist(Terorist t)
    {
        if (!Round.IsBombPlanted)
        {
            if (IsSuccessful(5)) t.IsDead = true;
        }
        else
        {
            if (IsSuccessful(3)) t.IsDead = true;
        }
    }
    
    private bool IsSuccessful(int maxValue)
    {
        Random rand = new Random();

        return rand.Next(0, maxValue) == 2;
    }
}
namespace CSGO;

public class Round
{
    public static bool IsRoundActive { get; set; }
    public static bool IsBombPlanted { get; set; }
    private Terorist[] _terorists { get;}
    private CounterTerrorist[] _counterTerrorists { get;}

    public Round()
    {
        IsRoundActive = true;
        IsBombPlanted = false;
        _terorists = new Terorist[5];
        _counterTerrorists = new CounterTerrorist[5];

        for (var i = 0; i < 5; i++)
        {
            _terorists[i] = new Terorist();
            _counterTerrorists[i] = new CounterTerrorist();
        }
    }

    private int CheckAliveAmount(Terorist[] terorists)
    {
        var aliveNum = 5;
        foreach (var t in terorists)
        {
            if (t.IsDead) aliveNum--;
        }

        return aliveNum;
    }

    private int CheckAliveAmount(CounterTerrorist[] counterTerrorists)
    {
        var aliveNum = 5;
        foreach (var ct in counterTerrorists)
        {
            if (ct.IsDead) aliveNum--;
        }
        return aliveNum;
    }
}
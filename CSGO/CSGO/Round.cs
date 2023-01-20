namespace CSGO;

public class Round
{
    public string _roundWinner { get; private set; }
    public bool IsRoundActive { get; private set; }
    public bool IsRoundFinished { get; private set; }
    public bool IsBombPlanted { get; private set; }
    private Terrorist[] Terrorists { get;}
    private CounterTerrorist[] CounterTerrorists { get;}

    private readonly Random _random;
    private int _bombTimer;

    public Round()
    {
        _bombTimer = 15;
        IsRoundFinished = false;
        IsRoundActive = false;
        IsBombPlanted = false;
        _random = new Random();
        Terrorists = new Terrorist[5];
        CounterTerrorists = new CounterTerrorist[5];

        for (var i = 0; i < 5; i++)
        {
            Terrorists[i] = new Terrorist();
            CounterTerrorists[i] = new CounterTerrorist();
        }
    }

    // public void RoundLoop()
    // {
    //     
    //     while (IsRoundActive && !IsRoundFinished || _bombTimer != 0)
    //     {
    //         var randomRoundCycle = _random.Next(0, 5);
    //         if (CheckAliveAmount(Terrorists) <= 0)
    //         {
    //             _roundWinner = "Terroristene vant";
    //             IsRoundActive = false;
    //             IsRoundFinished = true;
    //             break;
    //         }
    //         if (CheckAliveAmount(CounterTerrorists) <= 0)
    //         {
    //             _roundWinner = "CounterTerroristene vant";
    //             IsRoundActive = false;
    //             IsRoundFinished = true;
    //             break;
    //         }
    //
    //         if (!Terrorists[randomRoundCycle].IsDead) Terrorists[randomRoundCycle].DoRandomAction(CounterTerrorists[randomRoundCycle], this);
    //         if (!CounterTerrorists[randomRoundCycle].IsDead && CheckAliveAmount(Terrorists) > 0)CounterTerrorists[randomRoundCycle].KillTerrorist(Terrorists[randomRoundCycle], this);
    //         if(!CounterTerrorists[randomRoundCycle].IsDead && CheckAliveAmount(Terrorists) == 0) CounterTerrorists[randomRoundCycle].DefuseBomb(this);
    //         _bombTimer--;
    //     }
    // }

    private int CheckAliveAmount(Terrorist[] terrorists)
    {
        var aliveNum = 5;
        foreach (var t in terrorists)
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

    public void SetRoundActive()
    {
        IsRoundActive = true;
    }

    public void SetBombToDefused()
    {
        IsRoundActive = false;
        IsRoundFinished = true;
    }

    public void SetBombActive()
    {
        for (int i = 5; i > 0; i--)
        {
            Console.WriteLine($"Terroristene planter bomba om: {i} sekunder");
            if (i == 1)
            {
                IsBombPlanted = true;
                Console.WriteLine("Bomba har blitt plantet");
            }
            Thread.Sleep(1000);
        }
    }
}
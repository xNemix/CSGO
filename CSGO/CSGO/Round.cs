namespace CSGO;

public class Round
{
    public string _roundWinner { get; private set; }
    public bool IsRoundActive { get; private set; }
    public bool IsRoundFinished { get; private set; }
    public bool IsBombPlanted { get; private set; }
    private Terrorist[] _terrorists { get;}
    private CounterTerrorist[] _counterTerrorists { get;}

    private Random _random;
    private int _bombTimer;

    public Round()
    {
        _bombTimer = 15;
        IsRoundFinished = false;
        IsRoundActive = false;
        IsBombPlanted = false;
        _random = new Random();
        _terrorists = new Terrorist[5];
        _counterTerrorists = new CounterTerrorist[5];

        for (var i = 0; i < 5; i++)
        {
            _terrorists[i] = new Terrorist();
            _counterTerrorists[i] = new CounterTerrorist();
        }
    }

    public void RoundLoop()
    {
        
        while (IsRoundActive && !IsRoundFinished || _bombTimer != 0)
        {
            var randomRoundCycle = _random.Next(0, 5);
            if (CheckAliveAmount(_terrorists) <= 0)
            {
                _roundWinner = "Terroristene vant";
                IsRoundActive = false;
                IsRoundFinished = true;
                break;
            }
            if (CheckAliveAmount(_counterTerrorists) <= 0)
            {
                _roundWinner = "CounterTerroristene vant";
                IsRoundActive = false;
                IsRoundFinished = true;
                break;
            }

            if (!_terrorists[randomRoundCycle].IsDead) _terrorists[randomRoundCycle].DoRandomAction(_counterTerrorists[randomRoundCycle], this);
            if (!_counterTerrorists[randomRoundCycle].IsDead && CheckAliveAmount(_terrorists) > 0)_counterTerrorists[randomRoundCycle].KillTerrorist(_terrorists[randomRoundCycle], this);
            if(!_counterTerrorists[randomRoundCycle].IsDead && CheckAliveAmount(_terrorists) == 0) _counterTerrorists[randomRoundCycle].DefuseBomb(this);
            _bombTimer--;
        }
    }

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
        
        // for (int i = 15; i > 0; i--)
        // {
        //     Console.WriteLine($"Bomba sprenger om {i} sekunder");
        //     if (!IsBombPlanted) return;
        //     if (i == 1)
        //     {
        //         Console.WriteLine("Bomba har sprengt");
        //         _roundWinner = "Terroristene vant";
        //         IsBombPlanted = false;
        //         IsRoundActive = false;
        //         IsRoundFinished = true;
        //         return;
        //     }
        //     Thread.Sleep(1000);
        // }
        
    }
}
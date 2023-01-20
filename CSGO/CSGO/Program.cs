// namespace CSGO
// {
//     public class Program
//     {
//         static void Main(string[] args)
//         {
//             var game = new Game(1);
//             var activeRound = game._roundNumber -1;
//             while (game.TotalRounds > activeRound)
//             {
//                 game.SetActiveRound(activeRound);
//                 
//                 //Vente til den aktive runden er ferdig
//                 if (game.Rounds[activeRound].IsRoundFinished == true)
//                 {
//                     activeRound++;
//                 }
//                 
//             }
//         }
//     }
// }


using CSGO;

var terrorists = new Terrorist[5];
var counterTerrorists = new CounterTerrorist[5];
for (int i = 0; i < 5; i++)
{
    terrorists[i] = new Terrorist();
    counterTerrorists[i] = new CounterTerrorist();
}


bool isGameActive = true;
bool isBombPlanted = false;
int bombTimer = 15;
var random = new Random();

while (isGameActive || bombTimer != 0)
{
    var randomIndexT = random.Next(0, AliveListT().Count -1);
    var randomIndexCt = random.Next(0, AliveListCT().Count -1);
    if (CheckAliveAmountT() <= 0 || CheckAliveAmountCt() <= 0)
    {
        isGameActive = false;
        break;
    }

    if (isBombPlanted)
    {
        AliveListT()[randomIndexT].KillCounterTerrorist(AliveListCT().ToArray(), randomIndexCt);
    }
    else
    {
        AliveListT()[randomIndexT].KillCounterTerrorist(AliveListCT().ToArray(), randomIndexCt);
        isBombPlanted = AliveListT()[randomIndexT].PlantBomb();
    }
    
    
    if (AliveListT().Count > 0)
    {
        AliveListCT()[randomIndexCt].KillTerrorist(AliveListT().ToArray(), randomIndexT, isBombPlanted);
    }
    
    if (AliveListT().Count == 0)
    {
        if (isBombPlanted)
        {
            if (!AliveListCT()[randomIndexCt].DefuseBomb())
            {
                isGameActive = false;
                break;
            }
        }
    }
    
    bombTimer--;
    Thread.Sleep(1000);
}


int CheckAliveAmountT()
{
    var aliveNum = 5;
    for (int i = 0; i < terrorists.Length; i++)
    {
        if (terrorists[i].IsDead) aliveNum--;
    }

    return aliveNum;
}

int CheckAliveAmountCt()
{
    var aliveNum = 5;
    for (int i = 0; i < counterTerrorists.Length; i++)
    {
        if (counterTerrorists[i].IsDead) aliveNum--;
    }
    return aliveNum;
}

List<Terrorist> AliveListT()
{
    var aliveList = new List<Terrorist>();
    for (int i = 0; i < terrorists.Length; i++)
    {
        if (!terrorists[i].IsDead) aliveList.Add(terrorists[i]);
    }
    return aliveList;
}



List<CounterTerrorist> AliveListCT()
{
    var aliveList = new List<CounterTerrorist>();
    for (int i = 0; i < counterTerrorists.Length; i++)
    {
        if (!counterTerrorists[i].IsDead) aliveList.Add(counterTerrorists[i]);
    }
    return aliveList;
}




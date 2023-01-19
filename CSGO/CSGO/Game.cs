namespace CSGO;

public class Game
{
    public Round[] Rounds;
    public int TotalRounds { get; private set; }
    public int _roundNumber { get; private set; }


    public Game(int rounds)
    {
        TotalRounds = rounds;
        _roundNumber = 1;
        Rounds = new Round[rounds];
        for (int i = 0; i < rounds; i++)
        {
            Rounds[i] = new Round();
        }
    }

    public void SetActiveRound(int activeRound)
    {
        var round = Rounds[activeRound];
        round.SetRoundActive();
        round.RoundLoop();
        SetNextRound();
    }

    private void SetNextRound()
    {
        _roundNumber++;
    }
    
}
namespace CSGO
{
    public class Program
    {
        static void Main(string[] args)
        {
            var game = new Game(1);
            var activeRound = game._roundNumber -1;
            while (game.TotalRounds > activeRound)
            {
                game.SetActiveRound(activeRound);
                
                //Vente til den aktive runden er ferdig
                if (game.Rounds[activeRound].IsRoundFinished == true)
                {
                    activeRound++;
                }
                
            }
        }
    }
}




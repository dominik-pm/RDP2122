using System;

namespace ObserverPatternToEvents
{
    internal class Program
    {
        private static int myTeam;

        static void Main(string[] args)
        {
            Console.WriteLine("Following shows an example of the \"Observer-Pattern\" in its regular form and with events.");
            Console.WriteLine("If you find any mistakes or want to give feedback contact the author Gabriel Lugmayr.");
            Console.WriteLine("\nThis example is about a football match. If a Team scores a goal, all viewers should get notified which team scored. If the viewer is fan of this theam, the viewer cheers.\n");

            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Starting with the regular Observer Pattern:\n");
            Soccermatch match = new Soccermatch();

            for (int i = 0; i < 3; i++)
            {
                match.RegisterObserver(new SoccerViewer() { MyTeam = 0});
            }
            for (int i = 0; i < 5; i++)
            {
                match.RegisterObserver(new SoccerViewer() { MyTeam = 1 });
            }
            Console.WriteLine("Team 0 Scored (3 fans)");
            match.NotifyObservers((byte)0);
            Console.WriteLine("\nTeam 1 Scored (5 fans)");
            match.NotifyObservers((byte)1);
            Console.WriteLine("------------------------------------------------\n");

            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Now the same with Events:\n");

            ESoccerMatch eMatch = new ESoccerMatch();
            for (int i = 0; i < 3; i++)
            {
                eMatch.TeamScored += new ESoccerViewer(0).ATeamScored;
            }
            for (int i = 0; i < 5; i++)
            {
                eMatch.TeamScored += new ESoccerViewer(1).ATeamScored;
            }

            Console.WriteLine("Team 0 Scored (3 fans)");
            eMatch.Notify(0);
            Console.WriteLine("\nTeam 1 Scored (5 fans)");
            eMatch.Notify(1);
            Console.WriteLine("------------------------------------------------");

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPatternToEvents
{
    public class ESoccerEventArgs : EventArgs
    {
        public byte whoScored;
    }

    public class ESoccerMatch
    {
        public event EventHandler<ESoccerEventArgs>? TeamScored;
        public void Notify(byte whoScored)
        {
            if (TeamScored == null) return;
            TeamScored(this, new ESoccerEventArgs() { whoScored = whoScored });
        }
    }

    public class ESoccerViewer
    {
        public byte myTeam;

        public ESoccerViewer(byte myTeam)
        {
            this.myTeam = myTeam;
        }

        public void ATeamScored(object? sender, ESoccerEventArgs e)
        {
            if (e.whoScored != myTeam) return;
            Console.WriteLine("wohoo my team scored!");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPatternToEvents
{
    interface Observer
    {
        public void Update(object eventhappened);
    }
    abstract class Subject
    {
        private List<Observer> observers = new List<Observer>();

        public void RegisterObserver(Observer observer)
        {
            observers.Add(observer);
        }
        public void UnregisterObserver(Observer observer)
        {
            observers.Remove(observer);
        }

        public virtual void NotifyObservers(object eventhappened)
        {
            foreach (Observer observer in observers)
            {
                observer.Update(eventhappened);
            }
        }
    }

    class SoccerViewer : Observer
    {
        public byte MyTeam { get; set; }
        public void Update(object whichTeamScored)
        {
            if (whichTeamScored is not byte) throw new NotImplementedException(); 
            Update((byte)whichTeamScored);
        }
        public void Update(byte whichTeamScored)
        {
            if (whichTeamScored != MyTeam) return;

            Console.WriteLine("Wohoooo my team scored!!!");
        }
    }

    class Soccermatch : Subject
    {
        public void NotifyObservers(byte whichTeamScored)
        {
            base.NotifyObservers(whichTeamScored);
        }
    }
}

using System;
using System.Collections.Generic;

namespace DesignPatterns.ObserverPattern
{
    public class Subject : IObservable<PayLoad>
    {
        public IList<IObserver<PayLoad>> Observers { get; set; }

        public Subject()
        {
            Observers = new List<IObserver<PayLoad>>();
        }

        public IDisposable Subscribe(IObserver<PayLoad> observer)
        {
            if (!Observers.Contains(observer))
            {
                Observers.Add(observer);
            }
            return new Unsubscriber(Observers, observer);
        }

        public void SendMessage(string message)
        {
            foreach (var observer in Observers)
            {
                observer.OnNext(new PayLoad { Message = message });
            }
        }
    }
}

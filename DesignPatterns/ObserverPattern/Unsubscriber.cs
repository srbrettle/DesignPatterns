using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.ObserverPattern
{
    public class Unsubscriber : IDisposable
    {
        private IObserver<PayLoad> observer;
        private IList<IObserver<PayLoad>> observers;
        public Unsubscriber(IList<IObserver<PayLoad>> observers, IObserver<PayLoad> observer)
        {
            this.observers = observers;
            this.observer = observer;
        }

        public void Dispose()
        {
            if (observer != null && observers.Contains(observer))
            {
                observers.Remove(observer);
            }
        }
    }
}

using System;

namespace DesignPatterns.ObserverPattern
{
    public class Observer : IObserver<PayLoad>
    {
        public string Message { get; set; }

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(PayLoad value)
        {
            Message = value.Message;
        }

        public IDisposable Register(Subject subject)
        {
            return subject.Subscribe(this);
        }
    }
}

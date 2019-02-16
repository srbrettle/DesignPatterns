using DesignPatterns.ObserverPattern;
using System;
using Xunit;

namespace UnitTest.DesignPatterns
{
    public class TestObserverPattern
    {
        [Fact]
        public void Test_Execute()
        {
            string firstMessage = "first message";
            string secondMessage = "second message";

            Subject observable = new Subject();
            Observer observerA = new Observer();
            Observer observerB = new Observer();

            // Subscribe both observers
            IDisposable observerAUnsubscriber = observable.Subscribe(observerA);
            IDisposable observerBUnsubscriber = observable.Subscribe(observerB);

            // Both observers have no message
            Assert.Null(observerA.Message);
            Assert.Null(observerB.Message);

            // Send first message
            observable.SendMessage(firstMessage);
            // both observers updated
            Assert.Equal(firstMessage, observerA.Message);
            Assert.Equal(firstMessage, observerB.Message);

            // Unsubscribe observerA
            observerAUnsubscriber.Dispose();

            // Send second message
            observable.SendMessage(secondMessage);
            // observerB updates, observerA not updated as unsubscribed
            Assert.Equal(firstMessage, observerA.Message);
            Assert.Equal(secondMessage, observerB.Message);
        }
    }
}

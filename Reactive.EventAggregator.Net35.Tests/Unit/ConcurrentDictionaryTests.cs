namespace Reactive.EventAggregator.Net35.Tests.Unit
{
    using NUnit.Framework;

    using Reactive.EventAggregator.Net35;

    [TestFixture]
    public class ConcurrentDictionaryTests
    {
        private class TestEvent
        {
            public int Status { get; set; }
        }

        [Test]
        public void Subscribe_WhenGivenEvent_ShouldRaiseEvent()
        {
            var eventWasRaised = false;
            var eventBus = new EventAggregator();

            eventBus.GetEvent<TestEvent>().Subscribe(new Observer<TestEvent>(x => eventWasRaised = true));

            eventBus.Publish(new TestEvent());

            Assert.IsTrue(eventWasRaised);
        }

        [Test]
        public void Unsubscribe_WhenGivenEvent_ShouldNotRaiseEvent()
        {
            var eventWasRaised = false;
            var eventBus = new EventAggregator();

            var subscription = eventBus.GetEvent<TestEvent>().Subscribe(new Observer<TestEvent>(x => eventWasRaised = true));

            subscription.Dispose();
            eventBus.Publish(new TestEvent());

            Assert.IsFalse(eventWasRaised);
        }
    }
}
namespace Reactive.EventAggregator.Net35.Tests.Unit
{
    using System;

    using NUnit.Framework;
    using Reactive.EventAggregator.Net35;

    [TestFixture]
    public class EventAggregatorTests
    {
        private class SampleEvent
        {
            public int Status { get; set; }
        }

        private class FirstClass
        {
            public FirstClass()
            {
                EventBus.Instance.GetEvent<SampleEvent>().Subscribe(new Observer<SampleEvent>(
                    x =>
                    {
                        this.Status = "First Class received event! Status: " + x.Status;

                        Console.WriteLine(this.Status);
                    }));
            }

            public string Status { get; set; }
        }

        private class SecondClass
        {
            public SecondClass()
            {
                EventBus.Instance.GetEvent<SampleEvent>().Subscribe(new Observer<SampleEvent>(
                    x =>
                    {
                        this.Status = "Second Class received event! Status: " + x.Status;

                        Console.WriteLine(this.Status);
                    }));
            }

            public string Status { get; set; }
        }

        [Test]
        public void Publish_WhenGivenEvent_ShouldTriggerFirstClassObserver()
        {
            var f = new FirstClass();

            EventBus.Instance.Publish(new SampleEvent() { Status = 2 });

            Assert.That(f.Status == "First Class received event! Status: 2");
        }

        [Test]
        public void Publish_WhenGivenEvent_ShouldTriggerFirstAndSecondClassObserver()
        {
            var f = new FirstClass();
            var s = new SecondClass();

            EventBus.Instance.Publish(new SampleEvent() { Status = 1 });

            Assert.That(f.Status == "First Class received event! Status: 1");
            Assert.That(s.Status == "Second Class received event! Status: 1");
        }
    }
}
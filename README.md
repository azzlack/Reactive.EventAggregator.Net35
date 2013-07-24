Reactive.EventAggreator.Net35
=============================

Event Aggregator using Reactive Extensions 1.0, comptable with .NET 3.5 applications.

Inspired by https://github.com/shiftkey/Reactive.EventAggregator

## Reactive.EventAggreator

This is an update of a blog post from José F. Romaniello about using Reactive Extensions to implement an event aggregator. [source](http://joseoncode.com/2010/04/29/event-aggregator-with-reactive-extensions/)

### Installation

To install it, just run this from the Package Manager Console:

    Install-Package Reactive.EventAggregator.Net35

### Usage

#### Subscribing to an event

    private class TestEvent
    {
        public int Status { get; set; }
    }

    public void Subscribe_WhenGivenEvent_ShouldRaiseEvent()
    {
        var eventWasRaised = false;
        var eventBus = new EventAggregator();

        eventBus.GetEvent<TestEvent>().Subscribe(new Observer<TestEvent>(x => eventWasRaised = true));

        eventBus.Publish(new TestEvent());

        Assert.IsTrue(eventWasRaised);
    }

#### Unsubscribing to an event

    private class TestEvent
    {
        public int Status { get; set; }
    }

    public void Unsubscribe_WhenGivenEvent_ShouldNotRaiseEvent()
    {
        var eventWasRaised = false;
        var eventBus = new EventAggregator();

        var subscription = eventBus.GetEvent<TestEvent>().Subscribe(new Observer<TestEvent>(x => eventWasRaised = true));

        subscription.Dispose();
        eventBus.Publish(new TestEvent());

        Assert.IsFalse(eventWasRaised);
    }

### Using the EventBus singleton
Normally, I'd recommend using a DI container to set up `EventAggregator` as a singleton instance for `IEventAggregator`, but there are some situations where this is not possible.  
For those situations, there is a class called `EventBus`. It has the same methods as `EventAggregator` and can be used similarily:

    public class MainForm : Form 
    {
        private
        public MainForm()
        {
            
        }
    }

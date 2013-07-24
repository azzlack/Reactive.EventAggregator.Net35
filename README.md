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

    // arrange
    var eventWasRaised = false;
    var eventPublisher = new EventAggregator();

    eventPublisher.GetEvent<SampleEvent>().Subscribe(se => eventWasRaised = true);

    eventPublisher.Publish(new SampleEvent());
    
    eventWasRaised.ShouldBe(true);

#### Disposing of the event

  // arrange
    var eventWasRaised = false;
    var eventPublisher = new EventAggregator();

    // act
    var subscription = eventPublisher.GetEvent<SampleEvent>().Subscribe(se => eventWasRaised = true);

    subscription.Dispose();
    eventPublisher.Publish(new SampleEvent());

    // assert
    eventWasRaised.ShouldBe(false);

#### Selectively subscribing to an event

    // arrange
    var eventWasRaised = false;
    var eventPublisher = new EventAggregator();

    // act
    eventPublisher.GetEvent<SampleEvent>()
                  .Where(se => se.Status == 1)
                  .Subscribe(se => eventWasRaised = true);

    eventPublisher.Publish(new SampleEvent { Status = 1 });

    // assert
    eventWasRaised.ShouldBe(true);

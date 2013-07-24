namespace Reactive.EventAggreator.Net35
{
    using System;

    /// <summary>
    /// Interface for event aggregators
    /// </summary>
    public interface IEventAggregator
    {
        /// <summary>
        /// Gets the observable for the specified event type.
        /// </summary>
        /// <typeparam name="TEvent">The event type.</typeparam>
        /// <returns>An observable.</returns>
        IObservable<TEvent> GetEvent<TEvent>();

        /// <summary>
        /// Publishes the specified event.
        /// </summary>
        /// <typeparam name="TEvent">The event type.</typeparam>
        /// <param name="e">The event.</param>
        void Publish<TEvent>(TEvent e);
    }
}
namespace Reactive.EventAggreator.Net35
{
    using System;

    /// <summary>
    /// Singleton implementation of the <see cref="EventAggregator"/>. 
    /// For use when dependency injection is not an option.
    /// </summary>
    public class EventBus
    {
        /// <summary>
        /// The subjects
        /// </summary>
        private readonly IEventAggregator aggregator = new EventAggregator();

        /// <summary>
        /// The default instance
        /// </summary>
        private static readonly EventBus DefaultInstance = new EventBus();

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static EventBus Instance
        {
            get
            {
                return DefaultInstance;
            }
        }

        /// <summary>
        /// Gets the observable for the specified event type.
        /// </summary>
        /// <typeparam name="TEvent">The event type.</typeparam>
        /// <returns>An observable.</returns>
        public IObservable<TEvent> GetEvent<TEvent>()
        {
            return this.aggregator.GetEvent<TEvent>();
        }

        /// <summary>
        /// Publishes the specified event.
        /// </summary>
        /// <typeparam name="TEvent">The event type.</typeparam>
        /// <param name="e">The event.</param>
        public void Publish<TEvent>(TEvent e)
        {
            this.aggregator.Publish(e);
        }
    }
}
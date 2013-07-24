namespace Reactive.EventAggregator.Net35
{
    using System;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;

    /// <summary>
    /// Container for aggregated events that allows publishing and subscribing of events independently.
    /// </summary>
    public class EventAggregator : IEventAggregator
    {
        /// <summary>
        /// The subjects
        /// </summary>
        private readonly ConcurrentDictionary<Type, object> subjects = new ConcurrentDictionary<Type, object>();

        /// <summary>
        /// Gets the observable for the specified event type.
        /// </summary>
        /// <typeparam name="TEvent">The event type.</typeparam>
        /// <returns>An observable.</returns>
        public IObservable<TEvent> GetEvent<TEvent>()
        {
            var subject = (ISubject<TEvent>)this.subjects.GetOrAdd(typeof(TEvent), t => new Subject<TEvent>());

            return subject.AsObservable();
        }

        /// <summary>
        /// Publishes the specified event.
        /// </summary>
        /// <typeparam name="TEvent">The event type.</typeparam>
        /// <param name="e">The event.</param>
        public void Publish<TEvent>(TEvent e)
        {
            object subject;

            if (this.subjects.TryGetValue(typeof(TEvent), out subject))
            {
                ((ISubject<TEvent>)subject).OnNext(e);
            }
        }
    }
}
namespace Reactive.EventAggregator.Net35
{
    using System;

    /// <summary>
    /// An generic implementation of an observer for receiving push-based notifications.
    /// </summary>
    /// <typeparam name="T">The class to observe.</typeparam>
    public class Observer<T> : IObserver<T>
    {
        /// <summary>
        /// The action to perform when there is a new value in the sequence.
        /// </summary>
        private readonly Action<T> onNext;

        /// <summary>
        /// The action to perform when an error has occurred.
        /// </summary>
        private readonly Action<Exception> onError;

        /// <summary>
        /// The action to perform when the first action has completed.
        /// </summary>
        private readonly Action onCompleted;

        /// <summary>
        /// Initializes a new instance of the <see cref="Observer{T}" /> class.
        /// </summary>
        /// <param name="onNext">The on next.</param>
        /// <exception cref="System.ArgumentNullException">onNext</exception>
        public Observer(Action<T> onNext)
        {
            if (onNext == null)
            {
                throw new ArgumentNullException("onNext");
            }

            this.onNext = onNext;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Observer{T}"/> class.
        /// </summary>
        /// <param name="onNext">The on next.</param>
        /// <param name="onCompleted">The on completed.</param>
        /// <exception cref="System.ArgumentNullException">
        /// onNext
        /// or
        /// onCompleted
        /// </exception>
        public Observer(Action<T> onNext, Action onCompleted)
        {
            if (onNext == null)
            {
                throw new ArgumentNullException("onNext");
            }

            if (onCompleted == null)
            {
                throw new ArgumentNullException("onCompleted");
            }

            this.onNext = onNext;
            this.onCompleted = onCompleted;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Observer{T}"/> class.
        /// </summary>
        /// <param name="onNext">The on next.</param>
        /// <param name="onError">The on error.</param>
        /// <param name="onCompleted">The on completed.</param>
        /// <exception cref="System.ArgumentNullException">
        /// onNext
        /// or
        /// onError
        /// or
        /// onCompleted
        /// </exception>
        public Observer(Action<T> onNext, Action<Exception> onError, Action onCompleted)
        {
            if (onNext == null)
            {
                throw new ArgumentNullException("onNext");
            }

            if (onError == null)
            {
                throw new ArgumentNullException("onError");
            }

            if (onCompleted == null)
            {
                throw new ArgumentNullException("onCompleted");
            }

            this.onNext = onNext;
            this.onError = onError;
            this.onCompleted = onCompleted;
        }

        /// <summary>
        /// Notifies the observer of a new value in the sequence.
        /// </summary>
        public void OnNext(T value)
        {
            this.onNext(value);
        }

        /// <summary>
        /// Notifies the observer that an exception has occurred.
        /// </summary>
        public void OnError(Exception error)
        {
            if (this.onError != null)
            {
                this.onError(error);
            }
        }

        /// <summary>
        /// Notifies the observer of the end of the sequence.
        /// </summary>
        public void OnCompleted()
        {
            if (this.onError != null)
            {
                this.onCompleted();
            }
        }
    }
}

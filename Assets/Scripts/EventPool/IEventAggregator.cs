using System;
using UniRx;

namespace CFramework.EventUni
{
    public interface IEventAggregator
    {
        IObservable<TEvent> GetEvent<TEvent>();
        void Publish<TEvent>(TEvent evt);
        bool DebugEnabled { get; set; }
    }

}


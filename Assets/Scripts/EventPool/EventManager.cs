using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UniRx;
using JetBrains.Annotations;


namespace CFramework.EventUni
{
    public interface IEventBase
    {
        int EventID { get; set; }
        Type For { get; }
    }

    public interface IEventBase<in TEvent> : IEventBase
    {
        void Publish(TEvent evt);
    }

    public class IEvent<TEvent>: IEventBase<TEvent>
    {
        private Subject<TEvent> _eventType;
        private int _eventId;

        public Subject<TEvent> EventSubject
       {
            get { return _eventType ?? (_eventType = new Subject<TEvent>()); }
            set { _eventType = value; }
        }

        public int EventID
        {
            get
            {
                if (_eventId > 0)
                    return _eventId;

                var eventIdAttribute =
                       For.GetCustomAttributes(typeof(EventID), true).FirstOrDefault() as EventID;

                if (eventIdAttribute != null)
                {
                    return _eventId = int.Parse(eventIdAttribute.Identifier);
                }

                return _eventId;
            }
            set
            {
                _eventId = value;
            }
        }

        public Type For{ get { return typeof(TEvent); } }

        public void Publish(TEvent evt)
        {
            if(_eventType != null)
            {
                _eventType.OnNext(evt);
            }
        }
    }
    public class EventManager : IEventAggregator
    {
        private Dictionary<Type, IEventBase> managers;
        private Dictionary<int, IEventBase> managersById;

        public Dictionary<Type,IEventBase> Managers
        {
            get { return managers ?? (managers = new Dictionary<Type, IEventBase>()); }
            set { managers = value; }
        }

        public Dictionary<int,IEventBase> ManagersById
        {
            get { return managersById ??( managersById = new Dictionary<int, IEventBase>()); }
            set { managersById = value; }
        }

        public IEventBase GetEventManager(int eventID)
        {
            if(managersById.ContainsKey(eventID))
            {
                return managersById[eventID];
            }
            return null;
        }


        public IObservable<TEvent> GetEvent<TEvent>()
        {
            IEventBase eventBase;
            Type eventType = typeof(TEvent);
            if(!Managers.TryGetValue(eventType,out eventBase))
            {
                eventBase = new IEvent<TEvent>();
                Managers.Add(eventType, eventBase);
                var eventId = eventBase.EventID;
                if(eventId>0)
                {
                    ManagersById.Add(eventId, eventBase);
                }
                else
                {
                    Debug.LogError("当前事件 属性id未设置");
                }
            }
            IEvent<TEvent> em = (IEvent<TEvent>)eventBase;
            return em.EventSubject;
        }

        public void Publish<TEvent>(TEvent evt)
        {
            if(DebugEnabled)
            {
                PublishInternal(new DebugEventWrapperEvent(evt));
            }
            PublishInternal(evt);
        }

        private void PublishInternal<TEvent>(TEvent evt)
        {
            IEventBase eventBase;
            Type type = typeof(TEvent);
            if(!Managers.TryGetValue(type,out eventBase))
            {
                Debug.LogError("当前事件没有监听" + evt.ToString());
                //没有监听
                return;
            }
            IEventBase<TEvent> eventBaseTyped = (IEventBase<TEvent>)eventBase;
            eventBaseTyped.Publish(evt);
        }

       public bool DebugEnabled { get; set; }
    }

    public struct DebugEventWrapperEvent
    {
        public readonly object Event;

        public DebugEventWrapperEvent(object evt)
        {
            Event = evt;
        }
    }
}


//使用方式

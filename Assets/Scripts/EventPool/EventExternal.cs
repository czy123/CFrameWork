using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

namespace CFramework.EventUni
{
    public interface ICommand
    {
        object Result { get; set; }
    }

    public interface ICommand<TResult>
    {
        TResult Result { get; set; }
    }

    public static class EventExternal
    {

        private static EventManager eventManager;
        public static EventManager EventManager
        {
            get
            {
                if (eventManager == null)
                    eventManager = new EventManager();
                return eventManager;
            }
        }

        public static void Publish<TEvent>(this object o,TEvent evt)
        {
            EventManager.Publish<TEvent>(evt);
        }

        public static TResult Execute<TCommond,TResult>(this object o,TCommond evt) where TCommond : ICommand<TResult>
        {
            EventManager.Publish(evt);
            return evt.Result;
        }

        public static IObservable<TEvent> OnEvent<TEvent>(this object o)
        {
            return EventManager.GetEvent<TEvent>();
        }

        public static void Publish<TEvent>(TEvent evt)
        {
            EventManager.Publish<TEvent>(evt);
        }

        public static IObservable<TEvent> OnEvnt<TEvent>()
        {
            return EventManager.GetEvent<TEvent>();
        }
    }
}

//使用方式
//订阅事件：
//this.OnEvent<TEvent>().Subscribe(x => { });

//发布事件：
//this.Pubish(new TEvent());


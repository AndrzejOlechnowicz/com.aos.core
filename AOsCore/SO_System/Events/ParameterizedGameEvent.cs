using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AOsCore.SO_System.Events
{
    
    public class ParameterizedGameEvent<T> : ScriptableObject
    {
        private readonly List<ParameterizedGameEventListener<T>> _listeners = new List<ParameterizedGameEventListener<T>>();

        private Action<T> eventAction;

        public void SubscribeToEvent(ParameterizedGameEventListener<T> listener)
        {
            if (_listeners.Contains(listener)) return;

            if (_listeners.Count == 0 || _listeners.Count > 0 && _listeners.First() > listener)
            {
                _listeners.Add(listener);
            }
            else
            {
                _listeners.Insert(0, listener);
            }
        }
    
        public void UnsubscribeFromEvent(ParameterizedGameEventListener<T> listener)
        {
            _listeners.Remove(listener);
        }

        public void AddToEventAction(Action<T> action)
        {
            eventAction += action;
        }

        public void RemoveFromEventAction(Action<T> action)
        {
            eventAction -= action;
        }
    
        public void Raise(T value)
        {
            Debug.LogC($"Raising event: {name}", "yellow");
            for (var index = _listeners.Count - 1; index >= 0; index--)
            {
                try
                {
                    var listener = _listeners[index];
                    listener.Respond(value);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    UnityEngine.Debug.Log($"{e.Message}\n faulty index: {index}, _listeners.Count: {_listeners.Count},");
                }
            }
            Debug.LogC($"Raising event: {name} action", "orange");
            eventAction?.Invoke(value);
        }
        
        public void PrintListeners()
        {
            Debug.LogC($"Printing listeners for event: {name}", "cyan");
            foreach(ParameterizedGameEventListener<T> listener in _listeners)
            {
                Debug.LogC($"{listener.name}", "yellow");
            }
            Debug.LogC($"Printing for event: {name} ended", "cyan");
            
#if !SO_SYSTEM_LOG
            UnityEngine.Debug.Log($"Printing listeners for event: {name}");
            foreach(ParameterizedGameEventListener<T> listener in _listeners)
            {
                UnityEngine.Debug.Log($"{listener.name}");
            }
            UnityEngine.Debug.Log($"Printing for event: {name} ended");
#endif
        }
        
    }
    
}

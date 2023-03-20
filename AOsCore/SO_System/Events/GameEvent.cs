using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AOsCore.SO_System.Events
{
    [CreateAssetMenu(menuName="SO_SYSTEM/Events/GameEvent")]
    public class GameEvent : ScriptableObject
    {
        private readonly List<GameEventListener> _listeners = new List<GameEventListener>();

        public void SubscribeToEvent(GameEventListener listener)
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
    
        public void UnsubscribeFromEvent(GameEventListener listener)
        {
            _listeners.Remove(listener);
        }
    
        public void Raise()
        {
            Debug.LogC($"Raising event: {name}", "yellow");
            for (var index = _listeners.Count - 1; index >= 0; index--)
            {
                try
                {
                    var listener = _listeners[index];
                    listener.Respond();
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Debug.Log($"{e.Message}\n faulty index: {index}, _listeners.Count: {_listeners.Count},");
                }
            }
        }

        public void PrintListeners()
        {
            Debug.LogC($"Printing listeners for event: {name}", "cyan");
            foreach(GameEventListener listener in _listeners)
            {
                Debug.LogC($"{listener.name}", "yellow");
            }
            Debug.LogC($"Printing for event: {name} ended", "cyan");
            
            #if !SO_SYSTEM_LOG
            UnityEngine.Debug.Log($"Printing listeners for event: {name}");
            foreach(GameEventListener listener in _listeners)
            {
                UnityEngine.Debug.Log($"{listener.name}");
            }
            UnityEngine.Debug.Log($"Printing for event: {name} ended");
            #endif
        }
    }
}

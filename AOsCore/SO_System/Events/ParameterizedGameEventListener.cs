using System;

using UnityEngine;
using UnityEngine.Events;

namespace AOsCore.SO_System.Events
{
    public class ParameterizedGameEventListener<T> : MonoBehaviour
    {
        public ParameterizedGameEvent<T> eventToListenTo;

        [Tooltip("Priority - the lower the better (first to react to event)")]
        [SerializeField] private int _priority = 9999;

        [Tooltip("List of responses to an event - run when event is raised")]
        [SerializeField] private UnityEvent<T> response = new UnityEvent<T>();

        public static event Action<T> responseAction;
        
        private void OnEnable()
        {
            eventToListenTo.SubscribeToEvent(this);
        }

        private void OnDisable()
        {
            eventToListenTo.UnsubscribeFromEvent(this);
        }

        public virtual void Respond(T value)
        {
            Debug.Log($"GameEventListener with priority: {_priority} in gameObject: {gameObject.name} " +
                      $"responding to event: {eventToListenTo.name}, response.Count: {response.GetPersistentEventCount()}" +
                      $"");
            response.Invoke(value);
            responseAction?.Invoke(value);
        }

        public virtual void AddResponse(UnityAction<T> action)
        {
            response.AddListener(action);
        }

        public virtual void AddResponseAction(Action<T> action)
        {
            //response.AddPersistentListener(action);
            //var chuj = UnityEventTools.AddPersistentListener(action);
            responseAction += action;
        }

        public static bool operator <(ParameterizedGameEventListener<T> l, ParameterizedGameEventListener<T> r)
        {
            return l._priority< r._priority;
        }
    
        public static bool operator >(ParameterizedGameEventListener<T> l, ParameterizedGameEventListener<T> r)
        {
            return l._priority> r._priority;
        }
    }
}

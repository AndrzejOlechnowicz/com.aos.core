using UnityEngine;
using UnityEngine.Events;

namespace AOsCore.SO_System.Events
{
    public class GameEventListener : MonoBehaviour
    {
        public GameEvent eventToListenTo;

        [Tooltip("Priority - the lower the better (first to react to event)")]
        [SerializeField] private int _priority = 9999;

        [Tooltip("List of responses to an event - run when event is raised")]
        [SerializeField] private UnityEvent response = new UnityEvent();
        private void OnEnable()
        {
            eventToListenTo.SubscribeToEvent(this);
        }

        private void OnDisable()
        {
            eventToListenTo.UnsubscribeFromEvent(this);
        }

        public void Respond()
        {
            Debug.Log($"GameEventListener with priority: {_priority} in gameObject: {gameObject.name} responding to event: {eventToListenTo.name}");
            response.Invoke();
        }

        public void AddResponse(UnityAction action)
        {
            response.AddListener(action);
        }

        public static bool operator <(GameEventListener l, GameEventListener r)
        {
            return l._priority< r._priority;
        }
    
        public static bool operator >(GameEventListener l, GameEventListener r)
        {
            return l._priority> r._priority;
        }

        public void SetResponse(UnityAction responseAction)
        {
            response.AddListener(responseAction);
        }
    }
}

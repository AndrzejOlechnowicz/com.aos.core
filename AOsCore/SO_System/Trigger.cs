using System;
using UnityEngine;
using UnityEngine.Events;

namespace AOsCore.SO_System
{
    [RequireComponent(typeof(Collider))]
    public class Trigger : MonoBehaviour
    {
        [SerializeField] protected string triggeringTag;
        [SerializeField] protected UnityEvent onTriggerEnter, onTriggerExit, onTriggerStay;

        private void OnTriggerEnter(Collider other)
        {
            TriggerEnter(other);
        }

        private void OnTriggerExit(Collider other)
        {
            TriggerExit(other);
        }

        private void OnTriggerStay(Collider other)
        {
            TriggerStay(other);
        }

        protected virtual void TriggerEnter(Collider other)
        {
            if (!other.CompareTag(triggeringTag)) return;
            onTriggerEnter?.Invoke();
        }

        protected virtual void TriggerExit(Collider other)
        {
            if (!other.CompareTag(triggeringTag)) return;
            onTriggerExit?.Invoke();
        }

        private void TriggerStay(Collider other)
        {
            if (!other.CompareTag(triggeringTag)) return;
            onTriggerStay?.Invoke();
        }
    }
}

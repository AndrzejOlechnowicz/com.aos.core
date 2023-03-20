using System;
using UnityEngine;

namespace AOsCore.SO_System
{
    public class GameObjectReferenceSetter : MonoBehaviour
    {
        [SerializeField] private GameObjectReference referenceToSet;

        private void Awake()
        {
            UnityEngine.Debug.Log($"GameObject set to reference: {referenceToSet.name}");
            referenceToSet.SetGameObjectReference(gameObject);
        }
    }
}

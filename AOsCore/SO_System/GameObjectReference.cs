using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO_SYSTEM/GameObjectReference")]
public class GameObjectReference : ScriptableObject
{
    [SerializeField] private GameObject go;

    public GameObject GameObject()
    {
        return go;
    }
    public void SetGameObjectReference(GameObject gameObject)
    {
        go = gameObject;
    }
}

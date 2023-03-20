using UnityEditor;
using UnityEngine;

namespace AOsCore.SO_System.Data.References.Editor
{
#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(Vector3Reference))]
    public class Vector3ReferenceDrawer : DataReferenceDrawer<Vector3>
    {
    
    }
    #endif
}

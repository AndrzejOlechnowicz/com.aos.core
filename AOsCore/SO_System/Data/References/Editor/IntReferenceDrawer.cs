using UnityEditor;

namespace AOsCore.SO_System.Data.References.Editor
{
    #if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(IntReference))]
    public class IntReferenceDrawer : DataReferenceDrawer<int>
    {
    
    }
    #endif
}

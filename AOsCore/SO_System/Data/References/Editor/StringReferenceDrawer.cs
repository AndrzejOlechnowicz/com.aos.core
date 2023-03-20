using UnityEditor;

#if UNITY_EDITOR
namespace AOsCore.SO_System.Data.References.Editor
{
    [CustomPropertyDrawer(typeof(StringReference))]
    public class StringReferenceDrawer : DataReferenceDrawer<string>
    {
    
    }
}
#endif
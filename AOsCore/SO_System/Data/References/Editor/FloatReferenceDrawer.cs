
using AOsCore.SO_System.Data.References.Editor;
using UnityEditor;

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(FloatReference))]
public class FloatReferenceDrawer : DataReferenceDrawer<float>
{
    
}
#endif

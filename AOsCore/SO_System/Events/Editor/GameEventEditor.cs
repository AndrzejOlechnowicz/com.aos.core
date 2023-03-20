#if UNITY_EDITOR


using UnityEditor;
using UnityEngine;

namespace AOsCore.SO_System.Events.Editor
{
    [CustomEditor(typeof(GameEvent))]
    public class GameEventEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            
            var gameEvent = (GameEvent) target;
            if(GUILayout.Button("Raise"))
            {
                gameEvent.Raise();
            }

            if(GUILayout.Button("Print listeners"))
            {
                gameEvent.PrintListeners();
            }
        }
        
    }
}
#endif

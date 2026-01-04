using UnityEditor;
using UnityEngine;

namespace VPopup
{
    [CustomEditor(typeof(VPopup), true)]
    public class UIPopupEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            VPopup vPopup = (VPopup)target;

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Popup Debug", EditorStyles.boldLabel);

            using (new EditorGUI.DisabledScope(!Application.isPlaying))
            {
                if (GUILayout.Button("Show Popup"))
                {
                    vPopup.Open();
                }
            
                if (GUILayout.Button("Hide Popup"))
                {
                    vPopup.Hide();
                }
            }
            
            if (GUILayout.Button("Validate Popup"))
            {
                vPopup.ValidatePopup();
            }
        }
    }   
}
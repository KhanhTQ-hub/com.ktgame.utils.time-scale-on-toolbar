using UnityEditor;
using UnityEngine;

namespace com.ktgame.utils.time_scale_on_toolbar.editor
{
    [InitializeOnLoad]
    internal static class TimeScaleSliderOnToolbar
    {
        static TimeScaleSliderOnToolbar()
        {
            ToolbarExtender.LeftToolbarGUI.Remove(OnToolbarGUI);
            ToolbarExtender.LeftToolbarGUI.Add(OnToolbarGUI);
        }

        private static void OnToolbarGUI()
        {
            var setting = TimeScaleSliderOnToolbarSetting.instance;

            if (!setting.IsEnable) return;

            using (new EditorGUILayout.HorizontalScope(GUILayout.Width(224)))
            {
                EditorGUILayout.LabelField("Time Scale", GUILayout.Width(70));

                foreach (var timeScale in setting.TimeScaleArray)
                {
                    var text = $"{timeScale:0.##}";

                    if (!GUILayout.Button(text, EditorStyles.toolbarButton)) continue;

                    Time.timeScale = timeScale;
                    var message = $"Time Scale: {text}";
                    TooltipWindow.Open(message);
                    Debug.Log(message);
                }
            }
        }
    }
}
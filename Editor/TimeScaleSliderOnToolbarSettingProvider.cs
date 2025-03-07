using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace com.ktgame.utils.time_scale_on_toolbar.editor
{
    internal sealed class TimeScaleSliderOnToolbarSettingProvider : SettingsProvider
    {
        private const string PATH = "Ktgame/Time Scale Slider On Toolbar";

        private Editor _editor;

        private TimeScaleSliderOnToolbarSettingProvider
        (
            string path,
            SettingsScope scopes,
            IEnumerable<string> keywords = null
        ) : base(path, scopes, keywords) { }

        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            var instance = TimeScaleSliderOnToolbarSetting.instance;

            instance.hideFlags = HideFlags.HideAndDontSave & ~HideFlags.NotEditable;

            Editor.CreateCachedEditor(instance, null, ref _editor);
        }

        public override void OnGUI(string searchContext)
        {
            using var changeCheckScope = new EditorGUI.ChangeCheckScope();

            _editor.OnInspectorGUI();

            if (!changeCheckScope.changed) return;

            TimeScaleSliderOnToolbarSetting.instance.Save();
        }

        [SettingsProvider]
        private static SettingsProvider CreateSettingProvider()
        {
            return new TimeScaleSliderOnToolbarSettingProvider
            (
                path: PATH,
                scopes: SettingsScope.Project
            );
        }
    }
}
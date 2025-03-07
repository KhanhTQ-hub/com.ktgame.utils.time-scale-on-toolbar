using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace com.ktgame.utils.time_scale_on_toolbar.editor
{
    [FilePath("UserSettings/Ktgame/TimeScaleSliderOnToolbarSetting.asset", FilePathAttribute.Location.ProjectFolder)]
    internal sealed class TimeScaleSliderOnToolbarSetting : ScriptableSingleton<TimeScaleSliderOnToolbarSetting>
    {
        [SerializeField] private bool isEnable = true;
        [SerializeField] private float[] timeScaleArray = { 0, 0.25f, 0.5f, 1, 2, 4, 8 };

        public bool IsEnable => isEnable;
        public IReadOnlyList<float> TimeScaleArray => timeScaleArray;

        public void Save()
        {
            Save(true);
        }
    }
}
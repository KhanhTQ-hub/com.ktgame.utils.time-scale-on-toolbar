using System.Reflection;
using UnityEngine;

namespace com.ktgame.utils.time_scale_on_toolbar.editor
{
    public static class EventInternal
    {
        public static Event GetCurrent()
        {
            var fieldInfo = typeof(Event).GetField
            (
                name: "s_Current",
                bindingAttr: BindingFlags.Static | BindingFlags.NonPublic
            );

            return (Event)fieldInfo.GetValue(null);
        }
    }
}
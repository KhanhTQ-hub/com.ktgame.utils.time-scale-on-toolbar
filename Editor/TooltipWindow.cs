using UnityEditor;
using UnityEngine;

namespace com.ktgame.utils.time_scale_on_toolbar.editor
{
    public static class TooltipWindow
    {
        public static void Open
        (
            string text,
            float time = 3,
            int fontSize = 20
        )
        {
            var current = EventInternal.GetCurrent();
            var activatorRect = new Rect(current.mousePosition, Vector2.one);
            var content = new TooltipWindowContent(text, time, fontSize);

            PopupWindow.Show(activatorRect, content);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Settings
{
    public abstract class SettingSegmentSetGUI : SettingSegmentGUI, IEnumerable<ISettingSegmentGUI>
    {
        protected readonly List<ISettingSegmentGUI> settingSegmentGuis;


        protected SettingSegmentSetGUI(params ISettingSegmentGUI[] segmentGuis)
        {
            settingSegmentGuis = segmentGuis.ToList();
        }


        protected void DrawChildrenInOrder()
        {
            for (var index = 0; index < settingSegmentGuis.Count; index++)
            {
                var settingSegmentGui = settingSegmentGuis[index];
                settingSegmentGui.OnGUI();
                if (index < settingSegmentGuis.Count - 2)
                    DrawSpaceBetweenChildren();
            }
        }

        protected virtual void DrawSpaceBetweenChildren()
        {
        }

        public IEnumerator<ISettingSegmentGUI> GetEnumerator()
        {
            return settingSegmentGuis.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    
}
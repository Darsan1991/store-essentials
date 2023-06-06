using System.Linq;

namespace Settings
{
    public abstract class SettingSegmentSetGUIWithSymbols : SettingSegmentSetGUI, ISettingSegmentGUIWithSymbols
    {
        protected SettingSegmentSetGUIWithSymbols(params ISettingSegmentGUI[] segmentGuis) : base(segmentGuis)
        {
        }

        public bool HasSymbolsProblem()
        {
            return settingSegmentGuis.OfType<ISettingSegmentGUIWithSymbols>().Any(s => s.HasSymbolsProblem());
        }

        public void FixSymbolsProblem()
        {
            foreach (var guiWithSymbols in settingSegmentGuis.OfType<ISettingSegmentGUIWithSymbols>()
                         .Where(s => s.HasSymbolsProblem()))
            {
                guiWithSymbols.FixSymbolsProblem();
            }
        }
    }
}
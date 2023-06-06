namespace Settings
{
    public abstract class SettingSegmentGUIWithSymbols : SettingSegmentGUI, ISettingSegmentGUIWithSymbols
    {
        public abstract bool HasSymbolsProblem();
        public abstract void FixSymbolsProblem();
    }
}
namespace Settings
{
    public interface ISettingSegmentGUIWithSymbols : ISettingSegmentGUI
    {
        bool HasSymbolsProblem();
        void FixSymbolsProblem();
    }
}
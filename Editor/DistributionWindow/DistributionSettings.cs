using ConsoleGPlayAPITool;

namespace UniModules.UniGame.Distribution.Editor.DistributionWindow
{
    using Core.Editor.EditorProcessors;

    [GeneratedAssetInfoAttribute("Distribution/Editor/")]
    public class DistributionSettings : GeneratedAsset<DistributionSettings>
    {
        
#if ODIN_INSPECTOR
        [Sirenix.OdinInspector.InlineProperty]
        [Sirenix.OdinInspector.HideLabel]
#endif
        public AndroidDistributionSettings androidDistributionSettings = new AndroidDistributionSettings();

        
#if ODIN_INSPECTOR
        [Sirenix.OdinInspector.Button]
#endif
        public void Reset()
        {
            androidDistributionSettings = new AndroidDistributionSettings();
            androidDistributionSettings.Validate();
        }
    
        private void OnEnable()
        {
            androidDistributionSettings.Validate();
        }
    }
}
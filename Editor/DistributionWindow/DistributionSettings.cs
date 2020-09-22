using ConsoleGPlayAPITool;
using UniModules.UniGame.Core.EditorTools.Editor;
using UniModules.UniGame.Core.EditorTools.Editor.Tools;
using UnityEngine;

public class DistributionSettings : ScriptableObject
{
    public static string FolderPath   = "Distribution/Editor/";
    public static string SettingsPath = EditorPathConstants.GeneratedContentPath.CombinePath(FolderPath);
    
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
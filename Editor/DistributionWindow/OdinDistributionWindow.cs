#if ODIN_INSPECTOR

namespace UniModules.UniGame.Distribution.Editor.DistributionWindow
{
    using Sirenix.OdinInspector.Editor;
    using ConsoleGPlayAPITool;
    using Core.EditorTools.Editor.AssetOperations;
    using Sirenix.OdinInspector;
    using UniModules.UniCore.EditorTools.Editor;
    using UniModules.UniCore.Runtime.DataFlow;
    using UniModules.UniCore.Runtime.Rx.Extensions;
    using UniRx;
    using UnityEditor;
    using UnityEngine;

    public class OdinDistributionWindow : OdinEditorWindow
    {
        #region static data
        
        [MenuItem("UniGame/Distribution/DistributionWindow")]
        private static void OpenWindow()
        {
            var window = GetWindow<OdinDistributionWindow>();
            window.InitializeWindow();
            window.titleContent = new GUIContent("DistributionWindow");
            window.Show();
        }

        #endregion

        #region inspector
        
        [InlineProperty]
        [HideLabel]
        public AndroidDistributionSettings androidDistributionSettings = new AndroidDistributionSettings();

        [ReadOnly]
        public string progressInfo;
        
        [ProgressBar(0,1)]
        public float progress = 0;
        
        #endregion

        #region private 
        
        private LifeTimeDefinition _lifeTime = new LifeTimeDefinition();
        
        private DistributionSettings _distributionSettings;
        
        #endregion
        
        #region public properties

        public  DistributionSettings Settings => _distributionSettings = _distributionSettings.LoadOrCreate(DistributionSettings.SettingsPath);
        
        public IPlayStorePublisher PlayStorePublisher { get; protected set; }

        #endregion
        
        #region public methods

        [Button]
        public void Publish()
        {
            _lifeTime.Release();
            progress           = 0;
            
            PlayStorePublisher = new PlayStorePublisher();
            PlayStorePublisher.Progress.
                Subscribe(OnProgressChanged).
                AddTo(_lifeTime);
            
            PlayStorePublisher.Publish(androidDistributionSettings);
        }
        
        
        #endregion

        private void OnProgressChanged(ProgressData progressData)
        {
            progress     = progressData.Progress;
            progressInfo = progressData.Content;
        }
        
        private void InitializeWindow()
        {
            androidDistributionSettings = Settings.androidDistributionSettings;
        }
        
    }
}

#endif
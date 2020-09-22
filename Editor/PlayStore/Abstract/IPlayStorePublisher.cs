namespace ConsoleGPlayAPITool
{
    using Google.Apis.Upload;
    using UniGreenModules.UniCore.EditorTools.Editor;
    using UniRx;

    public interface IPlayStorePublisher
    {
        IReadOnlyReactiveProperty<ProgressData> Progress { get; }

        /// <summary>
        /// publish your android artifact by configuration to your target branch
        /// </summary>
        void Publish(IAndroidDistributionSettings configs);
    }
}
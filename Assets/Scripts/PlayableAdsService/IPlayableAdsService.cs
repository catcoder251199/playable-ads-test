namespace DefaultNamespace.PlayableAdsService
{
    public interface IPlayableAdsService
    {
        void OnGameLoaded();
        void OnGameStarted();
        void OnGameEnded(string reason = null);
        void OnLevelChanged(int level);
        void OnCTAButtonClicked();
    }

}
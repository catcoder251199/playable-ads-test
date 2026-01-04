using System.Collections.Generic;
using UnityEngine;
using Luna.Unity;

namespace DefaultNamespace.PlayableAdsService
{
    public class PlayableAdsAdsService : MonoBehaviour, IPlayableAdsService
    {
        void Awake()
        {
#if UNITY_EDITOR
            Debug.Log("[LunaService] Running in Editor – Luna API disabled");
#endif
            ServiceLocator.Register<IPlayableAdsService>(this);
        }

        // ------------------------
        // Lifecycle
        // ------------------------

        public void OnGameLoaded()
        {
            LifeCycle.GameLoaded();
        }

        public void OnGameStarted()
        {
            LifeCycle.GameStarted();
        }

        public void OnGameEnded(string reason = null)
        {
            LifeCycle.GameEnded();
        }


        public void OnLevelChanged(int level)
        {
            LifeCycle.LevelChanged();
        }

        // ------------------------
        // CTA / Install
        // ------------------------

        public void OnCTAButtonClicked()
        {
            Playable.InstallFullGame();
        }
    }
}
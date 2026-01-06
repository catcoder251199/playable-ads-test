using UnityEngine;

namespace DefaultNamespace.Game
{
    public class PageMover : MonoBehaviour
    {
        [SerializeField] private LevelDataSO levelDataSO;
        [SerializeField] private TilePage[] pages;
        [SerializeField] private bool _updatable = true;

        public void SetMoveable(bool moveable) => _updatable = moveable;
        
        private void Update()
        {
            if (!_updatable)
                return;

            foreach (var page in pages)
            {
                page.UpdateY(levelDataSO.TilesVelocity);
            }
        }
    }
}
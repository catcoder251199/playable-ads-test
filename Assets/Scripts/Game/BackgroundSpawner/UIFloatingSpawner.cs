using UnityEngine;
using System.Collections.Generic;

namespace DefaultNamespace.Game.BackgroundSpawner
{
    

    public class UIFloatingSpawner : MonoBehaviour
    {
        [Header("Refs")]
        [SerializeField] private RectTransform spawnArea;
        [SerializeField] private UIFloatingItem prefab;

        [Header("Spawn Config")]
        [SerializeField] private float spawnInterval = 0.4f;
        [SerializeField] private int maxSpawned = 10;

        private readonly Queue<UIFloatingItem> pool = new Queue<UIFloatingItem> ();
        private readonly HashSet<UIFloatingItem> active = new HashSet<UIFloatingItem>();

        float timer;

        void Update()
        {
            if (active.Count >= maxSpawned)
                return;

            timer += Time.deltaTime;
            if (timer >= spawnInterval)
            {
                timer = 0f;
                Spawn();
            }
        }

        void Spawn()
        {
            UIFloatingItem item = Get();
            item.transform.SetParent(spawnArea, false);
            item.gameObject.SetActive(true);
            Rect areaRect = spawnArea.rect;

            Vector2 randomPos = new Vector2(
                Random.Range(areaRect.xMin, areaRect.xMax),
                Random.Range(areaRect.yMin, areaRect.yMax)
            );

            item.GetComponent<RectTransform>().anchoredPosition = randomPos;

            active.Add(item);
            item.Play(this);
        }

        UIFloatingItem Get()
        {
            if (pool.Count > 0)
                return pool.Dequeue();

            return Instantiate(prefab);
        }

        public void Release(UIFloatingItem item)
        {
            active.Remove(item);
            item.gameObject.SetActive(false);
            pool.Enqueue(item);
        }
    }

}
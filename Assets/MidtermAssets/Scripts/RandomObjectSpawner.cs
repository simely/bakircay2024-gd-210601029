using System.Collections.Generic;
using UnityEngine;

namespace MidtermAssets.Scripts
{
    public class RandomObjectSpawner : MonoBehaviour
    {
        [SerializeField] private Vector2 m_xRange, m_yRange, m_zRange;

        [SerializeField] private List<SimpleObject> m_prefabs;

        public void SpawnObjects()
        {
            var range = Random.Range(5, 10);


            for (var i = 0; i < range; i++)
            {
                var prefab = m_prefabs[Random.Range(0, m_prefabs.Count)];
                var pos = new Vector3(Random.Range(m_xRange.x, m_xRange.y), Random.Range(m_yRange.x, m_yRange.y),
                    Random.Range(m_zRange.x, m_zRange.y));
                var instance = Instantiate(prefab, pos, Quaternion.identity);
                instance.transform.localScale = Vector3.one * Random.Range(0.5f, 1.5f);
                instance.transform.eulerAngles = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
            }
        }
    }
}
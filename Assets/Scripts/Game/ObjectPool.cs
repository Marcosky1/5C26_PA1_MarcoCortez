using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class PoolItem
    {
        public GameObject prefab;
        public int initialSize;
    }

    public List<PoolItem> pools;
    private Dictionary<GameObject, Queue<GameObject>> poolDictionary;

    private void Awake()
    {
        poolDictionary = new Dictionary<GameObject, Queue<GameObject>>();

        foreach (PoolItem poolItem in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < poolItem.initialSize; i++)
            {
                GameObject obj = Instantiate(poolItem.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(poolItem.prefab, objectPool);
        }
    }

    public GameObject GetObject(GameObject prefab)
    {
        if (poolDictionary.ContainsKey(prefab))
        {
            GameObject obj = poolDictionary[prefab].Dequeue();
            obj.SetActive(true);
            poolDictionary[prefab].Enqueue(obj);
            return obj;
        }
        else
        {
            Debug.LogError("Prefab not found in pool: " + prefab.name);
            return null;
        }
    }

    public void ReturnObject(GameObject obj)
    {
        if (obj != null)
        {
            obj.SetActive(false);
            foreach (var entry in poolDictionary)
            {
                if (entry.Key == obj)
                {
                    entry.Value.Enqueue(obj);
                    return;
                }
            }
            Destroy(obj);
        }
    }
}

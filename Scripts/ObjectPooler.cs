using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPooler : MonoBehaviour
{
    [Serializable]
    public class Pool
    {
        public int tag;
        public GameObject preFab;
        public int size;
    }

    public List<Pool> pools;

    public void Awake()
    {
        foreach (var pool in pools)
        {
            var objectPool = new Queue<GameObject>();

            for (var i = 0; i < pool.size; i++)
            {
                var obj = Instantiate(pool.preFab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public static Dictionary<int, Queue<GameObject>> poolDictionary = new Dictionary<int, Queue<GameObject>>();

    public static GameObject SpawnFromPool(int tag, Vector3 position, Vector3 upPosition, Dictionary<int, Queue<GameObject>> poolDictionary)
    {

        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't excist");
            return null;
        }

        var objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.up = upPosition;

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

    public static void ClearDictionary()
    {
        poolDictionary.Clear();
    }
}



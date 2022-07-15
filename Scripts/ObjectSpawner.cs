using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : ObjectPooler
{
    public static ObjectSpawner Instance;

    public Vector3 UfoDefaultPosition;

    public float spawnDistance = 8f;

    public int SmallAsteroidsCounter = 8;
    public int LargeAsteroidsCounter = 2;

    private Vector3 _direction;

    public void SpawnAsteroids(int tag, int amount, Vector3 position, Vector3 direction)
    {
        if (direction == Vector3.zero)
        {
            for (int i = 1; i <= amount; i++)
            {
                direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
                SpawnFromPool(tag, position, direction, poolDictionary);
            }
        }
        else
        {
            for (int i = 1; i <= amount; i++)
            {
                SpawnFromPool(tag, position, direction, poolDictionary);
            }
        }
    }

    private void OnDisabled()
    {
        StopAllCoroutines();
    }

    private void Start()
    {
        Instance = this;

        StartCoroutine(SpawnAsteroidWithDelay(2, LargeAsteroidsCounter));
        StartCoroutine(SpawnUFO(Random.Range(2f, 4f), 3));
    }

    private IEnumerator SpawnAsteroidWithDelay(float time, int amount)
    {
        yield return new WaitForSeconds(time);
        SpawnAsteroids(0, amount, Random.insideUnitCircle.normalized * spawnDistance, Vector3.zero);
    }

    private IEnumerator SpawnUFO(float time, int tag)
    {
        yield return new WaitForSeconds(time);
        SpawnFromPool(tag, CalcPosition(), _direction, poolDictionary);
    }

    private Vector3 CalcPosition()
    {
        var pos = new Vector3(UfoDefaultPosition.x * (Random.Range(0, 2) * 2 - 1), Random.Range(-5f * 0.8f, 5f * 0.8f), UfoDefaultPosition.z);
        if (pos.x > 0)
        {
            _direction = transform.right * -1;
        }
        else
        {
            _direction = transform.right;
        }
        return pos;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOBulletPooler : ObjectPooler
{
    private void OnDisabled()
    {
        StopAllCoroutines();
    }

    private void Start()
    {
        StartCoroutine(ShootWithDelay());
    }

    private IEnumerator ShootWithDelay()
    {
        for (; ; )
        {
            SpawnFromPool(6, transform.position, Vector3.MoveTowards(transform.position, ShipMovement.GetPosition(), 0.05f), poolDictionary);
            yield return new WaitForSeconds(Random.Range(1f, 1f));
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class AsteroidOnTriggerEnterAction : MonoBehaviour
{
    public static UnityEvent<int> asteroidDestroyed = new UnityEvent<int>();

    [SerializeField] private int _points;
    [SerializeField] private int _tag;

    private ScoreCounter _score;
    private ObjectSpawner _objectSpawner;

    public void DestroyAsteroid()
    {
        asteroidDestroyed.Invoke(_tag);
        
        _score.AddPoints(_points);

        if (_tag < 2)
        {
            SpawnAfterDestroy();
        }else if (_tag == 2)
        {
            _objectSpawner.SmallAsteroidsCounter--;
            
            if (_objectSpawner.SmallAsteroidsCounter == 0)
            {
                _objectSpawner.SmallAsteroidsCounter += 4;
                StartCoroutine(RespawnWithDelay());
            }
        }
        gameObject.SetActive(false);
    }

    public void DestroyAsteroidFull()
    {
        asteroidDestroyed.Invoke(_tag);
        gameObject.SetActive(false);
    }

    private void OnDisabled()
    {
        StopAllCoroutines();
    }

    private void Start()
    {
        _objectSpawner = ObjectSpawner.Instance;
        _score = ScoreCounter.Instance;
    }

    private void SpawnAfterDestroy()    
    {
        var speed = Random.Range(1f, 3f);
        SlightlySmallerAsteroid(transform.up - transform.right, speed);
        SlightlySmallerAsteroid(transform.up + transform.right, speed);
    }

    private void SlightlySmallerAsteroid(Vector3 direction, float speed)
    {
        var smallerAsteroid = _objectSpawner.SpawnSmallerAsteroidOnce(_tag + 1, transform.position, direction);

        if (smallerAsteroid == null) { return; }

        smallerAsteroid.GetComponent<AsteroidMovement>().speed = speed;
    }

    private void OnTriggerEnter(Collider hitInfo)
    {
        if (hitInfo.tag == "Bound")
        {
            return;
        }else if (hitInfo.tag == "ShipBullet" || hitInfo.tag == "UFOBullet")
        {
            hitInfo.gameObject.SetActive(false);
            DestroyAsteroid();
        }
        else
        {
            DestroyAsteroidFull();
        }
    }

    private IEnumerator RespawnWithDelay()
    {
        _objectSpawner.LargeAsteroidsCounter++;
        _objectSpawner.SpawnLargeAsteroids(_objectSpawner.LargeAsteroidsCounter);
        yield return new WaitForSeconds(2);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public float speed;

    [SerializeField] private int _asteroidTag;

    private void OnDisabled()
    {
        StopAllCoroutines();
    }

    private void Start()
    {
        speed = Random.Range(1f, 3f);
        StartCoroutine(MoveAsteroid());
    }

    private IEnumerator MoveAsteroid()
    {
        for (; ; )
        {
            transform.position += transform.up * speed * Time.deltaTime;
            yield return null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public float speed;

    [SerializeField] private int _asteroidTag;

    private void OnDisabled()
    {
        Debug.Log("h");
        speed = Random.Range(1f, 3f);
        StopAllCoroutines();
    }

    private void Start()
    {
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

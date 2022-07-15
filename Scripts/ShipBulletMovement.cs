using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBulletMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;

    private float _screenWidth = 9.0f;
    private float _bulletDistance;

    private void OnDisabled()
    {
        StopAllCoroutines();
    }

    private void Awake()
    {
    }

    private void Start()
    {
        StartCoroutine(ShootWithDelay());
    }

    private IEnumerator ShootWithDelay()
    {
        for (; ; )
        {
            transform.position += transform.up * _speed * Time.deltaTime;
            _bulletDistance += _speed * Time.deltaTime;

            if (_bulletDistance >= _screenWidth)
            {
                gameObject.SetActive(false);
            }
            yield return null;
        }
    }
}

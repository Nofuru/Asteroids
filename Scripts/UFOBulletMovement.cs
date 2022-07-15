using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOBulletMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;

    private float _bulletDistance;
    private float _screenWidth = 9.0f;

    private Vector3 _distance = Vector3.zero;

    private ShipBulletMovement _bulletMovement;

    private void OnDisabled()
    {
        StopAllCoroutines();
    }

    private void Start()
    {
        StartCoroutine(Move());
    }

    private void CalculateBulletDirection()
    {
        Quaternion rotation = Quaternion.LookRotation(ShipMovement.GetPosition() - transform.position);
        transform.rotation = rotation;
    }

    private void CheckDistance()
    {
        if (_bulletDistance >= _screenWidth)
        {
            gameObject.SetActive(false);
        }
    }

    private IEnumerator Move()
    {
        CalculateBulletDirection();

        for (; ; )
        {
            transform.position += new Vector3(transform.forward.x, transform.forward.y, 0) * _speed * Time.deltaTime;
            _bulletDistance += _speed * Time.deltaTime;

            CheckDistance();
            yield return null;
        }
    }
}

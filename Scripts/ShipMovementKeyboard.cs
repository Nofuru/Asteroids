using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovementKeyboard : ShipMovement
{
    private static Vector3 _force = Vector3.zero;

    public static void SetForceToZero()
    {
        _force = Vector3.zero;
    }

    private void OnEnable()
    {
        StartCoroutine(Move());
    }

    private void Start()
    {
        StartCoroutine(Move());
    }

    private void Rotate()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(-Vector3.forward);
        }
    }

    private IEnumerator Move()
    {
        for (; ; )
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                _force = transform.up * maxSpeed * Time.deltaTime;
                source.Play(0);
            }
            else { yield return null; }
            transform.position += _force;

            Rotate();
            yield return null;
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOMovement : MonoBehaviour
{
    public Transform MyTransform;

    private Vector3 _direction;

    private void OnDisabled()
    {
        StopAllCoroutines();
    }

    private void Start()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        for(; ; )
        {
            transform.position += MyTransform.transform.up * Time.deltaTime;
            yield return null;
        }
    }
}

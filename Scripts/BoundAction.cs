using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BoundAction : MonoBehaviour
{
    protected Vector3 _pos = Vector3.zero;

    protected GameObject _object;

    public virtual void ReversePosition()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        _object = other.gameObject;
        ReversePosition();
        _object.transform.position = _pos;
    }
}

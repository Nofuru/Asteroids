using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] protected AudioSource source;
    [SerializeField] protected float maxSpeed = 3.0f;

    private static Vector3 _previousForce;
    private static Vector3 pos;

    private void Start()
    {
        pos = transform.position;
    }
    
    public static Vector3 GetPosition()
    {
        return pos;
    }
}

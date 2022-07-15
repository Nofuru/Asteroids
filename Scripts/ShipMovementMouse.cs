using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovementMouse : ShipMovement
{
    private static Vector3 _force = Vector3.zero;

    [SerializeField] private Camera _mainCamera;
    [SerializeField] private float _rotationSpeed = 5f;

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

    private void FollowMouse()
    {
        Vector2 directionToMouse = _mainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position; ;
        var angle = Mathf.Atan2(directionToMouse.x, directionToMouse.y) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, -Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
    }

    private IEnumerator Move()
    {
        for (; ; )
        {
            FollowMouse();

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Mouse1))
            {
                _force = transform.up * maxSpeed * Time.deltaTime;
                source.Play(0);
            }
            else { yield return null; }

            transform.position += _force;
            yield return null;
        }
    }
}

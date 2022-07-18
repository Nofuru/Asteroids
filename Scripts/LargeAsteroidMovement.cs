using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeAsteroidMovement : AsteroidMovement
{
    void OnEnable()
    {
        speed = Random.Range(1f, 3f);
    }
}

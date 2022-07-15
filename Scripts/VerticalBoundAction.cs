using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalBoundAction : BoundAction
{
    public override void ReversePosition()
    {
        _pos = new Vector3(_object.transform.position.x * 1, _object.transform.position.y * -0.97f, _object.transform.position.z * 1);
    }
}

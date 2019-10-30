using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScriptInst : MonoBehaviour {
    public void RotationInst(Vector3 point1, Vector3 point2)
    {
        transform.rotation = Quaternion.LookRotation(point1, point2);
        transform.Rotate(0, 0, -90);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 10, 0);

    private void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}

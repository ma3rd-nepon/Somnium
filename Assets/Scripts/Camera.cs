using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    private Vector3 offset = new Vector3(0, 10, 0);

    public bool fst_Person = true;
    private bool temppers = true;
    private float x, y;

    private void LateUpdate()
    {
        if (fst_Person) {
            if (temppers) {
                transform.eulerAngles = new Vector3(0, 0, 0);
                Cursor.visible = false;
                temppers = false;

            x = 1.0f * Input.GetAxis("Mouse X");
            y = -1.0f * Input.GetAxis("Mouse Y");
            transform.Rotate(y, x, 0);
            offset = new Vector3(0, 2, 0);

        }
        else {
            transform.eulerAngles = new Vector3(90, 0, 0);
            offset = new Vector3(0, 10, 0);
            temppers = true;
            Cursor.visible = true;
        }
        transform.position = target.position + offset;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
    }
}

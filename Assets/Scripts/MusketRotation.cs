using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusketRotation : MonoBehaviour
{
    public float offset;
    public Vector3 LocalScale = Vector3.one;

    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float RotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, RotateZ + offset);

        if (RotateZ > 90 || RotateZ < -90)
        {
            LocalScale.y = -1f;
        } else
        {
            LocalScale.y = +1f;
        }

        transform.localScale = LocalScale;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientationHandler : MonoBehaviour
{
    float lastHorizontalPosition;
    void Start()
    {
        lastHorizontalPosition = transform.position.x;
    }

    void Update()
    {
        float delta = transform.position.x - lastHorizontalPosition;
        if(delta != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(delta), 1, 1);
        }
        lastHorizontalPosition = transform.position.x;
    }
}

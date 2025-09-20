using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransform : MonoBehaviour
{
    public Transform trans;
    private void Update()
    {
        this.transform.position = trans.position;
    }
}

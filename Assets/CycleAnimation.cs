using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleAnimation : MonoBehaviour
{

    public float rotationPerSecond = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float timeToDegreePerSecond = 360 * rotationPerSecond;
        float rotationAngle = Time.deltaTime * timeToDegreePerSecond;
        transform.RotateAround(transform.parent.position, transform.parent.up, rotationAngle);
    }
}

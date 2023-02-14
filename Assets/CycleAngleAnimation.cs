using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleAngleAnimation : MonoBehaviour
{
    public float rotationPerSecond = 1f;
    private Vector3 rotAxis;
    private Quaternion spin;
    private Vector3 pos;


    // Start is called before the first frame update
    void Start()
    {
        // Find the vector be subtracting the location of the moon from the location of the earth (which is the parent).
        pos = gameObject.transform.position - gameObject.transform.parent.position;

        // Make the vector length one.
        pos.Normalize();

        /* The cross product of this vector and the Moon's forward direction will give us a vecctor that is at a right angle
           to both vectors with is what we want to rotate around.*/
        rotAxis = Vector3.Cross(pos, gameObject.transform.forward);

        // Convert that to a quaternion rotating on that axis, with 0 theta rotation.
        spin = Quaternion.AngleAxis(0.0f, rotAxis);
    }

    // Update is called once per frame.
    void Update()
    {
        // Find rotation update for this frame.
        float timeToDegreePerSecond = 360 * rotationPerSecond;
        float rotationAngleUpdate = Time.deltaTime * timeToDegreePerSecond;
        Quaternion rotThisFrame = Quaternion.AngleAxis(rotationAngleUpdate, rotAxis);

        // Add in the rotation.
        spin *= rotThisFrame;

        Vector3 currentPos = spin * pos;

        gameObject.transform.localPosition = currentPos;
        gameObject.transform.localRotation = spin;
    }
}

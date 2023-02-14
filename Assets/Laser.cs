using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    private LineRenderer line;

    [SerializeField]
    private int laserLength = 4;

    // Start is called before the first frame update.
    private void Awake()
    {
        line = GetComponent<LineRenderer>();

        // 1. make the initial laser points to form the shape.
        Vector3[] points = new Vector3[2];
        points[0] = new Vector3(0, 0, 0);
        points[1] = transform.forward * laserLength;
        line.SetPositions(points);

        // 2. Create a new Mesh named "Laser" from our line.
        lineBakedMesh = new Mesh();
        lineBakedMesh.name = "Laser";
        line.BakeMesh(lineBakedMesh, Camera.main, true);

        // 3. Add it to a MeshFilter it is just a placeholder for a mesh.
        gameObject.AddComponent<MeshFilter>();
        gameObject.GetComponent<MeshFilter>().mesh = lineBakedMesh;
    }

    Mesh lineBakedMesh;

    private void Start()
    {

        // 4. add a collider so collision can be detected.
        gameObject.AddComponent<MeshCollider>().sharedMesh = lineBakedMesh;
        //gameObject.GetComponent<MeshCollider>().convex = true;
    }

    // Update is called once per frame.
    void Update()
    {
        // Update laser pointer.
        Vector3[] points = new Vector3[2];
        points[0] = transform.position;
        points[1] = transform.position + transform.forward * 4;
        line.SetPositions(points);
    }
}
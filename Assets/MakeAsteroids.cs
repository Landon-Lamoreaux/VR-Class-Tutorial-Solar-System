using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeAsteroids : MonoBehaviour
{
    [SerializeField]
    private int count = 100;

    [SerializeField]
    private GameObject asteroidModel;


    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        GameObject temp;
        float x, y, z = 0;

        GameObject belt = new GameObject("Asteroid Belt");
        belt.transform.parent = transform;
        belt.transform.localPosition = Vector3.zero;
        belt.transform.localRotation = Quaternion.identity;
        belt.transform.localScale = Vector3.one;

        for( i = 0; i < count; i++ )
        {
            x = Random.Range(15f, 17f);
            y = Random.Range(-1f, 1f);
            temp = Instantiate(asteroidModel);
            temp.transform.parent = transform.Find("Asteroid Belt");
            temp.transform.localPosition = new Vector3(x, y, z);
            temp.transform.RotateAround(belt.transform.position, belt.transform.up, Random.Range(-180f, 180f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

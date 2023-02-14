using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;

public class PlanetEvents : MonoBehaviour
{
    private Vector3 growPos;
    private Vector3 shrinkPos;
    private float growSize;
    private bool grow = false;
    public float growTime = 1;
    private float startTime = 0;

    [SerializeField]
    private TMP_Text infoText;

    // Start is called before the first frame update
    void Start()
    {
        if (infoText == null)
            infoText = GetComponentInChildren<TMP_Text>();

        if (infoText == null)
        {
            Debug.LogError("TextMeshPro not cound in children or set.");
            return;
        }

        growSize = infoText.transform.localScale.x;

        growPos = new Vector3(infoText.rectTransform.localPosition.x,
                              infoText.rectTransform.localPosition.y,
                              infoText.rectTransform.localPosition.z);

        shrinkPos = new Vector3(0, 0, 0);
        infoText.transform.localPosition = new Vector3(0, 0, 0);
        infoText.transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float timeElapsed = Time.time -startTime;
        float percentDone = timeElapsed / growTime;

        if (infoText == null)
            return;

        if(!grow)
        {
            percentDone = 1 - percentDone;
        }

        infoText.transform.localPosition = Vector3.Lerp(shrinkPos, growPos, percentDone);

        float size = Mathf.Lerp(0, growSize, percentDone);
        infoText.transform.localScale = new Vector3(size, size, size);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "RightController")
        {
            grow = true;
            startTime = Time.time;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "RightController")
        {
            grow = false;
            startTime = Time.time;
        }
    }

    private void LateUpdate()
    {
        infoText.transform.rotation = Quaternion.LookRotation((infoText.transform.position - Camera.main.transform.position).normalized);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingValueText : MonoBehaviour
{
    Transform mainCam;
    Transform unit;
    Transform worldSpaceCanvas;

    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main.transform;
        unit = transform.parent;
        worldSpaceCanvas = GameObject.FindGameObjectWithTag("Float Canvas").transform;

        transform.SetParent(worldSpaceCanvas);


    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - mainCam.transform.position); // looks at camera
        transform.position = unit.position + offset;
    }
}

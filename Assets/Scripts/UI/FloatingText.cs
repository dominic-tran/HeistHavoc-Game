using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{

    private float destroyTime = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        //Destroys the floating text after 2.5 seconds
        Destroy(gameObject, destroyTime);
    }

    
}

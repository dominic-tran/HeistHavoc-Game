using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Contributors: Adrian, Jacky
public class FloatingText : MonoBehaviour
{

    private const float DESTORY_TIME = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        //Destroys the floating text after 2.5 seconds
        Destroy(gameObject, DESTORY_TIME);
    }

    
}

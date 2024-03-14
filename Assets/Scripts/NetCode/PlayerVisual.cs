using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Contributors: Adrian
public class PlayerVisual : MonoBehaviour
{
    private Renderer myRenderer;
    private void Start()
    {
        myRenderer = GetComponent<Renderer>();
        if (myRenderer != null)
        {
            // Access the materials array
            Material[] materials = myRenderer.materials;
            materials[0].color = Color.red;
            materials[1].color = Color.black;
            materials[2].color = Color.black;
            materials[3].color = Color.gray;
            materials[4].color = Color.white;
        }
    }
}

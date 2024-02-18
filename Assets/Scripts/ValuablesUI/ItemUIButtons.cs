using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIButtons : MonoBehaviour
{
    [SerializeField] private SOValuablesDefinition buttonData;
    private Button buttonComponent;
    private static List<GameObject> spawnedObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        buttonComponent = GetComponent<Button>();

        buttonComponent.onClick.AddListener(OnClick);
    }

    //Spawn object on click and destroy if spawned previously
    private void OnClick()
    {
        foreach (GameObject obj in spawnedObjects)
        {
            Destroy(obj);
        }
        spawnedObjects.Clear();

        GameObject spawnedObject = Instantiate(buttonData.prefab, new Vector3(435,255,48),Quaternion.identity);
        spawnedObjects.Add(spawnedObject);
    }

}

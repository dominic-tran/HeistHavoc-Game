using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTurn : MonoBehaviour
{
    public float secondsToRotate;
    public float degree;
    public float rotateSwitchTime;

    bool startNextRotation = true;
    public bool rotateRight;

    void Start()
    {
        SetUpStartRotation();
    }
    private void Update()
    {
        if (startNextRotation && rotateRight)
        {
            StartCoroutine(Rotate(degree, secondsToRotate));
        }
        else if (startNextRotation && !rotateRight)
        {
            StartCoroutine(Rotate(-degree, secondsToRotate));
        }
    }
    IEnumerator Rotate(float degree, float duration)
    {
        startNextRotation = false;

        Quaternion initialRotation = transform.rotation;

        float timer = 0f;

        while(timer < duration)
        {
            timer += Time.deltaTime;
            transform.rotation = initialRotation * Quaternion.AngleAxis(timer / duration * degree, Vector3.up);
            yield return null;
        }

        yield return new WaitForSeconds(rotateSwitchTime);

        startNextRotation = true;
        rotateRight = !rotateRight;
    }
    void SetUpStartRotation()
    {
        if (rotateRight)
        {
            transform.localRotation = Quaternion.AngleAxis(-degree / 2, Vector3.up);
        }
        else
        {
            transform.localRotation = Quaternion.AngleAxis(degree / 2, Vector3.up);
        }
    }
}

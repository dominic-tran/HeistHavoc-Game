using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Contributors: Nick, Dominic
public class SecurityCamera : Security
{
    [SerializeField] GameObject cameraSwivel;
    [SerializeField] private float secondsToRotate;
    [SerializeField] private float degree;
    [SerializeField] private float rotateSwitchTime;
    [SerializeField] private bool rotateRight;

    private bool startNextRotation;

    public override void Start()
    {
        base.Start();
        startNextRotation = true;

        // Starts camera rotation left or right
        if (rotateRight)
        {
            cameraSwivel.transform.localRotation = Quaternion.AngleAxis(-degree / 2, Vector3.up);
        }
        else
        {
            cameraSwivel.transform.localRotation = Quaternion.AngleAxis(degree / 2, Vector3.up);
        }
    }
    private void Update()
    {
        Move();
    }

    public override void Move()
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

    // Handles the calculations for rotating the camera swivel back and forth
    private IEnumerator Rotate(float degree, float duration)
    {
        startNextRotation = false;

        Quaternion initialRotation = cameraSwivel.transform.rotation;

        float timer = 0f;

        // Rotates the security camera
        while (timer < duration)
        {
            timer += Time.deltaTime;
            cameraSwivel.transform.rotation = initialRotation * Quaternion.AngleAxis(timer / duration * degree, Vector3.up);
            yield return null;
        }

        // Pauses security camera for a few seconds before turning back
        yield return new WaitForSeconds(rotateSwitchTime);

        // Reset loop
        startNextRotation = true;
        rotateRight = !rotateRight;
    }

}

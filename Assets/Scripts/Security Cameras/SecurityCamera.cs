using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Security Camera will use inheritance
public class SecurityCamera
{
    protected float turnSpeed;
    protected float turnAngle;
    protected float detectionDiameter;

    public SecurityCamera()
    {
        turnSpeed = 0;
        turnAngle = 0;
        detectionDiameter = 0;
    }

    public float getTurnSpeed()
    {
        return turnSpeed;
    }

    public float getTurnAngle()
    {
        return turnAngle;
    }

    public float getDetectionDiameter()
    {
        return detectionDiameter;
    }

    public void setTurnSpeed(float newTurnSpeed)
    {
        turnSpeed = newTurnSpeed;
    }

    public void setTurnAngle(float newTurnAngle)
    {
        turnAngle = newTurnAngle;
    }

    public void setDetectionDiameter(float newDetectionDiameter)
    {
        detectionDiameter = newDetectionDiameter;
    }

}

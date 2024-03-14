using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

// Contributors: Nick
public class AutoAddPlayerToVcamTargets : MonoBehaviour
{
    [TagField, SerializeField] private string Tag = string.Empty;

    private bool foundPlayer;


    private void Start()
    {
        foundPlayer = false;
    }

    private void Update()
    {
        if (!foundPlayer)
        {
            var vcam = GetComponent<CinemachineVirtualCameraBase>();
            if (vcam != null && Tag.Length > 0)
            {
                var targets = GameObject.FindGameObjectsWithTag(Tag);
                if (targets.Length > 0)
                {
                    vcam.LookAt = vcam.Follow = targets[0].transform;
                    foundPlayer = true;
                }
            }
        }
    }
}

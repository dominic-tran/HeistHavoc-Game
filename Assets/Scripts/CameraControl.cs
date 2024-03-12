using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Contributors: Dominic, Adrian, Nick, Jacky
public class CameraControl : MonoBehaviour
{
    [SerializeField] private GameObject singleCam;
    [SerializeField] private float m_DampTime = 0.2f;        
    [SerializeField] private float m_ScreenEdgeBuffer = 4f;   
    [SerializeField] private float m_MinSize = 6.5f;      
    
    private Transform[] m_Targets; // All the targets the camera needs to encompass.
    private GameObject[] players;
    private List<GameObject> m_Players;
    private Camera m_Camera;                        
    private float m_ZoomSpeed;                      
    private Vector3 m_MoveVelocity;                 
    private Vector3 m_DesiredPosition;
    private bool isFilled;

    private const int MAX_PLAYERS = 2;

    private void Awake()
    {
        singleCam.SetActive(false);
        m_Camera = GetComponentInChildren<Camera>();
        m_Targets = new Transform[MAX_PLAYERS];
        players = new GameObject[MAX_PLAYERS];
        isFilled = false;
    }


    private void FixedUpdate()
    {
        //Constanly check for players joining
        players = FindPlayers();

        if (!isFilled && players.Length == MAX_PLAYERS)
        {
            isFilled = true;
            FillTargets();
        }

        if (isFilled)
        {
            if (players.Length < MAX_PLAYERS)
            {
                isFilled = false;
                gameObject.SetActive(false);
                singleCam.SetActive(true);
                Time.timeScale = 1f;
            }
            else
            {
                // Move the camera towards a desired position.
                Move();

                // Change the size of the camera based.
                Zoom();
            }
        }
    }

    private GameObject[] FindPlayers()
    {
        return GameObject.FindGameObjectsWithTag("Player");
    }

    private void FillTargets()
    {
        for(int i = 0; i < MAX_PLAYERS; ++i)
        {
            m_Targets[i] = players[i].transform;
        }
    }

    private void Move()
    {
        // Find the average position of the targets.
        FindAveragePosition();

        // Smoothly transition to that position.
        transform.position = Vector3.SmoothDamp(transform.position, m_DesiredPosition, ref m_MoveVelocity, m_DampTime);
    }


    private void FindAveragePosition()
    {
        Vector3 averagePos = new Vector3();
        int numTargets = 0;

        // Go through all the targets and add their positions together.
        for (int i = 0; i < m_Targets.Length; i++)
        {
            if (!m_Targets[i].gameObject.activeSelf)
                continue;

            averagePos += m_Targets[i].position;
            numTargets++;
        }

        if (numTargets > 0)
            averagePos /= numTargets;

        averagePos.y = transform.position.y;

        m_DesiredPosition = averagePos;
    }


    private void Zoom()
    {
        // Find the required size based on the desired position and smoothly transition to that size.
        float requiredSize = FindRequiredSize();
        m_Camera.orthographicSize = Mathf.SmoothDamp(m_Camera.orthographicSize, requiredSize, ref m_ZoomSpeed, m_DampTime);
    }


    private float FindRequiredSize()
    {
        // Find the position the camera rig is moving towards in its local space.
        Vector3 desiredLocalPos = transform.InverseTransformPoint(m_DesiredPosition);

        float size = 0f;

        // Go through all the targets
        for (int i = 0; i < m_Targets.Length; i++)
        {
            if (!m_Targets[i].gameObject.activeSelf)
                continue;

            Vector3 targetLocalPos = transform.InverseTransformPoint(m_Targets[i].position);
            Vector3 desiredPosToTarget = targetLocalPos - desiredLocalPos;

            size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.y));
            size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.x) / m_Camera.aspect);
        }

        // Add the edge buffer to the size.
        size += m_ScreenEdgeBuffer;

        size = Mathf.Max(size, m_MinSize);

        return size;
    }


    public void SetStartPositionAndSize()
    {
        // Find the desired position.
        FindAveragePosition();

        // Set the camera's position to the desired position without damping.
        transform.position = m_DesiredPosition;
        m_Camera.orthographicSize = FindRequiredSize();
    }
}
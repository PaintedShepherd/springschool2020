using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MovementEvent : MonoBehaviour
{
    public List<Transform> positions;
    public float moveSpeed = 1.0f;
    public bool moveOnStart = false;

    private int positionIndex;
    private Transform targetTransform;

    private float distCovered;
    private float fractionOfJourney;
    private float journeyLength;
    private float startTime;    
    
    // Start is called before the first frame update
    void Awake()
    {
        GameObject startPosition = new GameObject();
        startPosition.transform.position = this.transform.position;
        startPosition.transform.rotation = this.transform.rotation;

        positions.Add(startPosition.transform);

        positionIndex = positions.Count - 1;

        targetTransform = positions[positionIndex];

        if (moveOnStart)
        {
            MoveToNextPosition();
        }
    }

    // Update is called once per frame
    void Update()
    {
        distCovered = (Time.time - startTime) * moveSpeed;

        fractionOfJourney = distCovered / journeyLength;

        transform.position = Vector3.Lerp(transform.position, targetTransform.position, fractionOfJourney);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetTransform.rotation, fractionOfJourney);
    }

    public void MoveToNextPosition()
    {
        positionIndex++;

        if (positionIndex >= positions.Count)
        {
            positionIndex = 0;
        }

        targetTransform = positions[positionIndex];

        startTime = Time.time;

        journeyLength = Vector3.Distance(transform.position, targetTransform.position);
    }

    public void MoveToPreviousPosition()
    {
        positionIndex--;

        if (positionIndex <= 0)
        {
            positionIndex = positions.Count - 1;
        }

        targetTransform = positions[positionIndex];

        startTime = Time.time;

        journeyLength = Vector3.Distance(transform.position, targetTransform.position);
    }

    public void MoveToPosition(int _positionIndex)
    {
        positionIndex = _positionIndex;

        targetTransform = positions[positionIndex];

        startTime = Time.time;

        journeyLength = Vector3.Distance(transform.position, targetTransform.position);
    }
}

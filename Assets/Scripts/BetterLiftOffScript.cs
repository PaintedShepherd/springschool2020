using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterLiftOffScript : LiftOffScript
{
    [Space]
    [Header("Advanced Options")]
    public ParticleSystem exhaust;
    public float liftOffTremorMax = 0.3f;

    protected Vector3 startPosition;
    protected float reverseTime;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        reverseTime = curve.keys[curve.length - 1].time; // Set reverse timer to time of the last key in the animation curve
        startPosition = transform.position;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if(start)
        {
            reverseTime -= Time.deltaTime;

            transform.position += RandomPosition();

            if(!exhaust.isPlaying) exhaust.Play();
        }
        else
        {
            if (exhaust.isPlaying) exhaust.Stop();
            reverseTime = curve.keys[curve.length - 1].time; // Set reverse timer to time of the last key in the animation curve
        }
    }

    public void StartLiftOff()
    {
        start = true;
    }

    public void ShutOffEngine()
    {
        start = false;
    }

    protected void LateUpdate()
    {
        transform.position = ClampedPosition();
    }

    protected Vector3 RandomPosition()
    {
        float x = Random.Range(-liftOffTremorMax, liftOffTremorMax) * curve.Evaluate(reverseTime);
        float z = Random.Range(-liftOffTremorMax, liftOffTremorMax) * curve.Evaluate(reverseTime);

        return new Vector3(x, 0, z);
    }

    protected Vector3 ClampedPosition()
    {
        float x = Mathf.Clamp(transform.position.x, startPosition.x - liftOffTremorMax, startPosition.x + liftOffTremorMax);
        float z = Mathf.Clamp(transform.position.z, startPosition.z - liftOffTremorMax, startPosition.z + liftOffTremorMax);

        return new Vector3(x, transform.position.y, z);
    }
}

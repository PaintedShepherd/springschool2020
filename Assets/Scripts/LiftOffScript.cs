using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
public class LiftOffScript : MonoBehaviour
{
    public AnimationCurve curve;
    public float endVelocity = 10f;
    public bool start = false;

    protected Rigidbody rb;
    protected float time;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if(start)
        {

            time += Time.deltaTime;
            time = Mathf.Clamp(time, 0f, curve.keys[curve.length - 1].time); // Clamps the time value betwenn zero and the maximum time of the curve

            rb.velocity = (endVelocity * curve.Evaluate(time)) * Vector3.up;
        } else
        {
            time = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScaleEvent : MonoBehaviour
{
    public float duration = 2.0f;
    public Vector3 scale;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyScale()
    {
        transform.DOScaleX(scale.x, duration);
        transform.DOScaleY(scale.y, duration);
        transform.DOScaleZ(scale.z, duration);
    }
}

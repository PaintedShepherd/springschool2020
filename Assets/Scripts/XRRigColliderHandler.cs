using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRRigColliderHandler : MonoBehaviour
{
    public BoxCollider boxCollider;
    private GameObject head;
    // Start is called before the first frame update
    void Start()
    {
        head = GetComponent<XRRig>().cameraGameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newCenter = head.transform.localPosition;

        boxCollider.center = newCenter;
    }
}

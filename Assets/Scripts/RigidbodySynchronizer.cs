using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RigidbodySynchronizer : MonoBehaviourPun, IPunObservable
{
    private Rigidbody rigidbody;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            if (rigidbody)
            {
                rigidbody.isKinematic = false;
                rigidbody.useGravity = true;
            }
        }
        else
        {
            if (rigidbody)
            {
                rigidbody.isKinematic = true;
                rigidbody.useGravity = false;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

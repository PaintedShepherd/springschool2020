using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformSynchronizer : MonoBehaviourPun, IPunObservable
{
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(this.transform.position);
            stream.SendNext(this.transform.rotation);

            if(rigidbody)
            {
                stream.SendNext(rigidbody.isKinematic);
                stream.SendNext(rigidbody.useGravity);
            }
        }
        else
        {
            this.transform.position = (Vector3)stream.ReceiveNext();
            this.transform.rotation = (Quaternion)stream.ReceiveNext();

            if(rigidbody)
            {
                rigidbody.isKinematic = (bool)stream.ReceiveNext();
                rigidbody.useGravity = (bool)stream.ReceiveNext();
            }
        }
    }
}

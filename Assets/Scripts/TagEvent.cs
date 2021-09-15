using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagEvent : MonoBehaviourPun, IPunObservable
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeTag(string tag)
    {
        this.transform.tag = tag;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(this.transform.tag);
        }
        else
        {
            this.transform.tag = (string)stream.ReceiveNext();
        }
    }
}

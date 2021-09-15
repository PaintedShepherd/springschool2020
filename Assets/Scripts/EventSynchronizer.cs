using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSynchronizer : MonoBehaviour, IPunObservable
{
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            stream.SendNext(this.gameObject.tag);
        }
        else
        {
            this.tag = (string)stream.ReceiveNext();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

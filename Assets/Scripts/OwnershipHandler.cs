using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class OwnershipHandler : MonoBehaviourPunCallbacks, IPunOwnershipCallbacks
{
     public void OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
     {
          if (targetView.ViewID == photonView.ViewID && photonView.OwnershipTransfer == OwnershipOption.Request)
          {
               photonView.TransferOwnership(requestingPlayer);
          }
     }

     public void OnOwnershipTransfered(PhotonView targetView, Player previousOwner)
     {
          //throw new System.NotImplementedException();
     }

     // Start is called before the first frame update
     void Start()
    {
        if(!photonView)
          {
               Debug.LogError("No PhotonView initialized");
          }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void RequestOwnership()
     {
          photonView.RequestOwnership();
     }
}

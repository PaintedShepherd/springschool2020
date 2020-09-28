using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PhotonAutoConnector: MonoBehaviour
{
     public PhotonLauncher launcher;
     // Start is called before the first frame update
     void Start()
     {

          if (launcher && !PhotonNetwork.IsConnected)
          {
               Debug.Log("AutoConnectorScript Start: Connecting via Launcher");

               launcher.Connect();
          }
     }

     // Update is called once per frame
     void Update()
     {

     }
}

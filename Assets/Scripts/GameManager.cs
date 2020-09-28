using System;
using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;

using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
     public static GameManager Instance;
     [Tooltip("The prefab to use for representing the player")]
     public GameObject avatarPrefab;
     public override void OnLeftRoom()
     {
          SceneManager.LoadScene(0);
     }
     public void LeaveRoom()
     {
          PhotonNetwork.LeaveRoom();
     }

     void LoadScene(string nameOfScene)
     {
          if (!PhotonNetwork.IsMasterClient)
          {
               return;
          }

          PhotonNetwork.LoadLevel(nameOfScene);
     }

     // Start is called before the first frame update
     void Start()
     {
          Instance = this;

        if(avatarPrefab == null)
        {
            Debug.LogWarning("No Avatar prefab is assigned. Please assign your Avatar to GameManager");

            return;
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");

          if (player != null)
          {
               if (PhotonNetwork.IsConnected)
               {
                    PhotonNetwork.Instantiate(avatarPrefab.name, player.transform.position, player.transform.rotation, 0);
               }
               else
               {
                    Instantiate(avatarPrefab, player.transform.position, player.transform.rotation);
               }
          }
          else
          {
               Debug.LogError("No Player found. Has your XRRig the 'Player' tag ?");
          }
     }

     // Update is called once per frame
     void Update()
     {

     }

     public override void OnPlayerEnteredRoom(Player other)
     {

     }

     public override void OnPlayerLeftRoom(Player other)
     {

     }
}

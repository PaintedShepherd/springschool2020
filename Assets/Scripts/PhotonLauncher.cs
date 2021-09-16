﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class PhotonLauncher : MonoBehaviourPunCallbacks
{
     [Tooltip("The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created")]
     [SerializeField]
     private byte maxPlayersPerRoom = 4;
     public string nameOfOnlineScene;

     string gameVersion = "1";

     bool isConnecting;

     // Start is called before the first frame update
     void Start()
     {
     }

     // Update is called once per frame
     void Update()
     {

     }

     void Awake()
     {
          // #Critical
          // this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
          PhotonNetwork.AutomaticallySyncScene = true;
     }

     public void Connect()
     {
          isConnecting = true;

          // we check if we are connected or not, we join if we are , else we initiate the connection to the server.
          if (PhotonNetwork.IsConnected)
          {
               // #Critical we need at this point to attempt joining a Random Room. If it fails, we'll get notified in OnJoinRandomFailed() and we'll create one.
               PhotonNetwork.JoinRandomRoom();
          }
          else
          {
               // #Critical, we must first and foremost connect to Photon Online Server. 
               PhotonNetwork.GameVersion = gameVersion;
               PhotonNetwork.NickName = "Player";
               PhotonNetwork.ConnectUsingSettings();
          }
     }

     public override void OnConnectedToMaster()
     {
          Debug.Log("PUN Basics Tutorial/Launcher: OnConnectedToMaster() was called by PUN");

          if (isConnecting)
          {
               // #Critical: The first we try to do is to join a potential existing room. If there is, good, else, we'll be called back with OnJoinRandomFailed()
               PhotonNetwork.JoinRandomRoom();
          }
     }

     public override void OnDisconnected(DisconnectCause cause)
     {
          Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0}", cause);
     }

     public override void OnJoinRandomFailed(short returnCode, string message)
     {
          Debug.Log("PUN Basics Tutorial/Launcher:OnJoinRandomFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");

          // #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
          PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
     }

     public override void OnJoinedRoom()
     {
          Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");

          Debug.Log("We load the " + nameOfOnlineScene);

          // #Critical
          // Load the Room Level.
          PhotonNetwork.LoadLevel(nameOfOnlineScene);
     }
}
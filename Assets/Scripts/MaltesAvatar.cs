using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;

public class MaltesAvatar : MonoBehaviourPunCallbacks
{
    public string nameOfHeadAnchor;
    public string nameOfLeftControllerAnchor;
    public string nameOfRightControllerAnchor;
    public GameObject HeadObject;
    public GameObject LeftControllerObject;
    public GameObject RightControllerObject;

    private bool isConnectedToRig = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!PhotonNetwork.IsConnected || photonView.IsMine)
        {
            if (!isConnectedToRig)
            {
                SnapToCameraRig();

                isConnectedToRig = true;
            }
        }
    }

    public void SnapToCameraRig()
    {
        SnapObjectToPosition(HeadObject, GameObject.Find(nameOfHeadAnchor).transform);
        SnapObjectToPosition(LeftControllerObject, GameObject.Find(nameOfLeftControllerAnchor).transform);
        SnapObjectToPosition(RightControllerObject, GameObject.Find(nameOfRightControllerAnchor).transform);
    }

    private void SnapObjectToPosition(GameObject targetObject, Transform transform)
    {
        targetObject.transform.parent = transform;
        targetObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
        targetObject.transform.localPosition = Vector3.zero;

    }
}

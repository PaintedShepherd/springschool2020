using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEvent : MonoBehaviour
{
    public GameObject prefab;
    public Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        if (transform == null)
        {
            this.transform = this.gameObject.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnObject()
    {
        PhotonNetwork.Instantiate(prefab.name, transform.position, transform.rotation, 0, null);
    }
}

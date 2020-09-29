using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEvent : MonoBehaviour
{
    public GameObject prefab;
    public Transform spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        if (transform == null)
        {
            this.spawnPosition = this.gameObject.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnObject()
    {
        PhotonNetwork.Instantiate(prefab.name, spawnPosition.position, spawnPosition.rotation, 0, null);
    }
}

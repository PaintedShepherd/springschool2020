using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEvent : MonoBehaviour
{
    public GameObject bullet;
    public float velocity = 20.0f;
    public Transform bulletSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        if (bulletSpawnPoint == null)
        {
            bulletSpawnPoint = this.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Shoot()
    {
        GameObject newBullet;

        if (PhotonNetwork.IsConnected)
        {
            newBullet = PhotonNetwork.Instantiate(bullet.name, bulletSpawnPoint.position, bulletSpawnPoint.rotation, 0, null);
        }
        else
        {
            newBullet = GameObject.Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation, null);
        }

        newBullet.GetComponent<Rigidbody>().AddForce(bulletSpawnPoint.forward * velocity, ForceMode.Impulse);
    }
}

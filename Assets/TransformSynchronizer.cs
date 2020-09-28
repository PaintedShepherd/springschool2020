using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformSynchronizer : MonoBehaviourPun, IPunObservable
{
    private Rigidbody rigidbody;
    private Renderer renderer;
    private string materialName;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();
        materialName = renderer.material.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (materialName != renderer.material.name)
        {
            Material yourMaterial = (Material)Resources.Load(materialName, typeof(Material));

            renderer.material = yourMaterial;

        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(this.transform.position);
            stream.SendNext(this.transform.rotation);

            if (rigidbody)
            {
                rigidbody.isKinematic = false;
                rigidbody.useGravity = true;
            }

            stream.SendNext(this.tag);

            if (renderer)
            {
                materialName = renderer.material.name;
                stream.SendNext(materialName);
            }

        }
        else
        {
            this.transform.position = (Vector3)stream.ReceiveNext();
            this.transform.rotation = (Quaternion)stream.ReceiveNext();

            if (rigidbody)
            {
                rigidbody.isKinematic = true;
                rigidbody.useGravity = false;
            }

            this.tag = (string)stream.ReceiveNext();

            if (renderer)
            {
                materialName = (string)stream.ReceiveNext();
            }
        }
    }
}

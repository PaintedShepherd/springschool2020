using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorEvent : MonoBehaviourPun, IPunObservable
{
    private string materialName;
    private MeshRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();

        materialName = renderer.material.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (renderer && materialName != renderer.material.name)
        {
            Material newMaterial = (Material)Resources.Load(materialName, typeof(Material));

            renderer.material = newMaterial;
        }
    }

    public void ChangeMaterial(Material material)
    {
        materialName = material.name;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(materialName);
        }
        else
        {
            materialName = (string)stream.ReceiveNext();
        }
    }
}

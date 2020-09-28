using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PictureArea : MonoBehaviour
{
     public List<Texture2D> images;
     public string tagOfImageReceiverObject = "PICTURE_RECEIVER";

     private PhotonView photonView;
     // Start is called before the first frame update
     void Start()
     {
          photonView = GetComponent<PhotonView>();

          if (images.Count <= 0 || images == null)
          {
               Destroy(this.gameObject);
          }
     }

     // Update is called once per frame
     void Update()
     {

     }

     private void OnTriggerEnter(Collider other)
     {
          if (other.gameObject.tag.Equals(tagOfImageReceiverObject))
          {
               PictureReceiver receiver = other.gameObject.GetComponent<PictureReceiver>();

               receiver.SetPictureAreaID(photonView.ViewID);
               receiver.SetImages(images);
               receiver.SetImage(0);
               receiver.image.gameObject.SetActive(true);
          }
     }

     private void OnTriggerExit(Collider other)
     {
          if (other.gameObject.tag.Equals(tagOfImageReceiverObject))
          {
               PictureReceiver receiver = other.gameObject.GetComponent<PictureReceiver>();

               receiver.SetPictureAreaID(-1);
               receiver.SetImages(null);
               receiver.image.gameObject.SetActive(false);

          }
     }
}

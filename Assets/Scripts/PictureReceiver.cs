using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PictureReceiver : MonoBehaviour, IPunObservable
{
     public Image image;

     private List<Texture2D> images;
     private float targetWidth = 0;
     private int currentIndexOfImage = 0;
     private int activePictureAreaID = 0;
     private bool isPictureAreaActive = false;

     // Start is called before the first frame update
     void Start()
     {
          targetWidth = image.rectTransform.sizeDelta.x;
     }

     // Update is called once per frame
     void LateUpdate()
     {

     }

     public void SetImages(List<Texture2D> newImages)
     {
          images = newImages;
     }

     public void SetImage(int indexOfImage)
     {
          currentIndexOfImage = indexOfImage;

          image.sprite = Sprite.Create(images[indexOfImage], new Rect(0, 0, images[indexOfImage].width, images[indexOfImage].height), new Vector2(0.5f, 0.5f));
          image.rectTransform.sizeDelta = new Vector2(targetWidth, ((float)images[indexOfImage].height / (float)images[indexOfImage].width) * targetWidth);
     }

     private void CheckForNewImages()
     {
          if (!isPictureAreaActive && activePictureAreaID > 0 && images == null)
          {

               images = GetPictureAreaByID().images;
               SetImage(0);
               image.gameObject.SetActive(true);
               isPictureAreaActive = true;
               SetImage(0);
          }
          else if (isPictureAreaActive && activePictureAreaID <= 0)
          {
               images = null;
               image.gameObject.SetActive(false);
               isPictureAreaActive = false;
          }
     }

     private PictureArea GetPictureAreaByID()
     {
          PhotonView view = PhotonNetwork.GetPhotonView(activePictureAreaID);
          return view.gameObject.GetComponent<PictureArea>();
     }

     public void SetPictureAreaID(int id)
     {
          activePictureAreaID = id;
     }

     public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
     {
          if (stream.IsWriting)
          {
               stream.SendNext(currentIndexOfImage);
               stream.SendNext(activePictureAreaID);
          }
          else
          {
               currentIndexOfImage = (int)stream.ReceiveNext();
               activePictureAreaID = (int)stream.ReceiveNext();
          }
     }
}

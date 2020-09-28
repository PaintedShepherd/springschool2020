using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSynchronizer : MonoBehaviour
{
     public Transform fromRotation;
     public bool syncX = true, syncY = true, syncZ = true;
     // Start is called before the first frame update
     void Start()
     {

     }

     // Update is called once per frame
     void Update()
     {

          this.transform.rotation = Quaternion.Euler(syncX ? fromRotation.rotation.eulerAngles.x : 0.0f,
               syncY ? fromRotation.rotation.eulerAngles.y : 0.0f,
               syncZ ? fromRotation.rotation.eulerAngles.z : 0.0f);
     }
}
